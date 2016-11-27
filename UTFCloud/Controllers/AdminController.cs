using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UTFCloud.Infraestrutura;
using System.Web.Helpers;
using UTFCloud.Models;
using static UTFCloud.Models.SegurancaViewModels;

namespace UTFCloud.Controllers
{
    public class AdminController : Controller
    {
        //[Authorize(Roles = "Administradores")]
        public ActionResult Index()
        {
            return View(GerenciadorUsuario.Users);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = GerenciadorUsuario.FindById(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = GerenciadorUsuario.FindById(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Delete(Usuario usuario)
        {
            Usuario user = GerenciadorUsuario.FindById(usuario.Id);
            if (user != null)
            {
                IdentityResult result = GerenciadorUsuario.Delete(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Papelaria", "Arquivos");
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult Edit()
        {

            Usuario usuario = GerenciadorUsuario.FindById(User.Identity.GetUserId());

            if (usuario == null)
                return HttpNotFound();

            var uvm = new MudaSenhaAdminModel();
            uvm.Id = usuario.Id;
            uvm.Nome = usuario.UserName;
            return View(uvm);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(MudaSenhaAdminModel uvm)
        {
            if (User.Identity.GetUserId() != uvm.Id)
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);

            if (ModelState.IsValid)
            {
                if (uvm.NovaSenha == uvm.NovaSenhaNovamente)
                {
                    Usuario usuario = GerenciadorUsuario.FindById(uvm.Id);
                    PasswordHasher ps = new PasswordHasher();

                    if (ps.VerifyHashedPassword(usuario.PasswordHash, uvm.Senha) != PasswordVerificationResult.Failed)
                    {
                        usuario.PasswordHash = GerenciadorUsuario.PasswordHasher.HashPassword(uvm.NovaSenha);
                        IdentityResult result = GerenciadorUsuario.Update(usuario);
                        if (result.Succeeded)
                            return RedirectToAction("Papelaria", "Arquivos");
                        else
                            AddErrorsFromResult(result);
                    }
                    else
                        ModelState.AddModelError("", "A senha atual informada é inválida");
                }
                else
                    ModelState.AddModelError("", "As sehas informadas são diferentes.");
            }
            return View(uvm);
        }

        [HttpPost]
        public ActionResult Create(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario user = new Usuario { UserName = model.Nome, Email = model.Email };
                IdentityResult result = GerenciadorUsuario.Create(user, model.Senha);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(model);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private GerenciadorUsuario GerenciadorUsuario
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuario>();
            }
        }
    }
}