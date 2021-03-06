﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Catalogo.Controllers
{
    public class AccesoController : Controller
    {
        //
        // GET: /Acceso/
        Data.UnitOfWork unitOfWork;
        Repositories.AccesoRepository accesoRepository;

        public AccesoController()
        {
            unitOfWork = new Data.UnitOfWork();
            accesoRepository = unitOfWork.AccesoRepository();
        }

        [HttpPost]
        public ActionResult Create(String programaId, String usuarioId)
        {
            try
            {
                var entity = new Entities.Acceso();
                entity.ProgramaId = programaId;
                entity.UsuarioId = usuarioId;
                entity.FechaInicio = DateTime.Now;
                entity.UnidadEmpId = "ue001";
                entity.SucursalId = "suc001";

                accesoRepository.Insert(entity);
            }
            catch (Exception e)
            {
                return Json(new { result = false, value = e.Message });
            }

            return Json(new { result = true });
        }

        [HttpPost]
        public ActionResult Remove(String programaId, String usuarioId)
        {
            try
            {
                var entity = accesoRepository.GetById(programaId, usuarioId);
                accesoRepository.Delete(entity);
            }
            catch (Exception e)
            {
                return Json(new { result = false, value = e.Message });
            }

            return Json(new { result = true });
        }

        [HttpPost]
        public ActionResult Update(Entities.Acceso model)
        {
            try
            {
                var entity = accesoRepository.GetById(model.ProgramaId, model.UsuarioId);
                entity.CheckSel = model.CheckSel;
                entity.CheckIns = model.CheckIns;
                entity.CheckMod = model.CheckMod;
                entity.CheckEli = model.CheckEli;
                entity.CheckImp = model.CheckImp;
                accesoRepository.Update(entity);
            }
            catch(Exception e)
            {
                return Json(new { result = false, value = e.Message });
            }

            return Json(new { result = true });
        }
        public JsonResult GetAccessByProgram(String id)
        {
            var data = accesoRepository.Accesos().Where(a => a.ProgramaId.Equals(id)).ToArray();
            return Json(data);
        }

    }
}
