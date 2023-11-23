int[] myArray = new int[4];

myArray[0] = 1;
myArray[1] = 2;
myArray[2] = 3;
myArray[3] = 4;

Console.WriteLine(Array.IndexOf(myArray, 3));
Console.WriteLine(Array.BinarySearch(myArray, 3));

Array.Fill(myArray, 5,2,1);
foreach (var item in myArray)
{
    Console.WriteLine(item);
}