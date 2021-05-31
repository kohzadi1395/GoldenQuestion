using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTOs;

namespace Application.Interfaces.State
{
    public interface IStateService
    {
        IEnumerable<StateDto> GetAllStates();
        Domain.Entities.State GetState(Guid id);

        Domain.Entities.State AddState(Domain.Entities.State state,
            Expression<Func<Domain.Entities.State, bool>> predicate = null);

        bool RemoveState(Expression<Func<Domain.Entities.State, bool>> predicate);
        bool RemoveState(Domain.Entities.State state);
        bool UpdateState(Domain.Entities.State state);
        IEnumerable<Domain.Entities.State> Find(Expression<Func<Domain.Entities.State, bool>> criteria);
    }
}