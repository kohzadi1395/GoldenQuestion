using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.Interfaces.General;

namespace Application.Interfaces.Option
{
    public interface IOptionRepository : IRepository<Domain.Entities.Option>
    {
        IEnumerable<Domain.Entities.Option> GetAllOptions();
        Domain.Entities.Option GetOption(Guid id);

        Domain.Entities.Option AddOption(Domain.Entities.Option option,
            Expression<Func<Domain.Entities.Option, bool>> predicate = null);

        bool RemoveOption(Expression<Func<Domain.Entities.Option, bool>> criteria);
        bool RemoveOption(Domain.Entities.Option option);
        bool UpdateOption(Domain.Entities.Option option);
    }
}