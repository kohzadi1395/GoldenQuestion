using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTOs;
using Application.Interfaces.Country;
using Application.Interfaces.General;
using Domain.Entities;

namespace Application.Services
{
    public partial class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository, IUtilities utilities)
        {
            _countryRepository = countryRepository;
            _utilities = utilities;
        }

        public IEnumerable<CountryDto> GetAllCountries()
        {
            var countries = _countryRepository.GetAll().Select(x => new CountryDto
            {
                Name = x.Name,
                flag = x.flag,
                States = x.States,
                Id = x.Id,
                CreateUser = x.CreateUser,
                CreateDate = x.CreateDate,
                ModifyUser = x.ModifyUser,
                ModifyDate = x.ModifyDate,
                Deleted = x.Deleted,
                RowVersion = x.RowVersion
            });
            return countries;
        }

        public Country GetCountry(Guid id)
        {
            return _countryRepository.GetById(id);
        }

        public Country AddCountry(Country country, Expression<Func<Country, bool>> predicate = null)
        {
            return _countryRepository.AddCountry(country, predicate);
        }

        public bool RemoveCountry(Country country)
        {
            return _countryRepository.RemoveCountry(country);
        }

        public bool RemoveCountry(Expression<Func<Country, bool>> predicate)
        {
            return _countryRepository.RemoveCountry(predicate);
        }

        public bool UpdateCountry(Country country)
        {
            return _countryRepository.UpdateCountry(country);
        }

        public IEnumerable<Country> Find(Expression<Func<Country, bool>> criteria)
        {
            return _countryRepository.Find(criteria);
        }
    }
}