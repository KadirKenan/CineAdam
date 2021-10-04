using DataAccess.Context;
using DataAccess.Entity;
using Service.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly MovieContext movieContext;
        BaseEntity entity;
        public GenreRepository(MovieContext _movieContext)
        {
            movieContext = _movieContext;
        }
        
        public bool Any(Expression<Func<Genre, bool>> exp)
        {
            return movieContext.Genres.Any(exp);
        }

        public string DeleteGenre(int genreId)
        {
            try
            {
                movieContext.Genres.Remove(Find(genreId));
                movieContext.SaveChanges();
                return "Tür silindi!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public Genre Find(int genreId)
        {
            return movieContext.Genres.Find(genreId);
        }

        public List<Genre> GetGenres()
        {
            return movieContext.Genres.ToList();
        }

        public string PostGenre(Genre genre)
        {
            try
            {
                genre.IsActive = true;
                movieContext.Genres.Add(genre);
                movieContext.SaveChanges();
                return "Tür eklendi!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string UpdateGenre(Genre genre)
        {
            try
            {
                Genre updated = Find(genre.Id);
                movieContext.Entry(updated).CurrentValues.SetValues(genre);
                if (genre.IsActive)
                {
                    movieContext.Entry(updated).Entity.IsActive = true;
                }
                else
                {
                    movieContext.Entry(updated).Entity.IsActive = false;
                }
                movieContext.SaveChanges();
                return "Tür güncellendi!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Genre> Where(Expression<Func<Genre, bool>> exp)
        {
            return movieContext.Genres.Where(exp).ToList();
        }
    }
}
