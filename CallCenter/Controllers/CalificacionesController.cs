using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenter.Controllers
{
    [Route("api/[controller]")]
    public class CalificacionesController : Controller
    {
        [HttpGet("[action]")]
        public string CalificacioGeneral()
        {
            return "Respuesta al metodo";
        }
    }
}
