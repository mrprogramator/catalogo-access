using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Catalogo.Repositories
{
    public class UsuarioGrupoRepository
    {
        Data.CatDBContext context;

        public UsuarioGrupoRepository(Data.CatDBContext context)
        {
            this.context = context;
        }

        public Entities.UsuarioGrupo GetById(Object usuarioId, Object grupoId)
        {
            return context.UsuarioGrupos.Find(usuarioId, grupoId);
        }

        public DbSet<Entities.UsuarioGrupo> UsuarioGrupos()
        {
            return this.context.UsuarioGrupos;
        }

        public void Insert(Entities.UsuarioGrupo entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
                this.context.UsuarioGrupos.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(Entities.UsuarioGrupo entity)
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

        public void Delete(Entities.UsuarioGrupo entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
                this.context.UsuarioGrupos.Remove(entity);
                this.context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}