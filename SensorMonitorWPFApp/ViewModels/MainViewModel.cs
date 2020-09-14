using Caliburn.Micro;
using MySql.Data.MySqlClient;
using OxyPlot;
using OxyPlot.Axes;
using SensorMonitorWPFApp.Helper;
using SensorMonitorWPFApp.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO.Ports;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace SensorMonitorWPFApp.ViewModels
{
    public class MainViewModel : Conductor<object>
    {
        const int MaxXValue = 50;
        const int MaxYValue = 1023;
        #region 변수
        int xValue, yValue;
        public int sub;
        public int Sub
        {
            get => sub;
            set
            {
                if (value < 0)
                    sub = 0;
                else
                    sub = value;
                NotifyOfPropertyChange(() => Sub);
            }
        }
        public int XValue
        {
            get => xValue;
            set
            {
                xValue = value;
                NotifyOfPropertyChange(() => XValue);
            }
        }
        public int YValue
        {
            get => yValue;
            set
            {
                yValue = value;
                NotifyOfPropertyChange(() => YValue);
            }
        }

        
        bool zoomChk = false;
        //시리얼
        public List<string> Serial { get; set; }
        SerialPort selSerial;

        //시뮬레이션
        DispatcherTimer timer;
        Random rand = new Random();
        
        //그래프
        List<DataPoint> grhData, TmpData;
        public List<DataPoint> GrhData
        {
            get => grhData;
            set
            {
                grhData = value;
                NotifyOfPropertyChange(() => GrhData);
            }
        }

        List<SensorData> photoDatas = new List<SensorData>();
        DateTime currentTime;
        
        bool isConnected = false;
        public bool IsConnected
        {
            get => isConnected;
            set
            {
                isConnected = value;
                NotifyOfPropertyChange(() => IsConnected);
                NotifyOfPropertyChange(() => CanConnPort);
                NotifyOfPropertyChange(() => CanDisPort);
            }
        }

        bool isSimulation=false;
        public bool IsSimulation
        {
            get => isSimulation;
            set
            {
                isSimulation = value;
                NotifyOfPropertyChange(() => IsSimulation);
                NotifyOfPropertyChange(() => CanConnPort);
            }
        }

        string selPortName;
        public string SelPortName
        {
            get => selPortName;
            set
            {
                selPortName = value;
                NotifyOfPropertyChange(() => SelPortName);
                NotifyOfPropertyChange(() => CanConnPort);
            }
        }

        string connPortName;
        public string ConnPortName
        {
            get => connPortName;
            set
            {
                connPortName = value;
                NotifyOfPropertyChange(() => ConnPortName);
            }
        }

        string connectTime = "연결시간 :";
        public string ConnectTime
        {
            get => connectTime;
            set
            {
                connectTime = value;
                NotifyOfPropertyChange(() => ConnectTime);
            }
        }

        string rtbLog;
        public string RtbLog
        {
            get => rtbLog;
            set
            {
                rtbLog = value;
                NotifyOfPropertyChange(() => RtbLog);
            }
        }

        ushort prgValue;
        public ushort PrgValue
        {
            get => prgValue;
            set
            {
                prgValue = value;
                NotifyOfPropertyChange(() => PrgValue);
            }
        }

        string recvValue;
        public string RecvValue
        {
            get => recvValue;
            set
            {
                recvValue = value;
                NotifyOfPropertyChange(() => RecvValue);
            }
        }

        string sensorCnt;
        public string SensorCnt
        {
            get => sensorCnt;
            set
            {
                sensorCnt = value;
                NotifyOfPropertyChange(() => SensorCnt);
            }
        }

        string portValue = "Port";
        public string PortValue
        {
            get => portValue;
            set
            {
                portValue = value;
                NotifyOfPropertyChange(() => PortValue);
            }
        }
        #endregion

        #region 함수
        //종료
        public void MenuSubItemClose()
        {
            System.Environment.Exit(0);
        }

        //프로그램 시작시 설정 값
        private void InitControls()
        {
            timer = new DispatcherTimer();
            TmpData = new List<DataPoint>();

            Serial = new List<string>();

            XValue = MaxXValue;
            YValue = MaxYValue;
            foreach (var item in SerialPort.GetPortNames())
            {
                Serial.Add(item);
            }
        }
        
        //서브창
        public void MenuSubItemInfo()
        {
            IWindowManager manager = new WindowManager();
            dynamic settings = new ExpandoObject();
            settings.ResizeMode = ResizeMode.NoResize;
            settings.Width = 580;
            settings.Height = 280;
            manager.ShowDialog(new InfoViewModel(), null, settings);
        }

        //포트 연결 해제
        public void ConnPort()
        {
            IsConnected = true;
            ConnPortName = SelPortName;

            selSerial = new SerialPort(ConnPortName);
            selSerial.Open();
            selSerial.DataReceived += Serial_DataReceived;

            ConnectTime = $"연결시간 : {DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}";
        }
        public void DisPort()
        {
            IsConnected = false;
            selSerial.DataReceived -= Serial_DataReceived;
            selSerial.Close();
        }

        //버튼
        public bool CanConnPort
        {
            get => !IsConnected && !string.IsNullOrEmpty(SelPortName) && !IsSimulation;
        }
        public bool CanDisPort
        {
            get => IsConnected;
        }

        //데이터 처리
        Dispatcher dispatcher = Application.Current.Dispatcher;
        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            RecvValue = selSerial.ReadLine();

            dispatcher.Invoke(DispatcherPriority.Normal, new System.Action(delegate
            {
                DisplayValue(RecvValue);
            }));
        }
        private void DisplayValue(string sVal)
        {
            try
            {
                if (ushort.Parse(sVal) > 1023) return;
                PrgValue = ushort.Parse(sVal);

                currentTime = DateTime.Now;
                SensorData data = new SensorData(currentTime, PrgValue);
                InsertDataToDB(data);
                photoDatas.Add(data);



                SensorCnt = photoDatas.Count.ToString();
                RtbLog += ($"{currentTime.ToString()} {sVal}\n");

                GraphDraw(photoDatas.Count, PrgValue);
                
                if (zoomChk)
                {
                    XValue = photoDatas.Count;
                    Sub = XValue - 10;
                }
                else
                {
                    Sub = 0;
                    if (photoDatas.Count <= MaxXValue) 
                        XValue = MaxXValue;
                    else
                        XValue = photoDatas.Count;
                }

                if (IsConnected)
                    PortValue = $"{selSerial.PortName}\n{PrgValue}";
                else
                    PortValue = $"{PrgValue}";
            }
            catch (Exception ex)
            {
                RtbLog += ($"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")} {ex.Message}\n");
            }
        }
        
        //그래프
        private void GraphDraw(double x, double y)
        {
            TmpData.Add(new DataPoint(x, y));
            GrhData = null;
            GrhData = TmpData;
        }
        
        //시뮬레이션
        public void SimulationStart()
        {
            if (!IsConnected && !IsSimulation)
            {
                IsSimulation = true;
                timer.Interval = TimeSpan.FromMilliseconds(1000);
                timer.Tick += Timer_Tick;
                timer.Start();
            }
        }
        public void SimulationStop()
        {
            IsSimulation = false;
            timer.Stop();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            ushort value = (ushort)rand.Next(0, 1023);
            RecvValue = value.ToString();
            DisplayValue(RecvValue);
        }

        //데이터베이스
        private void InsertDataToDB(SensorData data)
        {
            string strQuery = "INSERT INTO sensordatatbl " +
                " (Date, Value) " +
                " VALUES " +
                " (@Date, @Value) ";

            using (MySqlConnection conn = new MySqlConnection(Commons.STRCONN))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlParameter paramDate = new MySqlParameter("@Date", MySqlDbType.DateTime)
                {
                    Value = data.Date
                };
                cmd.Parameters.Add(paramDate);
                MySqlParameter paramValue = new MySqlParameter("@Value", MySqlDbType.Int32)
                {
                    Value = data.Value
                };
                cmd.Parameters.Add(paramValue);
                cmd.ExecuteNonQuery();
            }
        }

        public void ViewAll()
        {
            zoomChk = false;
        }
        public void Zoom()
        {
            zoomChk = true;
        }
        #endregion

        #region 생성자
        public MainViewModel()
        {
            InitControls();
        }
        #endregion

        #region 키입력
        public ICommand simulStartKey;
        public ICommand simulStopKey;
        public ICommand SimulStartKey => simulStartKey ?? (simulStartKey = new RelayCommand<object>(
            o => SimulationStart()));
        public ICommand SimulStopKey => simulStopKey ?? (simulStopKey = new RelayCommand<object>(
            o => SimulationStop()));
        #endregion

        
        
    }
}
