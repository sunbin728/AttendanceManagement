using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Net;

namespace AttendanceManagement
{
    
    public partial class FormMain : Form
    {
        int activeSettingCount = 0;
        string m_filename;
        List<Record> l_records = new List<Record>();
        //标准上班、下班时间
        DateTime WorkTime = DateTime.Now;
        DateTime LeaveTime = DateTime.Now;
        string License = "";
        bool IsCheckTime = true;
        //使用截止日期
        DateTime EndTime;
        //剩余使用次数
        int EndCount;
        //考勤的年月
        int Year = DateTime.Now.Year;
        int Month = DateTime.Now.Month - 1;
        Dictionary<string, Attendance> dic_Attendance = new Dictionary<string, Attendance>();
        List<DateTime> dt_listholiday = new List<DateTime>();
         
        public FormMain()
        {
            InitializeComponent();
            try 
            {
                if (!checkConf())
                {
                    btn_statistic.Enabled = false;
                    //System.Environment.Exit(0);
                }

                initCtrl();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void EnableStatistic()
        {
            btn_statistic.Enabled = true;
        }

        private void initCtrl()
        {
            this.dtp_begin.CustomFormat = "HH:mm";
            //使用自定义格式
            this.dtp_begin.Format = DateTimePickerFormat.Custom;
            //时间控件的启用
            this.dtp_begin.ShowUpDown = true;

            this.dtp_end.CustomFormat = "HH:mm";
            //使用自定义格式
            this.dtp_end.Format = DateTimePickerFormat.Custom;
            //时间控件的启用
            this.dtp_end.ShowUpDown = true;

            this.dtp_yearmonth.CustomFormat = "yyyy:MM";
            //使用自定义格式
            this.dtp_yearmonth.Format = DateTimePickerFormat.Custom;
            //时间控件的启用
            this.dtp_yearmonth.ShowUpDown = true;

            this.dtp_holiday.CustomFormat = "yyyy:MM:dd";
            //使用自定义格式
            this.dtp_holiday.Format = DateTimePickerFormat.Custom;
            //时间控件的启用


            //设置考勤年月
            dtp_yearmonth.Value = DateTime.Now.AddMonths(-1);


            //设置标准的考勤时间
            dtp_begin.Value = WorkTime;
            dtp_end.Value = LeaveTime;

        }

        private bool checkNetTime()
        {
            try
            {
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create("http://jerryboy.f3322.net:8181/now");
                httpRequest.Timeout = 3000;
                httpRequest.Method = "GET";
                HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                StreamReader sr = new StreamReader(httpResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("gb2312"));
                string result = sr.ReadToEnd();
                int status = (int)httpResponse.StatusCode;
                sr.Close();

                if (status != 200)
                {
                    MessageBox.Show("网络校时失败！");
                    return false;
                }
                else
                {
                    DateTime dt = DateTime.Parse(result);
                    DateTime now = DateTime.Now;
                    if (dt.Year != now.Year || dt.Month != now.Month || dt.Day != now.Day)
                    {
                        MessageBox.Show("本地时间与网络时间不一致!");
                        return false;
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        private bool checkConf()
        {
            string conffile = System.Environment.CurrentDirectory + "\\attendance.cnf";
            if (!File.Exists(conffile))
            {
                MessageBox.Show("没有发现License文件！");
                return false;
                //createLicense(conffile, "2016-05-15|30|0");
            }
            else
            {
                StreamReader sr = new StreamReader(conffile, Encoding.GetEncoding("GBK"));
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] cols = line.Split(new Char[] { '=' }, 2);
                    if (cols.Length != 2)
                    {
                        MessageBox.Show("配置文件格式错误！");
                        return false;
                    }
                    else if (cols[0] == "worktime")
                    {
                        WorkTime = DateTime.Parse(cols[1]);
                    }
                    else if (cols[0] == "leavetime")
                    {
                        LeaveTime = DateTime.Parse(cols[1]);
                    }
                    else if (cols[0] == "license")
                    {
                        License = Crypto.Decode(cols[1]);
                    }
                }
                sr.Close();
            }

            string[] licenses = License.Split('|');
            if(licenses.Length != 3)
            {
                MessageBox.Show("License格式错误！");
                return false;
            }
            else
            {
                EndTime = DateTime.Parse(licenses[0]);
                EndCount = int.Parse(licenses[1]);
                IsCheckTime = bool.Parse(licenses[2]);
            }

            if (!checkLicense())
            {
                return false;
            }
            if (IsCheckTime && !checkNetTime())
            {
                return false;
            }
            return true;
        }

        public void createLicense(string conffile, string license)
        {
            try
            {
                string en_license = Crypto.Encode(license);

                FileStream fs = new FileStream(conffile, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                string conf = @"worktime=08:30:00
leavetime=17:30:00
license= " + en_license;
                sw.Write(conf);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
                WorkTime = DateTime.Parse("08:30:00");
                LeaveTime = DateTime.Parse("17:30:00");
                dtp_begin.Value = WorkTime;
                dtp_end.Value = LeaveTime;
                License = license;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private bool checkLicense()
        {
            if (EndTime.CompareTo(DateTime.Now) < 0)
            {
                MessageBox.Show("License已到期！");
                return false;
            }
            if (EndCount <= 0)
            {
                MessageBox.Show("License已超过使用次数！");
                return false;
            }
            if (EndTime.CompareTo(new DateTime(Year, Month, 1)) < 0)
            {
                MessageBox.Show("考勤年月超过License使用期限！");
                return false;
            }
            return true;
        }
        private void initData()
        {

            //设置标准的考勤时间
            WorkTime = dtp_begin.Value;
            LeaveTime = dtp_end.Value;
            //设置考勤年月
            Year = dtp_yearmonth.Value.Year;
            Month = dtp_yearmonth.Value.Month;

            dic_Attendance.Clear();
            dt_listholiday.Clear();
            for (int i=0; i<lb_holiday.Items.Count;i++)
            {
                dt_listholiday.Add(DateTime.Parse(lb_holiday.Items[i].ToString()));
            }
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "文本文件|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                m_filename = openFileDialog.FileName;
                textBox1.Text = m_filename;
            }  
        }

        private void btn_output_Click(object sender, EventArgs e)
        {
            try
            {
                initData();
                Statistic(m_filename);
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message);
            }
        }

        //统计考勤
        public void Statistic(string path)
        {
            if (!checkLicense())
            {
                btn_statistic.Enabled = false;
                return;
            }
            if (IsCheckTime && !checkNetTime())
            {
                btn_statistic.Enabled = false;
                return;
            }
            if (path == null)
            {
                MessageBox.Show("请先导入原始考勤数据。");
                return;
            }
            StreamReader sr = new StreamReader(path, Encoding.GetEncoding("GBK"));
            string line;
            bool firstline = true;
            int namecol, daycol, timecol;
            namecol = daycol = timecol = -1;
            //收集考勤记录
            while ((line = sr.ReadLine()) != null)
            {
                line = Encoding.Default.GetString(Encoding.GetEncoding("GBK").GetBytes(line));
                string[] cols = line.Split(',');
                if (firstline == true)
                {
                    for(int i=0; i<cols.Length; i++)
                    {
                        if(cols[i] == "姓名")
                        {
                            namecol = i;
                        }else if (cols[i] == "日期")
                        {
                            daycol = i;
                        }else if (cols[i] == "时间")
                        {
                            timecol = i;
                        }
                    }
                    if (namecol == -1 || daycol == -1 || timecol == -1)
                    {
                        MessageBox.Show("文件格式错误，首行必须包含 姓名，日期，时间 字段。");
                        sr.Close();
                        return;
                    }
                    firstline = false;
                }
                else
                {
                    Record record = new Record();
                    for (int i = 0; i < cols.Length; i++)
                    {
                        if (i == namecol)
                        {
                            if (cols[i] != "")
                            {
                                record.name = cols[i];
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (i == daycol)
                        {
                            record.day = DateTime.Parse(cols[i]);
                        }
                        else if (i == timecol)
                        {
                            record.time = DateTime.Parse(cols[i]);
                        }
                    }
                    if (record.name != "")
                    {
                        l_records.Add(record);
                    }
                }  

            }
            sr.Close();

            //逐条计算考勤
            foreach (Record record in l_records)
            {
                if (dic_Attendance.ContainsKey(record.name) == false)
                {
                    dic_Attendance.Add(record.name, new Attendance(record.name, Year, Month, WorkTime, LeaveTime,dt_listholiday));
                }
                dic_Attendance[record.name].RecordAttendance(record);
            }

            string statisticFilename = System.Environment.CurrentDirectory + String.Format("\\statistic{0:D4}{1:D2}.csv", Year, Month);
            FileStream fs = new FileStream(statisticFilename, FileMode.Create);
            //FileStream fs = new FileStream("D:\\statistic.csv", FileMode.Create);
            //StreamWriter sw = new StreamWriter(fs);

            string title = "姓名,迟到日期,早退日期,缺勤日期" + Environment.NewLine;
            //title = Encoding.GetEncoding("GBK").GetString(Encoding.Default.GetBytes(title));
            byte[] data_title = Encoding.UTF8.GetBytes(title);
            byte[] data_title_gbk = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding("GBK"), data_title);
            fs.Write(data_title_gbk, 0, data_title_gbk.Length);
            //sw.Write(title);
            //统计
            foreach (Attendance attendance in dic_Attendance.Values)
            {
                attendance.Statistic();
                string str = attendance.Name + ",";
                string strlate = attendance.l_late.Count.ToString() + "天: ";
                string strearlyleave = attendance.l_leaveEarly.Count.ToString() + "天: ";
                string strabsence = attendance.l_absence.Count.ToString() + "天: ";
                foreach (DateTime dt in attendance.l_late)
                {
                    strlate = strlate + dt.ToShortDateString() + "|";
                }
                foreach (DateTime dt in attendance.l_leaveEarly)
                {
                    strearlyleave = strearlyleave + dt.ToShortDateString() + "|";
                }
                foreach (DateTime dt in attendance.l_absence)
                {
                    strabsence = strabsence + dt.ToShortDateString() + "|";
                }
                str = str + strlate + "," + strearlyleave + "," + strabsence + Environment.NewLine;
                //str = Encoding.GetEncoding("GBK").GetString(Encoding.Default.GetBytes(str));
                //开始写入
                //sw.Write(str);
                byte[] data = Encoding.UTF8.GetBytes(str);
                byte[] data_gbk = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding("GBK"), data);
                fs.Write(data_gbk, 0, data_gbk.Length);
            }
            //清空缓冲区
            //sw.Flush();
            //关闭流
            //sw.Close();
            fs.Close();
            MessageBox.Show("统计完成");
            EndCount = EndCount - 1;
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            string license = EndTime.ToShortDateString() + "|" + EndCount.ToString() + "|" + IsCheckTime.ToString();
            string conffile = System.Environment.CurrentDirectory + "\\attendance.cnf";

                FileStream fs = new FileStream(conffile, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                string conf = String.Format(@"worktime={0}
leavetime={1}
license={2}
", WorkTime.ToShortTimeString(), LeaveTime.ToShortTimeString(), Crypto.Encode(license));
                sw.Write(conf);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
        }

        private void dtp_begin_ValueChanged(object sender, EventArgs e)
        {
            WorkTime = dtp_begin.Value;
        }

        private void dtp_end_ValueChanged(object sender, EventArgs e)
        {
            LeaveTime = dtp_end.Value;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (!lb_holiday.Items.Contains(dtp_holiday.Value.ToShortDateString()))
            {
                lb_holiday.Items.Add(dtp_holiday.Value.ToShortDateString());
            }
            
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            lb_holiday.Items.RemoveAt(lb_holiday.SelectedIndex);
        }

        private void btn_about_Click(object sender, EventArgs e)
        {
            string about = String.Format(@"到期日期：{0}
剩余使用次数：{1}
是否网络校时：{2}", EndTime.ToShortDateString(), EndCount, IsCheckTime);
            MessageBox.Show(about);
        }

        private void lab_setting_Click(object sender, EventArgs e)
        {
            activeSettingCount++;
            if (activeSettingCount >= 10)
            {
                Setting setForm = new Setting(this);
                setForm.ShowDialog();
                if (!checkConf())
                {
                    btn_statistic.Enabled = false;
                    //System.Environment.Exit(0);
                }
            }
        }
    }

    public class Record
    {
        public string name;
        public DateTime day;
        public DateTime time;

        public Record()
        {
            name = "";
        }
    }
}
