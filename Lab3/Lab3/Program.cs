using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Laboratorium3
{
    public class Matrix
    {
        public int Rows { get; }
        public int Cols { get; }
        public double[,] Data { get; }

        public Matrix(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            Data = new double[rows, cols];
        }

        public static Matrix GenerateRandom(int rows, int cols)
        {
            var matrix = new Matrix(rows, cols);
            var rand = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix.Data[i, j] = rand.Next(1, 11);
                }
            }
            return matrix;
        }

        public void Display()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write($"{Data[i, j],4} ");
                }
                Console.WriteLine();
            }
        }
    }

    public class MatrixCalculator
    {
        public static Matrix MultiplyParallel(Matrix A, Matrix B, int maxThreads)
        {
            var result = new Matrix(A.Rows, B.Cols);
            var options = new ParallelOptions { MaxDegreeOfParallelism = maxThreads };

            Parallel.For(0, A.Rows, options, i =>
            {
                for (int j = 0; j < B.Cols; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < A.Cols; k++)
                    {
                        sum += A.Data[i, k] * B.Data[k, j];
                    }
                    result.Data[i, j] = sum;
                }
            });

            return result;
        }

        public static Matrix MultiplyWithThreads(Matrix A, Matrix B, int threadCount)
        {
            var result = new Matrix(A.Rows, B.Cols);
            Thread[] threads = new Thread[threadCount];
            int rowsPerThread = A.Rows / threadCount;

            for (int t = 0; t < threadCount; t++)
            {
                int startRow = t * rowsPerThread;
                int endRow = (t == threadCount - 1) ? A.Rows : (t + 1) * rowsPerThread;

                threads[t] = new Thread(() =>
                {
                    for (int i = startRow; i < endRow; i++)
                    {
                        for (int j = 0; j < B.Cols; j++)
                        {
                            double sum = 0;
                            for (int k = 0; k < A.Cols; k++)
                            {
                                sum += A.Data[i, k] * B.Data[k, j];
                            }
                            result.Data[i, j] = sum;
                        }
                    }
                });
                threads[t].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int size = 100;
            int threadCount = 2; //Environment.ProcessorCount;

            var A = Matrix.GenerateRandom(size, size);
            var B = Matrix.GenerateRandom(size, size);

            RunTest("Sekwencyjnie (1 wątek)", () => MatrixCalculator.MultiplyParallel(A, B, 1));
            RunTest($"Zadanie 1: Parallel ({threadCount} wątków)", () => MatrixCalculator.MultiplyParallel(A, B, threadCount));
            RunTest($"Zadanie 2: Thread ({threadCount} wątków)", () => MatrixCalculator.MultiplyWithThreads(A, B, threadCount));
        }

        static void RunTest(string label, Action action)
        {
            long totalMs = 0;
            int trials = 3;

            for (int i = 0; i < trials; i++)
            {
                var sw = Stopwatch.StartNew();
                action();
                sw.Stop();
                totalMs += sw.ElapsedMilliseconds;
            }

            Console.WriteLine($"{label}: {totalMs / trials} ms");
        }
    }
}