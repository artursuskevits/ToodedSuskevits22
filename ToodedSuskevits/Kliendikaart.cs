using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToodedSuskevits
{

    public partial class Kliendikaart : Form
    {
        //SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=ToodeDb;Integrated Security=True");
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\ARTUR\ONEDRIVE\РАБОЧИЙ СТОЛ\TOODEDSUSKEVITSAGAIN-MASTER\TOODEDSUSKEVITS\APPDATA\TOODED.MDF;Integrated Security=True");
        SqlDataAdapter adapter_toode, adapter_kategooria;
        SqlCommand command;
        List<string> Status_list = new List<string> { "Silver", "Gold", "Diamond" };
        public Kliendikaart()
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
        private void button1_Click(object sender, System.EventArgs e)
        {
            if (comboBox1.Text.Trim() != string.Empty && textBox1.Text.Trim() != string.Empty
                && textBox2.Text.Trim() != string.Empty && textBox3.Text.Trim() != string.Empty)
            {
                string status = comboBox1.Text.Trim();
                int bonus = 0;
                if (status== "Silver")
                {
                    bonus = 10;
                }
                else if (status == "Gold")
                {
                    bonus = 15;
                }
                else if (status=="Diamond")
                {
                    bonus = 20;
                }
                try
                {
                    connect.Open();
                    command = new SqlCommand("INSERT INTO Kliendid (nimi, perenimi, password, kliendikaar,boonus) VALUES " +
                        "(@nimi, @perenimi,@password, @kliendikaa,@bonus)", connect);
                    command.Parameters.AddWithValue("@nimi", textBox1.Text);
                    command.Parameters.AddWithValue("@perenimi", textBox1.Text);
                    command.Parameters.AddWithValue("@password", textBox1.Text);
                    command.Parameters.AddWithValue("@kliendikaa", (comboBox1.SelectedItem.ToString()));
                    command.Parameters.AddWithValue("@bonus", bonus);

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
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Sisestage andmeid!");
                
            }
        }

    }
}
