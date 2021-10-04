using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.IRepository
{
    public interface IMovieRepository
    {
        //Listeleme
        List<Movie> GetMovies();

        //Ekleme
        string PostMovie(Movie movie);

        //Arama
        Movie Find(int MovieId);


        //Güncelleme
        string UpdateMovie(Movie Movie);

        //Silme
        string DeleteMovie(int MovieId);

        //Kritere Göre Arama
        List<Movie> Where(Expression<Func<Movie, bool>> exp);

        //Var mı Yok mu?
        bool Any(Expression<Func<Movie, bool>> exp);
    }
}
