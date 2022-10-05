using AppDatabaseDLL;
using AppDatabaseDominio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString);

            conexao.Open();
            Usuario usuario = new Usuario();
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            Program program = new Program();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            
            Console.WriteLine("_________________AppBanco_________________");
            Console.WriteLine("        _________________________         ");
            Console.WriteLine("       |                         |        ");
            Console.WriteLine("       |  0 - Cadastrar Usuário  |        ");
            Console.WriteLine("       |  1 - Editar Usuário     |        ");
            Console.WriteLine("       |  2 - Excluir Usuário    |        ");
            Console.WriteLine("       |  3 - Listar Usuario     |        ");
            Console.WriteLine("       |  4 - Sair               |        ");
            Console.WriteLine("       |_________________________|        ");
            Console.WriteLine("                                          ");
            Console.WriteLine("__________________________________________");
            Console.WriteLine("");
            
            Console.WriteLine("Digite a opção desejada:");
            Console.ForegroundColor = ConsoleColor.White;
            var opcao = Console.ReadLine();

            while(opcao == "")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Por favor, digite a opção desejada:");
                opcao = Console.ReadLine();
            }

            switch (opcao)
            {
                case "0": //CADASTRAR X

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Digite o nome do usuário:");
                    Console.ForegroundColor = ConsoleColor.White;
                    usuario.UsuarioNome = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Digite o cargo do usuário:");
                    Console.ForegroundColor = ConsoleColor.White;
                    usuario.UsuarioCargo = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Digite a data de nascimento do usuário:");
                    Console.ForegroundColor = ConsoleColor.White;
                    usuario.UsuarioDataNasc = Console.ReadLine();

                    usuarioDAO.insertUsuario(usuario);

                    program.listarUsuarios();

                    break;

                case "1": // EDITAR X
                    

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Digite o nome do usuário:");
                    Console.ForegroundColor = ConsoleColor.White;
                    usuario.UsuarioNome = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Digite o cargo do usuário:");
                    Console.ForegroundColor = ConsoleColor.White;
                    usuario.UsuarioCargo = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Digite a data de nascimento do usuário:");
                    Console.ForegroundColor = ConsoleColor.White;
                    usuario.UsuarioDataNasc = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Digite o código do usuário:");
                    Console.ForegroundColor = ConsoleColor.White;
                    usuario.UsuarioId = Convert.ToInt32(Console.ReadLine());

                    usuarioDAO.updateUsuario(usuario);

                    program.listarUsuarios();

                    break;

                case "2": // EXCLUIR 

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Digite o código do usuário:");
                    Console.ForegroundColor = ConsoleColor.White;
                    usuario.UsuarioId = Convert.ToInt32(Console.ReadLine());

                    usuarioDAO.deleteUsuario(usuario);

                    program.listarUsuarios();

                    break;

                case "3": // LISTAR 

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    program.listarUsuarios();

                    
                    break;

                case "4": // SAIR

                    Environment.Exit(0);
                    break;

                default:

                    Console.WriteLine("Por favor");

                    break;

            }
        }

        public void listarUsuarios()
        {
            MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString);

            conexao.Open();

            string selectUserCommand = "SELECT * FROM tbUsuario";
                    MySqlCommand command = new MySqlCommand(selectUserCommand, conexao);
                    MySqlDataReader reader = command.ExecuteReader();

            Console.WriteLine("\nListagem de todos os usuários: ");

            while (reader.Read())
            {
                 Console.WriteLine("Código: {0} | Nome: {1} | Cargo: {2} | Data de Nascimento: {3}",
                      reader["idUsu"],
                      reader["nomeUsu"],
                      reader["cargo"],
                      reader["datanasc"]);
            }
            Console.ReadLine();
        }
    }
}
