using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.Interfaces.General;

namespace Application.Interfaces.Country
{
    public interface ICountryRepository : IRepository<Domain.Entities.Country>
    {
        IEnumerable<Domain.Entities.Country> GetAllCountries();
        Domain.Entities.Country GetCountry(Guid id);

        Domain.Entities.Country AddCountry(Domain.Entities.Country country,
            Expression<Func<Domain.Entities.Country, bool>> predicate = null);

        bool RemoveCountry(Expression<Func<Domain.Entities.Country, bool>> criteria);
        bool RemoveCountry(Domain.Entities.Country country);
        bool UpdateCountry(Domain.Entities.Country country);
    }
}