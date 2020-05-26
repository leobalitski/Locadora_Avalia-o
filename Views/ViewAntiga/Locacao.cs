// using System;
// using Models;
// using Controllers;
// using System.Linq;
// using System.Collections;
// using System.Collections.Generic;

// namespace View
// {
//     public class LocacaoView
//     {
//         /// <summary>
//         /// Listing rentals
//         /// </summary>
//         public static void ListarLocacao()
//         {
//             Console.WriteLine("\n===================[ LISTA LOCAÇÕES ]==================");
//             List<LocacaoModels> locacoes = LocacaoController.GetLocacao();

//             locacoes.ForEach(locacao => Console.WriteLine(locacao));
//         }

//         /// <summary>
//         /// Creating rentals by Customer ID and Movies ID
//         /// </summary>
//         public static void CadastrarLocacao()
//         {
//             Console.WriteLine("---===[ CADASTRO DA LOCAÇÃO ]===---");
//             List<ClienteModels> clientes = ClienteController.GetClientes();
//             List<FilmeModels> filmes = FilmeController.GetFilmes();

//             int idCliente = 0;

//             // Insert costumer by ID
//             Console.WriteLine("\nDigite o ID Cliente:");
//             idCliente = Convert.ToInt32(Console.ReadLine());

//             if (idCliente != 0)
//             {
//                 ClienteModels cliente = clientes.Find(cliente => cliente.IdCliente == idCliente);
//                 LocacaoModels locacao = LocacaoController.addLocacao(cliente);

//                 int idFilme = 0;

//                 // As long as IdFilm is not ZERO, it continues adding movies in rent                       
//                 do
//                 {
//                     Console.WriteLine("\nDigite o ID Filme: ");
//                     Console.WriteLine("DIGITE ZERO (0) P/ FINALIZAR!");
//                     idFilme = Convert.ToInt32(Console.ReadLine());

//                     if (idFilme != 0) // If movie ID is nonzero
//                     {
//                         FilmeModels filme = filmes.Find(filme => filme.IdFilme == idFilme);

//                         locacao.AdicionarFilme(filme); // Add movie in rent
//                     }
//                 } while (idFilme != 0); //Looping while movie ID is nonzero
//             }
//         }

//         /// <summary>
//         /// Consulting a rent by ID (LINQ)
//         /// </summary>
//         public static void ConsultarLocacao()
//         {
//             Console.WriteLine("Digite o ID da Locação: ");
//             int idLocacao = Convert.ToInt32(Console.ReadLine());

//             try
//             {
//                 LocacaoModels locacao =
//                 (from locacao1 in LocacaoController.GetLocacao()
//                  where locacao1.IdLocacao == idLocacao
//                  select locacao1).First();

//                 Console.WriteLine("\n=================[ CONSULTA LOCAÇÕES ]=================");
//                 Console.WriteLine(locacao.ToString());
//             }
//             catch
//             {
//                 Console.WriteLine("==> LOCAÇÃO NÃO EXISTE!");
//             }
//         }
//     }
// }