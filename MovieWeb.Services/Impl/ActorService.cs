using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieWeb.Database;
using MovieWeb.Domain;
using MovieWeb.Dto.Actors;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWeb.Services.Impl
{
    public class ActorService : IActorService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public ActorService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetActorDetailDto> CreateAsync(CreateActorDto actorDto)
        {
            var actor = _mapper.Map<Actor>(actorDto);

            _context.Actors.Add(actor);

            await _context.SaveChangesAsync();

            return _mapper.Map<GetActorDetailDto>(actor);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var actor = await _context.Actors.FindAsync(id);

            if (actor == null)
            {
                return false;
            }

            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<GetActorListDto>> GetActorsFromMovie(int? movieId)
        {
            var actors = await _context.Actors.Include(x => x.Movies).Where(x => x.Movies.Any(x => x.Id == movieId)).ToListAsync();
            return _mapper.Map<IEnumerable<GetActorListDto>>(actors);
        }

        public async Task<IEnumerable<GetActorListDto>> GetAsync()
        {
            var actors = await _context.Actors.ToListAsync();

            return _mapper.Map<IEnumerable<GetActorListDto>>(actors);
        }

        public async Task<GetActorDetailDto> GetAsync(int id)
        {
            var actor = await _context.Actors.FindAsync(id);

            if (actor == null)
            {
                return null;
            }

            return _mapper.Map<GetActorDetailDto>(actor);
        }

        public async Task<GetActorDetailDto> UpdateAsync(int id, UpdateActorDto actorDto)
        {
            var actor = await _context.Actors.FindAsync(id);

            _mapper.Map(actorDto, actor);

            _context.Actors.Update(actor);

            await _context.SaveChangesAsync();

            return _mapper.Map<GetActorDetailDto>(actor);
        }
    }
}
