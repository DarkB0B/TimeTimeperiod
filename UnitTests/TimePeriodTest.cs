using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeTimePeriod;
using System;
namespace UnitTests
{
    [TestClass]
    public class TimePeriodTest
    {


        [TestMethod]
        [DataRow(8, 4, 5)]
        public void timeperiodconstructorallparams(int a, int b, int c)
        {
            TimePeriod t1 = new TimePeriod(a, b, c);
            Assert.AreEqual($"{a:00}:{b:00}:{c:00}", t1.ToString());
        }
        [TestMethod]
        [DataRow(8, 4)]
        public void timeperiodconstructor2params(int a, int b)
        {
            TimePeriod t1 = new TimePeriod(a, b);
            Assert.AreEqual($"{a:00}:{b:00}:{0:00}", t1.ToString());
        }
        [TestMethod]
        [DataRow(8)]
        public void timeperiodconstructor1param(int a)
        {
            TimePeriod t1 = new TimePeriod(a);
            Assert.AreEqual($"{a:00}:{0:00}:{0:00}", t1.ToString());
        }
        [TestMethod]
        [DataRow(8, 4)]
        public void timeperiodconstructor2paramsfalse(int a, int b)
        {
            TimePeriod t1 = new TimePeriod(a, b);
            Assert.AreNotEqual($"{a:00}:{0:00}:{0:00}", t1.ToString());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(-25)]
        public void timeperiodconstructor1paramoutofrange(int a)
        {
            TimePeriod t1 = new TimePeriod(a);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(25, -1)]
        public void timeperiodconstructor2paramoutofrange(int a, int b)
        {
            TimePeriod t1 = new TimePeriod(a, b);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(25, 1, -2)]
        public void timeperiodconstructor3paramoutofrange(int a, int b, int c)
        {
            TimePeriod t1 = new TimePeriod(a, b, c);
        }
        [TestMethod]
        [DataRow(8, 4, 5, "08:04:05")]
        public void timeperiodconstructorstring(int a, int b, int c, string d)
        {
            TimePeriod t1 = new TimePeriod(a, b, c);
            TimePeriod t2 = new TimePeriod(d);
            Assert.AreEqual(t1, t2);
        }
        [TestMethod]
        [DataRow(8, 6, 5, "08:04:05")]
        public void timeperiodconstructorstringfalse(int a, int b, int c, string d)
        {
            TimePeriod t1 = new TimePeriod(a, b, c);
            TimePeriod t2 = new TimePeriod(d);
            Assert.AreNotEqual(t1, t2);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(8, 4, 5, "-1:04:05")]
        public void timeperiodconstructorstringexception(int a, int b, int c, string d)
        {           
            TimePeriod t2 = new TimePeriod(d);            
        }
        [TestMethod]
        [DataRow(8, 6, 5)]
        public void timeperiodconstructortime(int a, int b, int c)
        {
            Time t1 = new Time((byte)a, (byte)b, (byte)c);
            Time t2 = new Time((byte)a, (byte)b, (byte)c);
            TimePeriod tp1 = new TimePeriod(t1, t2);
            TimePeriod tp2 = new TimePeriod(0, 0, 0);
            Assert.AreEqual(tp1, tp2);          
        }
        [TestMethod]
        [DataRow(8, 6, 5, 9)]
        public void timeperiodconstructortime2(int a, int b, int c, int d)
        {
            Time t1 = new Time((byte)a, (byte)b, (byte)c);
            Time t2 = new Time((byte)a, (byte)b, (byte)d);
            TimePeriod tp1 = new TimePeriod(t1, t2);
            TimePeriod tp2 = new TimePeriod(0, 0, 4);
            Assert.AreEqual(tp1, tp2);
        }
        [TestMethod]
        [DataRow(8, 6, 5)]
        public void timeperiodconstructortimefalse(int a, int b, int c)
        {
            Time t1 = new Time((byte)a, (byte)b, (byte)c);
            Time t2 = new Time((byte)a, (byte)b, (byte)c);
            TimePeriod tp1 = new TimePeriod(t1, t2);
            TimePeriod tp2 = new TimePeriod(0, 5, 0);
            Assert.AreNotEqual(tp1, tp2);
        }
        [TestMethod]
        [DataRow(8, 6, 5, "08:04:05")]
        public void timeperiodtostringfalse(int a, int b, int c, string d)
        {
            TimePeriod t1 = new TimePeriod(a, b, c);
            
            Assert.AreNotEqual(t1.ToString(), d);
        }
        [TestMethod]
        [DataRow(10, 8, 5, "10:08:05")]
        public void timeperiodtostring(int a, int b, int c, string d)
        {
            TimePeriod t1 = new TimePeriod(a, b, c);

            Assert.AreEqual(t1.ToString(), d);
        }
        [TestMethod]
        [DataRow(8,6,5)]
        public void timeperiodequals(int a, int b, int c)
        {
            Time t1 = new Time((byte)a, (byte)b, (byte)c);
            Time t2 = new Time((byte)a, (byte)b, (byte)c);
            Assert.IsTrue(t1.Equals(t2));
        }
        [TestMethod]
        [DataRow(8, 6, 5)]
        public void timeperiodequals2(int a, int b, int c)
        {
            Time t1 = new Time((byte)a, (byte)b, (byte)c);
            Time t2 = new Time((byte)a, (byte)b, (byte)c);
            Assert.IsTrue(t1 == t2);
        }
        [TestMethod]
        [DataRow(8, 6, 5, 7)]
        public void timeperiodgreaterthan(int a, int b, int c, int d)
        {
            Time t1 = new Time((byte)a, (byte)b, (byte)c);
            Time t2 = new Time((byte)a, (byte)b, (byte)d);
            Assert.IsTrue(t1 < t2);
        }
        [TestMethod]
        [DataRow(8, 6, 5)]
        public void timeperiodgreaterthanfalse(int a, int b, int c)
        {
            Time t1 = new Time((byte)a, (byte)b, (byte)c);
            Time t2 = new Time((byte)a, (byte)b, (byte)c);
            Assert.IsFalse(t1 < t2);
        }

        [TestMethod]
        [DataRow(10, 16, 25, 57)]
        public void timeperiodgreaterthanorequal1(int a, int b, int c, int d)
        {
            Time t1 = new Time((byte)a, (byte)b, (byte)c);
            Time t2 = new Time((byte)a, (byte)b, (byte)d);
            Assert.IsTrue(t1 <= t2);
        }
        [TestMethod]
        [DataRow(10, 16, 25)]
        public void timeperiodgreaterthanorequal2(int a, int b, int c)
        {
            Time t1 = new Time((byte)a, (byte)b, (byte)c);
            Time t2 = new Time((byte)a, (byte)b, (byte)c);
            Assert.IsTrue(t1 <= t2);
        }

        [TestMethod]
        [DataRow(10, 16, 57, 51)]
        public void timeperiodgreaterthanorequal3(int a, int b, int c, int d)
        {
            Time t1 = new Time((byte)a, (byte)b, (byte)c);
            Time t2 = new Time((byte)a, (byte)b, (byte)d);
            Assert.IsTrue(t1 >= t2);
        }
        [TestMethod]
        [DataRow(5, 10)]
        public void TimePeriodPlusTimePeriod(int a, int b)
        {
            TimePeriod t1 = new TimePeriod(a);
            TimePeriod t2 = new TimePeriod(a);

            Assert.AreEqual(new TimePeriod(b), t1 + t2);
        }

    }    

}