using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ADM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlCommand cmdGetinfo;
        MySqlDataReader readgetinfo;

        Secretaire secretaire1;

        string mat, mpasse;

        public static string typecon = null;
        



        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 10;
            timer2.Interval = 350;
            timer3.Enabled = true; timer3.Interval = 10;

            panel11.Enabled = true; panel11.Visible = true; panel11.Dock = DockStyle.Fill;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text.Length < 15 )
            {
                if (Program.searchMat(textBox1.Text) == true)
                {
                    textBox2.Enabled = true;
                    textBox2.Visible = true;
                    mat = textBox1.Text;
                    textBox2.Focus();
                    timer1.Enabled = true;
                }
                else 
                {
                    textBox2.Enabled = false;
                    textBox2.Visible = false;
                    mat = "";
                    timer1.Enabled = true;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "Mot de passe") { textBox2.UseSystemPasswordChar = false; } else { textBox2.UseSystemPasswordChar = true; }
            
            if (textBox2.Text != "")
            {
                if (Program.verifCod(textBox2.Text) == true)
                {
                    button1.Enabled = true;
                    button1.Visible = true;
                    mpasse = textBox2.Text;
                    button1.Focus();
                    timer2.Enabled = true;
                }
                else 
                {
                    button1.Enabled = false;
                    button1.Visible = false;
                    mpasse = "";
                    timer2.Enabled = true;
                }
            }

        }
    
        
        //*************************************** DEBUT DU TIMER 1 *************************************
        //--------------- gestion de l'affichage et du positionement des textbox 1 et 2 -------------
        //**********************************************************************************************
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (textBox2.Location.X < -199 && Program.searchMat(textBox1.Text) == true)
            {
                if (textBox1.Location.Y > 157)
                {
                    while (textBox1.Location.Y > 125)
                    {
                        textBox1.Top = textBox1.Top - 1;
                    }
                }
                while (textBox2.Location.X < 47)
                {
                    textBox2.Left = textBox2.Left + 1;
                }
            }
            else if (textBox2.Location.X > 46)
            {
                while (textBox2.Location.X > -600)
                {
                    textBox2.Left = textBox2.Left - 1;
                } 
                if (textBox1.Location.Y < 126)
                {
                    while (textBox1.Location.Y < 158)
                    {
                        textBox1.Top = textBox1.Top + 1;
                    }
                }
            }

        }//fin timer 1

        //********************************************* DEBUT DU TIMER 2 **********************************************
        //--------------------- gestion de l'affichage et du positionement du bouton de connexion ---------------------
        //*************************************************************************************************************
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;

            if(button1.Location.Y > 420 && Program.verifCod(textBox2.Text) == true)
            {
                while(button1.Location.Y > 227)
                {
                    button1.Top = button1.Top - 1;
                }
            }else if (button1.Location.Y < 226)
            {
                while (button1.Location.Y < 423)
                {
                    button1.Top = button1.Top + 1;
                }
            }

        }//fin timer 2

        private void button1_Click(object sender, EventArgs e)
        {
            
                if (mat == textBox1.Text && mpasse == textBox2.Text)
                {
                    cmdGetinfo = new MySqlCommand("select * from secretaire where mle ='" + mat +"'", Program.conn);
                    readgetinfo = cmdGetinfo.ExecuteReader();
                    while(readgetinfo.Read())
                    {
                        secretaire1 = new Secretaire(readgetinfo.GetString(0), readgetinfo.GetString(1), readgetinfo.GetString(6));
                    }
                    readgetinfo.Close();
                    timer3.Enabled = true;
                    panel11.Enabled = false; panel11.Visible = false;
                    panel3.Enabled = true; panel3.Visible = true;
                }
            
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Enabled = false;
            if(panel1.Width < 2)
            {
                while (panel1.Width < 451)
                {
                    panel1.Width = panel1.Width + 10;
                }
                panel1.Enabled = true;
                panel1.Visible = true;
            }else if (panel1.Width > 432)
            {
                while(panel1.Width > 1)
                {
                    panel1.Width = panel1.Width - 10;
                }
                panel1.Enabled = false;
                panel1.Visible = false;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panel3.Enabled = false; panel3.Visible = false;
            panel11.Enabled = true; panel11.Visible = true;
            timer3.Enabled = true;
            textBox2.Text = "Mot de passe";
            textBox2.Focus();
            timer2.Enabled = true;
            if (button3.Enabled == false) { timer4.Enabled = true; button3.Enabled = true; }
            
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            timer4.Enabled = false;
            if (panel5.Width < 356 && button3.Enabled == true)
            {
                while (panel5.Width < 888)
                {
                    panel5.Width = panel5.Width + 13;
                }
                panel9.Enabled = true; panel9.Visible = true;
                button3.Enabled = false;
            }
            else if (panel5.Width > 887)
            {
                while (panel5.Width > 355)
                {
                    panel5.Width = panel5.Width - 13;
                }
                panel9.Enabled = false; panel9.Visible = false;
                button3.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer4.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer4.Enabled = true;
            
        }

       


    }
}
