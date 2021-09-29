using MovieWeb.Dto.Actors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieWeb.Services
{
    public interface IActorService
    {
        Task<IEnumerable<GetActorListDto>> GetAsync();
        Task<GetActorDetailDto> GetAsync(int id);
        Task<GetActorDetailDto> CreateAsync(CreateActorDto actor);
        Task<GetActorDetailDto> UpdateAsync(int id, UpdateActorDto actor);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<GetActorListDto>> GetActorsFromMovie(int? movieId);
    }
}
