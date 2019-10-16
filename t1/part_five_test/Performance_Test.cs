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
        public void TenThousandEntries_Test()
        {
            DataRepository repo = new DataRepository(new DataFillerRandom(10000));
            Assert.That(Time((() => repo.Api.Fill(repo.Storage))), Is.LessThanOrEqualTo(TimeSpan.FromSeconds(20)));
        }

        [Test]
        public void OneThousandEntries_Test()
        {
            DataRepository repo = new DataRepository(new DataFillerRandom(1000));
            Assert.That(Time(() => repo.Api.Fill(repo.Storage)), Is.LessThanOrEqualTo(TimeSpan.FromSeconds(15)));
        }
        
        
    }
}