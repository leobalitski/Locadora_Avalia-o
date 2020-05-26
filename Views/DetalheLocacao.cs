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
    public class LocacaoDetalhe : Form 
    {
        //Image for main window
        PictureBox pb_Detalhe;
        // Orientation Labels
        Label lbl_IdCliente;  
        Label lbl_NomeCliente;      
        Label lbl_DataNascimento;
        Label lbl_CpfCliente;
        Label lbl_IdLocacao;
        Label lbl_DataLocacao;
        Label lbl_DataDevolucao;
        Label lbl_QtdeFilmes;
        Label lbl_ValorTotal;
        Label lbl_Filmes;
        GroupBox gb_DadosCliente;
        GroupBox gb_DadosLocacao;
        GroupBox gb_DadosFIlmes;
        Button btn_SairDetalhe;
        Form parent;

      

        int idLocacao;
        LocacaoModels LocacaoX; 

        public LocacaoDetalhe (Form parent, LocacaoModels Locacao) 
        {
            
            this.BackColor = ColorTranslator.FromHtml("#898989");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(600, 640);
            this.idLocacao = Locacao.IdLocacao;
            this.LocacaoX = Locacao;
            this.parent = parent;

           
            pb_Detalhe = new PictureBox();
            pb_Detalhe.Location = new Point (10, 10);    
            pb_Detalhe.Size = new Size(180 , 100);
            pb_Detalhe.ClientSize = new Size (560 , 60);
            pb_Detalhe.BackColor = Color.Black;
            pb_Detalhe.Load ("./Views/assets/senac.jpg");
            pb_Detalhe.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb_Detalhe);         
            
            lbl_IdCliente = new Label ();
            lbl_IdCliente.Text = "ID do Cliente: "; 
            lbl_IdCliente.Location = new Point (20, 110);
            lbl_IdCliente.AutoSize = true;
            lbl_IdCliente.Font = new Font(lbl_IdCliente.Font, FontStyle.Bold);
            this.lbl_IdCliente.ForeColor = Color.White;
            this.Controls.Add(lbl_IdCliente);

            lbl_NomeCliente = new Label ();
            lbl_NomeCliente.Text = "Nome: "; 
            lbl_NomeCliente.Location = new Point (20, 150);            
            lbl_NomeCliente.AutoSize = true;
            lbl_NomeCliente.Font = new Font(lbl_NomeCliente.Font, FontStyle.Bold);
            this.lbl_NomeCliente.ForeColor = Color.White;
            this.Controls.Add(lbl_NomeCliente);

            lbl_DataNascimento = new Label ();
            lbl_DataNascimento.Text = "Data de Nascimento: ";
            lbl_DataNascimento.Location = new Point (20, 190);
            lbl_DataNascimento.AutoSize = true;
            lbl_DataNascimento.Font = new Font(lbl_DataNascimento.Font, FontStyle.Bold);
            this.lbl_DataNascimento.ForeColor = Color.White;
            this.Controls.Add(lbl_DataNascimento);

            lbl_CpfCliente = new Label ();
            lbl_CpfCliente.Text = "CPF: "; 
            lbl_CpfCliente.AutoSize = true;
            lbl_CpfCliente.Font = new Font(lbl_CpfCliente.Font, FontStyle.Bold);
            this.lbl_CpfCliente.ForeColor = Color.White;
            this.Controls.Add(lbl_CpfCliente);

            lbl_IdLocacao = new Label ();
            lbl_IdLocacao.Text = "ID da Locação: "; 
            lbl_IdLocacao.Location = new Point (20, 270);
            lbl_IdLocacao.AutoSize = true;
            lbl_IdLocacao.Font = new Font(lbl_IdLocacao.Font, FontStyle.Bold);
            this.lbl_IdLocacao.ForeColor = Color.White;
            this.Controls.Add(lbl_IdLocacao);

            lbl_DataLocacao = new Label ();
            lbl_DataLocacao.Text = "Data da Locação: "; 
            lbl_DataLocacao.Location = new Point (20, 310);
            lbl_DataLocacao.AutoSize = true;
            lbl_DataLocacao.Font = new Font(lbl_DataLocacao.Font, FontStyle.Bold);
            this.lbl_DataLocacao.ForeColor = Color.White;
            this.Controls.Add(lbl_DataLocacao);

            lbl_DataDevolucao = new Label ();
            lbl_DataDevolucao.Text = "Data de Devolução: "; 
            lbl_DataDevolucao.Location = new Point (300, 310);
            lbl_DataDevolucao.AutoSize = true;
            lbl_DataDevolucao.Font = new Font(lbl_DataDevolucao.Font, FontStyle.Bold);
            this.lbl_DataDevolucao.ForeColor = Color.White;
            this.Controls.Add(lbl_DataDevolucao);

            lbl_QtdeFilmes = new Label ();
            lbl_QtdeFilmes.Text = "Quantidade de Filmes: "; 
            lbl_QtdeFilmes.Location = new Point (20, 350);
            lbl_QtdeFilmes.AutoSize = true;
            lbl_QtdeFilmes.Font = new Font(lbl_QtdeFilmes.Font, FontStyle.Bold);
            this.lbl_QtdeFilmes.ForeColor = Color.White;
            this.Controls.Add(lbl_QtdeFilmes);

            lbl_ValorTotal = new Label ();
            lbl_ValorTotal.Text = "Total da Locação: "; 
            lbl_ValorTotal.Location = new Point (300, 350);
            lbl_ValorTotal.AutoSize = true;
            lbl_ValorTotal.Font = new Font(lbl_ValorTotal.Font, FontStyle.Bold);
            this.lbl_ValorTotal.ForeColor = Color.White;
            this.Controls.Add(lbl_ValorTotal);

            lbl_Filmes = new Label ();
            lbl_Filmes.Text = "Filmes Locados: "; 
            lbl_Filmes.Location = new Point (20, 430);
            lbl_Filmes.AutoSize = true;
            lbl_Filmes.Font = new Font(lbl_Filmes.Font, FontStyle.Bold);
            this.lbl_Filmes.ForeColor = Color.White;
            this.Controls.Add(lbl_Filmes);

            
            gb_DadosCliente = new GroupBox();
            gb_DadosCliente.Location = new Point(10, 80);
            gb_DadosCliente.Size = new Size(560, 150);
            gb_DadosCliente.Text= "DADOS CLIENTE";
            gb_DadosCliente.ForeColor = ColorTranslator.FromHtml("#aa9270");
            this.Controls.Add(gb_DadosCliente);
            
            gb_DadosLocacao = new GroupBox();
            gb_DadosLocacao.Location = new Point(10, 240);
            gb_DadosLocacao.Size = new Size(560, 150);
            gb_DadosLocacao.Text= "DADOS LOCAÇÃO";
            gb_DadosLocacao.ForeColor = ColorTranslator.FromHtml("#aa9270");
            this.Controls.Add(gb_DadosLocacao);
            
            gb_DadosFIlmes = new GroupBox();
            gb_DadosFIlmes.Location = new Point(10, 400);
            gb_DadosFIlmes.Size = new Size(560, 120);
            gb_DadosFIlmes.Text= "LISTA DE LOCAÇÕES";
            gb_DadosFIlmes.ForeColor = ColorTranslator.FromHtml("#aa9270");
            this.Controls.Add(gb_DadosFIlmes); 

            btn_SairDetalhe = new Button ();
            btn_SairDetalhe.Text = "SAIR";
            btn_SairDetalhe.Location = new Point (215, 535);
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