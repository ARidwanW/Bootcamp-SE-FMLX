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

 /* 
    Some Disadvantage:
    1. Changed condition is typesafety (not yet test)
    2. Remove iterators 1by1
    3. Can remove default iterator
    4. Limited Update method parameter

 */

public class FooBarV2<TValue>
                where TValue : IConvertible
{
    private int _startNext = 0;
    private int _indexIterator = -1;
    private SortedDictionary<int, string> _defaultConditions;
    private SortedDictionary<int, TValue> _conditions;
    private List<int> _iterator;


    public FooBarV2()
    {
        _conditions = new SortedDictionary<int, TValue>();
        _iterator = new List<int>();
        _defaultConditions = new SortedDictionary<int, string>();
        _defaultConditions.Add(3, "foo");
        _defaultConditions.Add(5, "bar");
        _iterator.Add(1);
    }


    // * Main method
    public string Next(int start, int end)
    {
        StringBuilder stringBuilder = new StringBuilder();

        // * Using custom condition if there's a custom condition
        if (_conditions.Count > 0)
        {
            if (start <= end)
            {
                stringBuilder.Append(NextRight(start, end, false));
            }

            if (start >= end)
            {
                stringBuilder.Append(NextLeft(start, end, false));
            }
        }
        else
        {
            if (start <= end)
            {
                stringBuilder.Append(NextRight(start, end, true));
            }

            if (start >= end)
            {
                stringBuilder.Append(NextLeft(start, end, true));
            }
        }
        return stringBuilder.ToString();
    }


    // * Overloading default start parameter
    public string Next(int end)
    {
        return Next(_startNext, end);
    }


    // * Iteration to Right
    private string NextRight(int start, int end, bool defaultCondition)
    {
        StringBuilder stringBuilder = new StringBuilder();

        if (start <= end)
        {
            stringBuilder.Append(CheckNumber(start, end, defaultCondition));
            if (start != end)
            {
                if (_indexIterator > (_iterator.Count - 2))
                {
                    _indexIterator = -1;
                }
                _indexIterator++;

                stringBuilder.Append(NextRight(start + _iterator[_indexIterator], end, defaultCondition));
            }
        }
        return stringBuilder.ToString();
    }


    // * Iteration to Left
    private string NextLeft(int start, int end, bool defaultCondition)
    {
        StringBuilder stringBuilder = new StringBuilder();

        if (start >= end)
        {
            stringBuilder.Append(CheckNumber(start, end, defaultCondition));
            if (start != end)
            {
                if (_indexIterator > (_iterator.Count - 2))
                {
                    _indexIterator = -1;
                }
                _indexIterator++;

                stringBuilder.Append(NextLeft(start - _iterator[_indexIterator], end, defaultCondition));
            }
        }
        return stringBuilder.ToString();
    }


    // * Check Condition
    private string CheckNumber(int iteration, int end, bool defaultCondition)
    {
        StringBuilder stringBuilder = new StringBuilder();
        int onCondition = 0;

        if (defaultCondition)
        {
            if (iteration != 0)
            {
                foreach (var condition in _defaultConditions)
                {
                    if ((iteration % condition.Key) == 0)
                    {
                        stringBuilder.Append(condition.Value?.ToString());
                        onCondition++;
                    }
                }
            }
        }
        else
        {
            if (iteration != 0)
            {
                foreach (var condition in _conditions)
                {
                    if ((iteration % condition.Key) == 0)
                    {
                        stringBuilder.Append(condition.Value.ToString());
                        onCondition++;
                    }
                }
            }
        }

        if (onCondition < 1)
        {
            stringBuilder.Append(iteration);
        }

        if (iteration != end)
        {
            stringBuilder.Append(", ");
        }

        return stringBuilder.ToString();
    }


    // * Add custom condition will replace the default condition
    public bool AddCondition(int key, TValue value)
    {
        bool keyStatus = _conditions.TryAdd(key, value);
        return keyStatus;
    }


    // * Overloading Dictionary paramter
    public bool AddCondition(Dictionary<int, TValue> dict)
    {
        bool keyStatus = false;
        foreach (var item in dict)
        {
            keyStatus = _conditions.TryAdd(item.Key, item.Value);
        }
        return keyStatus;
    }


    // * Add iterator will add after default parameter (not replacing)
    public bool AddIterator(params int[] iterators)
    {
        if (iterators == null)
        {
            return false;
        }

        foreach (var iterator in iterators)
        {
            if (iterator == 0)
            {
                return false;
            }
            _iterator.Add(iterator);
        }
        return true;
    }


    // * Get condition or default condition and iterator(s)
    public string GetCondition()
    {
        StringBuilder msg = new StringBuilder();

        if (_conditions == null)
        {
            return msg.ToString();
        }

        // * if there's custom condition we use the custom
        // * if not we use the default condition
        if (_conditions.Count > 0)
        {
            foreach (var condition in _conditions)
            {
                msg.AppendLine($"{condition.Key} => {condition.Value}");
            }
        }
        else
        {
            foreach (var condition in _defaultConditions)
            {
                msg.AppendLine($"{condition.Key} => {condition.Value}");
            }
        }

        msg.Append("Iterator is ");
        foreach (var iterator in _iterator)
        {
            msg.Append($"{iterator} ");
        }

        return msg.ToString();
    }


    // * Update custom condition
    public bool UpdateCondition(int key, TValue value) //! bisa overloading
    {
        if (!_conditions.ContainsKey(key))
        {
            return false;
        }
        _conditions[key] = value;
        return true;
    }


    // * Update an iterator based on index
    public bool UpdateIterator(int index, int changeValue) //! bisa overloading
    {
        if ((index + 1) > _iterator.Count)
        {
            return false;
        }
        _iterator[index] = changeValue;
        return true;
    }


    // * Remove custome condition
    public bool RemoveCondition(int key)    //! bisa overloading
    {
        if (!_conditions.ContainsKey(key))
        {
            return false;
        }
        _conditions.Remove(key);
        return true;
    }

    // * Remove iterator
    public bool RemoveIterator(int index)   //! bisa overloading
    {
        if ((index + 1) > _iterator.Count)
        {
            return false;
        }
        _iterator.RemoveAt(index);
        return true;
    }
}
