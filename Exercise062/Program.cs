// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

void PrintArray2D(int[,] arrayPrint)
{
  for (int i = 0; i < arrayPrint.GetLength(0); i++)
  {
    Console.Write("[");
    for (int j = 0; j < arrayPrint.GetLength(1); j++)
    {
      if (j == (arrayPrint.GetLength(1) - 1))
        Console.WriteLine(String.Format("{0,2}]", arrayPrint[i, j]));
      else
        Console.Write(String.Format("{0,2} ", arrayPrint[i, j]));
    }
  }
}

int[,] CreationSpiral2DArray(int[,] array2D)
{
  int i = 0, j = 0;
  int count = 1;
  int direction = 1;
  bool correct = true;
  while (correct)
  {
    switch (direction)
    {
      case (0):
        {
          if (array2D[i, j + 1] != 0 &&
              array2D[i + 1, j] != 0)
          {
            array2D[i, j] = count;
            correct = !correct;
          }
          else
          {
            array2D[i, j] = count;
            count++;
            j++;
            direction = 1;
          }
          break;
        }
      case (1):
        {
          if (j < array2D.GetLength(1) - 1 &&
              array2D[i, j + 1] == 0)
          {
            array2D[i, j] = count;
            count++;
            j++;
          }
          else
          {
            array2D[i, j] = count;
            direction = 2;
          }
          break;
        }
      case (2):
        {
          if (i < array2D.GetLength(0) - 1 &&
              array2D[i + 1, j] == 0)
          {
            array2D[i, j] = count;
            count++;
            i++;
          }
          else
          {
            array2D[i, j] = count;
            direction = 3;
          }
          break;
        }
      case (3):
        {
          if (j > 0 &&
              array2D[i, j - 1] == 0)
          {
            array2D[i, j] = count;
            count++;
            j--;
          }
          else
          {
            array2D[i, j] = count;
            direction = 4;
          }
          break;
        }
      case (4):
        {
          if (i > 0 &&
              array2D[i - 1, j] == 0)
          {
            array2D[i, j] = count;
            count++;
            i--;
          }
          else
          {
            array2D[i, j] = count;
            direction = 0;
          }
          break;
        }
    }
  }
  return array2D;
}

int NumberOfColumns()
{
  Console.Write("Ведите количество столбцов матрицы: ");
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
  Console.Write("Ведите количество строк матрицы: ");
  int.TryParse(Console.ReadLine(), out int num);
  while (num <= 0)
  {
    Console.Write("Число меньше 1! Попробуйте ещё: ");
    int.TryParse(Console.ReadLine(), out num);
  }
  return num;
}


Console.WriteLine("Задайте параметры массива:");
int m = NumberOfRows();
int n = NumberOfColumns();
int[,] array2D = new int[m, n];

array2D = CreationSpiral2DArray(array2D);

Console.WriteLine();
Console.WriteLine("Заполненный спирально массив");
Console.WriteLine();
PrintArray2D(array2D);
