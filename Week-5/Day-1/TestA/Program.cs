List<int> ints = new List<int>(){2,3,1,3,-1,-3,4,1,-2};
Console.WriteLine(string.Join(" ", TakeWhilePositive(ints)));
Console.Write(TakeWhilePositive(ints).Count());

IEnumerable<int> TakeWhilePositive(IEnumerable<int> numbers)
{
    foreach (int n in numbers)
    {
        if (n > 0)
        {
            yield return n;
        }
        else
        {
            yield break;
        }
    }
}