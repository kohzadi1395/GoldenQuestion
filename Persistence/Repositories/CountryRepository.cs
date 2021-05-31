using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.Interfaces.Country;
using Domain.Entities;
using Persistence.Core;

namespace Persistence.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private readonly ApiContext _context;

        public CountryRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return GetAll();
        }

        public Country GetCountry(Guid id)
        {
            return GetById(id);
        }

        public Country AddCountry(Country country, Expression<Func<Country, bool>> predicate = null)
        {
            Add(country, predicate);
            return country;
        }

        public bool RemoveCountry(Country country)
        {
            try
            {
                Remove(country);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RemoveCountry(Expression<Func<Country, bool>> criteria)
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

        public bool UpdateCountry(Country country)
        {
            try
            {
                Update(country);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}