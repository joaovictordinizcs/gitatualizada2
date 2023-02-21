using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Biblioteca.Models
{
    public class UsuarioService
    {
        public void Inserir(Usuario u)
        {
            using(BibliotecaContext uu = new BibliotecaContext())
            {
                uu.Usuario.Add(u);
                uu.SaveChanges();
            }
        }

        public void Atualizar(Usuario u)
        {
            using(BibliotecaContext uu = new BibliotecaContext())
            {
                Usuario usuario = uu.Usuario.Find(u.Id);
                usuario.loginUsuario = u.loginUsuario;
                usuario.senhaUsuario = u.senhaUsuario;

                uu.SaveChanges();
            }
        }
        
        public Usuario ObterPorId(int id)
        {
            using(BibliotecaContext uu = new BibliotecaContext())
            {
                return uu.Usuario.Find(id);
            }
        }

        public ICollection <Usuario> Listar(){
            using(BibliotecaContext bc = new BibliotecaContext()){
                ICollection<Usuario> consulta = bc.Usuario.ToList();
                return consulta;
            }
        }

         public void Deletar(int id)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario usuario = bc.Usuario.Find(id);
                bc.Usuario.Remove(usuario);
                bc.SaveChanges();
            }
        }
    }
}