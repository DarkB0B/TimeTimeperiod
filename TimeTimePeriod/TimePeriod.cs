using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTimePeriod
{
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        private readonly long _seconds = 0;
        

        public TimePeriod(int hours, int minutes, int seconds)
        {
            if (hours < 0 || minutes < 0 || seconds < 0)
            {
                throw new ArgumentOutOfRangeException();               
            }
            _seconds = hours * 3600 + minutes * 60 + seconds;
        }
        public TimePeriod(int hours, int minutes)
        {
            if (hours < 0 || minutes < 0 )
            {
                throw new ArgumentOutOfRangeException();
            }
            _seconds = hours * 3600 + minutes * 60;
        }
        public TimePeriod(int hours)
        {
            if (hours < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            _seconds = hours * 3600;
        }
        public TimePeriod(string time)
        {
            string[] data = time.Split(':');
            int value = 0;
            int hours = int.Parse(data[0]);
            int minutes = 0;
            int seconds = 0;
            if (hours < 0)
            { 
                throw new ArgumentOutOfRangeException();
            }
            if(data.Length > 1) 
            {
                 minutes = int.Parse(data[1]); 
            }
           if(data.Length > 2) 
            {
                 seconds = int.Parse(data[2]);
            }
            value = hours * 3600 + minutes * 60 + seconds;

            _seconds = value;
            
        }
        public TimePeriod(Time t1, Time t2)
        {
            if (t1.Equals(t2))
            {
                _seconds = 0;
            }
            else if(t1 > t2)
            {
                long t1val = t1.Hours * 3600 + t1.Minutes * 60 + t1.Seconds;
                long t2val = t2.Hours * 3600 + t2.Minutes * 60 + t2.Seconds;
                _seconds = Math.Abs(t2val - t1val);
            }
            else
            {
                long t1val = t1.Hours * 3600 + t1.Minutes * 60 + t1.Seconds;
                long t2val = t2.Hours * 3600 + t2.Minutes * 60 + t2.Seconds;
                _seconds = Math.Abs(t1val - t2val);
            }
        }
        public override string ToString()
        {
            if(_seconds == 0)
            {
                return "00:00:00";
            }          
            double H = Math.Floor((double)(_seconds / 3600));
            double M = Math.Floor((_seconds - (H * 3600)) / 60);
            double S = _seconds - (H * 3600) - (M * 60);
            return $"{H:00}:{M:00}:{S:00}";
        }
        public int CompareTo(TimePeriod other)
        {
            return (int)(_seconds - other._seconds);
        }

        public bool Equals(TimePeriod other)
        {
            return _seconds == other._seconds;
        }
        public static bool operator ==(TimePeriod t1, TimePeriod t2)
        {
            return t1.Equals(t2);
        }
        public static bool operator !=(TimePeriod t1, TimePeriod t2)
        {
            return !t1.Equals(t2);
        }
        public static bool operator <(TimePeriod t1, TimePeriod t2)
        {
            return t1.CompareTo(t2) < 0;
        }
        public static bool operator >(TimePeriod t1, TimePeriod t2)
        {
            return t1.CompareTo(t2) > 0;
        }
        public static bool operator <=(TimePeriod t1, TimePeriod t2)
        {
            return t1.CompareTo(t2) <= 0;
        }
        public static bool operator >=(TimePeriod t1, TimePeriod t2)
        {
            return t1.CompareTo(t2) >= 0;
        }
        public TimePeriod Plus( TimePeriod t2)
        {
            long t3sec = this._seconds + t2._seconds;
            return new TimePeriod((int)t3sec);         
        }
        public static TimePeriod operator +(TimePeriod t1, TimePeriod t2)
        {
            return t1.Plus(t2);
        }
        public TimePeriod Substract(TimePeriod t2)
        {
            long sec = this._seconds - t2._seconds;
            if(sec < 0)
            {
                throw new ArithmeticException();
            }
            else
            {
                return new TimePeriod((int)sec);
            }

        }

        public override bool Equals(object obj)
        {
            if (obj is TimePeriod)
            {
                return Equals((TimePeriod)obj);
            }
            else
            {
                return false;
            }                
        }

        public override int GetHashCode()
        {
            return _seconds.GetHashCode();
        }
    }
}
