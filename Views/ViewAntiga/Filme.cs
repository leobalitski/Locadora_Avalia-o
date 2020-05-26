// using System;
// using Models;
// using Controllers;
// using System.Linq;

// namespace View
// {
//     public class FilmeView
//     {
//         /// <summary>
//         /// Creating movies
//         /// </summary>
//         public static void CadastrarFilme()
//         {
//             Console.WriteLine("---===[ CADASTRO DO FILME ]===---");
//             Console.WriteLine("Título: ");
//             string titulo = Console.ReadLine();
//             Console.WriteLine("\nData de Lançamento (dd/mm/yyyy): ");
//             string dataLancamento = Console.ReadLine();
//             Console.WriteLine("\nSinopse: ");
//             string sinopse = Console.ReadLine();
//             Console.WriteLine("\nValor para Locação: ");
//             double valorLocacaoFilme = Convert.ToDouble(Console.ReadLine());
//             Console.WriteLine("\nQuantidade em Estoque: ");
//             int estoqueFilme = Convert.ToInt32(Console.ReadLine());

//             FilmeController.CadastrarFilme(
//                 titulo,
//                 dataLancamento,
//                 sinopse,
//                 valorLocacaoFilme,
//                 estoqueFilme
//             );
//         }

//         /// <summary>
//         /// Listing movies
//         /// </summary>
//         public static void ListarFilmes()
//         {
//             Console.WriteLine("=====================[ LISTA DE FILMES ]=========================================================================================");
//             FilmeController.GetFilmes().ForEach(filme => Console.WriteLine(filme));
//         }

//         /// <summary>
//         /// Consulting a movie by ID (LINQ)
//         /// </summary>
//         public static void ConsultarFilme()
//         {
//             Console.WriteLine("Digite o ID do Filme: ");
//             int idFilme = Convert.ToInt32(Console.ReadLine());

//             try
//             {
//                 FilmeModels filme =
//                 (from filme1 in FilmeController.GetFilmes()
//                  where filme1.IdFilme == idFilme
//                  select filme1).First();

//                 Console.WriteLine("=====================[ CONSULTA FILMES ]=========================================================================================");
//                 Console.WriteLine(filme.ToString());
//             }
//             catch
//             {
//                 Console.WriteLine("==> FILME NÃO EXISTE!");
//             }
//         }
//     }
// }