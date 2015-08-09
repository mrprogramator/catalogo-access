using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Catalogo.Repositories
{
    public class ParametroRepository
    {
        Data.CatDBContext context;

        public ParametroRepository(Data.CatDBContext context)
        {
            this.context = context;
        }

        public Entities.Parametro GetById(Object id)
        {
            return context.Parametros.Find(id);
        }

        public IEnumerable<Entities.Parametro> GetByGroup(String grupo)
        {
            return context.Parametros.Where(p => p.Grupo.Equals(grupo)).ToArray();
        }

        public DbSet<Entities.Parametro> Parametros
        {
            get
            {
                return this.context.Parametros;
            }
        }

        public void Insert(Entities.Parametro entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
                this.context.Parametros.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(Entities.Parametro entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(Entities.Parametro entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
                this.context.Parametros.Remove(entity);
                this.context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}