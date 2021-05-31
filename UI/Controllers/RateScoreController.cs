
using System;
using System.Linq;
using Application.Interfaces.RateScore;
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
    public partial class RateScoresController : GoldenControl
    {
        private readonly IRateScoreService _rateScoreService;
        private readonly IUnitOfWork _unitOfWork;

        public RateScoresController(IRateScoreService rateScoreService, IUnitOfWork unitOfWork)
        {
            _rateScoreService = rateScoreService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var rateScore = _rateScoreService.GetRateScore(id);
            if (rateScore == null)
                return NotFound("RateScore not found");

            return Ok(rateScore);
        }

        [HttpGet]
        public ActionResult Get()
        {
            var rateScore = _rateScoreService.GetAllRateScores();
            return Ok(rateScore);
        }
        
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult Add(RateScore rateScore)
        {
            rateScore.CreateUser = UserId;
            rateScore.ModifyUser = UserId;
            if (_rateScoreService.AddRateScore(rateScore) != null && _unitOfWork.Commit() > 0)
                return Ok("New RateScore is Added");

            return Problem();
        }

        [HttpPut]
        [ServiceFilter(typeof(ValidationFilter))]
        public IActionResult Update(RateScore rateScore)
        {
            rateScore.ModifyUser = UserId;
            if (_rateScoreService.UpdateRateScore(rateScore) && _unitOfWork.Commit() > 0)
                return Ok("RateScore is Update");

            return Problem();

        }
    }
}