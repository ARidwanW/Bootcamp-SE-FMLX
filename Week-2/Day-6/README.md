# What is Day 6
Second week is coming!! no its already done lol. we learn more about object and stuff. Let's take a look.

<picture>
  <source media="(prefers-color-scheme: dark)" srcset="https://user-images.githubusercontent.com/25423296/163456776-7f95b81a-f1ed-45f7-b7ab-8fa810d529fa.png">
  <source media="(prefers-color-scheme: light)" srcset="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
  <img alt="Shows an illustrated sun in light mode and a moon with stars in dark mode." src="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
</picture>

## In Detail
1. Object
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
            public override string ToString()
            {
                return brand;
            }

            public override bool Equals(object obj)
            {
                // Check if the object is null or not of the same type
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }

                // Convert the object to Car type for comparison
                Car otherCar = (Car) obj;

                // Compare the 'brand' property for equality
                return brand == otherCar.brand;
            }

            public override int GetHashCode()
            {
                return brand.GetHashCode();
            }
        ```

2. Dynamic

    ```
        dynamic a = 3;
        a = "hello";
        a = true;
        // Var will check at compile time
        // Dynamic will check at running time
    ```

3. ref : parameter modifier, 
    * passing reference from variable inside the method
    * Two-way communication, possible to change variable value passed and the changes visible outside the method
    * before passing, variable must be assigned

    ```
        void UpdateValue(ref int x) {
            x = 20;
        }
        // ...
        int number = 10;
        UpdateValue(ref number);
        // Sekarang, nilai number akan menjadi 20.

    ```

4. in : parameter modifier,
    * Passing a value to a method but preventing value changes inside the method
    * Read-Only
    * Must be assigned before passed

    ```
        void DisplayValue(in int x) {
            // Tidak bisa mengubah nilai x di sini.
            // ...
            //x = x + 3; <- Error, change value not possible
        }
        // ...
        int number = 10;
        DisplayValue(in number);
        // Nilai number tetap 10 di luar method.

    ```

5. out : parameter modifier,
    * like ref, but does not require the variable to be initialized before it is passed to the method.
    * Output Only

    ```
        void GetValues(out int x, out int y) {
            x = 5;
            y = 10;
        }
        // ...
        int a, b;
        GetValues(out a, out b);
        // Sekarang, nilai a = 5 dan nilai b = 10.

    ```

    * tryParse

    ```
        string b = "30a";
        int value;
        bool status = int.TryParse(b, out value);
    ```

6. Static : own by class, you dont need to create instance to use a static method and so on. created when program run.
    * static class must have all static method
    * static method can only access static variable
    * Non-static method can access static variable or non static variable
    * cannot be inherit

7. Extension Method : allows you to add new methods to an existing data type without changing the data type's source code.
    * the key is: `public` `static`
    * support for Open Close Principle

    ```
        public static class IniExtensions
        {
            public static string Dump(this object obj)
            {
                Console.WriteLine(obj.ToString());
            }
        }
    ```

8. Property:
    * Instead of using the GetId or SetName method, we can use the property
    * We define method access (getter and setter)
    * We can called it `Variable Method`. A variable that can behave like a method.
    
    ```
        public int MyProperties {get; private set;}
    ```

    * When to use property:
        * When we want to give access to read or write the class data
        * Want to keep data privacy
        * usually use in interface

(this we will discuss in the next day)
9. Generic + Constraint
10. Exception & Handling