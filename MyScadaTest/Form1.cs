using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opc.Da;
using System.Windows.Threading;
using System.Data.SqlClient;


namespace MyScadaTest
{
    public partial class Form1 : Form
    {

        #region private fields

        Graphics graphics = new Graphics();
        
        private float temperature_value1;
        private float temperature_value2;
        private float temperature_value3;
        private float Random1;
        private float Random2;
        private float Random3;
        private float Random4;

        //строка подключения к БД
        
        static string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project VS\MyScadaTest _v1.4\MyScadaTest\Database1.mdf;Integrated Security=True";

        //таймер для обновления данных на экране
        DispatcherTimer tmr = new DispatcherTimer();
        //таймер для записи в БД
        DispatcherTimer tmr_write_SQL = new DispatcherTimer();
        //Экземпляр Connection для БД
        SqlConnection connection = new SqlConnection(conStr);
        //Переменная даты и времени для сохранения в БД
        DateTime myDateTime;

        #endregion

        #region OPC private fields

        private Opc.Da.Server server;
        private OpcCom.Factory fact = new OpcCom.Factory();
        private Subscription groupRead;
        private SubscriptionState groupState;
        private List<Item> itemsList = new List<Item>();
        #endregion

        #region Constructor

        public Form1()
        {
            InitializeComponent();
            
            //событие для обновления данных на экране
            tmr.Interval = TimeSpan.FromMilliseconds(10);
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Start();

            //событие для записи данных в БД
            tmr_write_SQL.Interval = TimeSpan.FromSeconds(1);
            tmr_write_SQL.Tick += new EventHandler(Write_SQL_server);
            tmr_write_SQL.Start();
            
            //подключение к OPC
            ConnectToOpcServer();
            
            //подключение к MSSQL и проверка наличия нужной таблицы
            CheckTableMSSQLServer();
        }


        #endregion

        #region CheckTableMSSQLServer

