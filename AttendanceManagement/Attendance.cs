using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceManagement
{
    public class Attendance
    {
        private string _name;
        private int _year;
        private int _month;
        private DateTime Work, Leave;
        public List<DateTime> l_late, l_leaveEarly, l_absence;
        public List<SubAttendance> l_subAttendance;
        public List<DateTime> l_holiday;

        public Attendance(string name, int year, int month, DateTime work, DateTime leave, List<DateTime> _l_holiday)
        {
            _name = name;
            _year = year;
            _month = month;

            Work = work;
            Leave = leave;
            l_holiday = _l_holiday;

            InitData();
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }
        public int Month
        {
            get { return _month; }
            set { _month = value; }
        }

        public void InitData()
        {
            l_late = new List<DateTime>();
            l_leaveEarly = new List<DateTime>();
            l_absence = new List<DateTime>();

            l_subAttendance = new List<SubAttendance>();

            int maxday = DateTime.DaysInMonth(Year, Month);
            for (int day=1;day<= maxday;day++)
            {
                DateTime daytime = new DateTime(Year, Month, day);
                bool isholiday = false;
                foreach(DateTime dt in l_holiday)
                {
                    if (dt.CompareTo(daytime) == 0)
                    {
                        isholiday = true;
                    }
                }


                if (!isholiday && daytime.DayOfWeek != DayOfWeek.Saturday && daytime.DayOfWeek != DayOfWeek.Sunday)
                { 
                    l_subAttendance.Add(new SubAttendance(daytime));
                }
            }
        }

        public void RecordAttendance(Record record)
        {
            foreach(SubAttendance subAttendance in l_subAttendance)
            {
                if(subAttendance.Day.CompareTo(record.day) == 0)
                {
                    DateTime worktime = new DateTime(record.day.Year, record.day.Month, record.day.Day,
                        Work.Hour, Work.Minute, 0);
                    DateTime leavetime = new DateTime(record.day.Year, record.day.Month, record.day.Day,
                        Leave.Hour, Leave.Minute, 0);
                    DateTime recordtime = new DateTime(record.day.Year, record.day.Month, record.day.Day,
                        record.time.Hour, record.time.Minute, record.time.Second);

                    subAttendance.Absence = false;
                    if (recordtime.CompareTo(worktime) <= 0 && subAttendance.Late == true)
                    {
                        subAttendance.Late = false;
                    }
                    else if (recordtime.CompareTo(leavetime) >= 0 && subAttendance.LeaveEarly == true)
                    {
                        subAttendance.LeaveEarly = false;
                    }
                }
            }
        }

        public void Statistic()
        {
            foreach (SubAttendance subAttendance in l_subAttendance)
            {
                if (subAttendance.Absence)
                {
                    l_absence.Add(subAttendance.Day);
                }
                else
                {
                    if (subAttendance.Late)
                    {
                        l_late.Add(subAttendance.Day);
                    }
                    if (subAttendance.LeaveEarly)
                    {
                        l_leaveEarly.Add(subAttendance.Day);
                    }
                }
            }
        }
    }

    public class SubAttendance
    {
        public DateTime Day;
        //是否迟到
        public bool Late;
        //是否早退
        public bool LeaveEarly;
        //是否缺勤
        public bool Absence;

        public SubAttendance(DateTime day)
        {
            Day = day;
            Late = true;
            LeaveEarly = true;
            Absence = true;
        }
    }
}
