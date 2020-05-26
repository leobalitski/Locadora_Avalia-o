using System;
using System.Drawing;
using System.Windows.Forms;
using Controllers;
using static Locadora_MVC_LINQ_API_BD_IF.Program;

namespace Locadora_MVC_LINQ_API_BD_Interface 
{
    public class CadastroFilme : Form 
    {
        //Imagem
        PictureBox pb_Cadastro;
        Label lbl_Titulo;
        Label lbl_DataLancamento;
        Label lbl_Sinopse;
        Label lbl_ValorLocacao;
        Label lbl_QtdeEstoque;
        RichTextBox rtxt_Titulo;
        NumericUpDown num_DtLancDia;
        NumericUpDown num_DtLancMes;
        NumericUpDown num_DtLancAno;
        RichTextBox rtxt_Sinopse;
        ComboBox cb_ValorLocacao;
        NumericUpDown num_QtdeEstoque;
        Button btn_Confirmar;
        Button btn_Cancelar;
        Form parent;

       
        public CadastroFilme (Form parent) 
        {
            this.BackColor = ColorTranslator.FromHtml("#898989");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500,420);
            this.parent = parent;

            // Image 
            pb_Cadastro = new PictureBox();
            pb_Cadastro.Location = new Point (10, 10);    
            pb_Cadastro.Size = new Size(500, 100);
            pb_Cadastro.ClientSize = new Size (460 , 60);
            pb_Cadastro.BackColor = Color.Black;
            pb_Cadastro.Load ("./Views/assets/senac.jpg");
            pb_Cadastro.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb_Cadastro);

            lbl_Titulo = new Label ();
            lbl_Titulo.Text = "Título :";
            lbl_Titulo.Location = new Point (20, 100);
            this.Controls.Add (lbl_Titulo);

            lbl_DataLancamento = new Label ();
            lbl_DataLancamento.Text = "Ano de Lançamento :";
            lbl_DataLancamento.AutoSize = true;
            lbl_DataLancamento.Location = new Point (30, 140);
            this.Controls.Add (lbl_DataLancamento);

            lbl_Sinopse = new Label ();
            lbl_Sinopse.Text = "Sinopse :";
            lbl_Sinopse.Location = new Point (30, 180);
            this.Controls.Add (lbl_Sinopse);

            lbl_ValorLocacao = new Label ();
            lbl_ValorLocacao.Text = "Valor da Locação :";
            lbl_ValorLocacao.AutoSize = true;
            lbl_ValorLocacao.Location = new Point (30, 250);
            this.Controls.Add (lbl_ValorLocacao);

            lbl_QtdeEstoque = new Label ();
            lbl_QtdeEstoque.Text = "Quantidade:";
            lbl_QtdeEstoque.AutoSize = true;
            lbl_QtdeEstoque.Location = new Point (30, 290);
            this.Controls.Add (lbl_QtdeEstoque);

            rtxt_Titulo = new RichTextBox();
            rtxt_Titulo.SelectionFont = new Font("verdana", 10, FontStyle.Bold);  
            rtxt_Titulo.SelectionColor = System.Drawing.Color.Black;
            rtxt_Titulo.Location = new Point (160, 100);    
            rtxt_Titulo.Size = new Size(300, 20);       
            this.Controls.Add(rtxt_Titulo);

            
            num_DtLancDia = new NumericUpDown();
            num_DtLancDia.Location = new Point (160, 140);    
            num_DtLancDia.Size = new Size(60, 20);
            num_DtLancDia.Minimum = 1;
            num_DtLancDia.Maximum = 31;
            this.Controls.Add(num_DtLancDia);

            num_DtLancMes = new NumericUpDown();
            num_DtLancMes.Location = new Point (220, 140);    
            num_DtLancMes.Size = new Size(60, 20);
            num_DtLancMes.Minimum = 1;
            num_DtLancMes.Maximum = 12;
            this.Controls.Add(num_DtLancMes);

