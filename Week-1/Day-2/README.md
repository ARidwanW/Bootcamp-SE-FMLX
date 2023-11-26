# What is Day 2
We Explore more about how to create a sln and a project folder also about OOP like params, namespace, using, etc

<picture>
  <source media="(prefers-color-scheme: dark)" srcset="https://user-images.githubusercontent.com/25423296/163456776-7f95b81a-f1ed-45f7-b7ab-8fa810d529fa.png">
  <source media="(prefers-color-scheme: light)" srcset="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
  <img alt="Shows an illustrated sun in light mode and a moon with stars in dark mode." src="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
</picture>

## In Detail
1. How the Structure (sln & csproj) of C# Project
   ```
   - Bootcamp --> solution (dotnet new sln)
      - Day1 --> project (dotnet new project)
         - Program.cs --> static void Main(){}
         - Day1.csproj
         - Another.cs
      - Day1.Test --> unit testing
   ```

> [!NOTE]
> if you rename csproj name in VSCode Solution Explorer extension, you must rename manually in sln file.

2. Parameter Stuff
   * example you have a void method named Add() which will doing addition of two or more numbers. 
      * So if you want to add just two numbers, you can use 
      
         ```
         public int Add(int a, int b) {return a+b}
         ```

      * if you want to add more than two numbers and infinitive, you can use:

         ```
         // (params datatype[] variable)
         public int Add(params int[] input)
         {
            int sum = 0;
            foreach(int number in input)
            {
               sum += number;
            }

            return sum;
         }
         ```

      * if you want to add two or limited numbers with same data type, but optionally u can add different data type, you can use overloading (overloading is same method name but different parameter):

         ```
         public int Add(int a, int b)
         {
            return a + b;
         }

         public int Add(float a, float b)
         {
            return a + b;
         }
         ```

3. How compiler works in a Project Folder
   * the compiler will compile all .cs file if there's no `namespace` in the file
   * if u dont want to compile a .cs file, u can add `namespace` above all codes in that file
   * and if u want to compile it in `static void Main()`, u need to add `using` in Main program
   * if u want to use class in .cs file with `namespace (namespace name)` u must add `using (namespace name)`, if not, it will error. Example if u using namespace:
   ```
   // in Cat.cs
   namespace Animal;

   public class Cat
   {
      // your code
   }

   // in Program.cs
   using Animal;

   class Program
   {
      static void Main()
      {
         Cat catName = new Cat();
      }
   }
   ```

> [!IMPORTANT]
> namespace name cannot be the same as class name

4. How to use variable in string (idk how to say lol, but like string interpolation)
   * u can use `$` before the string like
      ```
      string msg = $"Hello, My name is {name}"
      ```

5. Method with no return and with return
   * method with no return called `void method`
   * method with return called `return method`
   * The return type of a method must match the type of the value that the method will return