using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ToodedSuskevits
{
    public partial class Registartion : Form
    {
        //SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=ToodeDb;Integrated Security=True");
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\ARTUR\ONEDRIVE\РАБОЧИЙ СТОЛ\TOODEDSUSKEVITSAGAIN-MASTER\TOODEDSUSKEVITS\APPDATA\TOODED.MDF;Integrated Security=True");

        SqlCommand command;
        List<string> Status_list = new List<string> { "Müüja", "Omanik","Admin"};
        public Registartion()
        {
            InitializeComponent();
            NaitaKategooriat();
        }
        public void NaitaKategooriat()
        {
            foreach (string item in Status_list)
            {
                comboBox1.Items.Add(item);
            }

        }


        private void Button1_Click1(object sender, System.EventArgs e)
        { 

            if (comboBox1.Text.Trim() != string.Empty && textBox1.Text.Trim() != string.Empty)
            {
                try
                {
                    connect.Open();
                    command = new SqlCommand("INSERT INTO Registration (login, status) VALUES (@login, @status)", connect);
                    command.Parameters.AddWithValue("@login", textBox1.Text);
                    command.Parameters.AddWithValue("@status", (comboBox1.SelectedItem.ToString()));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Andmebaasid viga: " + ex.Message);
                }
                finally
                {   
                    if (connect.State == ConnectionState.Open)
                    {
                        connect.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Sisestage andmeid!");
            }
        }
        private void Button2_Click(object sender, System.EventArgs e)
        
        {
            if (comboBox1.Text.Trim() != string.Empty && textBox1.Text.Trim() != string.Empty)
            {
                try
                {
                    string login = textBox1.Text;
                    string status = comboBox1.SelectedItem.ToString();
                    connect.Open();
                    command = new SqlCommand("SELECT COUNT(*) FROM Registration WHERE login = @login AND status = @status;", connect);
                    command.Parameters.AddWithValue("@login", textBox1.Text);
                    command.Parameters.AddWithValue("@status", comboBox1.SelectedItem.ToString());

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        if (status == "Müüja")
                        {
                            Kassa secondForm = new Kassa();
                            secondForm.Show();
                        }
                        else if (status == "Admin")
                        {
                            AdminPannel secondForm = new AdminPannel();
                            secondForm.Show();
                        }
                        else
                        {
                            Form1 secondForm = new Form1();
                            secondForm.Show();
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Andmebaasid viga: " + ex.Message);
                }
                finally
                {
                    if (connect.State == ConnectionState.Open)
                    {
                        connect.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Sisestage andmeid!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Kliendikaart secondForm = new Kliendikaart();
            secondForm.Show();
        }
    }
}
