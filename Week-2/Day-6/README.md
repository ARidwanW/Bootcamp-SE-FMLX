# What is Day 5
Fuuuh, friday...
Ok, so in day 5, we explore about ValueType vs ReferenceType (must be carefull about this, yes memory management), Mutable vs Immutable, String vs StringBuilder, etc.

<picture>
  <source media="(prefers-color-scheme: dark)" srcset="https://user-images.githubusercontent.com/25423296/163456776-7f95b81a-f1ed-45f7-b7ab-8fa810d529fa.png">
  <source media="(prefers-color-scheme: light)" srcset="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
  <img alt="Shows an illustrated sun in light mode and a moon with stars in dark mode." src="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
</picture>

## In Detail
* Object
    * Boxing

        ```
            //Boxing
            int x = 3;
            object obj = x;
        ```

    * Unboxing

        ```
            //Unboxing
            int result = (int)obj;
            Console.WriteLine(result);
        ```

        ```
            //No need for cast, just unbox
            object obj1 = 3;
            double myDouble = (int)obj1;
        ```

        ```
            //Need for cast + unbox
            object obj2 = 3.0;
            int myInt = (int)(double)obj2;
        ```

    * Check Data Type

        ```
            static void Add(object a,object b) {
                if(a is int && b is int) {
                    int resulta = (int)a;
                    int resultb = (int)b;
                    Console.WriteLine(resulta+resultb);
                }
                if (a is float && b is float)
                {
                    float resulta = (float)a;
                    float resultb = (float)b;
                    Console.WriteLine(resulta + resultb);
                }
                if (a is string && b is string)
                {
                    string resulta = (string)a;
                    string resultb = (string)b;
                    Console.WriteLine(resulta + resultb);
                }
            }
        ```

    * Pattern Matching

        ```
            //Syntatic Sugar
            //Pattern Matching
            if (a is int inta && b is int intb)
            {
                Console.WriteLine(inta + intb);
            }
        ```

    * is : type checking
    * as : explicit cast for reference type

        ```
            object a = "Hello";
            string resulta = a as string;
            //string resulta = (string)a;
        ```

    * Override ToString From Class Object

        ```
            
        ```

* Dynamic

    ```
        dynamic a = 3;
        a = "hello";
        a = true;
        // Var will check at compile time
        // Dynamic will check at running time
    ```

* Ref, in, out
* Static
* Property
* Generic + Constraint
* Exception & Handling