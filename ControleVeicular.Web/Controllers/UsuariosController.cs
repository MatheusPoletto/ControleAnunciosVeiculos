using AutoMapper;
using ControleVeicular.Application.Interfaces;
using ControleVeicular.Domain.Entities;
using ControleVeicular.Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
namespace ControleVeicular.Web.Controllers
{
    [Authorize]
    public class UsuariosController : BaseController
    {
        private readonly IUsuarioAppService _usuarioApp;
        private readonly IMapper _mapper;

        public UsuariosController(IMapper mapper, IUsuarioAppService usuarioApp)
        {
            _mapper = mapper;
            _usuarioApp = usuarioApp;
        }

        // GET: UsuariosController
        public ActionResult Index()
        {
            var usuarioViewModel = _mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioApp.GetAll());

            return View(usuarioViewModel);
        }

        // GET: UsuariosController/Details/5
        public ActionResult Details(int id)
        {
            var usuario = _usuarioApp.GetById(id);
            var usuarioViewModel = _mapper.Map<Usuario, UsuarioViewModel>(usuario);

            return View(usuarioViewModel);
        }

        // GET: UsuariosController/Create

        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        [AllowAnonymous]
        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                var usuarioDomain = _mapper.Map<UsuarioViewModel, Usuario>(usuario);                
                _usuarioApp.Add(usuarioDomain);

                if(usuarioDomain.UsuarioId == 0)
                {
                    Alert("O Login já está em uso!", Enums.Enum.NotificationType.warning);
                    return View(usuario);
                }    

                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int id)
        {
            var usuario = _usuarioApp.GetById(id);
            var usuarioViewModel = _mapper.Map<Usuario, UsuarioEditViewModel>(usuario);

            return View(usuarioViewModel);
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioEditViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                var usuarioDomain = _mapper.Map<UsuarioEditViewModel, Usuario>(usuario);
                _usuarioApp.Update(usuarioDomain);

                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int id)
        {
            var usuario = _usuarioApp.GetById(id);
            var usuarioViewModel = _mapper.Map<Usuario, UsuarioViewModel>(usuario);

            return View(usuarioViewModel);
        }

        // POST: UsuariosController/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var usuario = _usuarioApp.GetById(id);
            _usuarioApp.Remove(usuario);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UsuarioLoginViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                var usuarioDomain = new Usuario("", usuario.Login, usuario.Senha);
                var autenticar = _usuarioApp.Autenticar(usuarioDomain);

                if (!autenticar)
                {
                    Alert("Usuário ou senha inválidos!", Enums.Enum.NotificationType.warning);
                    return View();
                }

                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, usuario.Login)
                };

                var identity = new ClaimsIdentity(userClaims, "Usuario");
                var userPrincipal = new ClaimsPrincipal(new[] { identity });

                HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View(usuario);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
