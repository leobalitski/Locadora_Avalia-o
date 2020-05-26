using System;
using Models;
using Controllers;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using static Locadora_MVC_LINQ_API_BD_IF.Program;

namespace Locadora_MVC_LINQ_API_BD_Interface 
{
    public class FilmeDetalhe : Form 
    {
       
        PictureBox pb_Detalhe;
        
        Label lbl_Titulo;  
        Label lbl_DataLancamento;      
        Label lbl_Sinopse;
        Label lbl_ValorFilme;
        Label lbl_QtdeFilme;
        GroupBox gb_FilmeDetalhe;
        Button btn_SairDetalhe;
        Form parent;
        int idFilme;
        FilmeModels FilmeX; 

        public FilmeDetalhe (Form parent, FilmeModels filme) 
        {
            
            this.BackColor = ColorTranslator.FromHtml("#898989");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 500);
            this.idFilme = filme.IdFilme;
            this.FilmeX = filme;
            this.parent = parent;

          
            pb_Detalhe = new PictureBox();
            pb_Detalhe.Location = new Point (10, 10);    
            pb_Detalhe.Size = new Size(480 , 100);
            pb_Detalhe.ClientSize = new Size (460 , 60);
            pb_Detalhe.BackColor = Color.Black;
            pb_Detalhe.Load ("./Views/assets/senac.jpg");
            pb_Detalhe.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb_Detalhe);         
            
            lbl_Titulo = new Label ();
            lbl_Titulo.Text = "Título: " + filme.Titulo;
            lbl_Titulo.Location = new Point (20, 100);
            lbl_Titulo.AutoSize = true;
            lbl_Titulo.Font = new Font(lbl_Titulo.Font, FontStyle.Bold);
            this.lbl_Titulo.ForeColor = Color.White;
            this.Controls.Add(lbl_Titulo);

            lbl_DataLancamento = new Label ();
            lbl_DataLancamento.Text = "Data de Lançamento: " + filme.DataLancamento.ToString();
            lbl_DataLancamento.Location = new Point (20, 140);            
            lbl_DataLancamento.AutoSize = true;
            lbl_DataLancamento.Font = new Font(lbl_DataLancamento.Font, FontStyle.Bold);
            this.lbl_DataLancamento.ForeColor = Color.White;
            this.Controls.Add(lbl_DataLancamento);

            lbl_Sinopse = new Label ();
            lbl_Sinopse.Text = "Sinopse: " + filme.Sinopse;
            lbl_Sinopse.Location = new Point (20, 180);
            lbl_Sinopse.Size = new Size(440, 120);
            lbl_Sinopse.Font = new Font(lbl_Sinopse.Font, FontStyle.Bold);
            this.lbl_Sinopse.ForeColor = Color.White;
            this.Controls.Add(lbl_Sinopse);

            lbl_ValorFilme = new Label ();
            lbl_ValorFilme.Text = "Preço Aluguel: " + filme.ValorLocacaoFilme.ToString();
            lbl_ValorFilme.Location = new Point (20, 310);
            lbl_ValorFilme.AutoSize = true;
            lbl_ValorFilme.Font = new Font(lbl_ValorFilme.Font, FontStyle.Bold);
            this.lbl_ValorFilme.ForeColor = Color.White;
            this.Controls.Add(lbl_ValorFilme);

            lbl_QtdeFilme = new Label ();
            lbl_QtdeFilme.Text = "Quantidade Estoque: " + filme.EstoqueFilme.ToString();
            lbl_QtdeFilme.Location = new Point (20, 350);
            lbl_QtdeFilme.AutoSize = true;
            lbl_QtdeFilme.Font = new Font(lbl_QtdeFilme.Font, FontStyle.Bold);
            this.lbl_QtdeFilme.ForeColor = Color.White;
            this.Controls.Add(lbl_QtdeFilme);

            
            gb_FilmeDetalhe = new GroupBox();
            gb_FilmeDetalhe.Location = new Point(10, 80);
            gb_FilmeDetalhe.Size = new Size(460, 300);
            gb_FilmeDetalhe.Text= "CONSULTA FILMES";
            gb_FilmeDetalhe.ForeColor = ColorTranslator.FromHtml("#aa9270");
            this.Controls.Add(gb_FilmeDetalhe);

            btn_SairDetalhe = new Button ();
            btn_SairDetalhe.Text = "SAIR";
            btn_SairDetalhe.Location = new Point (160, 400);
            btn_SairDetalhe.Size = new Size (150, 40);            
            this.btn_SairDetalhe.BackColor = ColorTranslator.FromHtml("#aa9270");
            this.btn_SairDetalhe.ForeColor = Color.Black;         
            btn_SairDetalhe.Click += new EventHandler (this.btn_SairDetalheClick);
            this.Controls.Add(btn_SairDetalhe);
        }

        private void btn_SairDetalheClick(object sender, EventArgs e)
        {
            MessageBox.Show ("CANCELADO!");
            this.Close ();
            this.parent.Show ();    
        }
    }
}