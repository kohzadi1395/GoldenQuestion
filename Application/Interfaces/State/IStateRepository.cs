using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.Interfaces.General;

namespace Application.Interfaces.State
{
    public interface IStateRepository : IRepository<Domain.Entities.State>
    {
        IEnumerable<Domain.Entities.State> GetAllStates();
        Domain.Entities.State GetState(Guid id);

        Domain.Entities.State AddState(Domain.Entities.State state,
            Expression<Func<Domain.Entities.State, bool>> predicate = null);

        bool RemoveState(Expression<Func<Domain.Entities.State, bool>> criteria);
        bool RemoveState(Domain.Entities.State state);
        bool UpdateState(Domain.Entities.State state);
    }
}