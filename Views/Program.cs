using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Locadora_MVC_LINQ_API_BD_Interface;

namespace Locadora_MVC_LINQ_API_BD_IF
{
    static class Program
    {
       
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TelaInicial());
        }
        public class TelaInicial : Form 
        {
            
            PictureBox pb_Menu;
            GroupBox gb_Cliente;
            GroupBox gb_Filme;
            GroupBox gb_Locaçao;
            Button btn_CadastroCliente;
            Button btn_ConsultaCliente;
            Button btn_ListaClientes;
            Button btn_CadastroFilme;
            Button btn_ConsultaFilme;
            Button btn_ListaFilmes;
            Button btn_CadastroLocacao;
            Button btn_ConsultaLocacao;
            Button btn_ListaLocacoes;
            Button btn_MenuSair;

        public TelaInicial(){
            
            this.Text = "BLOCKBUSTER - SENAC 2020";            
            this.BackColor = ColorTranslator.FromHtml("#898989");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(600,560);
 
            pb_Menu = new PictureBox();
            pb_Menu.Location = new Point (10, 10);    
            pb_Menu.Size = new Size(560 , 100);
            pb_Menu.ClientSize = new Size (560 , 120);
            pb_Menu.BackColor = Color.Goldenrod;
            pb_Menu.Load ("./Views/assets/senac.jpg");
            pb_Menu.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(pb_Menu);

                    
            btn_CadastroCliente = new Button();            
            btn_CadastroCliente.Location = new Point(40, 160);
            btn_CadastroCliente.Size = new Size(200, 30);
            btn_CadastroCliente.Text = "CADASTRO DO CLIENTE";            
            this.btn_CadastroCliente.BackColor = ColorTranslator.FromHtml("#aa9270");
            this.btn_CadastroCliente.ForeColor = Color.Black;
            this.Controls.Add(btn_CadastroCliente);
            btn_CadastroCliente.Click += new EventHandler(btn_CadastroClienteClick);

            
            btn_ConsultaCliente = new Button();
            btn_ConsultaCliente.Location = new Point(40, 200);
            btn_ConsultaCliente.Size = new Size(200, 30);
            btn_ConsultaCliente.Text = "CONSULTA CLIENTE";
            this.btn_ConsultaCliente.BackColor = ColorTranslator.FromHtml("#aa9270");
            this.btn_ConsultaCliente.ForeColor = Color.Black;
            this.Controls.Add(btn_ConsultaCliente);
            btn_ConsultaCliente.Click += new EventHandler(btn_ConsultaClienteClick);

            
            btn_ListaClientes = new Button();
            btn_ListaClientes.Location = new Point(40, 240);
            btn_ListaClientes.Size = new Size(200, 30);            
            btn_ListaClientes.Text = "LISTA DE CLIENTES";
            this.btn_ListaClientes.BackColor = ColorTranslator.FromHtml("#aa9270");
            this.btn_ListaClientes.ForeColor = Color.Black;
            this.Controls.Add(btn_ListaClientes);
            btn_ListaClientes.Click += new EventHandler(btn_ListaClientesClick);

            
            gb_Cliente = new GroupBox();    
            gb_Cliente.Location = new Point(25, 135);        
            gb_Cliente.Size = new Size(230, 150);            
            gb_Cliente.Text= "CLIENTE";
            gb_Cliente.ForeColor = ColorTranslator.FromHtml("#dfb841");
            this.Controls.Add(gb_Cliente);

          
            btn_CadastroFilme = new Button();
            btn_CadastroFilme.Location = new Point(350, 160);
            btn_CadastroFilme.Size = new Size(200, 30);
            btn_CadastroFilme.Text = "CADASTRO DO FILME";
            this.btn_CadastroFilme.BackColor = ColorTranslator.FromHtml("#aa9270");
            this.btn_CadastroFilme.ForeColor = Color.Black;
            this.Controls.Add(btn_CadastroFilme);
            btn_CadastroFilme.Click += new EventHandler(btn_CadastroFilmeClick);

          
            btn_ConsultaFilme = new Button();            
            btn_ConsultaFilme.Location = new Point(350, 200);
            btn_ConsultaFilme.Size = new Size(200, 30);
            btn_ConsultaFilme.Text = "CONSULTA FILME";
            this.btn_ConsultaFilme.BackColor = ColorTranslator.FromHtml("#aa9270");
            this.btn_ConsultaFilme.ForeColor = Color.Black;
            this.Controls.Add(btn_ConsultaFilme);
            btn_ConsultaFilme.Click += new EventHandler(btn_ConsultaFilmeClick);

       
            btn_ListaFilmes = new Button();            
            btn_ListaFilmes.Location = new Point(350, 240);
            btn_ListaFilmes.Size = new Size(200, 30);
            btn_ListaFilmes.Text = "LISTA DE FILMES";
            this.btn_ListaFilmes.BackColor = ColorTranslator.FromHtml("#aa9270");
            this.btn_ListaFilmes.ForeColor = Color.Black;
            this.Controls.Add(btn_ListaFilmes);
            btn_ListaFilmes.Click += new EventHandler(btn_ListaFilmesClick);

           
            gb_Filme = new GroupBox();
            gb_Filme.Location = new Point(335, 135);
            gb_Filme.Size = new Size(230, 150);
            gb_Filme.Text= "FILME";
            gb_Filme.ForeColor = ColorTranslator.FromHtml("#aa9270");
            this.Controls.Add(gb_Filme);

            
            btn_CadastroLocacao = new Button();
            btn_CadastroLocacao.Location = new Point(195, 320);
            btn_CadastroLocacao.Size = new Size(200, 30);
            btn_CadastroLocacao.Text = "CADASTRO DA LOCAÇÃO";
            this.btn_CadastroLocacao.BackColor = ColorTranslator.FromHtml("#aa9270");
            this.btn_CadastroLocacao.ForeColor = Color.Black;
            this.Controls.Add(btn_CadastroLocacao);
            btn_CadastroLocacao.Click += new EventHandler(btn_CadastroLocacaoClick);

            
            btn_ConsultaLocacao = new Button();
            btn_ConsultaLocacao.Location = new Point(195, 360);
            btn_ConsultaLocacao.Size = new Size(200, 30);
            btn_ConsultaLocacao.Text = "CONSULTA LOCAÇÃO";
            this.btn_ConsultaLocacao.BackColor = ColorTranslator.FromHtml("#aa9270");
            this.btn_ConsultaLocacao.ForeColor = Color.Black;
            this.Controls.Add(btn_ConsultaLocacao);
            btn_ConsultaLocacao.Click += new EventHandler(btn_ConsultaLocacaoClick);

           
            btn_ListaLocacoes = new Button();
            btn_ListaLocacoes.Location = new Point(195, 400);
            btn_ListaLocacoes.Size = new Size(200, 30);
            btn_ListaLocacoes.Text = "LISTA DE LOCAÇÕES";
            this.btn_ListaLocacoes.BackColor = ColorTranslator.FromHtml("#aa9270");
            this.btn_ListaLocacoes.ForeColor = Color.Black;
            this.Controls.Add(btn_ListaLocacoes);
            btn_ListaLocacoes.Click += new EventHandler(btn_ListaLocacoesClick);

            
            gb_Locaçao = new GroupBox();
            gb_Locaçao.Location = new Point(180, 295);
            gb_Locaçao.Size = new Size(230, 150);
            gb_Locaçao.Text= "LOCAÇÃO";
            gb_Locaçao.ForeColor = ColorTranslator.FromHtml("#aa9270");
            this.Controls.Add(gb_Locaçao);

            btn_MenuSair = new Button();
            btn_MenuSair.Location = new Point(220, 450);
            btn_MenuSair.Size = new Size(150, 50);            
            btn_MenuSair.Text = "SAIR";
            this.btn_MenuSair.BackColor = ColorTranslator.FromHtml("#aa9270");
            this.btn_MenuSair.ForeColor = Color.Black;            
            this.Controls.Add(btn_MenuSair);
            btn_MenuSair.Click += new EventHandler(btn_MenuSairClick);
        }
    
        
        private void btn_CadastroClienteClick(object sender, EventArgs e)
        {            
            CadastroCliente cadastrarClienteClick = new CadastroCliente(this);
            cadastrarClienteClick.Show();            
        }

      
        private void btn_ConsultaClienteClick(object sender, EventArgs e)
        {            
            ConsultaCliente consultaClienteClick = new ConsultaCliente(this);
            consultaClienteClick.Show();
        }

      
        private void btn_ListaClientesClick(object sender, EventArgs e)
        {            
            ListaCliente listaClienteClick = new ListaCliente(this);
            listaClienteClick.Show();
        }

        private void btn_CadastroFilmeClick(object sender, EventArgs e)
        {            
            CadastroFilme cadastrarFilmeClick = new CadastroFilme(this);
            cadastrarFilmeClick.Show();            
        }

       
        private void btn_ConsultaFilmeClick(object sender, EventArgs e)
        {            
            ConsultaFilme consultarFilmeClick = new ConsultaFilme(this);
            consultarFilmeClick.Show();
        }

        private void btn_ListaFilmesClick(object sender, EventArgs e)
        {            
            ListaFilme listaFilmeClick = new ListaFilme(this);
            listaFilmeClick.Show();
        }

       
        private void btn_CadastroLocacaoClick(object sender, EventArgs e)
        {            
            CadastroLocacao cadastrarLocacaoClick = new CadastroLocacao(this);
            cadastrarLocacaoClick.Show();
        }

       
        private void btn_ConsultaLocacaoClick(object sender, EventArgs e)
        {
            ConsultaLocacao consultarLocacaoClick = new ConsultaLocacao(this);
            consultarLocacaoClick.Show();
        }

      
        private void btn_ListaLocacoesClick(object sender, EventArgs e)
        {            
            ListaLocacao listaLocacaoClick = new ListaLocacao(this);
            listaLocacaoClick.Show();
        }

       
        private void btn_MenuSairClick(object sender, EventArgs e)
        {
            this.Close();           
        }

        }
    }
}
