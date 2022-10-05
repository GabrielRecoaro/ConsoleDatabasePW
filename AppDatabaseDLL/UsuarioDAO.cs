using AppDatabaseADO;
using AppDatabaseDominio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDatabaseDLL
{
    public class UsuarioDAO
    {
        private Database db;

        public void insertUsuario(Usuario usuario)
        {
            //string insertQuery = String.Format("INSERT INTO tbUsuario VALUES (default, {0}, {1}, {2}",
            //                                      usuario.UsuarioNome,
            //                                      usuario.UsuarioCargo,
            //                                      Convert.ToDateTime(usuario.UsuarioDataNasc));
            //using (db = new Database())
            //{
            //    db.ExecuteCommand(insertQuery);
            //}

            var strQuery = "";
            strQuery += "INSERT INTO tbUsuario(nomeUsu, cargo, datanasc)";
            strQuery += string.Format("VALUES ('{0}','{1}',STR_TO_DATE('{2}','%d/%m/%Y %T'));", usuario.UsuarioNome, usuario.UsuarioCargo, usuario.UsuarioDataNasc);


            using (db = new Database())
            {
                db.ExecuteCommand(strQuery);
            }
        }

        public void updateUsuario(Usuario usuario)
        {
            //string updateQuery = String.Format("UPDATE tbUsuario " +
            //                                    "SET nomeUsu = {0}, " +
            //                                        "cargo = {1}, " +
            //                                        "datanasc = {2} " +
            //                                    "WHERE idUsu = {3}",
            //                                     usuario.UsuarioNome,
            //                                     usuario.UsuarioCargo,
            //                                     usuario.UsuarioDataNasc,
            //                                     usuario.UsuarioId);

            //using (db = new Database())
            //{
            //    db.ExecuteCommand(updateQuery);
            //}

            var strQuery = "";
            strQuery += "UPDATE tbUsuario set ";
            strQuery += string.Format(" nomeUsu = '{0}', ", usuario.UsuarioNome);
            strQuery += string.Format(" cargo = '{0}', ", usuario.UsuarioCargo);
            strQuery += string.Format(" datanasc = STR_TO_DATE('{0}','%d/%m/%Y %T')", usuario.UsuarioDataNasc);
            strQuery += string.Format(" Where idUsu = {0}", usuario.UsuarioId);

            using (db = new Database())
            {
                db.ExecuteCommand(strQuery);
            }
        }

        public void deleteUsuario(Usuario usuario)
        {
            string deleteQuery = String.Format("DELETE FROM tbUsuario WHERE idUsu = {0}", usuario.UsuarioId);
            using (db = new Database())
            {
                db.ExecuteCommand(deleteQuery);
            }
        }

        public List<Usuario> Select()
        {
            using (db = new Database())
            {
                string strQuery = "select * from tbUsuario;";
                var leitor = db.RetornaComando(strQuery);

                return GeraListUsuario(leitor);
            }
        }

        public List<Usuario> GeraListUsuario(MySqlDataReader leitor)
        {
            var usuarios = new List<Usuario>();

            while (leitor.Read())
            {
                var tempUsuario = new Usuario()
                {
                    UsuarioId = int.Parse(leitor["IdUsu"].ToString()),
                    UsuarioNome = leitor["NomeUsu"].ToString(),
                    UsuarioCargo = leitor["Cargo"].ToString(),
                    UsuarioDataNasc = DateTime.Parse(leitor["DataNasc"].ToString())
                };
                usuarios.Add(tempUsuario);
            }
            leitor.Close();
            return usuarios;
        }

    }
}
