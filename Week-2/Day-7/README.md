# What is Day 7
In day 7, we continue our lesson from day-6. There're Generic, Constraint, Operator Overloading, Delegates, etc.

<picture>
  <source media="(prefers-color-scheme: dark)" srcset="https://user-images.githubusercontent.com/25423296/163456776-7f95b81a-f1ed-45f7-b7ab-8fa810d529fa.png">
  <source media="(prefers-color-scheme: light)" srcset="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
  <img alt="Shows an illustrated sun in light mode and a moon with stars in dark mode." src="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
</picture>

## In Detail

1. Generic `<T>`
    * allows you to create classes, structures, methods, or interfaces that can work with different types of data without having to specify the data type at compile time.

    ```
        public class MyGenericClass<T>
        {
            public T Value { get; set; }
        }

    ```

    * ucan change the T with any data type like `<int>`, `<string>`, and so on.

2. Generic Constraint `<T> where T : constraint`
    * the constraint can be like `INumber<T>`, `struct`, `class`, and so on.

    ```
        // T can only be reference type
        public class MyGenericClass<T> where T : class
        {
            public T Value { get; set; }
        }

    ```

    * it limit or control type of data type.

3. Operator Overloading

    ```
        public static Car operator +(Car left, Car right)
        {
            return new Car(left.price + right.price);
        }
    ```

4. Delegate : create a reference method with the appropriate signature
    * a data type to save method reference
    * used in notification / observer / listener / publisher subscriber
    * also can use callback method

    * single delegate

    ```
        // the signature must be the same: (void and parameterless)
        public delegate void MyDelegate();

        // in class
        public MyDelegate mydel;

        mydel = MyMethod;
        mydel = aClass.ItsMethod;

        // to call the method
        mydel.Invoke();

        // or if the method / delegate has a parameter
        // mydel.Invoke("argument");
        
    ```

    * multicast delegate

    ```
        MyDelegate mydel = Displayer;
		mydel += Yusuf;
		mydel.Invoke(); //Displayer Yusuf
		
		mydel -= Displayer;
		mydel(); //Yusuf
    ```

    ```
        // or
        MyDelegate mydel;
		Information info = new();
		
		mydel = info.Displayer;
		mydel += info.Yusuf;
		
		mydel.Invoke();
    ```

    ```
        // Or
        MyDelegate hello;
		MyDelegate hai;
		Information info = new();

		hello = info.Displayer;
		hai = info.Yusuf;

		hello.Invoke("Halo");
		hai.Invoke("Hai");
    ```

    * delegate with return value

    ```
        public delegate int MyDelegate(int a, int b);

        //...some add method for delegate

        int result = del.Invoke(10,9);
		Console.WriteLine(result);
    ```

    * catch delegate with return value

    ```
        MyDelegate del = calc.Add;

        Delegate[] delegateList = del.GetInvocationList();
		int[] result = new int[delegateList.Length];
		int count = 0;
		foreach(MyDelegate d in delegateList) {
			result[count] = d.Invoke(10,9);
			count++;
		}
		foreach(int i in result) {
			i.Dump();
		}
    ```

    * simple publisher and subscriber you can see in [this code](https://github.com/ARidwanW/Bootcamp-SE-FMLX/blob/main/Week-2/Day-7/K_SimplePubSub/Program.cs)