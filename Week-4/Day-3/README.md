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

      event if you define RELEASE before DEBUG, it will run DEBUG because, it's default. If you want to run only Release, u can do this below:
    
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
      graph TD;
      Memory-->Stack;
      Memory-->Heap;
      Heap-->Managed;
      Heap-->Unmanaged;
      Managed-->A[class];
      Managed-->string;
      Managed-->Internal;
      Unmanaged-->File;
      Unmanaged-->API;
      Unmanaged-->External;
      ```

    * For Unmanaged resource must be dispose by Dispose()
    
    ```mermaid
    graph TD;
      GarbageCollector-->Mark;
      GarbageCollector-->Sweep;
      GarbageCollector-->Compact;
      Mark-->A[mark the alive instance];
      Sweep-->B[shifts the memory boundary forward, <br>so that alive data will enter the next Gen <br>while dead data will be deleted in the previous Gen.];
      Compact-->C[shifts data forward to fill in gaps <br>and prevent fragmentation]
    ```

3. Managed Heap
    ```mermaid
      flowchart TD;
      id1([Start]) --> id2[(Gen 0 <br>Short Live Object</br>New Allocation)];
      id2 --> id3{Is variable <br>alive?};
      id3 -- Yes --> id4[[GC Mark]];
      id4 --> id5[[GC Sweep]];
      id5 -- from gen 0 --> id6[(Gen 1)];
      id6 --> id7[[GC Clear Gen 0]];
      id3 -- No from gen 0 --> id2;
      id6 --> id3;
      id5 -- from gen 1 --> id8[(Gen 2 <br>Long Live Object</br>Must be avoid)];
      id8 --> id7;
      id8 --> id9[[GC clear Gen 1]];
      id8 --> id3;
      id3 -- Yes from gen 2 --> id10[[Clear all Gen<br>alive var still in Gen 2]];
      ```

3. LOH
    * Large Object Heap
    * New allocation memory for instance that have more than 81kb.
    * Will be clear or remove when Gen 2 is being checked.

4. Finalizers
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

    * Undetermine instance
    * Can release unmanage resource
    * In Finalizer list the object is unreferenced
    * The Object will be hold a bit in Finalizer list
    * and Randomly Sweep

    * If a class have finalizers:
      * Object --> GC Mark --> Finalizer list --> GC Sweep (random)
      
    * If a class doesn't have finalizers:
      * Object --> GC Sweep

>[!WARNING]
>There's a method `GC.Collect()` to force call the GC to mark, but still randomly sweep who and when. But, this must be avoided, Because it will take time and performances of your code (freeze).

>[!NOTE]
>There's also a method to execute the finalizer without waiting the GC to comes. it is `GC.WaitForPendingFinalizers()`.

>[!NOTE]
>Also Finalizers be avoided, due to performance issues. Instead, we can use `Dispose()` to release unmanaged resource.

5. Dispose
    * Release Unmanaged resource
    * from IDisposeable --> void Dispose();
    * commonly use in try catch finally (especially in finally)
    * But we can replace it with `using` rather than try finally,

      ```
        using(FileStream file = new FileStream(path, mode, access))
        {
          //...
        }
      ```
      