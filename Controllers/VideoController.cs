using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using treino_mvc.Models;

namespace treino_mvc.Controllers 
{
    public class VideoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastrarVideo()
        {
            return View();
        }

        public IActionResult Salvar()
        {
            return RedirectToAction("Index");
        }
    }
}