namespace Day_4_PR;

// * 1. iterasi dari a hingga b             [1]
// * 2. iterasi dari 0 hingga b             [1]
// * 3. iterasi dari b hingga a             [0]
// * 4. iterasi dari b hingga 0             [0]
// * 5. ganti nomor untuk foo               [0]
// * 6. ganti nomor untuk bar               [0]
// * 7. ganti nomor untuk foo dan bar       [0]
// * 8. ganti string foo                    [0]
// * 9. ganti string bar                    [0]
// * 10. ganti string foo dan bar           [0]

public class FooBar
{
    private int _startNext = 0;

    private string FooBarPrint(int iteration, int end)
    {
        // * create msg integer to string
        string msg = iteration.ToString();

        if (iteration != 0)
        {
            if (iteration % 3 == 0 && iteration % 5 == 0)
            {
                msg = "foobar";
            }
            else if (iteration % 3 == 0)
            {
                msg = "foo";
            }
            else if (iteration % 5 == 0)
            {
                msg = "bar";
            }
        }
        else
        {
            msg = iteration.ToString();
        }

        // * add ", " to the msg if the iteration is not the end
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

            return msg + Next(start + 1, end);
        }

        return "";
    }

    public string Next(int end)
    {
        if (_startNext < end)
        {
            string msg = FooBarPrint(_startNext, end);
            
            return msg + Next(_startNext + 1, end);
        }

        return "";
    }

}
