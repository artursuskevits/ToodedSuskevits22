using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ToodedSuskevits
{
    partial class Form1
    {
        
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Koguslbl = new System.Windows.Forms.Label();
            this.Hindlbl = new System.Windows.Forms.Label();
            this.Todelbl = new System.Windows.Forms.Label();
            this.kogusBox = new System.Windows.Forms.TextBox();
            this.HindBox = new System.Windows.Forms.TextBox();
            this.Todebox = new System.Windows.Forms.TextBox();
            this.Uuendabtn = new System.Windows.Forms.Button();
            this.KustutaBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button(); 
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.Pb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;

            // 
            // dataGridView1
            // 


            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(99, 399);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(568, 202);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowHeaderMouseClick += DataGridView1_RowHeaderMouseClick;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(278, 277);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(156, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.BackColor = System.Drawing.Color.Silver;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 280);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.label1.Size = new System.Drawing.Size(70, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kategooriad: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(161, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Lisa Kategooriat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Koguslbl
            // 
            this.Koguslbl.AutoSize = true;
            this.Koguslbl.Location = new System.Drawing.Point(158, 113);
            this.Koguslbl.Name = "Koguslbl";
            this.Koguslbl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.Koguslbl.Size = new System.Drawing.Size(43, 23);
            this.Koguslbl.TabIndex = 4;
            this.Koguslbl.Text = "Kogus: ";
            // 
            // Hindlbl
            // 
            this.Hindlbl.AutoSize = true;
            this.Hindlbl.Location = new System.Drawing.Point(158, 161);
            this.Hindlbl.Name = "Hindlbl";
            this.Hindlbl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.Hindlbl.Size = new System.Drawing.Size(35, 23);
            this.Hindlbl.TabIndex = 5;
            this.Hindlbl.Text = "Hind: ";
            // 
            // Todelbl
            // 
            this.Todelbl.AutoSize = true;
            this.Todelbl.Location = new System.Drawing.Point(158, 62);
            this.Todelbl.Name = "Todelbl";
            this.Todelbl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.Todelbl.Size = new System.Drawing.Size(38, 23);
            this.Todelbl.TabIndex = 6;
            this.Todelbl.Text = "Tode: ";
            // 
            // kogusBox
            // 
            this.kogusBox.Location = new System.Drawing.Point(242, 110);
            this.kogusBox.Name = "kogusBox";
            this.kogusBox.Size = new System.Drawing.Size(100, 20);
            this.kogusBox.TabIndex = 7;
            this.kogusBox.BackColor = System.Drawing.Color.Silver;
            // 
            // HindBox
            // 
            this.HindBox.Location = new System.Drawing.Point(242, 158);
            this.HindBox.Name = "HindBox";
            this.HindBox.Size = new System.Drawing.Size(100, 20);
            this.HindBox.TabIndex = 8;
            this.HindBox.BackColor = System.Drawing.Color.Silver;
            // 
            // Todebox
            // 
            this.Todebox.Location = new System.Drawing.Point(242, 65);
            this.Todebox.Name = "Todebox";
            this.Todebox.Size = new System.Drawing.Size(100, 20);
            this.Todebox.TabIndex = 9;
            this.Todebox.BackColor = System.Drawing.Color.Silver;
            // 
            // Uuendabtn
            // 
            this.Uuendabtn.Location = new System.Drawing.Point(276, 321);
            this.Uuendabtn.Name = "Uuendabtn";
            this.Uuendabtn.Size = new System.Drawing.Size(75, 23);
            this.Uuendabtn.TabIndex = 10;
            this.Uuendabtn.Text = "Lisa Toode";
            this.Uuendabtn.UseVisualStyleBackColor = true;
            this.Uuendabtn.Click += new System.EventHandler(this.Uuendabtn_Click);
            // 
            // KustutaBtn
            // 
            this.KustutaBtn.Location = new System.Drawing.Point(385, 321);
            this.KustutaBtn.Name = "KustutaBtn";
            this.KustutaBtn.Size = new System.Drawing.Size(75, 23);
            this.KustutaBtn.TabIndex = 11;
            this.KustutaBtn.Text = "Kustuta Toode";
            this.KustutaBtn.UseVisualStyleBackColor = true;
            this.KustutaBtn.Click += KustutaBtn_Click;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(431, 269);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 35);
            this.button2.TabIndex = 12;
            this.button2.Text = "KUSTUTA KATEGORIA";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(531, 269);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 35);
            this.button3.TabIndex = 12;
            this.button3.Text = "Uuenda Toode";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += Button3_Click;

            this.button4.Location = new System.Drawing.Point(531, 330);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 35);
            this.button4.TabIndex = 12;
            this.button4.Text = "Ava File";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += Button4_Click;
            // 
            // dgv
            // 
            this.button5.Location = new System.Drawing.Point(0,0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(86, 35);
            this.button5.TabIndex = 12;
            this.button5.Text = "Ava Kassa";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += Button5_Click;
            this.button5.BackColor = System.Drawing.Color.Lime;

            this.Pb.Size =  new System.Drawing.Size(200, 200);
            this.Pb.Location = new System.Drawing.Point(531, 30);
            this.Pb.BackColor = Pb.BackColor = Color.LightPink;
            this.Pb.SizeMode = PictureBoxSizeMode.Zoom;
            // 
            // Form1
            // 

            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black; // Set label text color to black
            this.Koguslbl.ForeColor = this.Hindlbl.ForeColor = this.Todelbl.ForeColor = System.Drawing.Color.Black; // Set label text color
            this.Koguslbl.Font = this.Hindlbl.Font = this.Todelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F); // Set label font size
            this.button1.BackColor = this.Uuendabtn.BackColor = this.KustutaBtn.BackColor = this.button2.BackColor = this.button3.BackColor = this.button4.BackColor = System.Drawing.Color.Silver;
            this.button1.Size = this.Uuendabtn.Size = this.KustutaBtn.Size = this.button2.Size = this.button3.Size = this.button4.Size = this.button5.Size = new System.Drawing.Size(120, 50); // Set a larger size for all buttons

            // Align buttons to the left
            this.button1.Location = new System.Drawing.Point(20, 321);
            this.Uuendabtn.Location = new System.Drawing.Point(151, 321);
            this.KustutaBtn.Location = new System.Drawing.Point(282, 321);
            this.button2.Location = new System.Drawing.Point(413, 321);
            this.button3.Location = new System.Drawing.Point(544, 321);
            this.button4.Location = new System.Drawing.Point(675, 321);

            // PictureBox styling
            this.Pb.Size = new System.Drawing.Size(250, 250);
            this.Pb.Location = new System.Drawing.Point(531, 30);
            this.Pb.BackColor = this.BackColor; // Set PictureBox background color to form color
            this.Pb.SizeMode = PictureBoxSizeMode.Zoom;
            this.Pb.BorderStyle = BorderStyle.FixedSingle; // Set a black border to PictureBox

            // DataGridView styling
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;

            // Additional styling can be added based on your preferences
            // ...

            this.ResumeLayout(false);
            this.PerformLayout();
        

      

        // Rest of your code...

            this.ResumeLayout(false);
            this.PerformLayout();

            this.ResumeLayout(false);
            this.PerformLayout();

            this.ResumeLayout(false);
            this.PerformLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 655);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.KustutaBtn);
            this.Controls.Add(this.Uuendabtn);
            this.Controls.Add(this.Todebox);
            this.Controls.Add(this.HindBox);
            this.Controls.Add(this.kogusBox);
            this.Controls.Add(this.Todelbl);
            this.Controls.Add(this.Hindlbl);
            this.Controls.Add(this.Koguslbl);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.Pb);
            this.Name = "Pood";
            this.Text = "Pood";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        












        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Koguslbl;
        private System.Windows.Forms.Label Hindlbl;
        private System.Windows.Forms.Label Todelbl;
        private System.Windows.Forms.TextBox kogusBox;
        private System.Windows.Forms.TextBox HindBox;
        private System.Windows.Forms.TextBox Todebox;
        private System.Windows.Forms.Button Uuendabtn;
        private System.Windows.Forms.Button KustutaBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox Pb;
        private System.Windows.Forms.DataGridView dgv;
    }
}

