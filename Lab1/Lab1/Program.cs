using System;
using System.Collections.Generic;
using System.Linq;

using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("TestProject1"), InternalsVisibleTo("GUI")]


namespace Lab1
{
    public class Item
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int Weight { get; set; }

        public double ValuePerWeight => (double)Value / Weight;
    }

    public class Result
    {
        public List<Item> ItemsInBag { get; set; } = new List<Item>();
        public int SumValue { get; set; }
        public int SumWeight { get; set; }

        public override string ToString()
        {

            var ids = ItemsInBag.Select(i => i.Id);
            return $"Przedmioty w plecaku (ID): {string.Join(", ", ids)}\n" +
                   $"Sumaryczna wartość: {SumValue}\n"+
                   $"Sumaryczna waga: {SumWeight}";
        }
    }

    public class Problem
    {
        private int n;
        private List<Item> items = new List<Item>();

        public Problem(int n, int seed)
        {
            this.n = n;
            Random rand = new Random(seed);

            for (int i = 0; i < n; i++)
            {
                items.Add(new Item
                {
                    Id = i,
                    Value = rand.Next(1, 11),
                    Weight = rand.Next(1, 11)
                });
            }
        }

        public Result Solve(int capacity)
        {
            var result = new Result();

            var sortedItems = items.OrderByDescending(i => i.ValuePerWeight).ToList();

            foreach (var item in sortedItems)
            {

                if (result.SumWeight + item.Weight <= capacity)
                {
                    result.ItemsInBag.Add(item);
                    result.SumValue += item.Value;
                    result.SumWeight += item.Weight;
                }
            }
            return result;
        }

        public override string ToString()
        {
            string info = "Lista wygenerowanych przedmiotów\n";
            foreach (var p in items)
            {
                info += $"ID: {p.Id,2} | Wartość: {p.Value,2} | Waga: {p.Weight,2} | Stosunek: {p.ValuePerWeight:F2}\n";
            }
            return info;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("GENERATOR PROBLEMU PLECAKOWEGO");

            Console.Write("Podaj liczbę przedmiotów: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Podaj ziarno losowania (seed): ");
            int seed = int.Parse(Console.ReadLine());

            Console.Write("Podaj pojemność plecaka: ");
            int capacity = int.Parse(Console.ReadLine());

            Problem problem = new Problem(n, seed);

            Console.WriteLine("\n" + problem.ToString());


            Result wynik = problem.Solve(capacity);

            Console.WriteLine("ROZWIĄZANIE (Algorytm zachłanny)");
            Console.WriteLine(wynik.ToString());

            Console.WriteLine("\nNaciśnij dowolny klawisz, aby zakończyć...");
            Console.ReadKey();
        }
    }
}