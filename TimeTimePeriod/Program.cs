// See https://aka.ms/new-console-template for more information
using TimeTimePeriod;

Console.WriteLine("Hello, World!");


Time a  = new Time((byte)23, (byte)59, (byte)1);
TimePeriod b = new TimePeriod(0, 2, 0);
Time z = a.Plus(b);

Console.WriteLine(z.ToString());


