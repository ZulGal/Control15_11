﻿// длина строк в формируемом массиве
int sizeOfNew=3;
// исходный массив
string[] a= {"12","34","56789"};
int la = a.Length;

int lb = Convert.ToInt32(Math.Pow(2,la)); 
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

string temp = String.Empty;
string[] result = new string[sizeOfNew+1];
for (int i=1; i<sizeOfNew+1; i++)
    result[i] = String.Empty;
int iresult = 0;
int n = 1; 


void PrintArray(int k,int m)
{
    if (elementForPrint[k,m] != 0)
    {
        int j=elementForPrint[k,m]-1;
        for (int i=0; i<a[j].Length; i++)
        {
            temp = a[j];
            iresult++;
            result[iresult] = result[iresult-1] + temp[i];

            if (m+1 <numberOfElementsForPrint[k])
                PrintArray(k,m+1);
            else 
            {
                n++;
                Console.WriteLine($"{n}. [{result[iresult]}]"); 
                iresult = iresult - 1;
            }    
        }
        iresult = iresult-1;
    } 
} 
 
Console.WriteLine($"{n}. []");   
for (int i=1; i<=lb-1; i++)
{
    if (numberOfElementsForPrint[i]<=sizeOfNew)
    {
        iresult = 0;
        PrintArray(i,0);
    }
}
