using System;
using System.Linq;
using Application.Interfaces.General;
using Application.Interfaces.Option;
using Domain.Entities;
using IoC.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class OptionsController : GoldenControl
    {
        private readonly IOptionService _optionService;
        private readonly IUnitOfWork _unitOfWork;

        public OptionsController(IOptionService optionService, IUnitOfWork unitOfWork)
        {
            _optionService = optionService;
            _unitOfWork = unitOfWork;
        }

        
        
        
        
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var option = _optionService.GetOption(id);
            if (option == null)
                return NotFound("Option not found");

            return Ok(option);
        }

        
        
        
        
        [HttpGet]
        public ActionResult Get()
        {
            var option = _optionService.GetAllOptions();

            return Ok(option);
        }

        
        
        
        
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult Add(Option option)
        {
            option.CreateUser = UserId;
            option.ModifyUser = UserId;
            if (_optionService.AddOption(option) != null && _unitOfWork.Commit() > 0)
                return Ok("New Option is Added");

            return Problem();
        }

        
        
        
        
        [HttpPut]
        [ServiceFilter(typeof(ValidationFilter))]
        public IActionResult Update(Option option)
        {
            option.ModifyUser = UserId;
            if (_optionService.UpdateOption(option) && _unitOfWork.Commit() > 0)
                return Ok("Option is Update");

            return Problem();
        }

        
        
        
        
        [HttpDelete("{id}")]
        public ActionResult Remove(Guid id)
        {
            var option = new Option
            {
                Id = id,
                ModifyUser = UserId
            };
            return _optionService.RemoveOption(option) && _unitOfWork.Commit() > 0
                ? Ok("Option is Removed")
                : Problem();
        }
    }
}