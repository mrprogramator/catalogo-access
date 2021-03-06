﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Catalogo.Repositories
{
    public class ProgramaRepository
    {
        Data.CatDBContext context;

        public ProgramaRepository(Data.CatDBContext context)
        {
            this.context = context;
        }

        public Entities.Programa GetById(Object id)
        {
            return context.Programas.Find(id);
        }

        public DbSet<Entities.Programa> Programas()
        {
            return this.context.Programas;
        }

        public void Insert(Entities.Programa entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
                this.context.Programas.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(Entities.Programa entity)
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

        public void Delete(Entities.Programa entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
                this.context.Programas.Remove(entity);
                this.context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}