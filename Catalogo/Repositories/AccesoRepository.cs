using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Catalogo.Repositories
{
    public class AccesoRepository
    {
        Data.CatDBContext context;

        public AccesoRepository(Data.CatDBContext context)
        {
            this.context = context;
        }

        public Entities.Acceso GetById(Object programaId, Object usuarioId)
        {
            return context.Accesos.Find(programaId, usuarioId);
        }

        public DbSet<Entities.Acceso> Accesos()
        {
            return this.context.Accesos;
        }

        public void Insert(Entities.Acceso entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
                this.context.Accesos.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(Entities.Acceso entity)
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

        public void Delete(Entities.Acceso entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
                this.context.Accesos.Remove(entity);
                this.context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}