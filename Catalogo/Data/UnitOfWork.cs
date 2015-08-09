using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Catalogo.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly CatDBContext context;
        private Boolean disposed;

        public UnitOfWork(CatDBContext context)
        {
            this.context = context; 
        }

        public UnitOfWork()
        {
            context = new CatDBContext();
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        public void Save()
        {
            context.SaveChanges();
        }

        public virtual void Dispose(Boolean disposing)
        {
            if (!disposed)
            {
                if (!disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public Repositories.AccesoRepository AccesoRepository()
        {
            return new Repositories.AccesoRepository(context);
        }
        
        public Repositories.AccesoGrupoRepository AccesoGrupoRepository()
        {
            return new Repositories.AccesoGrupoRepository(context);
        }

        public Repositories.GrupoRepository GrupoRepository()
        {
            return new Repositories.GrupoRepository(context);
        }

        public Repositories.ParametroRepository ParametroRepository()
        {
            return new Repositories.ParametroRepository(context);
        }

        public Repositories.ProgramaRepository ProgramaRepository()
        {
            return new Repositories.ProgramaRepository(context);
        }

        public Repositories.UsuarioGrupoRepository UsuarioGrupoRepository()
        {
            return new Repositories.UsuarioGrupoRepository(context);
        }

        public Repositories.UsuarioRepository UsuarioRepository()
        {
            return new Repositories.UsuarioRepository(context);
        }
    }
}