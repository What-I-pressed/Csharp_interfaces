using System.Diagnostics.Metrics;

Array arr = new Array();
arr += 20;
arr += 13;
arr += 34;
arr += 55;
arr += 13;
arr += 41;
foreach (int i in arr.arr)Console.WriteLine(i);
Console.WriteLine();
Console.WriteLine($"Number of arr items less than 35 : {arr.Less(35)}");
Console.WriteLine($"Number of arr items greater than 35 : {arr.Greater(35)}");
arr.ShowEven();
Console.WriteLine();
arr.ShowOdd();
Console.WriteLine($"Number of unique elements : {arr.CountDistinct()}");
Console.WriteLine($"Number of elements equal to 13: {arr.EqualToValue(13)}");


interface Icalc
{
    public int Less(int valueToCompare);

    public int Greater(int valueToCompare);

}

interface IOutput2
{
    public void ShowEven();

    public void ShowOdd();
}

interface Icalc2
{
    public int CountDistinct();

    public int EqualToValue(int value);
}

class Array: Icalc, IOutput2, Icalc2
{
    public int[] arr;

    public Array() {; } 

    public Array(int[] arr)
    {
        if(arr != null)
        {
            this.arr = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++) this.arr[i] = arr[i];
        }       
    }

    public void Add(int num)
    {
        if(arr == null)
        {
            arr = new int[1];
            arr[0] = num;
            return;
        }
        int[] array = new int[arr.Length + 1];
        for (int i = 0; i < arr.Length; i++) array[i] = arr[i];
        array[arr.Length] = num;
        arr = array;
    }

    public int Less(int value)
    {
        int counter = 0;
        foreach(int i in arr)
        {
            if (i < value) counter++;
        } return counter;
    }

    public int Greater(int value)
    {
        int counter = 0;
        foreach (int i in arr)
        {
            if (i > value) counter++;
        }
        return counter;
    }

    public void ShowEven()
    {
        foreach (int i in arr) if (i % 2 == 0) Console.WriteLine(i);
    }

    public void ShowOdd()
    {
        foreach (int i in arr) if (i % 2 == 1) Console.WriteLine(i);
    }

    public int CountDistinct()
    {
        int counter = 0;
        bool ch = true;
        for(int i = 0; i < arr.Length; i++)
        {
            for(int j= 0; j < arr.Length; j++) if (arr[j] == arr[i] && i != j) ch = false;
            if(ch) counter++;
            ch = true;
        }
        return counter;
    }

    public int EqualToValue(int value)
    {
        int counter = 0;
        foreach(int i in arr)if(i == value) counter++;
        return counter;
    }

    public static Array operator +(Array ar, int num)
    {
        Array array = new Array(ar.arr);
        array.Add(num);
        return array;
    }
}
