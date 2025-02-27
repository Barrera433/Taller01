using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller01
{
     public class Time
    {
        public  int _hour;
        private int _millisecond;
        private int _minute;
        private int _second;

        public Time()
        {

        }

        public Time(int hour)
        {
            _hour = hour;
        }


        public Time(int hour, int minute)
        {
            _hour = hour;
            _minute = minute;
        }


        public Time(int hour, int minute, int second)
        {
            _hour = hour;
            _minute = minute;
            _second = second;
        }

        public Time(int hour, int minute, int second, int millisecond)
        {
            _hour = ValidHour (hour);
            _minute = ValidMinute (minute);
            _second = ValidSecond (second);
            _millisecond = ValidMillinsecond (millisecond);
        }

        public int Hour 
        {
            get => _hour ;
            set => _hour = value;
        }

        public int Millisecond 
        {
            get => _millisecond;
            set => _millisecond = value;
        }

        public int Minute 
        {
            get => _minute;
            set => _minute = value;
        }

        public int Second
        {
            get => _second;
            set => _second = value;
        }

     
        internal int ToMilliseconds()
        {
            return (_hour * 3600000) + (_minute * 60000) + (_second * 1000) + _millisecond;
        }

        internal int ToMinutes()
        {
            return _hour * 60 + _minute + _second / 60 + _millisecond / 60000;
        }

        internal int ToSeconds()
        {
            return (_hour * 3600) + (_minute * 60) + _second;
        }

        internal Time Add(Time t3)
        {
            int totalMilliseconds = this.ToMilliseconds() + t3.ToMilliseconds();

            int newHour = (totalMilliseconds / 3600000) % 24;
            int newMinute = (totalMilliseconds % 3600000) / 60000;
            int newSecond = (totalMilliseconds % 60000) / 1000;
            int newMillisecond = totalMilliseconds % 1000;

            return new Time(newHour, newMinute, newSecond, newMillisecond);
        }

        internal bool IsOtherDay(Time t4)
        {
            return this._hour > t4._hour;
        }



        public override string ToString()
        {
            string ampm = _hour < 12 ? "AM" : "PM";
            int hour12 = _hour % 12 == 0 ? 12 : _hour % 12; 

            return $"{hour12:00}:{_minute:00}:{_second:00}.{_millisecond:000} {ampm}";
        }  

        private int ValidHour(int hour)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentException($" The hour: {hour}, not is valid. ");
            }

            return hour;
        }

        private int ValidMinute(int minute)
        {
            if (minute < 0 || minute > 59)
            {
                throw new ArgumentException($" The minute: {minute}, not is valid. ");
            }

            return minute;
        }

        private int ValidSecond(int second)
        {
            if (second < 0 || second > 59)
            {
                throw new ArgumentException($" The second: {second}, not is valid. ");
            }

            return second ;
        }

        private int ValidMillinsecond(int millinsecond)
        {
            if (millinsecond < 0 || millinsecond > 999)
            {
                throw new ArgumentException($" The millinsecond: {millinsecond}, not is valid. ");
            }

            return millinsecond;
        }

    }
}
