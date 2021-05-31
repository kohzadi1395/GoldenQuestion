using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.Interfaces.State;
using Domain.Entities;
using Persistence.Core;

namespace Persistence.Repositories
{
    public class StateRepository : Repository<State>, IStateRepository
    {
        private readonly ApiContext _context;

        public StateRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<State> GetAllStates()
        {
            return GetAll();
        }

        public State GetState(Guid id)
        {
            return GetById(id);
        }

        public State AddState(State state, Expression<Func<State, bool>> predicate = null)
        {
            Add(state, predicate);
            return state;
        }

        public bool RemoveState(State state)
        {
            try
            {
                Remove(state);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RemoveState(Expression<Func<State, bool>> criteria)
        {
            try
            {
                Remove(criteria);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateState(State state)
        {
            try
            {
                Update(state);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}