using System.Collections.Specialized;
using System.Reflection.Metadata;
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
    private int _indexIterator = -1;
    private SortedDictionary<int, TValue> _conditions;
    private List<int> _iterator;
    private SortedDictionary<int, string> _defaultConditions;

    public FooBarV2()
    {
        _conditions = new SortedDictionary<int, TValue>();
        _iterator = new List<int>();
        _defaultConditions = new SortedDictionary<int, string>();
        _defaultConditions.Add(3, "foo");
        _defaultConditions.Add(5, "bar");
        _iterator.Add(1);
    }

    public string Next(int start, int end)
    {
        StringBuilder stringBuilder = new StringBuilder();
        if (_conditions.Count > 0)
        {
            // if (start <= end)
            // {
            //     stringBuilder.Append(CheckNumber(start, end));
            //     stringBuilder.Append(Next(start + _iterator[_indexIterator], end));

            //     if (_indexIterator >= _iterator.Count)
            //     {
            //         _indexIterator = 0;
            //     }
            //     _indexIterator++;
            // }
            // return stringBuilder.ToString();
            if (start <= end)
            {
                stringBuilder.Append(NextRight(start, end, false));
            }

            if (start >= end)
            {
                stringBuilder.Append(NextLeft(start, end, false));
            }
        }
        else{
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

                stringBuilder.Append(NextRight(start - _iterator[_indexIterator], end, defaultCondition));
            }
        }
        return stringBuilder.ToString();
    }

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

        //! bug here
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


    public bool AddCondition(int key, TValue value)
    {
        bool keyStatus = _conditions.TryAdd(key, value);
        return keyStatus;
    }

    public bool AddCondition(Dictionary<int, TValue> dict)
    {
        bool keyStatus = false;
        foreach (var item in dict)
        {
            keyStatus = _conditions.TryAdd(item.Key, item.Value);
        }
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
            if (iterator == 0)
            {
                return false;
            }
            _iterator.Add(iterator);
        }
        return true;
    }

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

    public bool UpdateCondition(int key, TValue value) //! overloading nanti
    {
        if (!_conditions.ContainsKey(key))
        {
            return false;
        }
        _conditions[key] = value;
        return true;
    }

    public bool UpdateIterator(int index, int changeValue)
    {
        if ((index + 1) > _iterator.Count)
        {
            return false;
        }
        _iterator[index] = changeValue;
        return true;
    }

    public bool RemoveCondition(int key)
    {
        if (!_conditions.ContainsKey(key))
        {
            return false;
        }
        _conditions.Remove(key);
        return true;
    }

    public bool RemoveIterator(int index)
    {
        if ((index + 1) > _iterator.Count)
        {
            return false;
        }
        _iterator.RemoveAt(index);
        return true;
    }
}
