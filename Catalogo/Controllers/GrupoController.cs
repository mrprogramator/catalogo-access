using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Catalogo.Controllers
{
    public class GrupoController : Controller
    {
        //
        // GET: /Grupo/

        private Data.UnitOfWork unitOfWork;
        private Repositories.GrupoRepository grupoRepository;

        public GrupoController()
        {
            unitOfWork = new Data.UnitOfWork();
            grupoRepository = unitOfWork.GrupoRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Grupo model)
        {
            try
            {
                var entity = new Entities.Grupo()
                {
                    Id = model.Id,
                    Nombre = model.Nombre,
                    EstadoId = model.EstadoId
                };
                grupoRepository.Insert(entity);
            }
            catch (Exception e)
            {
                return Json(new { result = false, value = e.Message });
            }
            return Json(new { result = true, value = Url.Action("Index") });
        }

        public ActionResult Edit(String id)
        {
            Models.Grupo model;
            try
            {
                var entity = grupoRepository.GetById(id);
                model = new Models.Grupo()
                {
                    Id = entity.Id,
                    Nombre = entity.Nombre,
                    EstadoId = entity.EstadoId,
                    EstadoValor = entity.Estado.Valor
                };
            }
            catch (Exception e)
            {
                throw e;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Models.Grupo model)
        {
            try
            {
                var entity = grupoRepository.GetById(model.Id);
                entity.Nombre = model.Nombre;
                entity.EstadoId = model.EstadoId;
                grupoRepository.Update(entity);
            }
            catch (Exception e)
            {
                return Json(new { result = false, value = e.Message });
            }
            return Json(new { result = true, value = Url.Action("Index") });
        }

        public ActionResult Delete(String id)
        {
            var entity = grupoRepository.GetById(id);

            var model = new Models.Grupo()
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                EstadoId = entity.EstadoId,
                EstadoValor = entity.Estado.Valor
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Remove(String id)
        {
            try
            {
                var entity = grupoRepository.GetById(id);
                grupoRepository.Delete(entity);
            }
            catch (Exception e)
            {
                return Json(new { result = false, value = e.Message });
            }
            return Json(new { result = true, value = Url.Action("Index") });
        }

        public ActionResult Detail(String id)
        {
            var entity = grupoRepository.GetById(id);

            var model = new Models.Grupo()
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                EstadoId = entity.EstadoId,
                EstadoValor = entity.Estado.Valor
            };

            return View(model);
        }

        public ActionResult Users(String id)
        {
            var entity = grupoRepository.GetById(id);

            var model = new Models.Grupo()
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                EstadoId = entity.EstadoId,
                EstadoValor = entity.Estado.Valor
            };

            return View(model);
        }

        public JsonResult GetGrupos()
        {
            var data = grupoRepository.Grupos();
            return Json(data);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
