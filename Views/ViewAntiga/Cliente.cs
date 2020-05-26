// using System;
// using Models;
// using Controllers;
// using System.Linq;

// namespace View
// {
//     public class ClienteView
//     {
//         /// <summary>
//         /// Creating customers
//         /// </summary>
//         public static void CadastrarCliente()
//         {
//             Console.WriteLine("---===[ CADASTRO DO CLIENTE ]===---");
//             Console.WriteLine("Nome: ");
//             string nomeCliente = Console.ReadLine();
//             Console.WriteLine("\nData de Nascimento (dd/mm/yyyy): ");
//             string dataNascimento = Console.ReadLine();
//             Console.WriteLine("\nC.P.F.: ");
//             string cpfCLiente = Console.ReadLine();
//             Console.WriteLine("\nDias P/ Devolução: ");
//             int diasDevolucao = Convert.ToInt32(Console.ReadLine());

//             ClienteController.CadastrarCliente(
//                 nomeCliente, 
//                 dataNascimento, 
//                 cpfCLiente, 
//                 diasDevolucao
//             );
//         }

//         /// <summary>
//         /// Listing customers
//         /// </summary>
//         public static void ListarClientes()
//         {
//             Console.WriteLine("=================[ LISTA DE CLIENTES ]=================");
//             ClienteController.GetClientes().ForEach(cliente => Console.WriteLine(cliente));
//         }

//         /// <summary>
//         /// Consulting a customer by ID (LINQ)
//         /// </summary>
//         public static void ConsultarCliente()
//         {
//             Console.WriteLine("Digite o ID do Cliente: ");
//             int idCliente = Convert.ToInt32(Console.ReadLine());
            

//             try 
//             {
//                 ClienteModels cliente =
//                 (from cliente1 in ClienteController.GetClientes()
//                  where cliente1.IdCliente == idCliente
//                  select cliente1).First();


//                 Console.WriteLine("=================[ CONSULTA CLIENTE ]==================");
//                 Console.WriteLine(cliente.ToString());
//             }
//             catch
//             {
//                 Console.WriteLine("==> CLIENTE NÃO EXISTE!");
//             }
//         }
//     }
// }