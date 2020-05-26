using System;
using Models;
using System.Linq;
using Controllers;
using DbRespositorie;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class LocacaoModels
    {
       

        
        [Key] 
        public int IdLocacao { get; set; }
        
        public ClienteModels Cliente { get; set; }
        
        [ForeignKey("clientes")] 
        public int IdCliente { get; set; }
        
        [Required] 
        public DateTime DataLocacao { get; set; }

       
        public List<FilmeModels> filmes = new List<FilmeModels>();

        public LocacaoModels(ClienteModels cliente, DateTime dataLocacao)
        {
            IdCliente = cliente.IdCliente;
            DataLocacao = dataLocacao;
            filmes = new List<FilmeModels>();
            cliente.AdicionarLocacao(this);

            var db = new Context();
            db.Locacoes.Add(this);
            db.SaveChanges();
        }
      
        public LocacaoModels()
        {

        }

               public void AdicionarFilme(FilmeModels filme)
        {
            var db = new Context();
            LocacaoFilmeModels locacaoFilme = new LocacaoFilmeModels()
            {
                IdFilme = filme.IdFilme,
                IdLocacao = IdLocacao
            };

            db.LocacaoFilme.Add(locacaoFilme);
            db.SaveChanges();
        }

        
        public override string ToString()
        {
            var db = new Context();

            IEnumerable<int> filmes =
            from filme in db.LocacaoFilme
            where filme.IdLocacao == IdLocacao
            select filme.IdFilme;

            ClienteModels cliente = ClienteModels.GetCliente(IdCliente);

            string retorno = cliente +
                $"\n----------------===[ DADOS LOCAÇÃO ]===----------------\n" +
                $"-> DATA DE LOCAÇÃO: {DataLocacao.ToString("dd/MM/yyyy")}\n" +
                $"-> DATA DE DEVOLUÇÃO: {LocacaoController.CalculoDataDevolucao(DataLocacao, cliente).ToString("dd/MM/yyyy")}\n" +
                $"-> QTDE TOTAL DE FILMES: {filmes.Count()}\n";


            double ValorTotal = 0;
            string strFilmes = "";

            if (filmes.Count() > 0)
            {
                foreach (int id in filmes)
                {
                    FilmeModels filme = FilmeModels.GetFilme(id);
                    strFilmes += filme;
                    ValorTotal += filme.ValorLocacaoFilme;
                }
            }
            else
            {
                strFilmes += "    NÃO HÁ FILMES!";
            }

            retorno += $"-> PREÇO TOTAL DAS LOCAÇÕES: R$ {ValorTotal.ToString("C2")}\n" +
            $"-------------------------------------------------------\n\n" +
            $"===================[ FILMES LOCADOS ]==================\n";
    
            return retorno + strFilmes +

            $"=======================================================\n";
        }

       
        public static List<LocacaoModels> GetLocacoes()
        {
            var db = new Context();
            return db.Locacoes.ToList();
        }

               public static LocacaoModels GetLocacao(int idLocacao)
        {
            var db = new Context();
            return (from locacao in db.Locacoes
                    where locacao.IdLocacao == idLocacao
                    select locacao).First();
        }
    }
}