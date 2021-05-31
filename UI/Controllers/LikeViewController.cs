 using System;
using System.Linq;
 using Application.DTOs.ReportDTO;
 using Application.Interfaces.LikeView;
using Application.Interfaces.General;
using Domain.Entities;
using IoC.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class LikeViewsController : GoldenControl
    {
        private readonly ILikeViewService _likeViewService;
        private readonly IUnitOfWork _unitOfWork;

        public LikeViewsController(ILikeViewService likeViewService, IUnitOfWork unitOfWork)
        {
            _likeViewService = likeViewService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var likeView = _likeViewService.GetLikeView(id);
            if (likeView == null)
                return NotFound("LikeView not found");

            return Ok(likeView);
        }

        [HttpGet]
        public ActionResult GetLikeViewUser(LikeViewUser likeViewUser)
        {
            var loginUser = UserId;
            var likeView = _likeViewService.GetLikeViewUser(likeViewUser, loginUser);

            return Ok(likeView);
        }

        [HttpGet]
        public ActionResult Get()
        {
            var likeView = _likeViewService.GetAllLikeViews();

            return Ok(likeView);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult Add(LikeView likeView)
        {
            likeView.CreateUser = UserId;
            likeView.ModifyUser = UserId;
            if (_likeViewService.AddLikeView(likeView) != null && _unitOfWork.Commit() > 0)
                return Ok("New LikeView is Added");

            return Problem();
        }

        [HttpPut]
        [ServiceFilter(typeof(ValidationFilter))]
        public IActionResult Update(LikeView likeView)
        {
            likeView.ModifyUser = UserId;
            if (_likeViewService.UpdateLikeView(likeView) && _unitOfWork.Commit() > 0)
                return Ok("LikeView is Update");

            return Problem();
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(Guid id)
        {
            var likeView = new LikeView
            {
                Id = id,
                ModifyUser = UserId
            };
            return _likeViewService.RemoveLikeView(likeView) && _unitOfWork.Commit() > 0
                ? Ok("LikeView is Removed")
                : Problem();
        }
        [HttpDelete]
        public ActionResult RemoveLikeViewUser(LikeViewUser likeViewUser)
        {
            var logingUser = UserId;
            return _likeViewService.RemoveLikeViewUser(likeViewUser, logingUser)
                ? Ok("LikeView is Removed")
                : Problem();
        }
        
    }

}