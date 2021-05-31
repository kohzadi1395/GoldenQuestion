using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.ReportDTO;
using Application.Interfaces.Comment;
using Application.Interfaces.Exam;
using Application.Interfaces.ExmDto;
using Application.Interfaces.General;
using Application.Interfaces.LikeView;
using Application.QTO;
using Domain.Entities;
using IoC.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Security.Application;

namespace UI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ExamsController :  GoldenControl
    {
        private readonly ICommentService _commentService;
        private readonly IConfiguration _configuration;
        private readonly IExamMongoRepository _examMongoRepository;
        private readonly IExamService _examService;
        private readonly ILikeViewService _likeViewService;
        private readonly IUnitOfWork _unitOfWork;

        public ExamsController(IExamService examService,
            IUnitOfWork unitOfWork,
            ILikeViewService likeViewService,
            ICommentService commentService,
            IConfiguration configuration,
            IExamMongoRepository examMongoRepository)
        {
            _examService = examService;
            _unitOfWork = unitOfWork;
            _likeViewService = likeViewService;
            _commentService = commentService;
            _configuration = configuration;
            _examMongoRepository = examMongoRepository;
        }

        [HttpGet]
        public ActionResult GetMyDraft(PaginationDto pagination)
        {
            var dataTransferObject = new DataTransferObject<ExamDto>
            {
                FilterDto = new FilterDto { UserId = UserId},
                Pagination = pagination,
                Result = null,
                TotalRow = 0
            };
            var examDto = _examService.GetDraftExams(dataTransferObject);
            return Ok(examDto);
            

           
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetMyExam(FilterDto filterDto, PaginationDto pagination)
        {
            filterDto.UserId = UserId;
            var dataTransferObject = new DataTransferObject<ExamDto>
            {
                FilterDto = filterDto,
                Pagination = pagination,
                Result = null,
                TotalRow = 0
            };
            var exam = _examService.GetMyExam(dataTransferObject);
            if (exam == null)
                return NotFound("Exam not found");

            return Ok(exam);
        }

        [HttpGet]
        public ActionResult TakeExam(Guid examId)
        {
            var exam = _examService.TakeExam(examId);

            if (exam == null)
                return NotFound("Exam not found");

            exam.StudentId = UserId;
            return Ok(exam);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public ActionResult GetMainPage(FilterDto filterDto, PaginationDto pagination)
        {
            var dataTransferObject = new DataTransferObject<ExamDto>
            {
                FilterDto = filterDto,
                Pagination = pagination,
                Result = null,
                TotalRow = 0
            };
            var examDto = _examService.GetMainPageExam(dataTransferObject);
            return Ok(examDto);
        }

        [HttpGet]
        public ActionResult GetGivenExam()
        {
            var examMongos = _examMongoRepository.Find(x => x.Exam.CreateUser == UserId);

            if (examMongos == null)
                return NotFound("Exames not found");

            return Ok(examMongos);
        }

        [HttpGet]
        public ActionResult GetTakenExam()
        {
            var studentId = UserId;
            var examMongos = _examMongoRepository.Find(x => x.StudentId== studentId);

            if (examMongos == null)
                return NotFound("Exam not found");

            return Ok(examMongos);
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var exam = _examService.GetExam(id);
            var likeView = new LikeView
            {
                CreateUser = UserId,
                CreateDate = DateTime.Now,
                ModifyUser = UserId,
                ModifyDate = DateTime.Now,
                Deleted = false,
                TableId = id,
                TableType = TableType.Exam,
                LikeViewType = LikeViewType.View
            };
            _likeViewService.AddLikeView(likeView);
            _unitOfWork.Commit();
            if (exam == null)
                return NotFound("Exam not found");

            return Ok(exam);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public ActionResult GetSearch(FilterDto filterDto, PaginationDto pagination)
        {
            var dataTransferObject = new DataTransferObject<ExamDto>
            {
                FilterDto = filterDto,
                Pagination = pagination,
                Result = null,
                TotalRow = 0
            };
            var learns = _examService.GetSearch(dataTransferObject);
            return Ok(learns);
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetUserComment(Guid tableId)
        {
            var users = await _commentService.GetComments(tableId, _configuration);
            return Ok(users);
        }

        [HttpGet]
        public ActionResult GetExamQuestionOption(Guid examId)
        {
            var question = _examService.GetExamQuestionOption(examId).Questions.OrderBy(x=>x.CreateDate);
            return Ok(question);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult Add(ExamDto exam)
        {
            exam.CreateUser = UserId;
            exam.ModifyUser = UserId;

            if (_examService.AddExam(exam) != null && _unitOfWork.Commit() > 0)
                return Ok("New Exam is Added");

            return Problem();
        }

        [HttpPost]
        public ActionResult SubmitExam([FromBody] ExamMongo exm)
        {
            if (exm == null)
                return Problem();
            exm.FinishDate = DateTime.Now;
            _examMongoRepository.Add(exm);
            var shipWrecks = _examMongoRepository.First(x => x.Id == exm.Id);
            return Ok(shipWrecks);
        }

        [HttpPut]
        [ServiceFilter(typeof(ValidationFilter))]
        public IActionResult Update(ExamDto exam)
        {
            
            exam.ModifyUser = UserId;
            if (_examService.UpdateExam(exam).Result && _unitOfWork.Commit() > 0)
                return Ok("Exam is Update");

            return Problem();
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(Guid id)
        {
            var exam = new Exam
            {
                Id = id,
                ModifyUser = UserId
            };
            return _examService.RemoveExam(exam) && _unitOfWork.Commit() > 0 ? Ok("Exam is Removed") : Problem();
        }
    }
}