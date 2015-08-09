using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Catalogo.Controllers
{
    public class ParametroController : Controller
    {
        //
        // GET: /Parametro/

        private static readonly String TIPPRO = "TIPPRO";
        private static readonly String CODEST = "TIPEST";

        Repositories.ParametroRepository parametroRepository;
        Data.UnitOfWork unitOfWork;

        public ParametroController()
        {
            unitOfWork = new Data.UnitOfWork();
            parametroRepository = unitOfWork.ParametroRepository();
        }

        public JsonResult GetTipoProgramas()
        {
            var data = parametroRepository.GetByGroup(TIPPRO);
            return Json(data);
        }

        public JsonResult GetEstados()
        {
            var data = parametroRepository.GetByGroup(CODEST);
            return Json(data);
        }
    }
}
