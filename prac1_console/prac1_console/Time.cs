using System;

namespace prac1_console
{
    public class Time
    {
        private int _seconds = 0;
        private int _minutes = 0;
        private int _hours = 0;

        public int Seconds { set => _seconds = value; get => _seconds; }
        public int Minutes { set => _minutes = value; get => _minutes; }
        public int Hours { set => _hours = value; get => _hours; }

        public Time()
        {

        }

        public Time(int seconds, int minutes, int hours)
        {
            Check(seconds,minutes,hours);
        }

        public Time(int seconds)
        {
            _hours = seconds / 60 / 60;
            _minutes = (seconds / 60) - (_hours *60);
            _seconds = seconds-((_minutes * 60)+(_hours * 60*60));
        }

        public static Time operator + (Time time, int minutes)
        {
            time._minutes += minutes;
            if(time._minutes>60)
            {
                time._hours++;
                time._minutes -= 60;
            }
            return time;
        }

        public void Check(int seconds, int minutes, int hours)
        {
            if (seconds < 60)
            {
                _seconds += seconds;
            }
            else
            {
                seconds -= 60;
                _seconds += seconds;
                _minutes++;
            }
            if (minutes < 60)
            {
                _minutes += minutes;
            }
            else
            {
                minutes -= 60;
                _minutes += minutes;
                _hours++;
            }

            _hours += hours;
        }

        public void Check()
        {
           if(_seconds>60)
            {
                _seconds -= 60;
                _minutes++;
            }
           if(_minutes>60)
            {
                _minutes -= 60;
                _hours++;
            }
           if(_seconds<0)
            {
                _seconds += 60;
                _minutes--;
            }
           if(_minutes<0)
            {
                _minutes += 60;
                _hours--;
            }
           if(_hours<0)
            {
                Console.WriteLine("Error");
            }
                
         
        }

        public static Time operator - (Time time_start, Time time_finish)
        {
            time_start._seconds -= time_finish._seconds;
            time_start._minutes -= time_finish._minutes;
            time_start._hours -= time_finish._hours;
            time_start.Check();
            return time_start;
        }

        public static Time Parse(string time)//стат метод класса для разделения строки на экземпляр класса
        {
            string[] str = time.Split(' ');
            Time t = new Time();
            if(str.Length == 1)
            {
                int seconds = int.Parse(str[0]);
                t._hours = seconds / 60 / 60;
                t._minutes = (seconds / 60) - (t._hours * 60);
                t._seconds = seconds - ((t._minutes * 60) + (t._hours * 60 * 60));
                t.Check();
                return t;
            }
            t._seconds = int.Parse(str[0]);
            t._minutes = int.Parse(str[1]);
            t._hours = int.Parse(str[2]);
            t.Check();

            return t;
        }
          

        public override string ToString()//переопределение
        {
            return "Hours: "+_hours+" Minutes: "+_minutes+" Seconds: "+_seconds;
        }

        ~Time()//деструктор
        {
            Console.WriteLine("Object has destroyed.");
        }


    }
}
