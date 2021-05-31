using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces.General;
using Domain.Entities;

namespace Application.Services
{
    public partial class OptionService
    {
        private readonly IUtilities _utilities;

        public async Task<Option> AddOption(OptionDto optionDto)
        {
            var option = optionDto.Mapper();
            var savedFile = await _utilities.GetImage(optionDto.Id.ToString(), optionDto.OptionImage);
            return _optionRepository.AddOption(option);
        }

        public async Task<bool> UpdateOption(OptionDto optionDto)
        {
            var option = optionDto.Mapper();
            var savedFile = await _utilities.GetImage(optionDto.Id.ToString(), optionDto.OptionImage);
            return _optionRepository.UpdateOption(option);
        }
    }
}