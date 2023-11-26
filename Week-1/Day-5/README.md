# What is Day 5
Fuuuh, friday...
Ok, so in day 5, we explore about ValueType vs ReferenceType (must be carefull about this, yes memory management), Mutable vs Immutable, String vs StringBuilder, etc.

<picture>
  <source media="(prefers-color-scheme: dark)" srcset="https://user-images.githubusercontent.com/25423296/163456776-7f95b81a-f1ed-45f7-b7ab-8fa810d529fa.png">
  <source media="(prefers-color-scheme: light)" srcset="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
  <img alt="Shows an illustrated sun in light mode and a moon with stars in dark mode." src="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
</picture>

## In Detail
1. If u try to assign a variable to another variable, and when u change the new variable, sometimes the old variable change as well. it because i rip my pants, the big larry... (haha kidding). No, It because some type of data is Value and another type is Reference.

    * Value Type:
        * using struct memory management (2-8MB) - LIFO
        * copy the value
        * int, bool, double, float, char

    * Reference Type:
        * using heap memory management (200GB)
        * copy the address
        * class, array, string, StringBuilder

2. Wait, string and string builder? what's the different:
    * string is **immutable**. It means that we cannot change the value of the same address. so when string reassigned, it will create a new address with new value. The old address will be remove by garbage collector. when we copy it, it will copy the address of new value.

    * StringBuilder is **mutable**. It means it will copy the address and it will change the value in the same address.

    * so if u want like array to copy its value u can using prototype design pattern (not yet lean), or like deepClone(), deepCopy(), Array.Copy().

> [!WARNING]
> there's a method to use garbage collector, but we must avoid it. can cause freeze and crash. it is GC.Collect()

3. In heap memory, unused memory will remove over time by garbage collectors (we do know when GC works). But, how in stack memory. So, there's a exception called StackOverflowException (not the web), that return if the stack if overflow (ehe).

4. Casting, as what actor/actrees is doing.
    
    * Upcasting

    ```
        // using implicit
        int a = 3;      // 4 byte
        double b = a;   // 8 byte
    ```

    * Downcasting

    ```
        double c = 3.2l
        int z = (int) c;    // this called explicit
    ```

5. Enum: list of consts
    ```
        public enum MonthOfYear
        {
            January = 1,
            February = 2,
            Maret = 3,
            April = 4,
            Mei = 5,
            Juni = 6,
            Juli = 7,
            Agustus = 8,
            September = 9,
            October = 10,
            November = 11,
            Desember = 12
        }
    ```

    * How to Access:

    ```
        string month = MonthOfYear.January.ToString();  // January
	    int count = (int)MonthOfYear.January;           // 1

        int x = 4;
	    MonthOfYear result = (MonthOfYear) x;           // April
    ```

    * Enum default start from 0, if u assign 2 the next const is 3 and so on. so be carefull if u assign it.

> [!IMPORTANT]
> If you assign parent with its child, the parent cannot use the method of its child. but you can check and create child instance in parent child to use child method.


