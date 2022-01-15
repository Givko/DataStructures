namespace DataStructures.Solutions.Tests.Exams
{
    using DataStructures.Solutions.Exams.Legion.Interfaces;
    using DataStructures.Solutions.Exams.Legion.Models;
    using NUnit.Framework;
    using System;
    using System.Diagnostics;

    public class LegionSystemPerformanceTests
    {
        [Test]
        public void GetOrderedByHealth_1000_Enemies()
        {
            IArmy legion = new Legion();
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();

            for (int i = 0; i < 1_000; i++)
            {
                legion.Create(new Biomechanoid(i + 1, rnd.Next(500)));
            }

            sw.Start();
            legion.GetOrderedByHealth();
            sw.Stop();

            Assert.IsTrue(sw.ElapsedMilliseconds <= 100);
        }
    }
}