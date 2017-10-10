using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.DBContext;
using CRUD.Repository;
using CRUD.Model.Model;
using System.Linq.Expressions;
using System.Data.Entity;

namespace CRUD.Repository
{
    public abstract class RepositoryBase<TModel> where TModel : ModelBase
    {
        public DBContext.DBContext context = new DBContext.DBContext();

        protected bool Add(TModel model)
        {
            model.Id = Guid.NewGuid();
            model.DateCreate = DateTime.Now;
            model.Status = EnumStatus.Active;
            context.Set<TModel>().Add(model);
            return true;
        }

        protected bool SaveChange()
        {
            context.SaveChanges();
            return true;
        }

        protected IQueryable<TModel> Read(Expression<Func<TModel, bool>> where = null, bool isNoTracking = false)
        {
            IQueryable<TModel> query;
            if (isNoTracking)
                query = context.Set<TModel>().AsNoTracking().AsQueryable();
            else
                query = context.Set<TModel>().AsQueryable();

            if (where != null)
                query = query.Where(where);

            return query;
        }
        protected bool DeleteById(Guid Id)
        {
            TModel model = context.Set<TModel>().SingleOrDefault(x => x.Id == Id);
            model.Status = EnumStatus.Deleted;
            context.SaveChanges();
            return true;
        }

    }
}
