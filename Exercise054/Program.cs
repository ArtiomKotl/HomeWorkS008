// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

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

int[,] SortArray2d(int[,] oldArray2D)
{
  int[,] sortArray2D = new int[oldArray2D.GetLength(0), oldArray2D.GetLength(1)];
  sortArray2D = oldArray2D;
  int temp = 0;
  int max = 0;
  for (int i = 0; i < sortArray2D.GetLength(0); i++)
  {
    for (int j = 0; j < sortArray2D.GetLength(1) - 1; j++)
    {
      for (int k = j + 1; k < sortArray2D.GetLength(1); k++)
      {
        max = sortArray2D[i, j];
        if (max < sortArray2D[i, k])
        {
          temp = sortArray2D[i, k];
          sortArray2D[i, k] = sortArray2D[i, j];
          sortArray2D[i, j] = temp;
        }
      }
    }
  }
  return sortArray2D;
}

int m = NumberOfRows();
int n = NumberOfColumns();
int min = ReceiveMinMax("минимума");
int max = ReceiveMinMax("максимума");

int[,] random2dArray = Generate2DArray(m, n, min, max);
PrintArray2D(random2dArray);
int[,] sortArray2D = SortArray2d(random2dArray);
Console.WriteLine();
Console.WriteLine("В итоге получается вот такой Отсортированный массив:");
PrintArray2D(sortArray2D);