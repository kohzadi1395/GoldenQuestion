using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTOs;

namespace Application.Interfaces.Option
{
    public partial interface IOptionService
    {
        IEnumerable<OptionDto> GetAllOptions();
        Domain.Entities.Option GetOption(Guid id);

        Domain.Entities.Option AddOption(Domain.Entities.Option option,
            Expression<Func<Domain.Entities.Option, bool>> predicate = null);

        bool RemoveOption(Expression<Func<Domain.Entities.Option, bool>> predicate);
        bool RemoveOption(Domain.Entities.Option option);
        bool UpdateOption(Domain.Entities.Option option);
        IEnumerable<Domain.Entities.Option> Find(Expression<Func<Domain.Entities.Option, bool>> criteria);
    }
}