using System;
using System.Linq;
using Application.DTOs;
using Application.Interfaces.ExamQuestion;
using Application.Interfaces.General;
using Application.Interfaces.Question;
using Domain.Entities;
using IoC.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class QuestionsController : GoldenControl
    {
        private readonly IExamQuestionService _examQuestionService;
        private readonly IQuestionService _questionService;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionsController(IQuestionService questionService, IUnitOfWork unitOfWork,
            IExamQuestionService examQuestionService)
        {
            _questionService = questionService;
            _unitOfWork = unitOfWork;
            _examQuestionService = examQuestionService;
        }

        #region HttpPut

        [HttpPut]
        [ServiceFilter(typeof(ValidationFilter))]
        public IActionResult Update(Question question)
        {
            question.ModifyUser = UserId;
            if (_questionService.UpdateQuestion(question) && _unitOfWork.Commit() > 0)
                return Ok("Question is Update");

            return Problem();
        }

        #endregion

        #region HttpGet

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var question = _questionService.GetQuestion(id);
            if (question == null)
                return NotFound("Question not found");

            return Ok(question);
        }

        [HttpGet]
        public ActionResult Get()
        {
            var question = _questionService.GetQuestions();
            return Ok(question);
        }

        [HttpGet]
        public ActionResult GetQuestions(Guid examId)
        {
            var question = _examQuestionService.GetQuestions(examId);
            return Ok(question);
        }

        [HttpGet]
        public ActionResult GetPublicQuestions(string keyword)
        {
            var question = _questionService.GetQuestions(x =>
                (x.IsPublic || x.CreateUser == UserId) &&
                (string.IsNullOrEmpty(keyword) || x.Tags.Contains(keyword)));
            return Ok(question);
        }

        #endregion

        #region HttpPost

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult Add([FromBody] Question question)
        {
            question.CreateUser = UserId;
            question.ModifyUser = UserId;
            if (_questionService.AddQuestion(question) != null && _unitOfWork.Commit() > 0)
                return Ok("New Question is Added");

            return Problem();
        }

        [HttpPost]
        public ActionResult AddExamQuestions([FromBody] ExamQuestionsDto examQuestionsDto)
        {
            if (examQuestionsDto?.Exam == null || examQuestionsDto.Questions == null)
                return Problem("data is null");

            examQuestionsDto.Exam.CreateUser = UserId;
            examQuestionsDto.Exam.NumberOfQuestion = examQuestionsDto.Questions.Count;
            foreach (var question in examQuestionsDto.Questions)
            {
                question.CreateUser = UserId;
                question.ModifyUser = UserId;
                foreach (var option in question.Options)
                {
                    option.CreateUser = UserId;
                    option.ModifyUser = UserId;
                }
            }

            if (_questionService.AddExamQuestions(examQuestionsDto.Questions, examQuestionsDto.Exam).Result &&
                _unitOfWork.Commit() > 0)
                return Ok("New Questions and Exam are Added");

            return Problem();
        }

        [HttpPost]
        public IActionResult AddExamQuestion(ExamQuestionSimpleDto examQuestionSimple)
        {
            var examQuestion = new ExamQuestion
            {
                ModifyUser = UserId,
                ExamId = examQuestionSimple.ExamId,
                QuestionId = examQuestionSimple.QuestionId,
                Question = examQuestionSimple.Question,
                CreateUser = UserId
            };
            _examQuestionService.AddExamQuestion(examQuestion);
            return _unitOfWork.Commit() > 0 ? Ok("Question is Update") : Problem();
        }

        //# todo

        [HttpPost]
        public ActionResult UpdateExamQuestions([FromBody] ExamQuestionsDto examQuestionsDto)
        {
            if (examQuestionsDto?.Exam == null || examQuestionsDto.Questions == null)
                return Problem("data is null");

            examQuestionsDto.Exam.CreateUser = UserId;
            examQuestionsDto.Exam.NumberOfQuestion = examQuestionsDto.Questions.Count;

            if (_questionService.AddExamQuestions(examQuestionsDto.Questions, examQuestionsDto.Exam).Result &&
                _unitOfWork.Commit() > 0)
                return Ok("New Questions and Exam are Added");

            return Problem();
        }

        #endregion

        #region HttpDelete

        [HttpDelete]
        public IActionResult RemoveExamQuestion(ExamQuestionSimpleDto examQuestionSimpleDto)
        {
            var examQuestion = new ExamQuestion
            {
                ModifyUser = UserId,
                ExamId = examQuestionSimpleDto.ExamId,
                QuestionId = examQuestionSimpleDto.QuestionId
            };

            if (_examQuestionService.RemoveExamQuestion(examQuestion))
                return Ok("Question is deleted from exam");

            return Problem();
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(Guid id)
        {
            var question = new Question
            {
                Id = id,
                ModifyUser = UserId
            };
            return _questionService.RemoveQuestion(question) && _unitOfWork.Commit() > 0
                ? Ok("Question is Removed")
                : Problem();
        }

        #endregion
    }
}