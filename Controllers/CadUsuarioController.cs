using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class CadUsuarioController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario u)
        {
            UsuarioService usuarioService = new UsuarioService();

            if(u.Id == 0)
            {
                usuarioService.Inserir(u);
            }
            else
            {
                usuarioService.Atualizar(u);
            }

            return RedirectToAction("Lista");
        }

        public IActionResult Lista()
        {
            UsuarioService usuarioService = new UsuarioService();
            return View(usuarioService.Listar());
        }

        public IActionResult Edicao(int id)
        {
            UsuarioService uc = new UsuarioService();
            Usuario u = uc.ObterPorId(id);
            return View(u);
        }
        
        public IActionResult Excluir(int id)
        {
            Autenticacao.CheckLogin(this);
            UsuarioService uc = new UsuarioService();
            uc.Deletar(id);
            @ViewBag.Pag = "Conta excluida com sucesso!";
            return View();
        }
    }
}
