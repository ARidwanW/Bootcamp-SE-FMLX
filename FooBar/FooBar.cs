namespace FooBarLib;

// * 1. iterasi dari a hingga b             [1]
// * 2. iterasi dari 0 hingga b             [1]
// * 3. iterasi dari b hingga a             [1]
// * 4. iterasi dari b hingga 0             [1]
// * 5. ganti nomor untuk foo               [1]
// * 6. ganti nomor untuk bar               [1]
// * 7. ganti nomor untuk foo dan bar       [1]
// * 8. ganti string foo                    [1]
// * 9. ganti string bar                    [1]
// * 10. ganti string foo dan bar           [1]

public class FooBar
{
    private int _startNext = 0;
    private int _firstNumber;
    private int _secondNumber;
    private string _firstString;
    private string _secondString;

    public FooBar(int firstNumber = 3, int secondNumber = 5, string firstString = "foo", string secondString = "bar")
    {
        _firstNumber = firstNumber;
        _secondNumber = secondNumber;
        _firstString = firstString;
        _secondString = secondString;
    }

    private string FooBarPrint(int iteration, int end)
    {
        string msg = iteration.ToString();

        if (iteration != 0)
        {
            if (iteration % _firstNumber == 0 && iteration % _secondNumber == 0)
            {
                msg = _firstString + _secondString;
            }
            else if (iteration % _firstNumber == 0)
            {
                msg = _firstString;
            }
            else if (iteration % _secondNumber == 0)
            {
                msg = _secondString;
            }
        }
        
        if (iteration != end)
        {
            msg += ", ";
        }

        return msg;
    }

    public string Next(int start, int end)
    {
        if (start <= end)
        {
            string msg = FooBarPrint(start, end);

            if (start != end)
            {
                msg += Next(start + 1, end);
            }

            return msg;
        }
        else
        {
            string msg = FooBarPrint(start, end);

            if (start != end)
            {
                msg += Next(start - 1, end);
            }

            return msg;
        }
    }

    public string Next(int end)
    {
        return Next(_startNext, end);
    }
}
