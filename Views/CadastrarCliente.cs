using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers;
using static Locadora_MVC_LINQ_API_BD_IF.Program;

namespace Locadora_MVC_LINQ_API_BD_Interface 
{
    public class CadastroCliente : Form 
    {
        
        PictureBox pb_Cadastro;
        
        Label lbl_Nome;  
        Label lbl_DataNasc;      
        Label lbl_CPF;
        Label lbl_DiasDevol;
        RichTextBox rtxt_NomeCliente;
        NumericUpDown num_DataNascDia;
        NumericUpDown num_DataNascMes;
        NumericUpDown num_DataNascAno;
        MaskedTextBox mtxt_CpfCLiente;
        ComboBox cb_DiasDevol;
        Button btn_Confirmar;
        Button btn_Cancelar;
        Form parent;

         

        public CadastroCliente (Form parent) 
        {
            this.BackColor = ColorTranslator.FromHtml("#898989");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(600,500);
            this.parent = parent;

           
            pb_Cadastro = new PictureBox();
            pb_Cadastro.Location = new Point (10, 10);    
            pb_Cadastro.Size = new Size(500 , 200);
            pb_Cadastro.ClientSize = new Size (500 , 70);
            pb_Cadastro.BackColor = Color.Black;
            pb_Cadastro.Load ("./Views/assets/senac.jpg");
            pb_Cadastro.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb_Cadastro);         
            
            lbl_Nome = new Label ();
            lbl_Nome.Text = "Nome :";
            lbl_Nome.Location = new Point (25, 100);
            lbl_Nome.AutoSize = true;
            this.Controls.Add(lbl_Nome);

            lbl_DataNasc = new Label ();
            lbl_DataNasc.Text = "Data de Nascimento :";
            lbl_DataNasc.AutoSize = true;
            lbl_DataNasc.Location = new Point (25, 140);            
            this.Controls.Add(lbl_DataNasc);

            lbl_CPF = new Label ();
            lbl_CPF.Text = "CPF :";
            lbl_CPF.Location = new Point (25, 180);
            this.Controls.Add(lbl_CPF);

            lbl_DiasDevol = new Label ();
            lbl_DiasDevol.Text = "Dias  Devolução :";
            lbl_DiasDevol.AutoSize = true;
            lbl_DiasDevol.Location = new Point (25, 220);
            this.Controls.Add(lbl_DiasDevol);

            rtxt_NomeCliente = new RichTextBox();
            rtxt_NomeCliente.SelectionFont = new Font("verdana", 10, FontStyle.Bold);  
            rtxt_NomeCliente.SelectionColor = System.Drawing.Color.Black;
            rtxt_NomeCliente.Location = new Point (160, 100);    
            rtxt_NomeCliente.Size = new Size(310, 20);       
            this.Controls.Add(rtxt_NomeCliente);            

            
            num_DataNascDia = new NumericUpDown();
            num_DataNascDia.Location = new Point (160, 140);    
            num_DataNascDia.Size = new Size(60, 20);
            num_DataNascDia.Minimum = 1;
            num_DataNascDia.Maximum = 31;
            this.Controls.Add(num_DataNascDia);

            num_DataNascMes = new NumericUpDown();
            num_DataNascMes.Location = new Point (200, 140);    
            num_DataNascMes.Size = new Size(60, 20);
            num_DataNascMes.Minimum = 1;
            num_DataNascMes.Maximum = 12;
            this.Controls.Add(num_DataNascMes);

            num_DataNascAno = new NumericUpDown();
            num_DataNascAno.Location = new Point (290, 140);    
            num_DataNascAno.Size = new Size(50, 20);
            num_DataNascAno.Minimum = 1930;
            num_DataNascAno.Maximum = 2020;
            this.Controls.Add(num_DataNascAno);

            mtxt_CpfCLiente = new MaskedTextBox ();
            mtxt_CpfCLiente.Location = new Point (160, 180);
            mtxt_CpfCLiente.Size = new Size (160, 20);
            mtxt_CpfCLiente.Mask = "000,000,000-00";
            this.Controls.Add(mtxt_CpfCLiente);

        
            cb_DiasDevol = new ComboBox();
            cb_DiasDevol.Items.Add("2 Dias");
            cb_DiasDevol.Items.Add("3 Dias");
            cb_DiasDevol.Items.Add("4 Dias");
            cb_DiasDevol.Items.Add("5 Dias");
            cb_DiasDevol.AutoCompleteMode = AutoCompleteMode.Append;
            cb_DiasDevol.Location = new Point (160, 220);    
            cb_DiasDevol.Size = new Size(180, 20);
            this.Controls.Add(cb_DiasDevol);

            btn_Confirmar = new Button ();
            btn_Confirmar.Text = "CONFIRMAR";
            btn_Confirmar.Location = new Point (90, 280);
            btn_Confirmar.Size = new Size (160, 40);            
            this.btn_Confirmar.BackColor = ColorTranslator.FromHtml("#9a8d7d");
            this.btn_Confirmar.ForeColor = Color.Black;         
            btn_Confirmar.Click += new EventHandler (this.btn_ConfirmarClick);
            this.Controls.Add(btn_Confirmar);

            btn_Cancelar = new Button ();
            btn_Cancelar.Text = "CANCELAR";
            btn_Cancelar.Location = new Point (280, 280);
            btn_Cancelar.Size = new Size (160, 40);            
            this.btn_Cancelar.BackColor = ColorTranslator.FromHtml("#9a8d7d");
            this.btn_Cancelar.ForeColor = Color.Black;         
            btn_Cancelar.Click += new EventHandler (this.btn_CancelarClick);
            this.Controls.Add(btn_Cancelar);
        }

        private void btn_ConfirmarClick (object sender, EventArgs e) 
        {
            ClienteController.CadastrarCliente( 
                rtxt_NomeCliente.Text, 
                (int)num_DataNascDia.Value, 
                (int)num_DataNascMes.Value,
                (int)num_DataNascAno.Value,
                mtxt_CpfCLiente.Text, 

                cb_DiasDevol.Text == "2 Dias"
                    ? 2
                    : cb_DiasDevol.Text == "3 Dias"
                        ? 3
                        : cb_DiasDevol.Text == "4 Dias"
                            ? 4
                            : cb_DiasDevol.Text == "5 Dias"
                                ? 5
                                : 10
            );
            MessageBox.Show ("CADASTRADO!");
            this.Close ();
            this.parent.Show ();
        }        

        private void btn_CancelarClick(object sender, EventArgs e)
        {
            MessageBox.Show ("CANCELADO!");
            this.Close ();
            this.parent.Show ();    
        }
    }
}