using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebScada2.Room_1
{
    public partial class Machine3 : System.Web.UI.Page
    {
        private float R1, R2;
        string _ExceptionT1_1_3, _ExceptionT2_1_3;
        SqlConnection connect_1_3;
        DateTime myDateTimeNow_1_3;
        TimeSpan Delay = new TimeSpan (00,00,02);
        DataTable TableTemperature_1_3 = new DataTable("Temperature");


        protected float Random1_1_3
        {
            get { return R1; }
        }
        protected float Random2_1_3
        {
            get { return R2; }
        }
        protected string ExceptionT1_1_3
        {
            get { return _ExceptionT1_1_3; }
        }
        protected string ExceptionT2_1_3
        {
            get { return _ExceptionT2_1_3; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["Database1ConnectionString"].ConnectionString;
            connect_1_3 = new SqlConnection(ConnectionString);
            connect_1_3.Open();
            this.DataBind();
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            if (connect_1_3 != null && connect_1_3.State !=ConnectionState.Closed)
            {
                connect_1_3.Close();
            }
           
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Label8.Text = DateTime.Now.ToLongTimeString();
        }

        protected void Button2_Click_1_3(object sender, EventArgs e)
        {

        }
        //Показываем текущие значения температуры по кнопке
        protected void Button3_Click_1_3(object sender, EventArgs e)
        {
            try
            {
                myDateTimeNow_1_3 = DateTime.Now;
                //вычитаем из текущего времени 2 секунды, чтобы приложение успело сохранить в БД
                DateTime TimeQuery = myDateTimeNow_1_3 - Delay;
                string sqlFormattedDate = TimeQuery.ToString("yyyy-MM-dd HH:mm:ss");//формат даты
                SqlCommand command = new SqlCommand("SELECT R2, R3 FROM Table_1 WHERE Time_data = '"+sqlFormattedDate+"'  ", connect_1_3);
                //Создание адаптера
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                //Выборка данных согласно команды в созданную таблицу
                adapter.Fill(TableTemperature_1_3);
                //Привязка                                 
                LbTemp1_1_3.Text = Convert.ToString(TableTemperature_1_3.Rows[0][0]);
                LbTemp2_1_3.Text = Convert.ToString(TableTemperature_1_3.Rows[0][1]);
                //привязка
                this.DataBind();
            }
            catch (Exception exx)
            {
                LbTemp1_1_3.Text = "Нет опроса датчика в настоящее время. Проверьте работу приложения, опрашивающего датчик";
                LbTemp2_1_3.Text = "Нет опроса датчика в настоящее время. Проверьте работу приложения, опрашивающего датчик";
                this.DataBind();
            }
        }
    }
}