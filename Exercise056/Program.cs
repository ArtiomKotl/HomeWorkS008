// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка



int[,] Generate2DArray(int m, int n, int min, int max)
{
  int[,] array2D = new int[m, n];
  Random random = new Random();
  for (int i = 0; i < array2D.GetLength(0); i++)
  {
    for (int j = 0; j < array2D.GetLength(1); j++)
    {
      array2D[i, j] = random.Next(min, max + 1);
    }
  }
  return array2D;
}

void PrintArray2D(int[,] array)
{
  for (int i = 0; i < array.GetLength(0); i++)
  {
    for (int j = 0; j < array.GetLength(1); j++)
    {
      if (j == (array.GetLength(1) - 1))
        Console.WriteLine(String.Format("{0,4}", array[i, j]));
      else
        Console.Write(String.Format("{0,4} ", array[i, j]));
    }
  }
}

int NumberOfColumns()
{
  Console.Write("Ведите количество столбцов 2D массива: ");
  int.TryParse(Console.ReadLine(), out int num);
  while (num <= 0)
  {
    Console.Write("Число меньше 1! Попробуйте ещё: ");
    int.TryParse(Console.ReadLine(), out num);
  }
  return num;
}

int NumberOfRows()
{
  Console.Write("Ведите количество строк 2D массива: ");
  int.TryParse(Console.ReadLine(), out int num);
  while (num <= 0)
  {
    Console.Write("Число меньше 1! Попробуйте ещё: ");
    int.TryParse(Console.ReadLine(), out num);
  }
  return num;
}

int ReceiveMinMax(string minOrMax)
{
  Console.Write($"Введите значение {minOrMax}: ");
  int.TryParse(Console.ReadLine(), out int result);
  return result;
}

int MinimumSummaryLength(int[,] array2d)
{
  int[] summaryArray = new int[array2d.GetLength(0)];
  for (int i = 0; i < array2d.GetLength(0); i++)
  {
    for (int j = 0; j < array2d.GetLength(1); j++)
    {
      summaryArray[i] += array2d[i, j];
    }
  }
  int minSum = summaryArray[0];
  int minLengthNumber = 0;
  for (int i = 0; i < summaryArray.GetLength(0); i++)
  {
    if (minSum > summaryArray[i])
    {
      minSum = summaryArray[i];
      minLengthNumber = i;
    }
  }
  return minLengthNumber + 1;
}


int m = NumberOfRows();
int n = NumberOfColumns();
int min = ReceiveMinMax("минимума");
int max = ReceiveMinMax("максимума");

int[,] random2dArray = Generate2DArray(m, n, min, max);
PrintArray2D(random2dArray);

int number = MinimumSummaryLength(random2dArray);
Console.WriteLine("Номер строки с наименьшей суммой элементов: " + number + " строка.");