using DataAccess.Context;
using DataAccess.Entity;
using DataAccess.ICoreService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Base
{
    public abstract class BaseService<T> : ICoreService<T> where T : BaseEntity
    {
       
        //Veri Tabanının İnstance alınacak.
        private readonly MovieContext _context;



        //public MyController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}


        public string Add(T model)
        {
            try
            {              
                _context.Set<T>().Add(model);
                _context.SaveChanges();
                return $"veri kaydedildi!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string Add(List<T> models)
        {
            try
            {
                foreach (T item in models)
                {
                    
                    _context.Set<T>().Add(item);
                    _context.SaveChanges();
                }
                return "Liste kaydedildi!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Any(exp);

        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).ToList();
        }

        public List<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public void RemoveForce(T model)
        {
            try
            {
                if (model.Id != null)
                {
                    T deleted = GetById(model.Id);
                    _context.Set<T>().Remove(deleted);
                    _context.SaveChanges();
                }
                else
                {
                    return;
                }


            }
            catch (Exception ex)
            {

                return;

            }
        }

        public string Update(T model)
        {
            try
            {
                T entity = GetById(model.Id);
                var entry = _context.Entry(entity);
                switch (model.IsActive)
                {
                    case false:
                        model.IsActive = false;
                        entry.CurrentValues.SetValues(model);
                        _context.SaveChanges();
                        break;
                    case true:
                        model.IsActive= true;
                        entry.CurrentValues.SetValues(model);
                        _context.SaveChanges();
                        break;
                   
                }
                return "veri güncellendi";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
