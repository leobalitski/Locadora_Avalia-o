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
    public class ListaFilme : Form 
    {
        PictureBox pb_Lista;
        ListView lv_ListaFilmes;
        GroupBox gb_ListaFilmes;
        Button btn_ListaSair;
        Form parent;

      
        public ListaFilme (Form parent)
        {
            this.BackColor = ColorTranslator.FromHtml("#898989");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(600, 640);
            this.parent = parent;

           
            pb_Lista = new PictureBox();
            pb_Lista.Location = new Point (60, 10);    
            pb_Lista.Size = new Size(580 , 100);
            pb_Lista.ClientSize = new Size (460 , 60);
            pb_Lista.BackColor = Color.Black;
            pb_Lista.Load ("./Views/assets/senac.jpg");
            pb_Lista.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb_Lista); 

           
            lv_ListaFilmes = new ListView();
            lv_ListaFilmes.Location = new Point(20, 100);
            lv_ListaFilmes.Size = new Size(540, 400);
            lv_ListaFilmes.View = Details;
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
            lv_ListaFilmes.Sorting = SortOrder.Ascending;
            lv_ListaFilmes.Columns.Add("ID", -2, HorizontalAlignment.Center);
            lv_ListaFilmes.Columns.Add("Título", -2, HorizontalAlignment.Left);
            lv_ListaFilmes.Columns.Add("Data Lançamento", -2, HorizontalAlignment.Center);
            lv_ListaFilmes.Columns.Add("Valor", -2, HorizontalAlignment.Center);
            lv_ListaFilmes.Columns.Add("Estoque", -2, HorizontalAlignment.Center);
            lv_ListaFilmes.Columns.Add("Sinopse", -2, HorizontalAlignment.Left);
            this.Controls.Add(lv_ListaFilmes);

       
            gb_ListaFilmes = new GroupBox();
            gb_ListaFilmes.Location = new Point(10, 80);
            gb_ListaFilmes.Size = new Size(560, 430);
            gb_ListaFilmes.Text= "LISTA DE FILMES";
            gb_ListaFilmes.ForeColor = ColorTranslator.FromHtml("#aa9270");
            this.Controls.Add(gb_ListaFilmes); 

           
            btn_ListaSair = new Button();
            btn_ListaSair.Location = new Point(200, 530);
            btn_ListaSair.Size = new Size(180, 50);            
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