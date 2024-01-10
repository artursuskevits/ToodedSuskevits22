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
using Aspose.Pdf;
using Image = System.Drawing.Image;
using Microsoft.VisualBasic;
using System.Net.Mail;
using System.Xml.Linq;
using System.IO;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;

namespace ToodedSuskevits
{
    public partial class Kassa : Form
    {
        //SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=ToodeDb;Integrated Security=True");
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\ARTUR\ONEDRIVE\РАБОЧИЙ СТОЛ\TOODEDSUSKEVITSAGAIN-MASTER\TOODEDSUSKEVITS\APPDATA\TOODED.MDF;Integrated Security=True");

        Document document;
        SqlDataAdapter adapter_toode, adapter_kategooria;
        SqlCommand command;
        List<string> Status_list = new List<string> { "Silver", "Gold", "Diamond" };
        List<string> toodenimetusList = new List<string>();
        List<string> Tooded_list = new List<string>();
        private List<string> originalComboBoxItems = new List<string>();
        string status = "";
        public Kassa()
        {
            InitializeComponent();
            NaitaKategooriat();
            YourForm_Load();
        }
        private void YourForm_Load()
        {
            // Display a MessageBox with information when the form is opened
            MessageBox.Show("AKTIVEERIGE OMA KAART ENNE OSTUKORVI LISAMIST!!!!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();
            if (comboBox1.SelectedItem != null)
            {
                string val_kat = comboBox1.SelectedItem.ToString();
                
                Tooded_list.Add(val_kat);
                comboBox1.Items.Remove(val_kat);
                for (int i = 0; i < Tooded_list.Count; i++)
                {
                    if (i+1==Tooded_list.Count)
                    {
                        label2.Text = label2.Text + "\n" + Tooded_list[i];
                    }
                }
                
                Tooded_list.Add("----------------------");
            }

            connect.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            document = new Document();
            var page = document.Pages.Add();
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("Toode Hind Kogus Summa"));
            foreach (var toode in Tooded_list)
            {
                
                page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment(toode));
            }
            string folderPath = (@"..\..\Arved");
            int fileCount = Directory.GetFiles(folderPath).Length;
            string filename = "Arve_" + fileCount + ".pdf";
            document.Save(string.Format(@"..\..\Arved\{0}", filename));
            document.Dispose();
            if (Tooded_list.Count>0)
            {
                    connect.Open();
                string query = "SELECT Toodenimetus FROM Toodetabel";

                using (SqlDataAdapter adapter_toode = new SqlDataAdapter(query, connect))
                {
                    DataTable dataTable = new DataTable();
                    adapter_toode.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows) 
                    {
                        string toodenimetusValue = row["Toodenimetus"].ToString();
                        toodenimetusList.Add(toodenimetusValue);
                    }
                }
                foreach (var item in toodenimetusList)
                {
                    int count = Tooded_list.Count(element => element.ToLower().Contains(item.ToLower()));
                    if (count != 0)
                    {
                        SqlCommand command = new SqlCommand("UPDATE Toodetabel SET Kogus = Kogus - @kogus WHERE Toodenimetus = @toode", connect);
                        command.Parameters.AddWithValue("@kogus", count);
                        command.Parameters.AddWithValue("@toode", item);
                        command.ExecuteNonQuery();

                    }
                    else if (count == 0)
                    { 
                    }
                    else
                    {
                        SqlCommand command2 = new SqlCommand("DELETE FROM Toodetabel WHERE WHERE Toodenimetus = @toode", connect);
                        command.Parameters.AddWithValue("@toode", item);
                        command.ExecuteNonQuery();
                    }
                }
                connect.Close();
                Kassa secondForm = new Kassa();
                secondForm.Show();
                this.Close();
            }
        }
        public void NaitaKategooriat()
        {
            connect.Open();
            adapter_kategooria = new SqlDataAdapter("Select Toodenimetus,Kogus,Hind FROM Toodetabel", connect);
            DataTable dt_kat = new DataTable();
            adapter_kategooria.Fill(dt_kat);

            // Clear existing items in comboBox1
            comboBox1.Items.Clear();

            foreach (DataRow item in dt_kat.Rows)
            {
                string toodenimetus = "";
                if (status == "Silver")
                {
                    toodenimetus = item["Toodenimetus"].ToString() + ": " + (Convert.ToSingle(item["Hind"]) * 0.9).ToString() + " Euro";
                }
                else if (status == "Gold")
                {
                    toodenimetus = item["Toodenimetus"].ToString() + ": " + (Convert.ToSingle(item["Hind"]) * 0.85).ToString() + " Euro";
                }
                else if (status == "Diamond")
                {
                    toodenimetus = item["Toodenimetus"].ToString() + ": " + (Convert.ToSingle(item["Hind"]) * 0.8).ToString() + " Euro";
                }
                else
                {
                    toodenimetus = item["Toodenimetus"].ToString() + ": " + item["Hind"] + " Euro";
                }

                // Check if the search text is empty or if the toodenimetus contains the search text
                string searchText = textBox4.Text.ToLower();
                if (string.IsNullOrEmpty(searchText) || toodenimetus.ToLower().Contains(searchText))
                {
                    if (int.TryParse(item["Kogus"].ToString(), out int kogus))
                    {
                        for (int i = 0; i < kogus; i++)
                        {
                            comboBox1.Items.Add(toodenimetus);
                        }       
                    }
                }
            }

            connect.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            {
                // Set the visibility of the controls to true
                textBox3.Visible = true;
                label5.Visible = true;
                button4.Visible = true;
                label4.Visible = true;
                label3.Visible = true;
                label6.Visible = true;
                textBox1.Visible = true;
                comboBox2.Visible = true;
                textBox2.Visible = true;
                NaitaStatusid();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connect.Open();

            // Create a new SqlCommand
            SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM Kliendid WHERE nimi LIKE @nimi" +
                " AND perenimi LIKE @perenimi AND password LIKE @password AND kliendikaar LIKE @kliendikaar", connect);

            // Set parameters for the command
            command.Parameters.AddWithValue("@nimi", textBox1.Text);
            command.Parameters.AddWithValue("@perenimi", textBox2.Text);
            command.Parameters.AddWithValue("@password", textBox3.Text);
            command.Parameters.AddWithValue("@kliendikaar", (comboBox2.SelectedItem != null) ? comboBox2.SelectedItem.ToString() : "");

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    status = comboBox2.SelectedItem.ToString();
                    string message = string.Format("Sul on {0} kaard", status);
                    MessageBox.Show(message,
                        "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connect.Close();
                    comboBox1.Items.Clear();
                    NaitaKategooriat();
                    button3.Visible = false;

                }
                else
                {
                    status = "";
                    MessageBox.Show("Vigan Andmed!",
                        "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connect.Close();
                    comboBox1.Items.Clear();
                    NaitaKategooriat();
                }
            }

            
            textBox3.Visible = false;
            label5.Visible = false;
            button4.Visible = false;
            label4.Visible = false;
            label3.Visible = false;
            label6.Visible = false;
            textBox1.Visible = false;
            comboBox2.Visible = false;
            textBox2.Visible = false;
        }

        private void SaadaArve_btn_Click(object sender, EventArgs e)
        {
            string adress = Interaction.InputBox("Sisseta e-mail","Kuhu saada","artursuskevits@gmail.com");
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential("mvc.programeerimine@gmail.com","3.Kuursus"),
                    EnableSsl = true
                };
                mail.From = new MailAddress("mvc.programeerimine@gmail.com");
                mail.To.Add(adress);
                mail.Subject = "Arve";
                mail.Body = "Arve on osetud ja ta on maanuses";
                mail.Attachments.Add(new Attachment(@"..\..\Arved\Arve.pdf"));
                smtpClient.Send(mail);
                MessageBox.Show("Arve oli saadetud mailile: " + adress);

            }
            catch (Exception)
            {
                MessageBox.Show("Viga");
            }

        }

        private void sa(object sender, EventArgs e)
        {
            string searchText = textBox4.Text.ToLower();

            // If the originalComboBoxItems is empty, store the initial items
            if (originalComboBoxItems.Count == 0)
            {
                foreach (var item in comboBox1.Items)
                {
                    originalComboBoxItems.Add(item.ToString());
                }
            }

            // Clear the ComboBox items
            comboBox1.Items.Clear();

            // Filter and add items based on the search text
            foreach (var item in originalComboBoxItems)
            {
                if (item.ToLower().Contains(searchText))
                {
                    comboBox1.Items.Add(item);
                }
            }
        }

        private void sdfsd(object sender, EventArgs e)
        {
            try
            {
                connect.Open(); // Open the connection

                string selectedToodenimetus = comboBox1.SelectedItem?.ToString(); // Added null check

                // Check if a selection is made in the comboBox1
                if (!string.IsNullOrEmpty(selectedToodenimetus))
                {
                    // Use parameterized query to prevent SQL injection
                    string query = "SELECT Toodenimetus, Pilte FROM Toodetabel WHERE Toodenimetus LIKE @Toodenimetus";

                    using (SqlCommand command = new SqlCommand(query, connect))
                    {
                        // Remove everything after the first space and colon in the selected item
                        string selectedToodenimetusWithoutExtras = selectedToodenimetus.Split(':')[0].Trim();

                        command.Parameters.AddWithValue("@Toodenimetus", "%" + selectedToodenimetusWithoutExtras + "%");

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Check if there are rows in the result set
                            if (reader.Read())
                            {
                                string queriedToodenimetus = reader["Toodenimetus"].ToString();

                                // Check if the queried Toodenimetus is contained within the selected item
                                if (!selectedToodenimetusWithoutExtras.Contains(queriedToodenimetus))
                                {
                                    Pb.Image = Image.FromFile(@"..\..\Images\" + "Question.png");
                                    MessageBox.Show("Toodenimetus from SQL query is not contained within the selected item in comboBox1.");
                                }
                                else
                                {
                                    // Proceed with loading the image
                                    string imagePath = reader["Pilte"].ToString();
                                    Pb.Image = Image.FromFile(@"..\..\Images\" + imagePath);
                                }
                            }
                            else
                            {
                                Pb.Image = Image.FromFile(@"..\..\Images\" + "Question.png");
                                MessageBox.Show("Pilti ei ole");
                            }
                        }
                    }
                }
                else
                {
                    Pb.Image = Image.FromFile(@"..\..\Images\" + "Question.png");
                    MessageBox.Show("Please select a Toodenimetus from the comboBox.");
                }
            }
            catch (Exception ex)
            {
                Pb.Image = Image.FromFile(@"..\..\Images\" + "Question.png");
            }
            finally
            {
                connect.Close(); // Moved connect.Close() to finally block to ensure it is always executed
            }
        }



        public void NaitaStatusid()
        {
            foreach (string item in Status_list)
            {
                comboBox2.Items.Add(item);
            }

        }

    }
}
