using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using treino_mvc.Models;
using treino_mvc.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace treino_mvc.Controllers
{
    [Authorize]
    public class CursoController : Controller
    {
        private readonly ApplicationDbContext database;

        public CursoController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [Authorize(Policy = "Cargo")]
        public IActionResult Index()
        {
            var curso = database.Curso.ToList();
            return View(curso);
        }

        [Authorize(Policy = "Cargo")]
        public IActionResult CadastrarCurso()
        {
            return View();
        }

        [Authorize(Policy = "Cargo")]
        [HttpPost]
        public IActionResult Salvar(Curso curso)
        {
            if (curso.Id == 0)
            {
                database.Curso.Add(curso);
            }
            else
            {
                Curso cursoDoBanco = database.Curso.First(registro => registro.Id == curso.Id);

                cursoDoBanco.Nome = curso.Nome;
                cursoDoBanco.Descricao = curso.Descricao;
            }

            database.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ExibirCursos()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            Curso curso = database.Curso.First(registro => registro.Id == id);
            return View("CadastrarCurso", curso);
        }

        public IActionResult Excluir(int id)
        {
            Curso curso = database.Curso.First(registro => registro.Id == id);
            database.Curso.Remove(curso);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}