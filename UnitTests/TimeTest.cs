using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeTimePeriod;
using System;
namespace UnitTests
{
    [TestClass]
    public class TimeTest
    {

    
        [TestMethod]
        [DataRow(8,4,5)]
        public void timeconstructorallparams(int a, int b, int c)
        {
            Time t1 = new Time((byte)a, (byte)b, (byte)c);
            Assert.AreEqual(t1.Hours, a);
            Assert.AreEqual(t1.Minutes, b);
            Assert.AreEqual(t1.Seconds, c);
        }
        [TestMethod]
        [DataRow(8, 4)]
        public void timeconstructor2params(int a, int b)
        {
            Time t1 = new Time((byte)a, (byte)b);
            Assert.AreEqual(t1.Hours, a);
            Assert.AreEqual(t1.Minutes, b);
            Assert.AreEqual(t1.Seconds, 0);
        }
        [TestMethod]
        [DataRow(8)]
        public void timeconstructor1param(int a)
        {
            Time t1 = new Time((byte)a);
            Assert.AreEqual(t1.Hours, a);
            Assert.AreEqual(t1.Minutes, 0);
            Assert.AreEqual(t1.Seconds, 0);
        }
        [TestMethod]
        [DataRow("5:15:10")]
        public void timeconstructorstring(string a)
        {
            Time t1 = new Time(a);
            Assert.AreEqual(t1.Hours, 5);
            Assert.AreEqual(t1.Minutes, 15);
            Assert.AreEqual(t1.Seconds, 10);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(25)]
        public void timeconstructor1paramoutofrange(int a)
        {
            Time t1 = new Time((byte)a);           
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(20, 61)]
        public void timeconstructor2paramoutofrange(int a,int b)
        {
            Time t1 = new Time((byte)a, (byte)b);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(21, 59, 61)]
        public void timeconstructor3paramoutofrange(int a,int b, int c)
        {
            Time t1 = new Time((byte)a, (byte)b, (byte)c);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow("25:65:10")]
        public void timeconstructorstringparamoutofrange(string a)
        {
            Time t1 = new Time(a);          
        }
        [TestMethod]
        [DataRow(8, 4, 5, "08:04:05")]
        public void timetostring(int a, int b, int c, string d)
        {
            Time t1 = new Time((byte)a, (byte)b, (byte)c);
            Assert.AreEqual(t1.ToString(), d);
        }
        [TestMethod]
        [DataRow(8, 4, 5)]
        public void timeequalstrue(int a, int b, int c)
        {
            Time t1 = new Time((byte)a, (byte)b, (byte)c);
            Time t2 = new Time((byte)a, (byte)b, (byte)c);
            Assert.IsTrue(t1.Equals(t2));
        }
        [TestMethod]
        [DataRow(8, 4, 5, 9)]
        public void timeequalsfalse(int a, int b, int c, int d)
        {
            Time t1 = new Time((byte)a, (byte)b, (byte)c);
            Time t2 = new Time((byte)a, (byte)b, (byte)d);
            Assert.IsFalse(t1.Equals(t2));
        }
        [TestMethod]
        [DataRow(8, 4, 5, 9)]
        public void timegreaterthan(int a, int b, int c, int d)
        {
            Time t1 = new Time((byte)a, (byte)b, (byte)c);
            Time t2 = new Time((byte)a, (byte)b, (byte)d);
            Assert.IsTrue(t1 < t2);
        }
        [TestMethod]
        [DataRow(8, 4, 5, 9)]
        public void timegreaterthanorqeual1(int a, int b, int c, int d)
        {
            Time t1 = new Time((byte)a, (byte)b, (byte)c);
            Time t2 = new Time((byte)a, (byte)b, (byte)d);
            Assert.IsTrue(t1 <= t2);
        }
        [TestMethod]
        [DataRow(8, 4, 5)]
        public void timegreaterthanorqeual2(int a, int b, int c)
        {
            Time t1 = new Time((byte)a, (byte)b, (byte)c);
            Time t2 = new Time((byte)a, (byte)b, (byte)c);
            Assert.IsTrue(t1 <= t2);
        }
        [TestMethod]
        [DataRow(8, 4, 5, 9)]
        public void timegreaterthanorqeual3(int a, int b, int c, int d)
        {
            Time t1 = new Time((byte)a, (byte)b, (byte)c);
            Time t2 = new Time((byte)a, (byte)b, (byte)d);
            Assert.IsFalse(t1 >= t2);
        }
        [TestMethod]
        [DataRow(8, 4, 5, 9)]
        public void timeqeualfalse(int a, int b, int c, int d)
        {
            Time t1 = new Time((byte)a, (byte)b, (byte)c);
            Time t2 = new Time((byte)a, (byte)b, (byte)d);
            Assert.IsFalse(t1 == t2);
        }
        [TestMethod]
        [DataRow(8, 4, 5)]
        public void timeqeualtrue(int a, int b, int c)
        {
            Time t1 = new Time((byte)a, (byte)b, (byte)c);
            Time t2 = new Time((byte)a, (byte)b, (byte)c);
            Assert.IsTrue(t1 == t2);
        }
        [TestMethod]
        [DataRow(8, 4, 5, 9)]
        public void timenotqeual(int a, int b, int c, int d)
        {
            Time t1 = new Time((byte)a, (byte)b, (byte)c);
            Time t2 = new Time((byte)a, (byte)b, (byte)d);
            Assert.IsTrue(t1 != t2);
        }
    }

}