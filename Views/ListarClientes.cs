using System;
using Models;
using Controllers;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using static System.Windows.Forms.View;
using static Locadora_MVC_LINQ_API_BD_IF.Program;

namespace Locadora_MVC_LINQ_API_BD_Interface 
{
    public class ListaCliente : Form 
    {
        PictureBox pb_Lista;
        ListView lv_ListaClientes;
        GroupBox gb_ListaClientes;
        Button btn_ListaSair;
        Form parent;

        

        public ListaCliente (Form parent) 
        {
            this.BackColor = ColorTranslator.FromHtml("#898989");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 640);
            this.parent = parent;

            
            pb_Lista = new PictureBox();
            pb_Lista.Location = new Point (10, 10);    
            pb_Lista.Size = new Size(480 , 100);
            pb_Lista.ClientSize = new Size (460 , 60);
            pb_Lista.BackColor = Color.Black;
            pb_Lista.Load ("./Views/assets/senac.jpg");
            pb_Lista.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb_Lista); 

            lv_ListaClientes = new ListView();
            lv_ListaClientes.Location = new Point(20, 100);
            lv_ListaClientes.Size = new Size(440, 400);
            lv_ListaClientes.View = Details;
            ListViewItem clientes = new ListViewItem();
            List<ClienteModels> clientesLista = ClienteController.GetClientes();
            foreach (var cliente in clientesLista)
            {
                ListViewItem lv_ListaCliente = new ListViewItem(cliente.IdCliente.ToString());                
                lv_ListaCliente.SubItems.Add(cliente.NomeCliente);
                lv_ListaCliente.SubItems.Add(cliente.DataNascimento);
                lv_ListaCliente.SubItems.Add(cliente.CpfCliente);
                lv_ListaCliente.SubItems.Add(cliente.DiasDevolucao.ToString());
                lv_ListaClientes.Items.Add(lv_ListaCliente);
            }
            lv_ListaClientes.FullRowSelect = true;
            lv_ListaClientes.GridLines = true;
            lv_ListaClientes.AllowColumnReorder = true;
            lv_ListaClientes.Sorting = SortOrder.Ascending;
            lv_ListaClientes.Columns.Add("ID", -2, HorizontalAlignment.Center);
            lv_ListaClientes.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            lv_ListaClientes.Columns.Add("Data Nascimento", -2, HorizontalAlignment.Center);
            lv_ListaClientes.Columns.Add("CPF", -2, HorizontalAlignment.Center);
            lv_ListaClientes.Columns.Add("Dias Devolução", -2, HorizontalAlignment.Center);
            this.Controls.Add(lv_ListaClientes);

            
            gb_ListaClientes = new GroupBox();
            gb_ListaClientes.Location = new Point(10, 80);
            gb_ListaClientes.Size = new Size(460, 430);
            gb_ListaClientes.Text= "LISTA DE CLIENTES";
            gb_ListaClientes.ForeColor = ColorTranslator.FromHtml("#aa9270");
            this.Controls.Add(gb_ListaClientes); 

         
            btn_ListaSair = new Button();
            btn_ListaSair.Location = new Point(160, 530);
            btn_ListaSair.Size = new Size(150, 50);            
            btn_ListaSair.Text = "SAIR";
            this.btn_ListaSair.BackColor = ColorTranslator.FromHtml("#aa9270");
            this.btn_ListaSair.ForeColor = Color.Black;            
            btn_ListaSair.Click += new EventHandler(btn_ListaSairClick);
            this.Controls.Add(btn_ListaSair);
        }

        private void btn_ListaSairClick (object sender, EventArgs e) 
        {
            MessageBox.Show ("CONCLUÍDO!");
            this.Close ();
            this.parent.Show ();
        }
    }
}