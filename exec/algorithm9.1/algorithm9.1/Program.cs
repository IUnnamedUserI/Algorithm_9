using System;
using System.Diagnostics;

class HelloWorld
{
    static void Main()
    {
        Console.WriteLine("[System] Введите количество элементов массива");
        Console.Write(">>> ");
        int N = int.Parse(Console.ReadLine()); Console.WriteLine("[System] Введите искомое число");
        Console.Write(">>> ");
        int searchNumber = int.Parse(Console.ReadLine());

        Stopwatch Timer = Stopwatch.StartNew();
        Timer.Start();
        int[] array = new int[N];
        Random rnd = new Random();
        for (int i = 0; i < array.Length; i++) array[i] = rnd.Next(-500, 500);
        Array.Sort(array); // Сортировка

        if (N < 30)
            for (int i = 0; i < array.Length; i++) Console.WriteLine($"[{i}] {array[i]}");

        int searchID = Array.BinarySearch(array, searchNumber);
        if (searchID > 0) Console.WriteLine($"[System] Искомое значение: [{Array.BinarySearch(array, searchNumber)}] {searchNumber}");
        else Console.WriteLine("[System] Искомое значение не найдено");
        Console.WriteLine($"[System] Время выполнения: {Timer.Elapsed.TotalSeconds}");
        Timer.Stop();
        Console.ReadKey();
    }
}