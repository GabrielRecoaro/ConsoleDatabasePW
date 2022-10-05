using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDatabaseDominio
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public string UsuarioCargo { get; set; }
        public string UsuarioDataNasc { get; set; }


        public Usuario()
        {

        }

        public Usuario(int usuarioId, string usuarioNome, string usuarioCargo, string usuarioDataNasc)
        {
            UsuarioId = usuarioId;
            UsuarioNome = usuarioNome;
            UsuarioCargo = usuarioCargo;
            UsuarioDataNasc = usuarioDataNasc;
        }
    }
}
