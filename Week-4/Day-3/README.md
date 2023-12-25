# What is Week-4 Day-3
Ok, after yesterday we learn about string and StringBuilder. Now in day 3 we learn about Garbage Collector, LOH (Large Object Heap), Finalizer, and Dispose.

> [!WARNING]
> remember not to use GC.Collect(), instead you can use Dispose() or using(...).

<picture>
  <source media="(prefers-color-scheme: dark)" srcset="https://user-images.githubusercontent.com/25423296/163456776-7f95b81a-f1ed-45f7-b7ab-8fa810d529fa.png">
  <source media="(prefers-color-scheme: light)" srcset="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
  <img alt="Shows an illustrated sun in light mode and a moon with stars in dark mode." src="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
</picture>

## In Detail
1. Conditional Compilation
    * it's define what part of code that will be compiled.
    * There's some state to use conditional compilation:
      1. `#define` --> will choose what condition
      2. `#if`
      3. `#elif`
      4. `#else`
      5. `endif`
      6. `#warning`
      7. `#error` --> commonly use for give sign that there's a critical code that not yet developed.
      8. `#region`

    * if you define two condition:

      ```
        // #define DEBUG // first come first serve
                        // and DEBUG is default
        // #define RELEASE 
      ```

      event if you define RELEASE before DEBUG, it will also run DEBUG because, it's default. If you want to run only Release, u can do this below:
    
    * To Run:

      ```
        dotnet build -c RELEASE 

        or 

        dotnet run -c RELEASE
      ```

    * This is a simple example (will run code below the GAMETESTER condition (not the else) and after endif):

      ```
        #define GAMETESTER

        class Program
        {
            static void Main()
            {
                #if GAMERUNNER
                Console.WriteLine("GameRunner.");

                #elif GAMETESTER
                Console.WriteLine("GameTester.");

                #else 
                Console.WriteLine("Not Anything.");
                #endif
                Console.WriteLine("Finish");
            }
        }
      ```

2. Garbage Collector
    * Call Factor : 
      1. How much garbage?
      2. Memory near full
      3. Time from last collection
    * Will automatically mark, sweep, compact the unuse of managed resource

      ```mermaid
      mindmap
      root((Memory))
        Stack
          Value Type variable
            Integer
            Char
            Float
            Decimal
            Double
            Boolean
          Automatically clear when the variable outside of it's scope
          StackOverflowException
        Heap
          Reference Type variable
            Class
            Object
            String
            StringBuilder
            Array
            List
          Managed Heap - Internal
            Class
            String
            Array
            And so on
          Unmanaged Heap - External
            File
            API
            Http Request
            Databases
            SMTP
      ```

    * For Unmanaged resource must be dispose by Dispose()

3. Finalizers
    * Or we can call it Destructor, the opposite of constructor.
    * using tilde `~`.
    * have no parameter
    * have no access modifier
    * name of finalizers same as name of class

      ```
        class Car
        {
          // Constructor
          public Car()
          {

          }

          // Destructor
          ~ Car()
          {

          }
        }
      ```

    * If a class have finalizers:
      * Object --> GC Mark --> Finalizer list --> sweep