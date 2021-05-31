using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces.General;
using Domain.Entities;

namespace Application.Services
{
    public partial class CountryService
    {
        private readonly IUtilities _utilities;

        public async Task<bool> AddCountry(CountryDto countryDto, Expression<Func<Country, bool>> predicate = null)
        {
            try
            {
                var country = countryDto.Mapper();
                var savedFile = await _utilities.GetImage(countryDto.Id.ToString(), countryDto.Flag);
                country.flag = savedFile.File;
                _countryRepository.Add(country);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}