         public void CheckTableMSSQLServer() //подключение к MSSQL серверу и создание таблицы, если не создана
        {
            try
            {
                 connection.Open();//подключились к БД
                
                //Проверяем наличие нужной таблицы, если её нет, то создаем
                SqlCommand testCommand = new SqlCommand("SELECT name FROM sys.tables WHERE name='Table_1'", connection);//запрос на получение данных из системной таблицы для проверки наличия нашей табл.
                try
                {
                    testCommand.ExecuteScalar().ToString();//выполняем команду
                }
                catch (Exception ex)
                {
                    //Если таблицы нужной нет, то создаем её
                    testCommand.CommandText = "CREATE TABLE Table_1(T1 float NULL,T2 float NULL,T3 float NULL,R1 float NULL,R2 float NULL,R3 float NULL,R4 float NULL, Time_data datetime  NOT NULL PRIMARY KEY)";//Создаем команду на таблицу
                    //testCommand.CommandText = "CREATE TABLE Table_1(T1 float NULL,T2 float NULL,T3 float NULL)";//Создаем команду на таблицу
                    testCommand.ExecuteNonQuery();//выполняем команду
                }
            }
            catch (Exception ex)
            {
                richTextBox1.Text = ex.Message;
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion

        #region GUI Update

        void tmr_Tick(object sender, EventArgs e)//метод выполняется по событию с заданным интервалом времени
        {
            GUI_Tempetature_1.Text = temperature_value1.ToString("#.##");
            GUI_Tempetature_2.Text = temperature_value2.ToString("#.##");
            GUI_Tempetature_3.Text = temperature_value3.ToString("#.##");
        }
        #endregion

        #region write SQL server
        //подключаемся к БД и производим запись в контексте вторичного потока
        async void Write_SQL_server(object sender, EventArgs e)
        {
            //Подключение к БД
            try
            {
                await connection.OpenAsync();//подключились к БД
                //richTextBox1.Text = connection.State.ToString();
                myDateTime = DateTime.Now;//время для сохранения в БД
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");//формат даты
                
                //создание команды на вставку данных
                SqlCommand insertCommand = new SqlCommand("INSERT Table_1 VALUES (" + temperature_value1 + "," + temperature_value2 + "," + temperature_value3 + "," + Random1 + "," + Random2 + "," + Random3 + "," + Random4 + ",'" + sqlFormattedDate + "')", connection);
                //SqlCommand insertCommand = new SqlCommand("INSERT Table_1 VALUES (-1,-2.123456789,3,4,5,6,7,'" + sqlFormattedDate + "')", connection);
                //SqlCommand insertCommand = new SqlCommand("INSERT Table_1 VALUES (" + temperature_value1 + "," + temperature_value2 + "," + temperature_value3 + ")", connection);
                try
                {
                    await insertCommand.ExecuteNonQueryAsync();//выполнение команды на вставку
                }
                catch (Exception exx)
                {
                    richTextBox2.Text = exx.Message;
                }
            }
            catch (Exception ex)
            {
                richTextBox1.Text = ex.Message;
            }
            finally
            {
                richTextBox1.Text = connection.State.ToString();
                connection.Close();
            }
                
            
        }
        #endregion

        #region OPC Connection and Data Updated callback

        private void ConnectToOpcServer()//метод выполняется один раз. Вызывается через конструктор
        {
            // 1st: Create a server object and connect to the RSLinx OPC Server
            try
            {
                server = new Opc.Da.Server(fact, null);
                server.Url = new Opc.URL("opcda://localhost/Kepware.KEPServerEX.V6");


                //2nd: Connect to the created server
                server.Connect();

                //Read group subscription
                groupState = new Opc.Da.SubscriptionState();
                groupState.Name = "myReadGroup";
                groupState.UpdateRate = 200;
                groupState.Active = true;
                //Read group creation
                groupRead = (Opc.Da.Subscription)server.CreateSubscription(groupState);
                groupRead.DataChanged += new Opc.Da.DataChangedEventHandler(groupRead_DataChanged);

                Item item = new Item();
                item.ItemName = "Simulation Examples.Functions.Sine1";
                itemsList.Add(item);

                item = new Item();
                item.ItemName = "Simulation Examples.Functions.Sine2";
                itemsList.Add(item);

                item = new Item();
                item.ItemName = "Simulation Examples.Functions.Sine3";
                itemsList.Add(item);

                item = new Item();
                item.ItemName = "Simulation Examples.Functions.Random1";
                itemsList.Add(item);

                item = new Item();
                item.ItemName = "Simulation Examples.Functions.Random2";
                itemsList.Add(item);

                item = new Item();
                item.ItemName = "Simulation Examples.Functions.Random3";
                itemsList.Add(item);

                item = new Item();
                item.ItemName = "Simulation Examples.Functions.Random4";
                itemsList.Add(item);


                groupRead.AddItems(itemsList.ToArray());

               // groupStateWrite = new Opc.Da.SubscriptionState();
               // groupStateWrite.Name = "myWriteGroup";
               // groupStateWrite.Active = false;
              //  groupWrite = (Opc.Da.Subscription)server.CreateSubscription(groupStateWrite);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        //метод выполняется по событию. Событие возникает при изменении данных
        void groupRead_DataChanged(object subscriptionHandle, object requestHandle, ItemValueResult[] values)
        {
            //count = count + 1;//индикация на экране количества вычитываний данных
            foreach (ItemValueResult itemValue in values)
            {
                switch (itemValue.ItemName)
                {
                    case "Simulation Examples.Functions.Sine1":
                        temperature_value1 =(float)itemValue.Value;
                        //GUI_Temp1_name.Text = itemValue.ItemName.Substring(30,13);
                        break;

                    case "Simulation Examples.Functions.Sine2":
                        temperature_value2 = (float)itemValue.Value;
                       // GUI_Temp2_name.Text = itemValue.ItemName.Substring(30, 13);
                        break;

                    case "Simulation Examples.Functions.Sine3":
                        temperature_value3 = (float)itemValue.Value;
                       // GUI_Temp3_name.Text = itemValue.ItemName.Substring(30, 13);
                        break;

                    case "Simulation Examples.Functions.Random1":
                        Random1 = (float)itemValue.Value;
                        // GUI_Temp3_name.Text = itemValue.ItemName.Substring(30, 13);
                        break;

                    case "Simulation Examples.Functions.Random2":
                        Random2 = (float)itemValue.Value;
                        // GUI_Temp3_name.Text = itemValue.ItemName.Substring(30, 13);
                        break;

                    case "Simulation Examples.Functions.Random3":
                        Random3 = (float)itemValue.Value;
                        // GUI_Temp3_name.Text = itemValue.ItemName.Substring(30, 13);
                        break;

                    case "Simulation Examples.Functions.Random4":
                        Random4 = (float)itemValue.Value;
                        // GUI_Temp3_name.Text = itemValue.ItemName.Substring(30, 13);
                        break;




                }
            }
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            graphics.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();//закрываем соединение с БД при закрытии формы
        }
    }
    
}
    

