using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Interfaces.Option
{
    public partial interface IOptionService
    {
        Task<Domain.Entities.Option> AddOption(OptionDto optionDto);
        Task<bool> UpdateOption(OptionDto optionDto);
    }
}