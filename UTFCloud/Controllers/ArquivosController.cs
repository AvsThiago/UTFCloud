﻿using Modelo;
using Servico;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace UTFCloud.Controllers
{
    public class ArquivosController : Controller
    {
        private ArquivoServico arquivoServico = new ArquivoServico();

        // GET: Arquivos
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return View("Papelaria");
            else
                return View("Create");
        }

        // GET: Arquivos/Details/5
        public ActionResult Details(int ra)
        {
            return View(arquivoServico.ObterArquivosPorRA(ra));
        }

        [Authorize]
        public ActionResult Papelaria(string registro = null)
        {
            if (registro != null)
                return View(arquivoServico.ObterArquivosPorRA(Convert.ToInt32(registro)));

            return View();
        }

        // GET: Arquivos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Arquivos/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Arquivo")]Arquivos arquivos, IEnumerable<HttpPostedFileBase> arquivo/*HttpPostedFileBase arquivo = null*/, string TempoParaRemover = null)
        {
            try
            {
                return GravarArquivo(arquivos, arquivo, TempoParaRemover);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        private ActionResult GravarArquivo(Arquivos arquivos, IEnumerable<HttpPostedFileBase> logotipo, string TempoParaRemover)
        {
            try
            {
                if (logotipo != null)
                {
                    if (ModelState.IsValid)
                    {
                        List<Arquivos> lArquivos = new List<Arquivos>();
                        foreach (var item in logotipo)
                        {
                            Arquivos arquivo = new Arquivos();
                            arquivo.DtSerRemovido = arquivos.DtSerRemovido;
                            arquivo.RA = arquivos.RA;
                            arquivo.Senha = arquivos.Senha;
                            arquivo.ArquivoMimeType = item.ContentType;
                            arquivo.Arquivo = SetArquivo(item);
                            arquivo.NomeArquivo = item.FileName;
                            arquivo.TamanhoArquivo = item.ContentLength;
                            arquivo = insereDataRemocao(arquivo, TempoParaRemover);
                            lArquivos.Add(arquivo);
                        }
                        arquivoServico.GravarArquivo(lArquivos);

                        return RedirectToAction("Details", new { ra = arquivos.RA });
                    }
                }
                else
                {
                    ModelState.AddModelError("55", "Escolha o arquivo a ser enviado.");
                }
               
                return View(arquivos);
            }
            catch (Exception ex)
            {
                //PopularViewBag(produto);
                return View(arquivos);
            }
        }

        private Arquivos insereDataRemocao(Arquivos arquivos, string TempoParaRemover)
        {
            int removerEm = 0;

            switch (TempoParaRemover)
            {
                case "1": removerEm = 1; break;
                case "2": removerEm = 2; break;
                case "6": removerEm = 6; break;
                case "12": removerEm = 12; break;
                case "24": removerEm = 24; break;
                default: removerEm = 24; break;
            }

            arquivos.DtSerRemovido = DateTime.Now.AddHours(removerEm);

            return arquivos;
        }

        private byte[] SetArquivo(HttpPostedFileBase arquivo)
        {
            var bytesArquivo = new byte[arquivo.ContentLength];
            arquivo.InputStream.Read(bytesArquivo, 0, arquivo.ContentLength);
            return bytesArquivo;
        }

        [Authorize]
        [HttpPost]
        public ActionResult DownloadArquivo(long id, string senha = null)
        {
            Arquivos arquivos = arquivoServico.ObterArquivoId(id, senha);

            if (arquivos != null)
            {
                FileStream fileStream = new FileStream(Server.MapPath("~/TempData/" + arquivos.NomeArquivo), FileMode.Create, FileAccess.Write);
                fileStream.Write(arquivos.Arquivo, 0, Convert.ToInt32(arquivos.TamanhoArquivo));
                fileStream.Close();

                return File(fileStream.Name, arquivos.ArquivoMimeType, arquivos.NomeArquivo);
            }
            else
            {
                
                return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
            }
        }
        
    }
}
