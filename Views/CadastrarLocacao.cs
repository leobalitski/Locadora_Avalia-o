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
    public class CadastroLocacao : Form 
    {
        //Image for main window
        PictureBox pb_Cadastro;
        Label lbl_BuscaCliente;
        Label lbl_BuscaFilme;        
        RichTextBox rtxt_BuscaCliente;
        RichTextBox rtxt_BuscaFilme;
        ListView lv_ListaClientes;
        ListView lv_ListaFilmes;
        GroupBox gb_ListaCliente;
        GroupBox gb_ListaFilme;
        Button btn_Confirmar;
        Button btn_Cancelar;    
        Form parent;

        // GUIDE FOR LOCATION n SIZE (X Y) 
        // Location (X = Horizontal - Y = Vertical)
        // Size     (X = Largura    - Y = Altura)     

        public CadastroLocacao (Form parent)         
        {
            this.BackColor = ColorTranslator.FromHtml("#898989");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 580);
            this.parent = parent;

            // Image to Bloclbuster
            pb_Cadastro = new PictureBox();
            pb_Cadastro.Location = new Point (10, 10);    
            pb_Cadastro.Size = new Size(480 , 100);
            pb_Cadastro.ClientSize = new Size (460 , 60);
            pb_Cadastro.BackColor = Color.Black;
            pb_Cadastro.Load ("./Views/assets/senac.jpg");
            pb_Cadastro.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb_Cadastro); 

            lbl_BuscaCliente = new Label ();
            lbl_BuscaCliente.Text = "Busca Cliente :";
            lbl_BuscaCliente.Location = new Point (30, 80);
            lbl_BuscaCliente.AutoSize = true;            
            this.Controls.Add(lbl_BuscaCliente);  

            lbl_BuscaFilme = new Label ();
            lbl_BuscaFilme.Text = "Busca Filme :";
            lbl_BuscaFilme.Location = new Point (30, 270);
            lbl_BuscaFilme.AutoSize = true;            
            this.Controls.Add(lbl_BuscaFilme);          

            rtxt_BuscaCliente = new RichTextBox ();
            rtxt_BuscaCliente.SelectionFont = new Font("verdana", 10, FontStyle.Bold);  
            rtxt_BuscaCliente.SelectionColor = System.Drawing.Color.Black;
            rtxt_BuscaCliente.Location = new Point (150, 80);
            rtxt_BuscaCliente.Size = new Size (300, 20);
            this.Controls.Add(rtxt_BuscaCliente);
            rtxt_BuscaCliente.KeyPress += new KeyPressEventHandler(keypressed1);

            rtxt_BuscaFilme = new RichTextBox ();
            rtxt_BuscaFilme.SelectionFont = new Font("verdana", 10, FontStyle.Bold);  
            rtxt_BuscaFilme.SelectionColor = System.Drawing.Color.Black;
            rtxt_BuscaFilme.Location = new Point (150, 270);
            rtxt_BuscaFilme.Size = new Size (300, 20);            
            this.Controls.Add(rtxt_BuscaFilme);
            rtxt_BuscaFilme.KeyPress += new KeyPressEventHandler(keypressed2);

            // ListView
            lv_ListaClientes = new ListView();
            lv_ListaClientes.Location = new Point(40, 130);
            lv_ListaClientes.Size = new Size(400, 120);
            lv_ListaClientes.View = Details;
            List<ClienteModels> listaCliente = (from cliente in ClienteController.GetClientes() where cliente.NomeCliente.Contains(rtxt_BuscaCliente.Text) select cliente).ToList();
            ListViewItem clientes = new ListViewItem();
            foreach (ClienteModels cliente in ClienteController.GetClientes())
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
            lv_ListaClientes.Sorting = SortOrder.None;
            lv_ListaClientes.Columns.Add("ID", -2, HorizontalAlignment.Center);
            lv_ListaClientes.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            lv_ListaClientes.Columns.Add("Data Nascimento", -2, HorizontalAlignment.Center);
            lv_ListaClientes.Columns.Add("CPF", -2, HorizontalAlignment.Center);
            lv_ListaClientes.Columns.Add("Dias Devolução", -2, HorizontalAlignment.Center);
            this.Controls.Add(lv_ListaClientes);

            
            gb_ListaCliente = new GroupBox();
            gb_ListaCliente.Location = new Point(30, 110);
            gb_ListaCliente.Size = new Size(420, 150);
            gb_ListaCliente.Text= "LISTA DE CLIENTES";
            gb_ListaCliente.ForeColor = ColorTranslator.FromHtml("#aa9270");
            this.Controls.Add(gb_ListaCliente);            

            lv_ListaFilmes = new ListView();
            lv_ListaFilmes.Location = new Point(40, 320);
            lv_ListaFilmes.Size = new Size(400, 120);
            lv_ListaFilmes.View = Details;
            lv_ListaFilmes.CheckBoxes = true;
            List<FilmeModels> listaFilme = (from filme in FilmeController.GetFilmes() where filme.Titulo.Contains(rtxt_BuscaFilme.Text) select filme).ToList();
            ListViewItem filmes = new ListViewItem();
            foreach (FilmeModels filme in FilmeController.GetFilmes())
            {
                ListViewItem lv_ListaFilme = new ListViewItem(filme.IdFilme.ToString());
                lv_ListaFilme.SubItems.Add(filme.Titulo);
                lv_ListaFilme.SubItems.Add(filme.DataLancamento);
                lv_ListaFilme.SubItems.Add(filme.ValorLocacaoFilme.ToString());
                lv_ListaFilme.SubItems.Add(filme.EstoqueFilme.ToString());
                lv_ListaFilme.SubItems.Add(filme.Sinopse);
                lv_ListaFilmes.Items.Add(lv_ListaFilme);
            }
            lv_ListaFilmes.FullRowSelect = true;
            lv_ListaFilmes.GridLines = true;
            lv_ListaFilmes.AllowColumnReorder = true;
            lv_ListaFilmes.Sorting = SortOrder.None;
            lv_ListaFilmes.Columns.Add("ID", -2, HorizontalAlignment.Center);
            lv_ListaFilmes.Columns.Add("Título", -2, HorizontalAlignment.Left);
            lv_ListaFilmes.Columns.Add("Data Lançamento", -2, HorizontalAlignment.Center);
            lv_ListaFilmes.Columns.Add("Preço", -2, HorizontalAlignment.Center);
            lv_ListaFilmes.Columns.Add("Estoque", -2, HorizontalAlignment.Center);
            this.Controls.Add(lv_ListaFilmes);

             Task t = new Task(new Action(() => { RefreshForm(); }));
            t.Start();

          
            gb_ListaFilme = new GroupBox();    
            gb_ListaFilme.Location = new Point(30, 300);        
            gb_ListaFilme.Size = new Size(420, 150);            
            gb_ListaFilme.Text= "LISTA DE FILMES";
            gb_ListaFilme.ForeColor = ColorTranslator.FromHtml("#aa9270");
            this.Controls.Add(gb_ListaFilme);

            btn_Confirmar = new Button ();
            btn_Confirmar.Text = "CONFIRMAR";
            btn_Confirmar.Location = new Point (80, 470);
            btn_Confirmar.Size = new Size (150, 40);
            this.btn_Confirmar.BackColor = ColorTranslator.FromHtml("#aa9270");
            this.btn_Confirmar.ForeColor = Color.Black;          
            btn_Confirmar.Click += new EventHandler (this.btn_ConfirmarClick);            
            this.Controls.Add(btn_Confirmar);

            btn_Cancelar = new Button ();
            btn_Cancelar.Text = "CANCELAR";
            btn_Cancelar.Location = new Point (260, 470);
            btn_Cancelar.Size = new Size (150, 40);  
            this.btn_Cancelar.BackColor = ColorTranslator.FromHtml("#aa9270");
            this.btn_Cancelar.ForeColor = Color.Black;          
            btn_Cancelar.Click += new EventHandler (this.btn_CancelarClick);
            this.Controls.Add(btn_Cancelar);
        }

       public void RefreshForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(this.RefreshForm));
            }
            Application.DoEvents();
        }

        private void keypressed1(Object o, KeyPressEventArgs e)
        {
            lv_ListaClientes.Items.Clear();
            List<ClienteModels> listaCliente = (from cliente in ClienteController.GetClientes() where cliente.NomeCliente.Contains(rtxt_BuscaCliente.Text, StringComparison.OrdinalIgnoreCase) select cliente).ToList();
            ListViewItem clientes = new ListViewItem();
            foreach (ClienteModels cliente in listaCliente)
            {
                ListViewItem lv_ListaCliente = new ListViewItem(cliente.IdCliente.ToString());
                lv_ListaCliente.SubItems.Add(cliente.NomeCliente);
                lv_ListaCliente.SubItems.Add(cliente.DataNascimento);
                lv_ListaCliente.SubItems.Add(cliente.CpfCliente);
                lv_ListaCliente.SubItems.Add(cliente.DiasDevolucao.ToString());
                lv_ListaClientes.Items.Add(lv_ListaCliente);
            }
            this.Refresh();
            Application.DoEvents();
        }

        private void keypressed2(Object o, KeyPressEventArgs e)
        {
            lv_ListaFilmes.Items.Clear();
            List<FilmeModels> listaFilme = (from filme in FilmeController.GetFilmes() where filme.Titulo.Contains(rtxt_BuscaFilme.Text, StringComparison.OrdinalIgnoreCase) select filme).ToList();
            ListViewItem filmes = new ListViewItem();
            foreach (FilmeModels filme in listaFilme)
            {
                ListViewItem lv_ListaFilme = new ListViewItem(filme.IdFilme.ToString());
                lv_ListaFilme.SubItems.Add(filme.Titulo);
                lv_ListaFilme.SubItems.Add(filme.DataLancamento);
                lv_ListaFilme.SubItems.Add(filme.Sinopse);
                lv_ListaFilme.SubItems.Add(filme.ValorLocacaoFilme.ToString());
                lv_ListaFilme.SubItems.Add(filme.EstoqueFilme.ToString());
                lv_ListaFilmes.Items.Add(lv_ListaFilme);
            }
            this.Refresh();
            Application.DoEvents();
        }

        private void btn_ConfirmarClick (object sender, EventArgs e) {
            MessageBox.Show (
                $"IdCliente.:> {rtxt_BuscaCliente.Text}\n" +
                $"IdFilme.:> {rtxt_BuscaFilme.Text}\n",
                "Locacao",
                MessageBoxButtons.OK
                
            );
        }

        private void btn_CancelarClick (object sender, EventArgs e) 
        {
            MessageBox.Show ("CANCELADO!");
            this.Close ();
            this.parent.Show ();
        }        
    }
}