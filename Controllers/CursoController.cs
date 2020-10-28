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
using treino_mvc.DTO;
using Microsoft.EntityFrameworkCore;

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
            ViewData["aux"] = 0;
            return View();
        }

        [Authorize(Policy = "Cargo")]
        [HttpPost]
        public IActionResult Salvar(CursoDTO cursoTemporario)
        {
            if (ModelState.IsValid)
            {
                Curso curso = new Curso();

                if (cursoTemporario.Id == 0)
                {
                    curso.Nome = cursoTemporario.Nome;
                    curso.Descricao = cursoTemporario.Descricao;

                    database.Curso.Add(curso);
                }
                else
                {
                    Curso cursoDoBanco = database.Curso.First(registro => registro.Id == cursoTemporario.Id);

                    cursoDoBanco.Nome = cursoTemporario.Nome;
                    cursoDoBanco.Descricao = cursoTemporario.Descricao;
                }

                database.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["aux"] = cursoTemporario.Id;
                return View("../Curso/CadastrarCurso");
            }
        }

        [HttpGet("Curso/ExibirCursos/{id:int}")]
        public IActionResult ExibirCursos(int id)
        {
            var listaDeVideosDeUmCurso = database.Video.Include(v => v.Curso).Where(v => v.Curso.Id == id).ToList();

            return View(listaDeVideosDeUmCurso);
        }

        public IActionResult Editar(int id)
        {
            Curso curso = database.Curso.First(registro => registro.Id == id);
            CursoDTO cursoTemporario = new CursoDTO();

            cursoTemporario.Id = curso.Id;
            cursoTemporario.Nome = curso.Nome;
            cursoTemporario.Descricao = curso.Descricao;

            ViewData["aux"] = id;

            return View("CadastrarCurso", cursoTemporario);
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