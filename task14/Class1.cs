namespace task14;
using System;
using System.Threading;

public class DefiniteIntegral
{
    public static double Solve(double a, double b, Func<double, double> function, double step, int threadsNumber)
    {
        double result = 0.0;
        using var barrier = new Barrier(threadsNumber + 1);
        double segmentLength = (b - a) / threadsNumber;

        for (int i = 0; i < threadsNumber; i++)
        {
            int index = i;
            new Thread(() =>
            {
                double start = a + index * segmentLength;
                double end;
                if (index == threadsNumber)
                {
                    end = b;
                }
                else
                {
                    end = start + segmentLength;
                }
                double segmentRes = 0.0;

                for (double x = start; x < end; x += step)
                {
                    double nextX = Math.Min(x + step, end);
                    segmentRes += (function(x) + function(nextX)) * (nextX - x) / 2.0;
                }

                double temp, update;
                do
                {
                    temp = result;
                    update = temp + segmentRes;
                } while (Interlocked.CompareExchange(ref result, update, temp) != temp);

                barrier.SignalAndWait();
            }).Start();
        }

        barrier.SignalAndWait();
        return result;
    }
}
