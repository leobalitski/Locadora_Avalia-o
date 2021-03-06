using System;
using Models;
using System.Collections.Generic;

namespace Controllers
{
    public class LocacaoController
    {
              public static LocacaoModels addLocacao(ClienteModels cliente)
        {
            return new LocacaoModels(cliente, DateTime.Now);
        }

        public static DateTime CalculoDataDevolucao(DateTime DtLocacao, ClienteModels Cliente)
        {
            return DtLocacao.AddDays(Cliente.DiasDevolucao);
        }

        public static List<LocacaoModels> GetLocacoes() 
        {
        return LocacaoModels.GetLocacoes();
        }
        public static LocacaoModels GetLocacao(int idLocacao)
        {
            return LocacaoModels.GetLocacao(idLocacao);
        }
    }
}