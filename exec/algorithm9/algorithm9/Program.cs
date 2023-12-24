using System;
using System.Diagnostics;

class HelloWorld
{
    public static SearchNumber SN = new SearchNumber();

    static void Main()
    {
        // Пользовательский ввод
        Console.WriteLine("[System] Введите количество элементов массива");
        Console.Write(">>> ");
        int N = int.Parse(Console.ReadLine());
        Console.WriteLine("[System] Введите искомое число");
        Console.Write(">>> ");
        int searchNumber = int.Parse(Console.ReadLine());

        // Генерация значений в массив и сортировка
        Stopwatch Timer = Stopwatch.StartNew();
        Timer.Start();
        int[] array = new int[N];
        Random rnd = new Random();
        for (int i = 0; i < array.Length; i++) array[i] = rnd.Next(-500, 500);
        array = ArraySort(array);

        // Вывод элементов, если их количество менее 30
        if (N < 30) for (int i = 0; i < array.Length; i++) Console.WriteLine($"[{i}] {array[i]}");

        SN = Binar(array, searchNumber, 0, array.Length - 1);
        if (SN.ID == -1) Console.WriteLine("[System] Искомое значения не было найдено");
        else Console.WriteLine($"[System] Искомое значение: [{SN.ID}] {SN.Number}");
        Console.WriteLine($"[System] Время выполнения: {Timer.Elapsed.TotalSeconds} сек.");
        Timer.Stop();
        Console.ReadKey();
    }

    // Метод сортировки
    static int[] ArraySort(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
            for (int j = 0; j < array.Length; j++)
                if (array[j] > array[i])
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
        return array;
    }

    // Метод бинарного поиска
    static SearchNumber Binar(int[] array, int number, int left, int right)
    {
        SearchNumber temp = new SearchNumber();

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (array[mid] == number)
            {
                temp = new SearchNumber(mid, number);
                break;
            }

            if (array[mid] < number) left = mid + 1;
            else right = mid - 1;
        }
        return temp;
    }
}

/*
Класс, созданный для упрощения работы со значениями.
Экземпляр содержит значения ID и Number, которые являются числовым
идентификатором и значением экземпляра соответственно.
*/
class SearchNumber
{
    public int ID;
    public int Number;

    public SearchNumber()
    {
        ID = -1;
        Number = int.MinValue;
    }

    public SearchNumber(int ID, int Number)
    {
        this.ID = ID;
        this.Number = Number;
    }
}