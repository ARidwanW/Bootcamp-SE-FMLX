using System.Text;

namespace FooBarLib;

/* 
    This Foobar class can do:
    1. Add condition to number iteration (e.g. 3 as "foo", 5 as "bar")
    2. Iterate left or right (default: from 0)
    3. Add iterator condition (default: +1 or -1)
    4. Changed condition implement IConvertible
    5. Changing condition only can int
    6. Iterator must have the same type of changing condition
 */

public class FooBarV2<TValue>
                where TValue : IConvertible
{
    private int _startNext = 0;
    private Dictionary<int, TValue> _conditions = new Dictionary<int, TValue>();
    private List<int> _iterator = new List<int>();
    private Dictionary<int, string> _defaultConditions;

    public FooBarV2()
    {
        _defaultConditions = new Dictionary<int, string>();
        _defaultConditions.Add(3, "foo");
        _defaultConditions.Add(5, "bar");
    }

    // private StringBuilder FooBarPrint(int iteration, int end)
    // {
    //     StringBuilder msg = new StringBuilder();
    //     msg.Append(iteration.ToString());

    //     if(_conditions == null)

    //     if (iteration != 0)
    //     {
    //         if (iteration % _firstNumber == 0 && iteration % _secondNumber == 0)
    //         {
    //             msg = _firstString + _secondString;
    //         }
    //         else if (iteration % _firstNumber == 0)
    //         {
    //             msg = _firstString;
    //         }
    //         else if (iteration % _secondNumber == 0)
    //         {
    //             msg = _secondString;
    //         }
    //     }
        
    //     if (iteration != end)
    //     {
    //         msg += ", ";
    //     }

    //     return msg;
    // }


    public bool AddCondition(int key, TValue value)
    {
        bool keyStatus = _conditions.TryAdd(key, value);
        return keyStatus;
    }

    public bool AddIterator(params int[] iterators)
    {
        if (iterators == null)
        {
            return false;
        }

        foreach (var iterator in iterators)
        {
            if(iterator == 0)
            {
                return false;
            }

            _iterator.Add(iterator);
        }
        return true;
    }

    public StringBuilder GetCondition()
    {
        StringBuilder msg = new StringBuilder();
        if (_conditions == null)
        {
            return msg;
        }

        foreach (var condition in _conditions)
        {
            msg.AppendLine($"{condition.Key} => {condition.Value}");
        }

        return msg;
    }

    public void UpdateCondition(int key, TValue value)
    {
        _conditions[key] = value;
    }

    public void DeleteCondition(int key)
    {
        _conditions.Remove(key);
    }


}
