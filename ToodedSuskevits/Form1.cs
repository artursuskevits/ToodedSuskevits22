using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToodedSuskevits
{
    public partial class Form1 : Form
    {
        //SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=ToodeDb;Integrated Security=True");
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\ARTUR\ONEDRIVE\РАБОЧИЙ СТОЛ\TOODEDSUSKEVITSAGAIN-MASTER\TOODEDSUSKEVITS\APPDATA\TOODED.MDF;Integrated Security=True");
        SqlDataAdapter adapter_toode, adapter_kategooria;
        SqlCommand command;
        public Form1()
        {
            InitializeComponent();
            NaitaAndmed();
            NaitaKategooriat();
        }

       //public void Lisa_kategooriat(object sender, EventArgs e)
       // {

       // }
        private void Button1_Click(object sender, System.EventArgs e)
        {


            try
            {
                command = new SqlCommand("Insert Into Kategooriatabel(Kategooria_nimetus)VALUES(@kat)", connect);
                connect.Open();
                command.Parameters.AddWithValue("@kat", comboBox1.Text);
                command.ExecuteNonQuery();
                connect.Close();
                comboBox1.Items.Clear();
                NaitaKategooriat();
             }
            catch (Exception)
            {
                MessageBox.Show("Andmebaasid viga!");
            }

        }

        private void Uuendabtn_Click(object sender, System.EventArgs e)
        {
            if (Todebox.Text.Trim() != string.Empty && kogusBox.Text.Trim() != string.Empty && HindBox.Text.Trim() != string.Empty && comboBox1.SelectedItem != null)
            {
                try
                {
                    connect.Open();

                    command = new SqlCommand("SELECT Id FROM Kategooriatabel WHERE Kategooria_nimetus = @kat", connect);
                    command.Parameters.AddWithValue("@kat", comboBox1.Text);
                    int Id = Convert.ToInt32(command.ExecuteScalar());

                    command = new SqlCommand("INSERT INTO Toodetabel (Toodenimetus, Kogus, Hind, Pilte, Kategooriat) VALUES (@toode, @kogus, @hind, @pilt, @kat)", connect);
                    command.Parameters.AddWithValue("@toode", Todebox.Text);
                    command.Parameters.AddWithValue("@kogus", Convert.ToInt32(kogusBox.Text));
                    command.Parameters.AddWithValue("@hind", Convert.ToDouble(HindBox.Text));
                    command.Parameters.AddWithValue("@pilt", Todebox.Text + ".jpg");
                    command.Parameters.AddWithValue("@kat", Id);

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
                        NaitaAndmed();
                    }
                }
            }
            else
            {
                MessageBox.Show("Sisestage andmeid!");
            }
        }

        private void Button5_Click(object sender, System.EventArgs e)
        {
            Kassa secondForm = new Kassa();

            // Show the form
            secondForm.Show();
        }
        public void NaitaKategooriat()
        {
            connect.Open();
            adapter_kategooria = new SqlDataAdapter("Select Kategooria_nimetus FROM Kategooriatabel", connect);
            DataTable dt_kat = new DataTable();
            adapter_kategooria.Fill(dt_kat);

            foreach (DataRow item in dt_kat.Rows)
            {
                string kategooria_nimetus = item["Kategooria_nimetus"].ToString();

                if (!comboBox1.Items.Contains(kategooria_nimetus))
                {
                    comboBox1.Items.Add(kategooria_nimetus);
                }
            }

            connect.Close();
        }
        private void TextBox4_TextChanged(object sender, System.EventArgs e)
        {
            string searchText = ((TextBox)sender).Text;
            comboBox1.Items.Clear();

            foreach (string item in comboBox1.Items)
            {
                if (item.Contains(searchText))
                {
                    comboBox1.Items.Add(item);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != 0)
            {
                try
                {
                    string val_kat = comboBox1.SelectedItem.ToString();
                    {
                        connect.Open();
                        SqlCommand command = new SqlCommand("DELETE FROM Kategooriatabel WHERE Kategooria_nimetus = @kat", connect);
                        command.Parameters.AddWithValue("@kat", val_kat);
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
                finally
                {
                    connect.Close();
                    if (comboBox1.Items.Count > 0)
                    {
                        comboBox1.Items.Clear();
                    }
                    NaitaKategooriat();
                    MessageBox.Show("Ma kustuan! @kat");
                }
            }
        }

        private void Button3_Click(object sender, System.EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) { 
                command = new SqlCommand("UPDATE Toodetabel SET Toodenimetus=@toode, Kogus=@kogus, Hind=@hind,Pilte=@pilt,Kategooriat=@kat WHERE Id=@id", connect);
            connect.Open();
            command.Parameters.AddWithValue("@id", Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value));
            command.Parameters.AddWithValue("@toode", Todebox.Text);
            command.Parameters.AddWithValue("@kogus", Convert.ToInt32(kogusBox.Text));
            command.Parameters.AddWithValue("@hind", Convert.ToDouble(HindBox.Text));
            command.Parameters.AddWithValue("@pilt", Todebox.Text + ".jpg");
            command.Parameters.AddWithValue("@kat", comboBox1.SelectedIndex+1);

            command.ExecuteNonQuery();
            connect.Close();
            NaitaAndmed();
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }
        string kat;
        SaveFileDialog save;
        OpenFileDialog open;
        private void Button4_Click(object sender, System.EventArgs e)
        {
            open = new OpenFileDialog();
            open.InitialDirectory = @"C:\Users\Opilane TTHK\Pictures";
            open.Multiselect = true;
            open.Filter = "Images Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            FileInfo open_info = new FileInfo(@"C:\Users\Opilane TTHK\Pictures"+open.FileName);
            if (open.ShowDialog()==DialogResult.OK && Todebox.Text!=null)
            {
                save = new SaveFileDialog();
                save.InitialDirectory = Path.GetFullPath(@"..\..\Images");
                save.FileName = Todebox.Text + Path.GetExtension(open.FileName);
                save.Filter = "Images" + Path.GetExtension(open.FileName)+"|"+Path.GetExtension(open.FileName);
                if (save.ShowDialog()==DialogResult.OK)
                {
                    File.Copy(open.FileName, save.FileName);
                    Pb.Image = Image.FromFile(save.FileName);
                }
            }
            else
            {
                MessageBox.Show("Puudub toode nimetus");
            }
            
        }
        private void KustutaBtn_Click(object sender, System.EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                int selectedId = Convert.ToInt32(dataGridView1.Rows[selectedIndex].Cells["Id"].Value);
                {
                    connect.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Toodetabel WHERE Id = @id", connect))
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
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new System.NotImplementedException();
        }
        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int Id = 0;
            Id = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
            Todebox.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            kogusBox.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            HindBox.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            try
            {
                Pb.Image = Image.FromFile(@"..\..\Images\"+ dataGridView1.Rows[e.RowIndex].Cells["Pilte"].Value.ToString());
            }
            catch (Exception)
            {
                Pb.Image = Image.FromFile(@"..\..\Images\"+"Question.png");
                MessageBox.Show("Pilti ei ole");
            }
            comboBox1.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[5].Value;
        }


        public void NaitaAndmed()
        {
            connect.Open();

            DataTable dt_toode = new DataTable();
            adapter_toode = new SqlDataAdapter("SELECT Toodetabel.Id, Toodetabel.Toodenimetus, Toodetabel.Kogus,Toodetabel.Hind, Toodetabel.Pilte," +
                " Kategooriatabel.Kategooria_nimetus FROM Toodetabel JOIN Kategooriatabel ON Toodetabel.Kategooriat = Kategooriatabel.Id;", connect);
            adapter_toode.Fill(dt_toode);
            //DataGridViewComboBoxColumn dgvcb = new DataGridViewComboBoxColumn();
            //foreach  (DataRow item in dt_toode.Rows)
            //{
            //    if (!dgvcb.Items.Contains(item["Kategooria_nimetus"]))
            //    {
            //        dgvcb.Items.Add(item["Kategooria_nimetus"]);
            //    }
            //}
            dataGridView1.DataSource = dt_toode;
            /*ataGridView1.Columns.Add(dgvcb);*/
            connect.Close();
        }
    }
}
