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
    public partial class Machine1 : System.Web.UI.Page
    {
        private float t1, t2;
        string _ExceptionT1, _ExceptionT2;
        SqlConnection connect;
        DateTime myDateTimeNow;
        TimeSpan Delay = new TimeSpan (00,00,02);
        DataTable TableTemperature = new DataTable("Temperature");


        protected float temperatura1
        {
            get { return t1; }
        }
        protected float temperatura2
        {
            get { return t2; }
        }
        protected string ExceptionT1
        {
            get { return _ExceptionT1; }
        }
        protected string ExceptionT2
        {
            get { return _ExceptionT2; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["Database1ConnectionString"].ConnectionString;
           connect = new SqlConnection(ConnectionString);
            connect.Open();
            this.DataBind();
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            if (connect!=null && connect.State !=ConnectionState.Closed)
            {
                connect.Close();
            }
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
        //Показываем текущие значения температуры по кнопке
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                myDateTimeNow = DateTime.Now;
                //вычитаем из текущего времени 2 секунды, чтобы приложение успело сохранить в БД
                DateTime TimeQuery = myDateTimeNow - Delay;
                string sqlFormattedDate = TimeQuery.ToString("yyyy-MM-dd HH:mm:ss");//формат даты
                SqlCommand command = new SqlCommand("SELECT T1, T2 FROM Table_1 WHERE Time_data = '"+sqlFormattedDate+"'  ", connect);
                //Создание адаптера
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                //Выборка данных согласно команды в созданную таблицу
                adapter.Fill(TableTemperature);
                //Привязка                                 
                t1 =Convert.ToSingle(TableTemperature.Rows[0][0]);
                t2 = Convert.ToSingle(TableTemperature.Rows[0][1]);
                //привязка
                this.DataBind();
            }
            catch (Exception exx)
            {
                t1 = 0000;
                _ExceptionT1 = "Нет опроса датчика в настоящее время. Проверьте работу приложения, опрашивающего датчик";
                t2 = 0000;
                _ExceptionT2 = "Нет опроса датчика в настоящее время. Проверьте работу приложения, опрашивающего датчик";
                this.DataBind();
            }
        }
    }
}