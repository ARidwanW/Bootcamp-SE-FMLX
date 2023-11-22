using System.Numerics;

namespace FooBarLib;

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
    private Dictionary<TKey, TValue> _condition;
}
