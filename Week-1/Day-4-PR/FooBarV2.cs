using System.Numerics;
using System.Text;

namespace Day_4_FooBarV2;

/* 
    This Foobar class can do:
    1. Add condition to number iteration (e.g. 3 as "foo", 5 as "bar")
    2. Iterate left or right (default: from 0)
    3. Add iterator condition (default: +1 or -1)
    4. Changed condition implement IConvertible
    5. Changing condition implement INumber
 */

public class FooBarV2<TKey, TValue>
        where TKey : INumber<TKey>
        where TValue : IConvertible
{
    private int _startNext = 0;
    private Dictionary<TKey, TValue> _conditions;
    private List<TKey> _iterator;

    public bool AddCondition(TKey key, TValue value)
    {
        bool keyStatus = _conditions.TryAdd(key, value);
        return keyStatus;
    }

    public StringBuilder GetCondition()
    {
        StringBuilder msg = new StringBuilder();
        if (_conditions != null)
        {
            foreach (var condition in _conditions)
            {
                msg.AppendLine($"{condition.Key} => {condition.Value}");
            }
        }
        return msg;
    }

    public void UpdateCondition(TKey key, TValue value)
    {
        _conditions[key] = value;
    }

    public void DeleteCondition(TKey key)
    {
        _conditions.Remove(key);
    }


}
