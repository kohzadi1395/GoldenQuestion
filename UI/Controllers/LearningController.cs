using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.ReportDTO;
using Application.Interfaces.Comment;
using Application.Interfaces.General;
using Application.Interfaces.Learning;
using Application.Interfaces.LikeView;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace UI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class LearningsController : GoldenControl
    {
        private readonly ICommentService _commentService;
        private readonly IConfiguration _configuration;
        private readonly ILearningService _learningService;
        private readonly ILikeViewService _likeViewService;
        private readonly IUnitOfWork _unitOfWork;

        public LearningsController(ILearningService learningService,
            IUnitOfWork unitOfWork, ILikeViewService likeViewService, ICommentService commentService,
            IConfiguration configuration)
        {
            _learningService = learningService;
            _unitOfWork = unitOfWork;
            _likeViewService = likeViewService;
            _commentService = commentService;
            _configuration = configuration;
        }


        [HttpPost]
        //[ServiceFilter(typeof(ValidationFilter))]
        public ActionResult Add(LearningDto learning)
        {
            learning.CreateUser = UserId;
            learning.ModifyUser = UserId;
            if (_learningService.AddLearning(learning) != null && _unitOfWork.Commit() > 0)
                return Ok("New Learning is Added");

            return Problem();
        }

        [HttpPut]
        //[ServiceFilter(typeof(ValidationFilter))]
        public IActionResult Update(LearningDto learning)
        {
            learning.ModifyUser = UserId;
            if (_learningService.UpdateLearning(learning).Result && _unitOfWork.Commit() > 0)
                return Ok("Learning is Update");

            return Problem();
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(Guid id)
        {
            var learning = new Learning
            {
                Id = id,
                ModifyUser = UserId
            };
            return _learningService.RemoveLearning(learning) && _unitOfWork.Commit() > 0
                ? Ok("Learning is Removed")
                : Problem();
        }

        #region HttpGet

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var learning = _learningService.GetLearning(id);

            var likeView = new LikeView
            {
                CreateUser = UserId,
                CreateDate = DateTime.Now,
                ModifyUser = UserId,
                ModifyDate = DateTime.Now,
                Deleted = false,
                TableId = id,
                TableType = TableType.Learning,
                LikeViewType = LikeViewType.View
            };
            _likeViewService.AddLikeView(likeView);
            _unitOfWork.Commit();
            if (learning == null)
                return NotFound("Learning not found");

            return Ok(learning);
        }
        
        [HttpGet]
        public ActionResult GetMyLeaning(FilterDto filterDto, PaginationDto pagination)
        {
            filterDto.UserId = UserId;
            var dataTransferObject = new DataTransferObject<LearningDto>
            {
                FilterDto = filterDto,
                Pagination = pagination,
                Result = null,
                TotalRow = 0
            };

            var myLeaning = _learningService.GetMyLearning(dataTransferObject);
            if (myLeaning == null)
                return NotFound("learning not found");

            return Ok(myLeaning);
        }

        [HttpGet]
       [AllowAnonymous]
        public ActionResult GetMainPage(FilterDto filterDto, PaginationDto pagination)
        {
            var dataTransferObject = new DataTransferObject<LearningDto>
            {
                FilterDto = filterDto,
                Pagination = pagination,
                Result = null,
                TotalRow = 0
            };
            var learningDtos = _learningService.GetMainPageLearning(dataTransferObject);
            return Ok(learningDtos);
        }

        [HttpGet]
         [AllowAnonymous]
        public ActionResult GetSearch(FilterDto filterDto, PaginationDto pagination)
        {
            var dataTransferObject = new DataTransferObject<LearningDto>
            {
                FilterDto = filterDto,
                Pagination = pagination,
                Result = null,
                TotalRow = 0
            };
            var learns = _learningService.GetSearch(dataTransferObject);
            return Ok(learns);
        }

        #endregion
    }
}