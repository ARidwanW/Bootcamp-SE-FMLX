# What is Day 2 - Extend
In this extend version, there're 2 folder: Day 2 and Day 2v2. U can read what we learn in Day 2 in [this readme](https://github.com/ARidwanW/Bootcamp-SE-FMLX/tree/main/Day-2/README.md). In Day 2v2 there're some addition of the material

<picture>
  <source media="(prefers-color-scheme: dark)" srcset="https://user-images.githubusercontent.com/25423296/163456776-7f95b81a-f1ed-45f7-b7ab-8fa810d529fa.png">
  <source media="(prefers-color-scheme: light)" srcset="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
  <img alt="Shows an illustrated sun in light mode and a moon with stars in dark mode." src="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
</picture>

## In Detail
1. How to automatically run something (statements) when create an object
    * we use `constructor`
      ```
      class Cat
      {
        // Constructor
        public Cat()
        {
          // your auto run code when create an object of Cat
        }
      }
      ```

2. `Overload` (not Overlord hehe)
    *  you can go to In Detail Parameter at Day 2 README.md [here](https://github.com/ARidwanW/Bootcamp-SE-FMLX/tree/main/Week-1/Day-2#:~:text=if%20you%20want%20to%20add%20two%20or%20limited%20numbers%20with%20same%20data%20type%2C%20but%20optionally%20u%20can%20add%20different%20data%20type%2C%20you%20can%20use%20overloading%20(overloading%20is%20same%20method%20name%20but%20different%20parameter)%3A)

3. Many Option to create constructor parameter and create object
    * when u create a class with empty construtor like

      ```
        public class Car
        {
          public string brand;
          public int totalTire;
          public string engineName;

          Public Car()
          {
            // it's mt
          }
        }
      ```

    * u can create object like this

      ```
        // in static void Main()
        Car honda = new Car()
        {
          brand = "Honda",
          totalTire = 4,
          engineName = "idk"
        };
      ```

    * if there's overloading like

      ```
        public Car(string brand, int tire)
        {
          this.brand = brand;
          tire = totalTire;
        }
      ```

    * u can create object like:

      ```
        // create with ordered arguments
        Car toyota = new Car("Toyota", 4);
        // create with unordered arguments
        Car toyota = new Car(tire : 4, brand : "Toyota);
      ```

    * and also u can use default parameter

      ```
        public Car(string brand = "no brand", string engine = "idk")
        {
          this.brand = brand;
          engineName = engine;
        }
      ```

> [!IMPORTANT]
> if parameter name same with variable name, recommended to use `this.variableName`
> and if the parameter has default or using infinity (params dataType[] variable) must put it in the last order, example:
```
  public Car(int tire, string brand = "Honda"){}

  //or
  public int Add(int a, params int[] b){}
```

> [!NOTE]
> use `PascalCase` for naming class & methods. also use `camelCase` for naming variable

4. Whattt?? Object that have another object inside it, yeah it's `Composition`
    * basically if u want to create example `Car Project`, U have to spesify what `Composition` or `Component` that a car has.
    * so it's like this:

        - Car Project --> Solution
          - Program.cs --> entry point
          - Car.cs --> blueprint of a car that have constructor parameter of (Engine, Exhaust, Wiper, Tire)
          - Engine.cs --> blueprint of engine that will be put in a car
          - Exhaust.cs --> same like another parameter for a car
          - Wiper.cs
          - Tire.cs

    * in car parameter like Engine u can implement what u want
    * in Car.cs u can code like this:

      ```
      namespace Car_Project;

      public class Car
      {
        public Engine engine;
        public Exhaust exhaust;
        public Wiper wiper;
        public Tire tire;

        public Car(Engine en, Exhaust ex, Wiper wp, Tire tr)
        {
          engine = en;
          exhaust = ex;
          wiper = wp;
          tire = tr;
        }
      }
      ```

    * in Program.cs u can code like this:

      ```
      using Car_Project;

      class Program
      {
        static void Main()
        {
          Engine engine = new Engine();
          Exhaust exhaust = new Exhaust();
          Wiper wiper = new Wiper();
          Tire tire = new Tire();

          Car honda = new Car(engine, exhaust, wiper, tire);
        }
      }
      ```
   