using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Reflection;
using System.Data.Entity.ModelConfiguration;

namespace Catalogo.Data
{
    public class CatDBContext : DbContext
    {
        public CatDBContext()
            : base("name=FilaVirtualDBConnection")
        {
        }

        public DbSet<Entities.Acceso> Accesos { get; set; }

        public DbSet<Entities.AccesoGrupo> AccesoGrupos { get; set; }
        
        public DbSet<Entities.Grupo> Grupos { get; set; }
        
        public DbSet<Entities.Parametro> Parametros { get; set; }
        
        public DbSet<Entities.Programa> Programas { get; set; }
        
        public DbSet<Entities.Usuario> Usuarios { get; set; }
        
        public DbSet<Entities.UsuarioGrupo> UsuarioGrupos { get; set; }
    }
}