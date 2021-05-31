using System;
using System.Linq;
using Application.Interfaces.General;
using Application.Interfaces.Tag;
using Domain.Entities;
using IoC.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class TagsController : GoldenControl
    {
        private readonly ITagService _tagService;
        private readonly IUnitOfWork _unitOfWork;

        public TagsController(ITagService tagService, IUnitOfWork unitOfWork)
        {
            _tagService = tagService;
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var tag = _tagService.GetTag(id);
            if (tag == null)
                return NotFound("Tag not found");

            return Ok(tag);
        }
        
        [HttpGet]
        public ActionResult Get()
        {
            var tag = _tagService.GetAllTags();

            return Ok(tag);
        }
        
        
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult Add(Tag tag)
        {
            tag.CreateUser = UserId;
            tag.ModifyUser = UserId;
            if (_tagService.AddTag(tag) != null && _unitOfWork.Commit() > 0)
                return Ok("New Tag is Added");

            return Problem();
        }

        
        
        
        
        [HttpPut]
        [ServiceFilter(typeof(ValidationFilter))]
        public IActionResult Update(Tag tag)
        {
            tag.ModifyUser = UserId;
            if (_tagService.UpdateTag(tag) && _unitOfWork.Commit() > 0)
                return Ok("Tag is Update");

            return Problem();
        }

        
        
        
        
        [HttpDelete("{id}")]
        public ActionResult Remove(Guid id)
        {
            var tag = new Tag
            {
                Id = id,
                ModifyUser = UserId
            };
            return _tagService.RemoveTag(tag) && _unitOfWork.Commit() > 0 ? Ok("Tag is Removed") : Problem();
        }
    }
}