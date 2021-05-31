using System;
using System.Linq;
using Application.Interfaces.General;
using Application.Interfaces.QuestionType;
using Domain.Entities;
using IoC.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class QuestionTypesController : GoldenControl
    {
        private readonly IQuestionTypeService _questionTypeService;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionTypesController(IQuestionTypeService questionTypeService, IUnitOfWork unitOfWork)
        {
            _questionTypeService = questionTypeService;
            _unitOfWork = unitOfWork;
        }

        
        
        
        
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var questionType = _questionTypeService.GetQuestionType(id);
            if (questionType == null)
                return NotFound("QuestionType not found");

            return Ok(questionType);
        }

        
        
        
        
        [HttpGet]
        public ActionResult Get()
        {
            var questionType = _questionTypeService.GetAllQuestionTypes();

            return Ok(questionType);
        }

        
        
        
        
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult Add(QuestionType questionType)
        {
            questionType.CreateUser = UserId;
            questionType.ModifyUser = UserId;
            if (_questionTypeService.AddQuestionType(questionType) != null && _unitOfWork.Commit() > 0)
                return Ok("New QuestionType is Added");

            return Problem();
        }

        
        
        
        
        [HttpPut]
        [ServiceFilter(typeof(ValidationFilter))]
        public IActionResult Update(QuestionType questionType)
        {
            questionType.ModifyUser = UserId;
            if (_questionTypeService.UpdateQuestionType(questionType) && _unitOfWork.Commit() > 0)
                return Ok("QuestionType is Update");

            return Problem();
        }

        
        
        
        
        [HttpDelete("{id}")]
        public ActionResult Remove(Guid id)
        {
            var questionType = new QuestionType
            {
                Id = id,
                ModifyUser = UserId
            };
            return _questionTypeService.RemoveQuestionType(questionType) && _unitOfWork.Commit() > 0
                ? Ok("QuestionType is Removed")
                : Problem();
        }
    }
}