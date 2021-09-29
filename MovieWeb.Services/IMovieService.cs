using MovieWeb.Dto.Movies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieWeb.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<GetMovieListDto>> GetAsync(string filter = null);
        Task<GetMovieDetailDto> GetAsync(int id);
        Task<GetMovieDetailDto> CreateAsync(CreateMovieDto movie);
        Task<bool> AddActorAsync(int id, int actorId);
        Task<bool> RemoveActorAsync(int id, int actorId);
        Task<GetMovieDetailWithActorsDto> GetWithActorsAsync(int id);
        Task DeleteAsync(int id);
        Task<bool> AddTagAsync(int id, string tag);
        Task DeleteTagAsync(int id, int tagId);
    }
}
