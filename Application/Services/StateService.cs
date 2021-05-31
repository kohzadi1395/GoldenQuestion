using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTOs;
using Application.Interfaces.State;
using Domain.Entities;

namespace Application.Services
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public IEnumerable<StateDto> GetAllStates()
        {
            var states = _stateRepository.GetAll().Select(x => new StateDto
            {
                Name = x.Name,
                CountryId = x.CountryId,
                Country = x.Country,
                Questions = x.Questions,
                Learnings = x.Learnings,
                Id = x.Id,
                CreateUser = x.CreateUser,
                CreateDate = x.CreateDate,
                ModifyUser = x.ModifyUser,
                ModifyDate = x.ModifyDate,
                Deleted = x.Deleted,
                RowVersion = x.RowVersion
            });
            return states;
        }

        public State GetState(Guid id)
        {
            return _stateRepository.GetById(id);
        }

        public State AddState(State state, Expression<Func<State, bool>> predicate = null)
        {
            return _stateRepository.AddState(state, predicate);
        }

        public bool RemoveState(State state)
        {
            return _stateRepository.RemoveState(state);
        }

        public bool RemoveState(Expression<Func<State, bool>> predicate)
        {
            return _stateRepository.RemoveState(predicate);
        }

        public bool UpdateState(State state)
        {
            return _stateRepository.UpdateState(state);
        }

        public IEnumerable<State> Find(Expression<Func<State, bool>> criteria)
        {
            return _stateRepository.Find(criteria);
        }
    }
}