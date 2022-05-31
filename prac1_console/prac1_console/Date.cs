using System;
using System.Linq;

namespace prac1_console
{
    internal class Date
    {
        public int day;
        public int month;
        public int year;
        private int maxdays;
        private static int[] maxdays30 = { 4, 6, 9, 11 };
        private static int[] maxdays31 = { 1, 3, 5, 7, 8, 10, 12 };

        public bool isLeap { private set; get; }

        public Date()
        {

        }

        public Date(int _day, int _month, int _year)
        {
            year = _year;
            if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
                isLeap = true;
            else
                isLeap = false;

            if (_month > 12)
                _month = 12;
            else if (_month < 1)
                _month = 1;

            month = _month;

            day = checkDays(_day);
        }

        private  int checkDays(int day)
        {
            if (maxdays31.Contains(month))
            {
                maxdays = 31;
                day = checkMaxDays(day);
            }
            else if (maxdays30.Contains(month))
            {
                maxdays = 30;

                day = checkMaxDays(day);
            }
            else if (month == 2 && isLeap)
            {
                maxdays = 29;
                day = checkMaxDays(day);
            }
            else if (month == 2 && !isLeap)
            {
                maxdays = 28;
                day = checkMaxDays(day);
            }
            return day;
        }

        private int checkMaxDays(int day)
        {
            if (day > maxdays)
            {
                day -= maxdays;
                month++;
                while (month > 12)
                {
                    month -= 12;
                    year++;
                }
                day = checkDays(day);
            }

            return day;
        }

        public static Date Parse(string str)
        {
            string[] array = str.Split(".");
            int parsedDay = Convert.ToInt32(array[0]);
            int parsedMonth = Convert.ToInt32(array[1]);
            int parsedYear = Convert.ToInt32(array[2]); 
            Date date = new Date(parsedDay,parsedMonth,parsedYear);
            return date;
        }

        public static Date operator +(Date date1, Date date2)
        {
            Date result = new Date();
            result.year = date1.year + date2.year;
            result.month = date1.month + date2.month;
            result.day = date1.day + date2.day;
            result.day = result.checkDays(result.day);
            return result;
        }

        public static Date operator +(Date date, int days)
        {
            date.day += days;
            date.day = date.checkDays(date.day);
            return date;
        }

        public static bool operator >(Date date1, Date date2)
        {
            if (date1.year>date2.year && date1.month > date2.month && date1.day > date2.day)
                return true;
            else
                return false;
        }

        public static bool operator <(Date date1, Date date2)
        {
            if (date1.year < date2.year && date1.month < date2.month && date1.day < date2.day)
                return true;
            else
                return false;
        }

        public static bool operator >=(Date date1, Date date2)
        {
            if (date1.year >= date2.year && date1.month >= date2.month && date1.day >= date2.day)
                return true;
            else
                return false;
        }

        public static bool operator <=(Date date1, Date date2)
        {
            if (date1.year <= date2.year && date1.month <= date2.month && date1.day <= date2.day)
                return true;
            else
                return false;
        }

        public static bool operator ==(Date date1, Date date2)
        {
            if (date1.year == date2.year && date1.month == date2.month && date1.day == date2.day)
                return true;
            else
                return false;
        }

        public static bool operator !=(Date date1, Date date2)
        {
            if (date1.year != date2.year && date1.month != date2.month && date1.day != date2.day)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return "Day: " + day + " Month: " + month + " Year: " + year; 
        }
    }
}
