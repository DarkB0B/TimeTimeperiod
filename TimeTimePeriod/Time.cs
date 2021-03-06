using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTimePeriod 
{
    public struct Time: IEquatable<Time>, IComparable<Time>
    {
        private readonly byte hours = 0;
        private readonly byte minutes = 0;
        private readonly byte seconds = 0;

        public byte Hours
        {
            get { return hours; }
            init
            {
                if (value < 0 || value >= 24)
                    throw new ArgumentOutOfRangeException();
                hours = value;
            }
        }
        public byte Minutes
        {
            get { return minutes; }
            init
            {
                if (value < 0 || value >= 60)
                    throw new ArgumentOutOfRangeException();
                minutes = value;
            }
        }
        public byte Seconds
        {
            get { return seconds; }
            init
            {
                if (value < 0 || value >= 60)
                    throw new ArgumentOutOfRangeException();
                seconds = value;
            }
        }
        public Time(byte hours, byte minutes, byte seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
        public Time(byte hours, byte minutes)
        {
            Hours = hours;
            Minutes = minutes;
        }
        public Time(byte hours)
        {
            Hours = hours;
        }
        public Time(string time)
        {
            string[] data = time.Split(':');
            Hours = Convert.ToByte(data[0]);
            Minutes = Convert.ToByte(data[1]);
            Seconds = Convert.ToByte(data[2]);

        }
        public override string ToString()
        {
            return $"{hours:00}:{minutes:00}:{seconds:00}";
        }
        public bool Equals(Time other)
        {
            if(Hours == other.Hours && minutes == other.Minutes && seconds == other.Seconds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override bool Equals(object obj)
        {
            return obj is Time && Equals(obj);
        }

        public int CompareTo(Time other) 
        {
            if (this.Equals(other))
            {
                return 0;
            } 
            else if(this.Hours != other.Hours)
            {
                return this.Hours.CompareTo(other.Hours);
            }
            else if(other.Minutes != this.Minutes)
            {
                return other.Minutes.CompareTo(this.Minutes);
            }
            else
            {
                return this.Seconds.CompareTo(other.Seconds);
            }
        }
        public static bool operator !=(Time t1, Time t2)
        {
            return !(t1.Equals(t2));
        }
        public static bool operator ==(Time t1, Time t2)
        {
            return t1.Equals(t2);
        }
        public static bool operator <(Time t1, Time t2)
        {
            return t1.CompareTo(t2) < 0;
        }
        public static bool operator >(Time t1, Time t2)
        {
            return t1.CompareTo(t2) > 0;
        }
        public static bool operator <=(Time t1, Time t2)
        {
            return t1.CompareTo(t2) <= 0;
        }
        public static bool operator >=(Time t1, Time t2)
        {
            return t1.CompareTo(t2) >= 0;
        }
        public override int GetHashCode()
        {
            return (hours * 3600 + minutes * 60 + seconds);
        }
        public static Time operator +(Time t1, TimePeriod t2)
        {
            return t1.Plus(t2);
        }
        public Time Plus(TimePeriod t2)
        {
            TimePeriod t1 = new TimePeriod((int)this.hours, (int)this.minutes, (int)this.seconds);
            TimePeriod t3 = t1 + t2;
            string[] data = t3.ToString().Split(":");         
            int Hours = Convert.ToInt32(data[0]);
            int Minutes = Convert.ToInt32(data[1]);
            int Seconds = Convert.ToInt32(data[2]);            
            while (Hours >= 24)
            {
                Hours -= 24;
            }
            return new Time((byte)Hours, (byte)Minutes, (byte)Seconds);
            
        }
        public static Time Substract(Time t, TimePeriod t2)
        {
            TimePeriod t1 = new TimePeriod(t.ToString());
            TimePeriod t3 = t1 - t2;
            string[] data = t3.ToString().Split(":");
            int Hours = Convert.ToInt32(data[0]);
            int Minutes = Convert.ToInt32(data[1]);
            int Seconds = Convert.ToInt32(data[2]);
            if (Hours < 0)
            {
                throw new ArgumentException();
            }
            if (Minutes < 0)
            {
                if(Hours >= 1) 
                {
                    Hours -= 1;
                    Minutes += 60;
                }
                else
                {
                    throw new ArgumentException();
                }
                
            }
            if (Seconds < 0)
            {
                if (Minutes >= 1)
                {
                    Minutes -= 1;
                    Seconds += 60;
                }
                else
                {
                    if (Hours >= 1)
                    {
                        Hours -= 1;
                        Minutes += 59;
                        Seconds += 60;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }              
            }
            Time result = new Time((byte)Hours, (byte)Minutes, (byte)Seconds);
            return result;
        }
        public static Time operator -(Time t1, TimePeriod t2)
        {
            return Time.Substract(t1, t2);
        }

    }
}
