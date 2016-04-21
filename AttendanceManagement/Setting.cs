using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AttendanceManagement
{
    public partial class Setting : Form
    {
        FormMain form;
        public Setting()
        {
            InitializeComponent();
        }
        public Setting(FormMain f)
        {
            form = f;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tb_pass.Text != "19880830")
            {
                MessageBox.Show("管理员口令错误！");
                return;
            }
            string checktime = "true";
            if (comboBox1.Text == "否")
            {
                checktime = "false";
            }
            string license = dtp_endtime.Value.ToShortDateString() + "|" + tb_endCount.Text + "|" + checktime;
            string conffile = System.Environment.CurrentDirectory + "\\attendance.cnf";
            form.createLicense(conffile, license);
            form.EnableStatistic();
            MessageBox.Show("新License文件已生成。");
            this.Close();
        }
    }
}
