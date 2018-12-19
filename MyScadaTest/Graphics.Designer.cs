namespace MyScadaTest
{
    partial class Graphics
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.btn_create_graphic = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cB_paint_T1 = new System.Windows.Forms.CheckBox();
            this.cB_paint_T2 = new System.Windows.Forms.CheckBox();
            this.cB_paint_T3 = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.btn_Save_File = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_create_graphic
            // 
            this.btn_create_graphic.Location = new System.Drawing.Point(12, 288);
            this.btn_create_graphic.Name = "btn_create_graphic";
            this.btn_create_graphic.Size = new System.Drawing.Size(136, 23);
            this.btn_create_graphic.TabIndex = 0;
            this.btn_create_graphic.Text = "Сформировать график";
            this.btn_create_graphic.UseVisualStyleBackColor = true;
            this.btn_create_graphic.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Дата и время ОТ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(402, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Дата и время ДО";
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            legend3.Title = "Температура";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(46, 12);
            this.chart1.Name = "chart1";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Legend = "Legend1";
            series7.Name = "Temperature_1";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Legend = "Legend1";
            series8.Name = "Temperature_2";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Legend = "Legend1";
            series9.Name = "Temperature_3";
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Series.Add(series9);
            this.chart1.Size = new System.Drawing.Size(788, 254);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            title3.Name = "Динамика температуры";
            title3.Text = "Динамика температуры";
            this.chart1.Titles.Add(title3);
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // cB_paint_T1
            // 
            this.cB_paint_T1.AutoSize = true;
            this.cB_paint_T1.Checked = true;
            this.cB_paint_T1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cB_paint_T1.Location = new System.Drawing.Point(598, 273);
            this.cB_paint_T1.Name = "cB_paint_T1";
            this.cB_paint_T1.Size = new System.Drawing.Size(39, 17);
            this.cB_paint_T1.TabIndex = 6;
            this.cB_paint_T1.Text = "Т1";
            this.cB_paint_T1.UseVisualStyleBackColor = true;
            // 
            // cB_paint_T2
            // 
            this.cB_paint_T2.AutoSize = true;
            this.cB_paint_T2.Checked = true;
            this.cB_paint_T2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cB_paint_T2.Location = new System.Drawing.Point(598, 293);
            this.cB_paint_T2.Name = "cB_paint_T2";
            this.cB_paint_T2.Size = new System.Drawing.Size(39, 17);
            this.cB_paint_T2.TabIndex = 7;
            this.cB_paint_T2.Text = "Т2";
            this.cB_paint_T2.UseVisualStyleBackColor = true;
            // 
            // cB_paint_T3
            // 
            this.cB_paint_T3.AutoSize = true;
            this.cB_paint_T3.Checked = true;
            this.cB_paint_T3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cB_paint_T3.Location = new System.Drawing.Point(598, 310);
            this.cB_paint_T3.Name = "cB_paint_T3";
            this.cB_paint_T3.Size = new System.Drawing.Size(39, 17);
            this.cB_paint_T3.TabIndex = 8;
            this.cB_paint_T3.Text = "Т3";
            this.cB_paint_T3.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(173, 290);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(158, 20);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(376, 289);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(166, 20);
            this.dateTimePicker2.TabIndex = 10;
            // 
            // btn_Save_File
            // 
            this.btn_Save_File.Enabled = false;
            this.btn_Save_File.Location = new System.Drawing.Point(12, 329);
            this.btn_Save_File.Name = "btn_Save_File";
            this.btn_Save_File.Size = new System.Drawing.Size(136, 23);
            this.btn_Save_File.TabIndex = 11;
            this.btn_Save_File.Text = "Сохранить на диск";
            this.btn_Save_File.UseVisualStyleBackColor = true;
            this.btn_Save_File.Click += new System.EventHandler(this.btn_Save_File_Click);
            // 
            // Graphics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 408);
            this.Controls.Add(this.btn_Save_File);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cB_paint_T3);
            this.Controls.Add(this.cB_paint_T2);
            this.Controls.Add(this.cB_paint_T1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_create_graphic);
            this.Name = "Graphics";
            this.Text = "Graphics";
            this.Load += new System.EventHandler(this.Graphics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_create_graphic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.CheckBox cB_paint_T1;
        private System.Windows.Forms.CheckBox cB_paint_T2;
        private System.Windows.Forms.CheckBox cB_paint_T3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button btn_Save_File;
    }
}