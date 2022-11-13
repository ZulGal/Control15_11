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
void GenerateForPrint()
{
    for (int i=0; i<=lb-1; i++)
    {
        int k=0;
        for(int j=0; j<la; j++)
            elementForPrint[i,j]=0;  //обнуление
        int temp = bin[i];
        int m =0;
        while (temp != 0)
        {
            if (temp%10 != 0)
            {
                elementForPrint[i,m] = k+1;
                m++;
            }   
            temp = temp / 10;
            k++;
        }
        numberOfElementsForPrint[i] = m;
    }
}

GenerateForPrint();

for (int i=0; i<=lb-1; i++)
    {
        for (int j=0; j<la;j++)
            Console.Write ($" {elementForPrint[i,j]}"); 
        Console.Write ($", {numberOfElementsForPrint[i]}");    
        Console.WriteLine();    
    }

