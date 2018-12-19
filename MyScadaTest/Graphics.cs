using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;
using System.IO;

namespace MyScadaTest
{
    public partial class Graphics : Form
    {
        //Поля
        ArrayList Arr_T1 = new ArrayList();
        ArrayList Arr_T2 = new ArrayList();
        ArrayList Arr_T3 = new ArrayList();
        ArrayList Arr_date_time = new ArrayList();
        //СОздание таблицы
        DataTable TableTemperature = new DataTable("Temperature");
        //Строка подключения к БД
        string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project VS\MyScadaTest _v1.4\MyScadaTest\Database1.mdf;Integrated Security=True";
        static DateTime myDateTime = DateTime.Now;
        string Date_time_for_NameSave = myDateTime.ToString("yyyy_dd_MM_HH_mm_ss");//формат даты

        public Graphics()
        {
            InitializeComponent();
            //настройка формата вывода даты и времени 
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            btn_Save_File.Enabled = false;
        }

        #region read SQL server
        //в контексте вторичного потока
        async void Read_SQL_server()
        {
            //Подключение к БД
            SqlConnection connection = new SqlConnection(conStr);
            try//
            {
                await connection.OpenAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //создание команды на выборку данных
            SqlCommand selectCommand = new SqlCommand("SELECT * FROM Table_1 WHERE [Time_data] BETWEEN '" + dateTimePicker1.Text + "' AND '" + dateTimePicker2.Text + "'", connection);
            //Создание адаптера
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);

            //Выборка данных согласно команды в созданную таблицу
            try
            {
                adapter.Fill(TableTemperature);
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
            finally
            {
                connection.Close();//закрываем соединение с БД
            }

            //Чистим график перед новым построением
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();

            //задаем временную шкалу по оси Х для всех графиков
            chart1.Series[0].XValueType = ChartValueType.DateTime;
            chart1.Series[1].XValueType = ChartValueType.DateTime;
            chart1.Series[2].XValueType = ChartValueType.DateTime;
            
            //настраиваем формат даты и времени, которые выводятся на оси Х
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd HH:mm:ss";

            //масштабирование графика/ по оси Y, по X не сделано
            //chart1.ChartAreas[0].AxisX.ScaleView.Zoom(convert.todouble(datetimepicker1.value.ticks), convert.todouble(datetimepicker2.value.ticks));
            chart1.ChartAreas[0].AxisY.ScaleView.Zoom(-100, 100);
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;

            for (int x = 0; x < TableTemperature.Rows.Count; x = x + 1)
            {
                //mySeriesOfPoint.Points.AddXY(Arr_date_time[x], Arr_T1[x]);
                if(cB_paint_T1.Checked)//если установлена галочка
                    chart1.Series[0].Points.AddXY(TableTemperature.Rows[x][3], TableTemperature.Rows[x][0]);
                    //chart1.Series[0].Points.AddXY(TableTemperature.Rows[x][0], TableTemperature.Rows[x][3]);
                if (cB_paint_T2.Checked)
                    chart1.Series[1].Points.AddXY(TableTemperature.Rows[x][3], TableTemperature.Rows[x][1]);
                if (cB_paint_T3.Checked)
                    chart1.Series[2].Points.AddXY(TableTemperature.Rows[x][3], TableTemperature.Rows[x][2]);
            }
  
        }
        #endregion

        #region SaveFle
        //Сохраяем выборку в файл
        void SaveFile()
        {
            // Создание файла.
            FileStream file = File.Create(@"D:\Отчет_"+ Date_time_for_NameSave +".txt");

            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine("Отчет за период времени с "+dateTimePicker1.Text+" по "+dateTimePicker2.Text+"");
            writer.WriteLine();//Перенос на новую строку
            for (int x = 0; x < TableTemperature.Rows.Count; x = x + 1)
            {
                if (cB_paint_T1.Checked)//если установлена галочка
                   writer.Write("T1: {0,-11:N2}",TableTemperature.Rows[x][0]);//запись Т1
                if (cB_paint_T2.Checked)
                    writer.Write("T2: {0,-11:N2}", TableTemperature.Rows[x][1]);//Запись Т2
                if (cB_paint_T3.Checked)
                    writer.Write("T3: {0,-11:N2}", TableTemperature.Rows[x][2]); ;//Запись Т3
                
                writer.WriteLine("Time: {0,-25}", TableTemperature.Rows[x][3]);//Запись времени
            }
            writer.Close();
            file.Close();
        }
        # endregion

        private void Graphics_Load(object sender, EventArgs e)
        {
          
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Чистим таблицу перед загрузкой новых данных с БД
            TableTemperature.Clear();
            
            //Подключаемся к БД, Делаем выборку, сохраняем данные в внутреннюю таблицу и строим график
            Read_SQL_server();

            //Делаем активной кнопку сохранения данных в файл
            btn_Save_File.Enabled = true;
        }
      
        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Save_File_Click(object sender, EventArgs e)
        {
            SaveFile();//Сохраняем выборку при нажатии кнопки
        }
    }
}
