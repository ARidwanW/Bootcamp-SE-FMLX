using System.ComponentModel;
using System.Numerics;
using System.Text;

namespace Day_4_FooBarV2;

public class FooBarV2<TKey, TValue>
        where TKey : INumber<TKey>
        where TValue : IConvertible
{
    private int _startNext = 0;
    private Dictionary<TKey, TValue> _conditions = new Dictionary<TKey, TValue>();

    public FooBarV2(TKey key, TValue value)
    {
        AddCondition(key, value);
    }

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
