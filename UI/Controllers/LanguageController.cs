using System;
using System.Linq;
using Application.Interfaces.General;
using Application.Interfaces.Language;
using Domain.Entities;
using IoC.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class LanguagesController : GoldenControl
    {
        private readonly ILanguageService _languageService;
        private readonly IUnitOfWork _unitOfWork;

        public LanguagesController(ILanguageService languageService, IUnitOfWork unitOfWork)
        {
            _languageService = languageService;
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var language = _languageService.GetLanguage(id);
            if (language == null)
                return NotFound("Language not found");

            return Ok(language);
        }
        
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Get()
        {
            var language = _languageService.GetAllLanguages();

            return Ok(language);
        }
        
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult Add(Language language)
        {
            language.CreateUser = UserId;
            language.ModifyUser = UserId;
            if (_languageService.AddLanguage(language) != null && _unitOfWork.Commit() > 0)
                return Ok("New Language is Added");

            return Problem();
        }
        
        [HttpPut]
        [ServiceFilter(typeof(ValidationFilter))]
        public IActionResult Update(Language language)
        {
            language.ModifyUser = UserId;
            if (_languageService.UpdateLanguage(language) && _unitOfWork.Commit() > 0)
                return Ok("Language is Update");

            return Problem();
        }
        
        [HttpDelete("{id}")]
        public ActionResult Remove(Guid id)
        {
            var language = new Language
            {
                Id = id,
                ModifyUser = UserId
            };
            return _languageService.RemoveLanguage(language) && _unitOfWork.Commit() > 0
                ? Ok("Language is Removed")
                : Problem();
        }
    }
}