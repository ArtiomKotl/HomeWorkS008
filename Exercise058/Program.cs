// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18


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

void PrintArray2D(int[,] arrayPrint)
{
  for (int i = 0; i < arrayPrint.GetLength(0); i++)
  {
    for (int j = 0; j < arrayPrint.GetLength(1); j++)
    {
      if (j == (arrayPrint.GetLength(1) - 1))
        Console.WriteLine(String.Format("{0,5}", arrayPrint[i, j]));
      else
        Console.Write(String.Format("{0,5} ", arrayPrint[i, j]));
    }
  }
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

int ReceiveMinMax(string minOrMax)
{
  Console.Write($"Введите значение {minOrMax}: ");
  int.TryParse(Console.ReadLine(), out int result);
  return result;
}


int[,] MatrixMultiplication(int[,] arrayOne, int[,] arrayTwo)
{
  int[,] resultMatrix = new int[arrayOne.GetLength(0), arrayTwo.GetLength(1)];
  for (int i = 0; i < resultMatrix.GetLength(0); i++)
  {
    for (int j = 0; j < resultMatrix.GetLength(1); j++)
    {
      for (int k = 0; k < arrayOne.GetLength(1); k++)
      {
        resultMatrix[i, j] = resultMatrix[i, j] + (arrayOne[i, k] * arrayTwo[k, j]);
      }
    }
  }
  return resultMatrix;
}


Console.WriteLine("Параметры первой матрицы:");
int m = NumberOfRows();
int n = NumberOfColumns();
int min = ReceiveMinMax("минимума");
int max = ReceiveMinMax("максимума");
int[,] array2dOne = Generate2DArray(m, n, min, max);

Console.WriteLine();
Console.WriteLine("Параметры второй матрицы:");
m = NumberOfRows();
n = NumberOfColumns();
min = ReceiveMinMax("минимума");
max = ReceiveMinMax("максимума");
int[,] array2dTwo = Generate2DArray(m, n, min, max);

Console.WriteLine();
Console.WriteLine("Сгенерированная первая матрица:");
PrintArray2D(array2dOne);
Console.WriteLine();
Console.WriteLine("Сгенерированная вторая матрица:");
PrintArray2D(array2dTwo);

if (array2dOne.GetLength(1) != array2dTwo.GetLength(0))
{
  Console.WriteLine("Выполнение умножения двух матриц невозможно,\n"
          + "так как Матрицы не согласованны ");
  return;
}

int[,] MultiMatrix = MatrixMultiplication(array2dOne, array2dTwo);
Console.WriteLine();
Console.WriteLine("Произведение двух матриц:");
PrintArray2D(MultiMatrix);