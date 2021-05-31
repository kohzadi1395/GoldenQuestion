using System;
using System.Linq;
using Application.Interfaces.General;
using Application.Interfaces.State;
using Domain.Entities;
using IoC.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class StatesController : GoldenControl
    {
        private readonly IStateService _stateService;
        private readonly IUnitOfWork _unitOfWork;

        public StatesController(IStateService stateService, IUnitOfWork unitOfWork)
        {
            _stateService = stateService;
            _unitOfWork = unitOfWork;
        }

        
        
        
        
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var state = _stateService.GetState(id);
            if (state == null)
                return NotFound("State not found");

            return Ok(state);
        }

        
        
        
        
        [HttpGet]
        public ActionResult Get()
        {
            var state = _stateService.GetAllStates();

            return Ok(state);
        }

        
        
        
        
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult Add(State state)
        {
            state.CreateUser = UserId;
            state.ModifyUser = UserId;
            if (_stateService.AddState(state) != null && _unitOfWork.Commit() > 0)
                return Ok("New State is Added");

            return Problem();
        }

        
        
        
        
        [HttpPut]
        [ServiceFilter(typeof(ValidationFilter))]
        public IActionResult Update(State state)
        {
            state.ModifyUser = UserId;
            if (_stateService.UpdateState(state) && _unitOfWork.Commit() > 0)
                return Ok("State is Update");

            return Problem();
        }

        
        
        
        
        [HttpDelete("{id}")]
        public ActionResult Remove(Guid id)
        {
            var state = new State
            {
                Id = id,
                ModifyUser = UserId
            };
            return _stateService.RemoveState(state) && _unitOfWork.Commit() > 0 ? Ok("State is Removed") : Problem();
        }
    }
}