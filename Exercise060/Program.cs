// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)


void PrintArray3D(int[,,] arrayPrint)
{
  for (int i = 0; i < arrayPrint.GetLength(0); i++)
  {
    for (int j = 0; j < arrayPrint.GetLength(1); j++)
    {
      for (int k = 0; k < arrayPrint.GetLength(2); k++)
      {
        Console.Write(String.Format("{0,5} ", arrayPrint[i, j, k]));
        Console.Write(String.Format("({0,2},", i));
        Console.Write(String.Format("{0,2},", j));
        Console.Write(String.Format("{0,2});", k));
      }
      Console.WriteLine();
    }
    Console.WriteLine();
  }
}

int[,,] CreateRandom3DArray(int m, int n, int o, int min, int max)
{
  int number;
  int[,,] array3D = new int[m, n, o];
  Random random = new Random();

  for (int i = 0; i < array3D.GetLength(0); i++)
  {
    for (int j = 0; j < array3D.GetLength(1); j++)
    {
      for (int k = 0; k < array3D.GetLength(2); k++)
      {

        do
        {
          number = random.Next(min, max);
        } while (ArrayContains(array3D, number));
        array3D[i, j, k] = number;
      }
    }
  }

  return array3D;
}

bool ArrayContains(int[,,] array, int number)
{
  foreach (int item in array)
  {
    if (item == number)
    {
      return true;
    }
  }
  return false;
}


int GetDemension(string demension)
{
  Console.Write($"{demension} измерение. Введите количество элементов: ");
  int.TryParse(Console.ReadLine(), out int num);
  while (num <= 0)
  {
    Console.WriteLine("Попробуйте ещё: ");
    int.TryParse(Console.ReadLine(), out num);
  }
  return num;
}


Console.WriteLine("Задайте параметры для трёхмерного массива:");
int m = GetDemension("Первое");
int n = GetDemension("Второе");
int o = GetDemension("Третье");


int min = 10;
int max = 99;
int[,,] array3D = CreateRandom3DArray(m, n, o, min, max);
PrintArray3D(array3D);