            num_DtLancAno = new NumericUpDown();
            num_DtLancAno.Location = new Point (280, 140);    
            num_DtLancAno.Size = new Size(60, 20);
            num_DtLancAno.Minimum = 1890;
            num_DtLancAno.Maximum = 2020;
            this.Controls.Add(num_DtLancAno);
            
            rtxt_Sinopse = new RichTextBox();
            rtxt_Sinopse.SelectionFont = new Font("verdana", 10, FontStyle.Italic);  
            rtxt_Sinopse.SelectionColor = System.Drawing.Color.Black;
            rtxt_Sinopse.Location = new Point (160, 180);    
            rtxt_Sinopse.Size = new Size(300, 60);       
            this.Controls.Add(rtxt_Sinopse);

            cb_ValorLocacao = new ComboBox();
            cb_ValorLocacao.Items.Add("R$ 1.99");
            cb_ValorLocacao.Items.Add("R$ 2.99");
            cb_ValorLocacao.Items.Add("R$ 3.99");
            cb_ValorLocacao.Items.Add("R$ 4.99");
            cb_ValorLocacao.Items.Add("R$ 5.99");
            cb_ValorLocacao.Items.Add("R$ 6.99");
            cb_ValorLocacao.AutoCompleteMode = AutoCompleteMode.Append;
            cb_ValorLocacao.Location = new Point (180, 250);    
            cb_ValorLocacao.Size = new Size(150, 20);
            this.Controls.Add(cb_ValorLocacao);
 
            num_QtdeEstoque = new NumericUpDown();
            num_QtdeEstoque.Location = new Point (180, 290);    
            num_QtdeEstoque.Size = new Size(60, 20);
            num_QtdeEstoque.Minimum = 1;
            num_QtdeEstoque.Maximum = 100;
            this.Controls.Add(num_QtdeEstoque);

            btn_Confirmar = new Button ();
            btn_Confirmar.Location = new Point (80, 330);
            btn_Confirmar.Size = new Size (180, 40);
            btn_Confirmar.Text = "CONFIRMAR";
            this.btn_Confirmar.BackColor = ColorTranslator.FromHtml("#aa9270");
            this.btn_Confirmar.ForeColor = Color.Black;            
            btn_Confirmar.Click += new EventHandler (this.btn_ConfirmarClick);
            this.Controls.Add (btn_Confirmar);

            btn_Cancelar = new Button ();
            btn_Cancelar.Location = new Point (260, 330);
            btn_Cancelar.Size = new Size (180, 40);
            btn_Cancelar.Text = "CANCELAR";
            this.btn_Cancelar.BackColor = ColorTranslator.FromHtml("#aa9270");
            this.btn_Cancelar.ForeColor = Color.Black;             
            btn_Cancelar.Click += new EventHandler (this.btn_CancelarClick);
            this.Controls.Add (btn_Cancelar);
        }

        private void btn_ConfirmarClick (object sender, EventArgs e)
        {
            FilmeController.CadastrarFilme(
                rtxt_Titulo.Text,
                (int)num_DtLancDia.Value,
                (int)num_DtLancMes.Value,
                (int)num_DtLancAno.Value,
                rtxt_Sinopse.Text,
                cb_ValorLocacao.Text == "R$ 1.99"
                ? 1.99
                    : cb_ValorLocacao.Text == "R$ 2.99"
                    ? 2.99
                        : cb_ValorLocacao.Text == "R$ 3.99"
                        ? 3.99
                        : cb_ValorLocacao.Text == "R$ 4.99"
                            ? 4.99
                            : cb_ValorLocacao.Text == "R$ 5.99"
                                ? 5.99
                                : 6.99,
                (int) num_QtdeEstoque.Value
            );
            MessageBox.Show ("CADASTRADO!");
            this.Close ();
            this.parent.Show ();
        }

        private void btn_CancelarClick (object sender, EventArgs e) 
        {
            MessageBox.Show ("CANCELADO!");
            this.Close ();
            this.parent.Show ();
        }
    }
}