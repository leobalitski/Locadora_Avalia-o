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
    public class ConsultaLocacao : Form 
    {
        PictureBox pb_Consulta;
        Label lbl_NomeLocacao;
        Label lbl_NomeFilme;
        RichTextBox rtxt_NomeLocacao;
        RichTextBox rtxt_NomeFilme;
        ListView lv_ListaLocacoes;
        GroupBox gb_ConsultaLocacao;
        GroupBox gb_ListaLocacoes;
        Button btn_ListaConsulta;
        Button btn_Cancelar; 
        Form parent;

          
        public ConsultaLocacao (Form parent) {
            this.BackColor = ColorTranslator.FromHtml("#898989");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 500);
            this.parent = parent;

         
            pb_Consulta = new PictureBox();
            pb_Consulta.Location = new Point (10, 10);    
            pb_Consulta.Size = new Size(480 , 100);
            pb_Consulta.ClientSize = new Size (460 , 60);
            pb_Consulta.BackColor = Color.Black;
            pb_Consulta.Load ("./Views/assets/senac.jpg");
            pb_Consulta.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb_Consulta);

            lbl_NomeLocacao = new Label ();
            lbl_NomeLocacao.Text = "Nome do Locacao :";
            lbl_NomeLocacao.Location = new Point (20, 100);
            lbl_NomeLocacao.AutoSize = true;            
            this.Controls.Add (lbl_NomeLocacao);

            lbl_NomeFilme = new Label ();
            lbl_NomeFilme.Text = "Nome do Filme :";
            lbl_NomeFilme.Location = new Point (20, 140);
            lbl_NomeFilme.AutoSize = true;            
            this.Controls.Add (lbl_NomeFilme);

            rtxt_NomeLocacao = new RichTextBox ();
            rtxt_NomeLocacao.SelectionFont  = new Font("verdana", 10, FontStyle.Bold);  
            rtxt_NomeLocacao.SelectionColor = System.Drawing.Color.Black;
            rtxt_NomeLocacao.Location = new Point (150, 100);
            rtxt_NomeLocacao.Size = new Size (300, 20);
            this.Controls.Add (rtxt_NomeLocacao);
            rtxt_NomeLocacao.KeyPress += new KeyPressEventHandler(keypressed1);

            rtxt_NomeFilme = new RichTextBox ();
            rtxt_NomeFilme.SelectionFont  = new Font("verdana", 10, FontStyle.Bold);  
            rtxt_NomeFilme.SelectionColor = System.Drawing.Color.Black;
            rtxt_NomeFilme.Location = new Point (150, 140);
            rtxt_NomeFilme.Size = new Size (300, 20);
            this.Controls.Add (rtxt_NomeFilme);
            rtxt_NomeFilme.KeyPress += new KeyPressEventHandler(keypressed2);

           
            lv_ListaLocacoes = new ListView();
            lv_ListaLocacoes.Location = new Point(30, 210);
            lv_ListaLocacoes.Size = new Size(420, 140);
            lv_ListaLocacoes.View = View.Details;
           
            foreach (LocacaoModels locacao in LocacaoController.GetLocacoes())
            {
                ListViewItem lv_ListaLocacao = new ListViewItem(locacao.IdLocacao.ToString());
                
                lv_ListaLocacoes.Items.Add(lv_ListaLocacao);
            }
            lv_ListaLocacoes.FullRowSelect = true;
            lv_ListaLocacoes.GridLines = true;
            lv_ListaLocacoes.AllowColumnReorder = true;
            lv_ListaLocacoes.Sorting = SortOrder.Ascending;
            lv_ListaLocacoes.Columns.Add("ID", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Locatário", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Qtde Filmes", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Total", -2, HorizontalAlignment.Center);
            lv_ListaLocacoes.Columns.Add("Pagto", -2, HorizontalAlignment.Center);
            this.Controls.Add(lv_ListaLocacoes);

            Task t = new Task(new Action(() => { RefreshForm(); }));
            t.Start();

            
            gb_ConsultaLocacao = new GroupBox();    
            gb_ConsultaLocacao.Location = new Point(10, 80);        
            gb_ConsultaLocacao.Size = new Size(460, 100);            
            gb_ConsultaLocacao.Text= "BUSCAR LOCAÇÃO";
            gb_ConsultaLocacao.ForeColor = ColorTranslator.FromHtml("#aa9270");
            this.Controls.Add(gb_ConsultaLocacao);
            
            gb_ListaLocacoes = new GroupBox();    
            gb_ListaLocacoes.Location = new Point(10, 190);        
            gb_ListaLocacoes.Size = new Size(460, 170);            
            gb_ListaLocacoes.Text= "LISTA DE FILMES";
            gb_ListaLocacoes.ForeColor = ColorTranslator.FromHtml("#aa9270");
            this.Controls.Add(gb_ListaLocacoes);

            btn_ListaConsulta = new Button ();
            btn_ListaConsulta.Location = new Point (80, 390);
            btn_ListaConsulta.Size = new Size (150, 40);            
            btn_ListaConsulta.Text = "CONSULTA";
            this.btn_ListaConsulta.BackColor = ColorTranslator.FromHtml("#aa9270");
            this.btn_ListaConsulta.ForeColor = Color.Black; 
            btn_ListaConsulta.Click += new EventHandler (this.btn_ListaConsultaClick);
            this.Controls.Add(btn_ListaConsulta);

            btn_Cancelar = new Button ();
            btn_Cancelar.Location = new Point (260, 390);
            btn_Cancelar.Size = new Size (150, 40);           
            btn_Cancelar.Text = "CANCELAR";
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
        
        }

        private void keypressed2(Object o, KeyPressEventArgs e)
        {
           
        }

        private void btn_ListaConsultaClick (object sender, EventArgs e) 
        {
            string IdLocacao = this.lv_ListaLocacoes.SelectedItems[0].Text;
            LocacaoModels locacao = LocacaoController.GetLocacao(Int32.Parse(IdLocacao));
            LocacaoDetalhe btn_ListaConsultaClick = new LocacaoDetalhe(this, locacao);
            btn_ListaConsultaClick.Show();
        }

        private void btn_CancelarClick (object sender, EventArgs e) 
        {
            MessageBox.Show("CONCLUÍDO!");
            this.Close();
            this.parent.Show();  
        }
    }
}