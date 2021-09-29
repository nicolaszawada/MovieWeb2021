using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieWeb.Database;
using MovieWeb.Domain;
using MovieWeb.Dto.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWeb.Services.Impl
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public MovieService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<GetMovieDetailDto> CreateAsync(CreateMovieDto movie)
        {
            var entity = _mapper.Map<Movie>(movie);

            _context.Movies.Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetMovieDetailDto>(entity);
        }

        public async Task<IEnumerable<GetMovieListDto>> GetAsync(string filter = null)
        {
            IQueryable<Movie> movieQuery = _context.Movies;

            if (!string.IsNullOrWhiteSpace(filter))
            {
                movieQuery = movieQuery.Where(x => x.Title.Contains(filter) || x.Genre.Contains(filter) || x.Tags.Any(x=> x.Name.Contains(filter)));
            }

            var movies = await movieQuery.ToListAsync();

            return _mapper.Map<IEnumerable<GetMovieListDto>>(movies);
        }

        public async Task<GetMovieDetailDto> GetAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            return _mapper.Map<GetMovieDetailDto>(movie);
        }

        public async Task<bool> AddActorAsync(int id, int actorId)
        {
            var movie = await _context.Movies.Include(x => x.Actors).SingleOrDefaultAsync(x => x.Id == id);
            if (movie == null || movie.Actors.Any(x => x.Id == actorId))
            {
                return false;
            }

            var actor = await _context.Actors.FindAsync(actorId);
            if (actor == null)
            {
                return false;
            }

            movie.Actors.Add(actor);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<GetMovieDetailWithActorsDto> GetWithActorsAsync(int id)
        {
            var movie = await _context.Movies.Include(x => x.Actors).Include(x => x.Tags).FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<GetMovieDetailWithActorsDto>(movie);
        }

        public async Task<bool> RemoveActorAsync(int id, int actorId)
        {
            var movie = await _context.Movies.Include(x => x.Actors).SingleOrDefaultAsync(x => x.Id == id);
            if (movie == null || !movie.Actors.Any(x => x.Id == actorId))
            {
                return false;
            }

            var actor = await _context.Actors.FindAsync(actorId);
            if (actor == null)
            {
                return false;
            }

            movie.Actors.Remove(actor);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task DeleteAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AddTagAsync(int id, string tag)
        {
            var movie = await _context.Movies.Include(x => x.Tags).FirstOrDefaultAsync(x => x.Id == id);
            if (movie.Tags.Any(x => x.Name.Equals(tag, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            movie.Tags.Add(new Tag() { Name = tag });

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task DeleteTagAsync(int id, int tagId)
        {
            var movie = await _context.Movies.Include(x => x.Tags).FirstOrDefaultAsync(x => x.Id == id);
            var tag = await _context.Tags.FindAsync(tagId);

            movie.Tags.Remove(tag);

            await _context.SaveChangesAsync();
        }
    }
}
