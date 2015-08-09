using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Catalogo.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        private Data.UnitOfWork unitOfWork;
        private Repositories.UsuarioRepository usuarioRepository;

        public UsuarioController()
        {
            unitOfWork = new Data.UnitOfWork();
            usuarioRepository = unitOfWork.UsuarioRepository();
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
        public ActionResult Create(Models.Usuario model)
        {
            try
            {
                var entity = new Entities.Usuario();
                entity.Id = model.Id;
                entity.Email = model.Email;
                entity.Password = model.Password;
                
                usuarioRepository.Insert(entity);
            }
            catch (Exception e)
            {
                return Json(new { result = false, value = e.Message });
            }
            return Json(new { result = true, value = Url.Action("Index") });
        }

        public ActionResult Edit(String id)
        {
            var model = new Models.Usuario();
            try
            {
                var entity = usuarioRepository.GetById(id);
                model.Id = entity.Id;
                model.Email = entity.Email;
                model.Password = entity.Password;
            }
            catch (Exception e)
            {
                throw e;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Models.Usuario model)
        {
            try
            {
                var entity = usuarioRepository.GetById(model.Id);
                entity.Email = model.Email;
                usuarioRepository.Update(entity);
            }
            catch (Exception e)
            {
                return Json(new { result = false, value = e.Message });
            }
            return Json(new { result = true, value = Url.Action("Index") });
        }

        public ActionResult Delete(String id)
        {
            var entity = usuarioRepository.GetById(id);
            var model = new Models.Usuario()
            {
                Id = entity.Id,
                Email = entity.Email,
                Password = entity.Password
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Remove(String id)
        {
            try
            {
                var entity = usuarioRepository.GetById(id);
                usuarioRepository.Delete(entity);
            }
            catch (Exception e)
            {
                return Json(new { result = false, value = e.Message });
            }
            return Json(new { result = true, value = Url.Action("Index") });
        }

        public ActionResult Detail(String id)
        {
            var entity = usuarioRepository.GetById(id);
            var model = new Models.Usuario()
            {
                Id = entity.Id,
                Email = entity.Email,
                Password = entity.Password
            };
            return View(model);
        }

        public ActionResult Groups(String id)
        {
            var entity = usuarioRepository.GetById(id);
            var model = new Models.Usuario()
            {
                Id = entity.Id,
                Email = entity.Email,
                Password = entity.Password
            };
            return View(model);
        }

        public JsonResult GetUsuarios()
        {
            var data = usuarioRepository.Usuarios;

            return Json(data);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
