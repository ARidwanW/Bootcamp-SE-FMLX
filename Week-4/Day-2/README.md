# What is Week-4 Day-2
Hello hello, Welcome back in week 4. This is the second day of week 4. Coz in Week 3 and day 1 of week 4, we have exam and individual project. For individual project we create a class diagram of random games (board games) and I got the Othello game. You can see my Othello Class Diagram [here](https://github.com/ARidwanW/Bootcamp-SE-FMLX/blob/main/IndividualProject/ClassDiagram/class_diagram_othello.pdf) at the second page.

Also, in this day 2 of week 4, we learn the different between string and StringBuilder. Let's take a look.

<picture>
  <source media="(prefers-color-scheme: dark)" srcset="https://user-images.githubusercontent.com/25423296/163456776-7f95b81a-f1ed-45f7-b7ab-8fa810d529fa.png">
  <source media="(prefers-color-scheme: light)" srcset="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
  <img alt="Shows an illustrated sun in light mode and a moon with stars in dark mode." src="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
</picture>

## In Detail
1. String

    * **Reference Type Variable**
        * This means that it is stored in heap memory, not in the stack.
        * It holds the memory's address, not the value itself.
        * In the stack, it only stores the name that points to the address in the heap.
    * **Immutable**
        * This means that the value of the string in the heap cannot be changed.
        * If you reassign the value, it will create a new address with a new value and will reference the new address.
        * The old one will be removed by the garbage collector.

    ```
        string str = "This is a string";
    ```

2. StringBuilder

    * It is a class in .NET used to make an immutable string mutable.
        * This means that if we reassign the variable, it doesn't create a new address but changes the value itself at the same address.

    ```
        StringBuilder str = new StringBuilder();
        str.Append("This is a StringBuilder");
    ```

3. The Differences

    * **StringBuilder is faster than a string, but why?**
    * When we reassign a string, it creates a new allocation of memory (a new address), repeatedly. So, the old one will be removed by the Garbage Collector (GC), but randomly (we do not know when the GC will execute).
    * When the GC runs, the program may freeze for a short time, like milliseconds. However, if the GC is called frequently, it will take more time.
    * But when using StringBuilder, there's no additional memory allocation when we reassign it because it is mutable.