namespace AttendanceManagement
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btn_import = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_begin = new System.Windows.Forms.DateTimePicker();
            this.dtp_end = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_statistic = new System.Windows.Forms.Button();
            this.lab_setting = new System.Windows.Forms.Label();
            this.dtp_yearmonth = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_holiday = new System.Windows.Forms.ListBox();
            this.dtp_holiday = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_del = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_about = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(90, 253);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(276, 23);
            this.textBox1.TabIndex = 0;
            // 
            // btn_import
            // 
            this.btn_import.Location = new System.Drawing.Point(385, 251);
            this.btn_import.Margin = new System.Windows.Forms.Padding(2);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(74, 24);
            this.btn_import.TabIndex = 4;
            this.btn_import.Text = "导入";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 256);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "考勤文件:";
            // 
            // dtp_begin
            // 
            this.dtp_begin.CustomFormat = "";
            this.dtp_begin.Location = new System.Drawing.Point(98, 38);
            this.dtp_begin.Margin = new System.Windows.Forms.Padding(2);
            this.dtp_begin.Name = "dtp_begin";
            this.dtp_begin.Size = new System.Drawing.Size(86, 23);
            this.dtp_begin.TabIndex = 1;
            this.dtp_begin.Value = new System.DateTime(2016, 4, 11, 8, 30, 0, 0);
            this.dtp_begin.ValueChanged += new System.EventHandler(this.dtp_begin_ValueChanged);
            // 
            // dtp_end
            // 
            this.dtp_end.Location = new System.Drawing.Point(98, 78);
            this.dtp_end.Margin = new System.Windows.Forms.Padding(2);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.Size = new System.Drawing.Size(86, 23);
            this.dtp_end.TabIndex = 2;
            this.dtp_end.Value = new System.DateTime(2016, 4, 11, 17, 30, 0, 0);
            this.dtp_end.ValueChanged += new System.EventHandler(this.dtp_end_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "上班时间：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "下班时间：";
            // 
            // btn_statistic
            // 
            this.btn_statistic.Location = new System.Drawing.Point(464, 252);
            this.btn_statistic.Name = "btn_statistic";
            this.btn_statistic.Size = new System.Drawing.Size(75, 23);
            this.btn_statistic.TabIndex = 6;
            this.btn_statistic.Text = "统计";
            this.btn_statistic.UseVisualStyleBackColor = true;
            this.btn_statistic.Click += new System.EventHandler(this.btn_output_Click);
            // 
            // lab_setting
            // 
            this.lab_setting.AutoSize = true;
            this.lab_setting.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_setting.Location = new System.Drawing.Point(390, 292);
            this.lab_setting.Name = "lab_setting";
            this.lab_setting.Size = new System.Drawing.Size(149, 12);
            this.lab_setting.TabIndex = 7;
            this.lab_setting.Text = "作者： sunbin728@126.com";
            this.lab_setting.Click += new System.EventHandler(this.lab_setting_Click);
            // 
            // dtp_yearmonth
            // 
            this.dtp_yearmonth.Location = new System.Drawing.Point(98, 182);
            this.dtp_yearmonth.Margin = new System.Windows.Forms.Padding(2);
            this.dtp_yearmonth.Name = "dtp_yearmonth";
            this.dtp_yearmonth.Size = new System.Drawing.Size(86, 23);
            this.dtp_yearmonth.TabIndex = 3;
            this.dtp_yearmonth.Value = new System.DateTime(2016, 4, 11, 17, 30, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 185);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 5;
            this.label5.Text = "考勤年月：";
            // 
            // lb_holiday
            // 
            this.lb_holiday.FormattingEnabled = true;
            this.lb_holiday.ItemHeight = 14;
            this.lb_holiday.Location = new System.Drawing.Point(403, 29);
            this.lb_holiday.Name = "lb_holiday";
            this.lb_holiday.Size = new System.Drawing.Size(118, 116);
            this.lb_holiday.TabIndex = 5;
            // 
            // dtp_holiday
            // 
            this.dtp_holiday.CustomFormat = "";
            this.dtp_holiday.Location = new System.Drawing.Point(403, 152);
            this.dtp_holiday.Margin = new System.Windows.Forms.Padding(2);
            this.dtp_holiday.Name = "dtp_holiday";
            this.dtp_holiday.Size = new System.Drawing.Size(118, 23);
            this.dtp_holiday.TabIndex = 6;
            this.dtp_holiday.Value = new System.DateTime(2016, 4, 11, 8, 30, 0, 0);
            this.dtp_holiday.ValueChanged += new System.EventHandler(this.dtp_begin_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(298, 32);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 14);
            this.label6.TabIndex = 5;
            this.label6.Text = "法定节假日：";
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(402, 189);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(52, 23);
            this.btn_add.TabIndex = 9;
            this.btn_add.Text = "添加";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_del
            // 
            this.btn_del.Location = new System.Drawing.Point(469, 189);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(52, 23);
            this.btn_del.TabIndex = 10;
            this.btn_del.Text = "移除";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.菜单ToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(551, 25);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 菜单ToolStripMenuItem
            // 
            this.菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem";
            this.菜单ToolStripMenuItem.Size = new System.Drawing.Size(12, 21);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_about});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 21);
            this.toolStripMenuItem1.Text = "菜单";
            // 
            // btn_about
            // 
            this.btn_about.Name = "btn_about";
            this.btn_about.Size = new System.Drawing.Size(100, 22);
            this.btn_about.Text = "关于";
            this.btn_about.Click += new System.EventHandler(this.btn_about_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 318);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.lb_holiday);
            this.Controls.Add(this.lab_setting);
            this.Controls.Add(this.btn_statistic);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtp_yearmonth);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp_holiday);
            this.Controls.Add(this.dtp_end);
            this.Controls.Add(this.dtp_begin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "考勤管理 v1.0";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_begin;
        private System.Windows.Forms.DateTimePicker dtp_end;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_statistic;
        private System.Windows.Forms.Label lab_setting;
        private System.Windows.Forms.DateTimePicker dtp_yearmonth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lb_holiday;
        private System.Windows.Forms.DateTimePicker dtp_holiday;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem btn_about;
    }
}

