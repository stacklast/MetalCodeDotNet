using Backend.DTOs;

namespace Backend.Services
{
    public interface ICommonService<TDto, TInsertDto, TUpdateDto>
    {
        Task<IEnumerable<TDto>> Get();
        Task<TDto> GetById(int id);
        Task<TDto> Add(TInsertDto beerInsertDto);
        Task<TDto> Update(int id, TUpdateDto beerUpdateDto);
        Task<TDto> Delete(int id);
    }
}
