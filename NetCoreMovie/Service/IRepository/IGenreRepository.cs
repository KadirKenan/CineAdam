using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.IRepository
{
    public interface IGenreRepository
    {
        //Tür classı için tanımlanacak Metotlar.

        //Listeleme
        List<Genre> GetGenres();

        //Ekleme
        string PostGenre(Genre genre);

        //Arama
        Genre Find(int genreId);


        //Güncelleme
        string UpdateGenre(Genre genre);

        //Silme
        string DeleteGenre(int genreId);

        //Kritere Göre Arama
        List<Genre> Where(Expression<Func<Genre, bool>> exp);

        //Var mı Yok mu?
        bool Any(Expression<Func<Genre, bool>> exp);
    }
}
