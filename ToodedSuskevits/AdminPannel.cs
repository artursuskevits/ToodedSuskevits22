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
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ToodedSuskevits
{
    public partial class AdminPannel : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\ARTUR\ONEDRIVE\РАБОЧИЙ СТОЛ\TOODEDSUSKEVITSAGAIN-MASTER\TOODEDSUSKEVITS\APPDATA\TOODED.MDF;Integrated Security=True");
        SqlDataAdapter adapter_toode, adapter_kategooria;
        SqlCommand command;
        public AdminPannel()
        {
            InitializeComponent();
            NaitaAndmed();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                int selectedId = Convert.ToInt32(dataGridView1.Rows[selectedIndex].Cells["id"].Value);
                {
                    connect.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Registration WHERE id = @id", connect))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedId);
                        cmd.ExecuteNonQuery();
                    }

                    connect.Close();
                }

                dataGridView1.Rows.RemoveAt(selectedIndex);

                MessageBox.Show("Row deleted successfully.");
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row index
                int selectedIndex = dataGridView1.SelectedRows[0].Index;

                // Get the value of the ID column from the selected row
                int selectedId = Convert.ToInt32(dataGridView1.Rows[selectedIndex].Cells["id"].Value);

                // Get the new status from the TextBox
                string newStatus = textBox1.Text;
                {
                    connect.Open();

                    // Update the row in the database
                    using (SqlCommand cmd = new SqlCommand("UPDATE Registration SET login = @login WHERE id = @id", connect))
                    {
                        cmd.Parameters.AddWithValue("@login", newStatus);
                        cmd.Parameters.AddWithValue("@id", selectedId);
                        cmd.ExecuteNonQuery();
                    }

                    // Close the connection
                    connect.Close();
                }

                // Update the DataGridView with the new data
                NaitaAndmed(); // Call your method to refresh the data in the DataGridView

                MessageBox.Show("Row updated successfully.");
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                Form1 secondForm = new Form1();
                secondForm.Show();
            }
        }

        public void NaitaAndmed()
        {
            connect.Open();

            DataTable dt_toode = new DataTable();
            adapter_toode = new SqlDataAdapter("SELECT * from Registration;", connect);
            adapter_toode.Fill(dt_toode);
            dataGridView1.DataSource = dt_toode;
            connect.Close();
        }


    }
}
