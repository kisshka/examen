using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using MinDistanceFounder;

namespace MinDistanceFounderTest
{
    public class MinDistanceFounderTest
    {
        [Fact]
        public void DistanceFounderTest()
        {
            WaysFounder founder = new WaysFounder();
            double[,] mapGraph = {

                {0,      0.94,   10000,     10000,     10000,     10000,     1.88,   10000,     10000,     10000},
                {0.94,   0,      0.66,   10000,     10000,     10000,     1.2,    10000,     10000,     10000},
                {10000,     0.66,   0,      1.04,   10000,     1.7,    10000,     10000,     10000,     10000},
                {10000,     10000,     1.04,   0,       10000,    0.77,   10000,     10000,    10000,      10000},
                {10000,     10000,     10000,     10000,       0,    1.92,   10000,     10000,     10000,     10000},
                {10000,     10000,     1.7,    0.77,    1.92,  0,      10000,     10000,     10000,     1.52},
                {1.88,   1.2,    10000,     10000,       10000, 10000,      0,      0.53,   10000,     10000},
                {10000,     10000,     10000,     10000,       10000,   10000,      0.53,  0,       1.54,  10000},
                {10000,     10000,     10000,     10000,       10000,   10000,      10000,    1.54,       0,  0.86},
                {10000,     10000,     10000,     10000,       10000,   1.52,      10000,  10000,       0.86,  0}
            };
            
            double expected = 0.94;
            double fact = founder.DistanceFounder(founder.Floyd(mapGraph), 1, 2);
            Assert.Equal(expected, fact);
        }
    }
}
