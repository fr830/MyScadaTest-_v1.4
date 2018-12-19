namespace MyScadaTest
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
            this.GUI_Temp1_name = new System.Windows.Forms.Label();
            this.GUI_Temp2_name = new System.Windows.Forms.Label();
            this.GUI_Temp3_name = new System.Windows.Forms.Label();
            this.GUI_Tempetature_1 = new System.Windows.Forms.Label();
            this.GUI_Tempetature_2 = new System.Windows.Forms.Label();
            this.GUI_Tempetature_3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GUI_Temp1_name
            // 
            this.GUI_Temp1_name.AutoSize = true;
            this.GUI_Temp1_name.Location = new System.Drawing.Point(31, 23);
            this.GUI_Temp1_name.Name = "GUI_Temp1_name";
            this.GUI_Temp1_name.Size = new System.Drawing.Size(76, 13);
            this.GUI_Temp1_name.TabIndex = 0;
            this.GUI_Temp1_name.Text = "Temperature 1";
            // 
            // GUI_Temp2_name
            // 
            this.GUI_Temp2_name.AutoSize = true;
            this.GUI_Temp2_name.Location = new System.Drawing.Point(31, 52);
            this.GUI_Temp2_name.Name = "GUI_Temp2_name";
            this.GUI_Temp2_name.Size = new System.Drawing.Size(76, 13);
            this.GUI_Temp2_name.TabIndex = 1;
            this.GUI_Temp2_name.Text = "Temperature 2";
            // 
            // GUI_Temp3_name
            // 
            this.GUI_Temp3_name.AutoSize = true;
            this.GUI_Temp3_name.Location = new System.Drawing.Point(31, 78);
            this.GUI_Temp3_name.Name = "GUI_Temp3_name";
            this.GUI_Temp3_name.Size = new System.Drawing.Size(76, 13);
            this.GUI_Temp3_name.TabIndex = 2;
            this.GUI_Temp3_name.Text = "Temperature 3";
            // 
            // GUI_Tempetature_1
            // 
            this.GUI_Tempetature_1.AutoSize = true;
            this.GUI_Tempetature_1.Location = new System.Drawing.Point(132, 23);
            this.GUI_Tempetature_1.Name = "GUI_Tempetature_1";
            this.GUI_Tempetature_1.Size = new System.Drawing.Size(35, 13);
            this.GUI_Tempetature_1.TabIndex = 3;
            this.GUI_Tempetature_1.Text = "label4";
            // 
            // GUI_Tempetature_2
            // 
            this.GUI_Tempetature_2.AutoSize = true;
            this.GUI_Tempetature_2.Location = new System.Drawing.Point(132, 52);
            this.GUI_Tempetature_2.Name = "GUI_Tempetature_2";
            this.GUI_Tempetature_2.Size = new System.Drawing.Size(35, 13);
            this.GUI_Tempetature_2.TabIndex = 4;
            this.GUI_Tempetature_2.Text = "label5";
            // 
            // GUI_Tempetature_3
            // 
            this.GUI_Tempetature_3.AutoSize = true;
            this.GUI_Tempetature_3.Location = new System.Drawing.Point(132, 77);
            this.GUI_Tempetature_3.Name = "GUI_Tempetature_3";
            this.GUI_Tempetature_3.Size = new System.Drawing.Size(35, 13);
            this.GUI_Tempetature_3.TabIndex = 5;
            this.GUI_Tempetature_3.Text = "label6";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Подключение к БД";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Запрос на запись в БД";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(141, 123);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(72, 30);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(141, 226);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(168, 78);
            this.richTextBox2.TabIndex = 12;
            this.richTextBox2.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 281);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Графики";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 352);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GUI_Tempetature_3);
            this.Controls.Add(this.GUI_Tempetature_2);
            this.Controls.Add(this.GUI_Tempetature_1);
            this.Controls.Add(this.GUI_Temp3_name);
            this.Controls.Add(this.GUI_Temp2_name);
            this.Controls.Add(this.GUI_Temp1_name);
            this.Name = "Form1";
            this.Text = "MySCADA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GUI_Temp1_name;
        private System.Windows.Forms.Label GUI_Temp2_name;
        private System.Windows.Forms.Label GUI_Temp3_name;
        private System.Windows.Forms.Label GUI_Tempetature_1;
        private System.Windows.Forms.Label GUI_Tempetature_2;
        private System.Windows.Forms.Label GUI_Tempetature_3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button button1;
    }
}

