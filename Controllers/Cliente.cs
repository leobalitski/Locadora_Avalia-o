using System;
using Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Controllers
{

    public class ClienteController
    {

        /// <summary>
        /// Insert customer into the database
        /// </summary>
        public static void CadastrarCliente(
            string nomeCliente,
            int dataNascDia,
            int dataNascMes,
            int dataNascAno,
            string cpfCliente,
            int diasDevolucao
            )
            
        {
            string dataNascimento = "" + dataNascDia + "/" + dataNascMes + "/" + dataNascAno;
            DateTime dtNasc;
            try
            {                
                dtNasc = Convert.ToDateTime(dataNascimento);                
            }
            catch
            {
                Console.WriteLine("FORMATO INVÁLIDO!");
                dtNasc = DateTime.Now;
            }

            new ClienteModels(
                nomeCliente,
                dataNascimento,
                cpfCliente,
                diasDevolucao);
        }

        /// <summary>
        /// Access all customers
        /// </summary>
        public static List<ClienteModels> GetClientes() 
        {
        return ClienteModels.GetClientes();
        }

        public static ClienteModels GetCliente (int idCliente)
        {
            return ClienteModels.GetCliente(idCliente);
        }
    }
}