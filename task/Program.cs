﻿// длина строк в формируемом массиве
int sizeOfNew=3;
// исходный массив
string[] a= {"12","34","56789"};
int la = a.Length;
Console.WriteLine(la);

int lb = Convert.ToInt32(Math.Pow(2,la)); 
Console.WriteLine(lb);
//массив двоичных чисел от 0 до 2^a.Length
int[] bin = new int[lb];
//массив сочетаний индексов элементов исходного массива,из которых формируется новый
int[,] elementForPrint = new int[lb,la];
//количество элементов в одном сочетании
int[] numberOfElementsForPrint = new int[lb];

int DecimalToBin(int number)
{   
    int x = number;
    int xBin = 1;
    while (x > 0)
    {
        xBin = xBin*10 + x%2;
        x = x/2;
    }
    x = xBin;
    xBin = 0;
    while (x>0)
    {
        xBin = xBin*10 + x%10;
        x = x/10;
    }
    xBin = xBin/10;
    return xBin;
}
void binGenerate(int l)
{
    bin[0] = 0;
    for(int i=1; i<l; i++)
    {
       bin[i] = DecimalToBin(i);
    }
}
binGenerate(lb);
Console.WriteLine($"{string.Join(", ",bin)}");
