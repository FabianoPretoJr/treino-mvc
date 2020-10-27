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
using treino_mvc.DTO;

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
            ViewData["aux1"] = 0;
            return View();
        }

        [Authorize(Policy = "Cargo")]
        [HttpPost]
        public IActionResult Salvar(VideoDTO videoTemporario)
        {
            if (ModelState.IsValid)
            {
                Video video = new Video();

                if (videoTemporario.Id == 0)
                {
                    video.Nome = videoTemporario.Nome;
                    video.LinkVideo = videoTemporario.LinkVideo;
                    video.Descricao = videoTemporario.Descricao;
                    video.Curso = database.Curso.First(video => video.Id == videoTemporario.CursoID);
                    database.Video.Add(video);
                }
                else
                {
                    Video videoDoBanco = database.Video.First(registro => registro.Id == videoTemporario.Id);

                    videoDoBanco.Nome = videoTemporario.Nome;
                    videoDoBanco.LinkVideo = videoTemporario.LinkVideo;
                    videoDoBanco.Descricao = videoTemporario.Descricao;
                }
                database.SaveChanges();
                return RedirectToAction("Index", "Curso");
            }
            else
            {
                ViewData["aux1"] = 0;
                return View("../Video/CadastroVideo");
            }
        }

        public IActionResult ExibirVideos()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            Video video = database.Video.First(registro => registro.Id == id);
            Curso curso = database.Curso.First(curso => curso.Id == video.Curso.Id);
            VideoDTO videoTemporario = new VideoDTO();

            videoTemporario.Nome = video.Nome;
            videoTemporario.LinkVideo = video.LinkVideo;
            videoTemporario.Descricao = video.Descricao;
            videoTemporario.CursoID = curso.Id;
            videoTemporario.Id = id;

            ViewData["idCursoVideo"] = id;
            ViewData["aux1"] = id;

            return View("CadastrarVideo", videoTemporario);
        }

        public IActionResult Excluir(int id)
        {
            return Content("Excluir" + id);
        }
    }
}