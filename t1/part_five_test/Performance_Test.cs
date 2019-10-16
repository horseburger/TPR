using System;
using System.Diagnostics;
using NUnit.Framework;
using part_five;
using part_one;

namespace part_five_test
{
    [TestFixture]
    public class Performance_Test
    {
        private TimeSpan Time(Action toTime)
        {
            var timer = Stopwatch.StartNew();
            toTime();
            timer.Stop();
            return timer.Elapsed;
        }

        [Test]
        public void OneThousandEntries_Test()
        {
            DataRepository repo = new DataRepository(new DataFillerRandom(1000));
            TimeSpan time = Time((() => repo.Api.Fill(repo.Storage)));
            TestContext.WriteLine("Time / 1_000 / Linear: " + time.Milliseconds.ToString());
            Assert.That(time, Is.LessThanOrEqualTo(TimeSpan.FromSeconds(15)));
        }

        [Test]
        public void TenThousandEntries_Test()
        {
            DataRepository repo = new DataRepository(new DataFillerRandom(10000));
            TimeSpan time = Time((() => repo.Api.Fill(repo.Storage)));
            TestContext.WriteLine("Time / 10_000 / Linear: " + time.Milliseconds.ToString());
            Assert.That(time, Is.LessThanOrEqualTo(TimeSpan.FromSeconds(20)));
        }

        [Test]
        public void LogarithmicIncreaseInData_Test()
        {
            TestContext.WriteLine("Test for logarithmic increase in data:");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    int scale = (int)(j * Math.Pow(2, i));
                    DataRepository repo = new DataRepository(new DataFillerRandom(scale));
                    TimeSpan time = Time((() => repo.Api.Fill(repo.Storage)));
                    TestContext.WriteLine(scale + " elements / time: " + time);
                }
            }


        }
    }
}