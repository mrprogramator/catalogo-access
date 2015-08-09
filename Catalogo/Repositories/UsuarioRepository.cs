using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Catalogo.Repositories
{
    public class UsuarioRepository
    {
        Data.CatDBContext context;

        public UsuarioRepository(Data.CatDBContext context)
        {
            this.context = context;
        }

        public Entities.Usuario GetById(Object id)
        {
            return context.Usuarios.Find(id);
        }

        public DbSet<Entities.Usuario> Usuarios
        {
            get
            {
                return this.context.Usuarios;
            }
        }

        public void Insert(Entities.Usuario entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
                this.context.Usuarios.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(Entities.Usuario entity)
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

        public void Delete(Entities.Usuario entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
                this.context.Usuarios.Remove(entity);
                this.context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}