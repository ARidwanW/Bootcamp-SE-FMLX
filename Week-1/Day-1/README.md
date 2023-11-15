# What is Day-1
In Day-1 we learn about how to create a dotnet project, create classes, the body of program.cs, etc.

<picture>
  <source media="(prefers-color-scheme: dark)" srcset="https://user-images.githubusercontent.com/25423296/163456776-7f95b81a-f1ed-45f7-b7ab-8fa810d529fa.png">
  <source media="(prefers-color-scheme: light)" srcset="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
  <img alt="Shows an illustrated sun in light mode and a moon with stars in dark mode." src="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
</picture>

## In Detail
1. How to Create a C#.NET Project
   * > mkdir (sln folder name)
   * > cd (sln folder name)
   * > dotnet new sln
   * > mkdir (project name)
   * > cd (project name)
   * > dotnet new console

2. How to add Project to Solution
   * > dotnet sln (sln file path) add (csproj file path)
   * or u can using extension `VSCode Solution Explorer`

3. What is body of Program.cs
   ```
   class Program
   {
        static void Main() 
        {
            // Your code to be execute
        }
   }
   ```

4. How to create a class
   ```
   class Cat
   {
    // Variable / Field
    public string name;
    public int age;
    public bool isMale;

    // Contructor
    public Cat(someparameter)
    {
        // Your code to be auto executed first when u create an object
    }

    // Void Method
    public void Meow() 
    {
        // Your code to be executed when it is called
    }

    // Return Method
    public int Eat(string food) 
    {
        string eating = $"eating {food}";

        // must have return statement
        return eating;
    }
   }
   ```

5. How to create an Object
   ```
   // in static void Main()

    // Type variableName = new Class();
   Cat pokari = new Cat();
   
   ```