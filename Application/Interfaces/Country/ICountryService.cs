using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTOs;

namespace Application.Interfaces.Country
{
    public partial interface ICountryService
    {
        IEnumerable<CountryDto> GetAllCountries();
        Domain.Entities.Country GetCountry(Guid id);

        Domain.Entities.Country AddCountry(Domain.Entities.Country country,
            Expression<Func<Domain.Entities.Country, bool>> predicate = null);

        bool RemoveCountry(Expression<Func<Domain.Entities.Country, bool>> predicate);
        bool RemoveCountry(Domain.Entities.Country country);
        bool UpdateCountry(Domain.Entities.Country country);
        IEnumerable<Domain.Entities.Country> Find(Expression<Func<Domain.Entities.Country, bool>> criteria);
    }
}