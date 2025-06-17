using AutoTrackApp.AppConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrackApp.DataBase.Provider
{
  public abstract class CrudProviderBase<T> : ICrudProvider<T>
          where T : class
  {
    protected readonly AppDbContext _db = DbContextProvider.Instance;

    public virtual void Create(T entity)
    {
      _db.Set<T>().Add(entity);
      _db.SaveChanges();
    }

    public virtual T? Read(int id)
    {
      return _db.Set<T>().Find(id);
    }

    public virtual IEnumerable<T> ReadAll()
    {
      return _db.Set<T>().AsNoTracking().ToList();
    }

    public virtual void Update(T entity)
    {
      _db.Set<T>().Update(entity);
      _db.SaveChanges();
    }

    public virtual void Delete(int id)
    {
      var entity = Read(id);
      if (entity != null)
      {
        _db.Set<T>().Remove(entity);
        _db.SaveChanges();
      }
    }
  }
}
