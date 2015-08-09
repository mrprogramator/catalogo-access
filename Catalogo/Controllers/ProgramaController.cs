using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Catalogo.Controllers
{
    public class ProgramaController : Controller
    {
        //
        // GET: /Programa/

        private static readonly String CODSOL = "par003";
        private static readonly String CODCAR = "par004";
        private static readonly String CODPRO = "par005";

        Data.UnitOfWork unitOfWork;
        Repositories.ProgramaRepository programaRepository;

        public ProgramaController()
        {
            unitOfWork = new Data.UnitOfWork();
            programaRepository = unitOfWork.ProgramaRepository();
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
        public ActionResult Create(Models.Programa model)
        {
            try
            {
                var entity = new Entities.Programa()
                {
                    Id = model.Id,
                    Nombre = model.Nombre,
                    TipoId = model.TipoId,
                    PadreId = model.PadreId,
                    Orden = model.Orden,
                    EstadoId = model.EstadoId,
                    Url = model.Url,
                    CheckSel = model.CheckSel,
                    CheckIns = model.CheckIns,
                    CheckMod = model.CheckMod,
                    CheckEli = model.CheckEli,
                    CheckImp = model.CheckImp
                };
                programaRepository.Insert(entity);
            }
            catch (Exception e)
            {
                return Json(new { result = false, value = e.Message });
            }

            return Json(new { result = true, value = Url.Action("Index") });
        }

        public ActionResult Edit(String id)
        {
            var entity = programaRepository.GetById(id);

            var model = new Models.Programa()
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                TipoId = entity.TipoId,
                TipoValor = entity.Tipo.Valor,
                PadreId = entity.PadreId,
                Orden = entity.Orden,
                EstadoId = entity.EstadoId,
                EstadoValor = entity.Estado.Valor,
                Url = entity.Url,
                CheckSel = entity.CheckSel,
                CheckIns = entity.CheckIns,
                CheckMod = entity.CheckMod,
                CheckEli = entity.CheckEli,
                CheckImp = entity.CheckImp
            };

            if (!String.IsNullOrEmpty(model.PadreId))
            {
                model.PadreNombre = entity.Padre.Nombre;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Models.Programa model)
        {
            try
            {
                var entity = programaRepository.GetById(model.Id);
                entity.Nombre = model.Nombre;
                entity.TipoId = model.TipoId;
                entity.PadreId = model.PadreId;
                entity.Orden = model.Orden;
                entity.EstadoId = model.EstadoId;
                entity.Url = model.Url;
                entity.CheckSel = model.CheckSel;
                entity.CheckIns = model.CheckIns;
                entity.CheckMod = model.CheckMod;
                entity.CheckEli = model.CheckEli;
                entity.CheckImp = model.CheckImp;

                programaRepository.Update(entity);
            }
            catch (Exception e)
            {
                return Json(new { result = false, value = e.Message });
            }

            return Json(new { result = true, value = Url.Action("Index") });
        }

        public ActionResult Delete(String id)
        {
            var entity = programaRepository.GetById(id);

            var model = new Models.Programa()
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                TipoId = entity.TipoId,
                TipoValor = entity.Tipo.Valor,
                PadreId = entity.PadreId,
                Orden = entity.Orden,
                EstadoId = entity.EstadoId,
                EstadoValor = entity.Estado.Valor,
                Url = entity.Url,
                CheckSel = entity.CheckSel,
                CheckIns = entity.CheckIns,
                CheckMod = entity.CheckMod,
                CheckEli = entity.CheckEli,
                CheckImp = entity.CheckImp
            };

            if (!String.IsNullOrEmpty(model.PadreId))
            {
                model.PadreNombre = entity.Padre.Nombre;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Remove(String id)
        {
            try
            {
                var entity = programaRepository.GetById(id);

                programaRepository.Delete(entity);
            }
            catch (Exception e)
            {
                return Json(new { result = false, value = e.Message });
            }

            return Json(new { result = true, value = Url.Action("Index") });
        }

        public ActionResult Detail(String id)
        {
            var entity = programaRepository.GetById(id);

            var model = new Models.Programa()
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                TipoId = entity.TipoId,
                TipoValor = entity.Tipo.Valor,
                PadreId = entity.PadreId,
                Orden = entity.Orden,
                EstadoId = entity.EstadoId,
                EstadoValor = entity.Estado.Valor,
                Url = entity.Url,
                CheckSel = entity.CheckSel,
                CheckIns = entity.CheckIns,
                CheckMod = entity.CheckMod,
                CheckEli = entity.CheckEli,
                CheckImp = entity.CheckImp
            };

            if (!String.IsNullOrEmpty(model.PadreId))
            {
                model.PadreNombre = entity.Padre.Nombre;
            }

            return View(model);
        }

        public ActionResult Access(String id)
        {
            var entity = programaRepository.GetById(id);

            var model = new Models.Programa()
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                TipoId = entity.TipoId,
                TipoValor = entity.Tipo.Valor,
                PadreId = entity.PadreId,
                Orden = entity.Orden,
                EstadoId = entity.EstadoId,
                EstadoValor = entity.Estado.Valor,
                Url = entity.Url,
                CheckSel = entity.CheckSel,
                CheckIns = entity.CheckIns,
                CheckMod = entity.CheckMod,
                CheckEli = entity.CheckEli,
                CheckImp = entity.CheckImp
            };

            if (!String.IsNullOrEmpty(model.PadreId))
            {
                model.PadreNombre = entity.Padre.Nombre;
            }

            return View(model);
        }

        public ActionResult AccessGroup(String id)
        {
            var entity = programaRepository.GetById(id);

            var model = new Models.Programa()
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                TipoId = entity.TipoId,
                TipoValor = entity.Tipo.Valor,
                PadreId = entity.PadreId,
                Orden = entity.Orden,
                EstadoId = entity.EstadoId,
                EstadoValor = entity.Estado.Valor,
                Url = entity.Url,
                CheckSel = entity.CheckSel,
                CheckIns = entity.CheckIns,
                CheckMod = entity.CheckMod,
                CheckEli = entity.CheckEli,
                CheckImp = entity.CheckImp
            };

            if (!String.IsNullOrEmpty(model.PadreId))
            {
                model.PadreNombre = entity.Padre.Nombre;
            }

            return View(model);
        }
        
        public JsonResult GetItems()
        {
            var data = programaRepository.Programas();

            return Json(data);
        }

        public JsonResult GetSoluciones()
        {
            var data = programaRepository.Programas().Where(p => p.TipoId.Equals(CODSOL)).ToArray();
            return Json(data);
        }

        public JsonResult GetCarpetas()
        {
            var data = programaRepository.Programas().Where(p => p.TipoId.Equals(CODCAR)).ToArray();
            return Json(data);
        }

        public JsonResult GetProgramas()
        {
            var data = programaRepository.Programas().Where(p => p.TipoId.Equals(CODPRO)).ToArray();
            return Json(data);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
