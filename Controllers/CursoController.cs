using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using treino_mvc.Models;
using treino_mvc.Data;

namespace treino_mvc.Controllers
{
    public class CursoController : Controller
    {
        // private readonly ApplicationDbContext database;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastrarCurso()
        {
            return View();
        }

        public IActionResult Salvar()
        {
            return RedirectToAction("Index");
        }
    }
}