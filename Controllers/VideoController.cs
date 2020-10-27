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
using Microsoft.EntityFrameworkCore;

namespace treino_mvc.Controllers 
{
    [Authorize]
    public class VideoController : Controller
    {
        private readonly ApplicationDbContext database;

        public VideoController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [Authorize(Policy = "Cargo")]
        [HttpGet("Video/{id:int}")]
        public IActionResult Index(int id)
        {
            var listaDeVideosDeUmCurso = database.Video.Include(v => v.Curso).Where(v => v.Curso.Id == id).ToList();

            ViewData["idCurso"] = id;
            return View(listaDeVideosDeUmCurso);
        }

        [Authorize(Policy = "Cargo")]
        [HttpGet("Video/CadastrarVideo/{id:int}")]
        public IActionResult CadastrarVideo(int id)
        {
            ViewData["idCursoVideo"] = id;
            return View();
        }

        [Authorize(Policy = "Cargo")]
        [HttpPost]
        public IActionResult Salvar(Video video, Curso curso)
        {
            if (video.Id == 0)
            {
                video.Nome = video.Nome;
                video.LinkVideo = video.LinkVideo;
                video.Descricao = video.Descricao;
                video.Curso = database.Curso.First(c => c.Id == curso.Id);
                database.Add(video);
            }
            else
            {
                Video videoDoBanco = database.Video.First(registro => registro.Id == video.Id);

                videoDoBanco.Nome = video.Nome;
                videoDoBanco.LinkVideo = video.LinkVideo;
                videoDoBanco.Descricao = video.Descricao;
                videoDoBanco.Curso = curso;
            }

            database.SaveChanges();

            return View("Index");
        }

        public IActionResult ExibirVideos()
        {
            return View();
        }

        [HttpGet("Video/Editar/{id:int}")]
        public IActionResult Editar(int id)
        {
            return Content("Editar, id" + id);
        }

        [HttpGet("Video/Excluir/{id:int}")]
        public IActionResult Excluir(int id)
        {
            return Content("Excluir" + id);
        }
    }
}