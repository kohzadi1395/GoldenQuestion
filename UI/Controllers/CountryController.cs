using System;
using System.Linq;
using Application.Interfaces.Country;
using Application.Interfaces.General;
using Domain.Entities;
using IoC.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class CountriesController : GoldenControl
    {
        private readonly ICountryService _countryService;
        private readonly IUnitOfWork _unitOfWork;

        public CountriesController(ICountryService countryService, IUnitOfWork unitOfWork)
        {
            _countryService = countryService;
            _unitOfWork = unitOfWork;
        }


        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var country = _countryService.GetCountry(id);
            if (country == null)
                return NotFound("Country not found");

            return Ok(country);
        }


        [HttpGet]
        public ActionResult Get()
        {
            var country = _countryService.GetAllCountries();

            return Ok(country);
        }
        


        [HttpPost]
        [ServiceFilter(typeof(ValidationFilter))]
        public ActionResult Add(Country country)
        {
            country.CreateUser = UserId;
            country.ModifyUser = UserId;
            if (_countryService.AddCountry(country) != null && _unitOfWork.Commit() > 0)
                return Ok("New Country is Added");

            return Problem();
        }


        [HttpPut]
        [ServiceFilter(typeof(ValidationFilter))]
        public IActionResult Update(Country country)
        {
            country.ModifyUser = UserId;
            if (_countryService.UpdateCountry(country) && _unitOfWork.Commit() > 0)
                return Ok("Country is Update");

            return Problem();
        }


        [HttpDelete("{id}")]
        public ActionResult Remove(Guid id)
        {
            var country = new Country
            {
                Id = id,
                ModifyUser = UserId
            };
            return _countryService.RemoveCountry(country) && _unitOfWork.Commit() > 0
                ? Ok("Country is Removed")
                : Problem();
        }
    }
}