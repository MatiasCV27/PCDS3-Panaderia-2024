using Microsoft.AspNetCore.Mvc;
using PCDS2_Panaderia.Models;
using PCDS2_Panaderia.Data;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace PCDS2_Panaderia.Controllers
{
    public class AccesoController : Controller
    {

        UsuariosData _userData = new UsuariosData();

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ValidarUser(UsuariosModel _usuario)
        {
            if (string.IsNullOrEmpty(_usuario.usuario) || string.IsNullOrEmpty(_usuario.clave))
            {
                // Campos vacíos, devolver un mensaje de error
                return Json(new { success = false, message = "Por favor, ingresa un usuario y una contraseña." });
            }

            UsuariosData _usuarioData = new UsuariosData();
            var usuario = _usuarioData.ValidarUsuario(_usuario.usuario, _usuario.clave);
            if (usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.usuario),
                    new Claim(ClaimTypes.Role, usuario.rol),
                    new Claim("Correo", usuario.correo)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Usuario o contraseña incorrectos." });
            }
        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Acceso");
        }

        // Usuario Crea su propia cuenta
        public IActionResult Registrarse()
        {
            // Metodo solo vuelve a la Vista
            return View();
        }

        [HttpPost]
        public IActionResult Registrarse(UsuariosModel oUser)
        {
            // Metodo recibe el objeto para guardarlo en BD
            if (!ModelState.IsValid)
                return View();

            var respuesta = _userData.GuardarUsuarios(oUser);

            if (respuesta)
                return RedirectToAction("Login", "Acceso");
            else
                return View();
        }

        public IActionResult Niubiz()
        {
            return View();
        }
    }
}
