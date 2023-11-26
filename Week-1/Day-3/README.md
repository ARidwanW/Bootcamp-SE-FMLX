# What is Day 3
Its more on OOP, we learn the pilar (`Inheritance`, `Encapsulate`, `Polymorphism`,(`abstraction` in the next day))

<picture>
  <source media="(prefers-color-scheme: dark)" srcset="https://user-images.githubusercontent.com/25423296/163456776-7f95b81a-f1ed-45f7-b7ab-8fa810d529fa.png">
  <source media="(prefers-color-scheme: light)" srcset="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
  <img alt="Shows an illustrated sun in light mode and a moon with stars in dark mode." src="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
</picture>

## In Detail
1. What is `Inheritance`? As the name suggests, `inheritance` is when we want to pass on the parent class to its children.

    ```
        class Cat : Animal
        {
            // Cat is child
            // Animal is parent
        }
    ```

> [!NOTE]
> Child is more advance than parent, so child can use parent method, but parent cannot use child method. So, it's possible to assign parent by it's child, but cannot assign child with its parent. The solution is using explisit covert.

> [!NOTE]
> It's ok if child constructor is not parameterless with parent constructor is parameterless

> [!WARNING]
> But if parent constructor is not parameterless, child must send the argument to parent using `base` so it's like:

    ```
        // in Animal class parent
        public class Animal
        {
            ...
            public Animal(string name, string colour)
            {
                ...
            }
        }

        // in child
        public class Cat : Animal
        {
            ...
            public Cat(string name, string colour) : base(name, colour)
            {
                ...
            }
        }

        // or in child
        public class Dog : Animal
        {
            ...
            public Dog() : base("Jojo", "Black")
            {
                ...
            }
        }
    ```


    * but what if parent constructor is overloading, it has parameterless and not parameterless?, soo it's ok if child using `base` or not.

2. When we use `Inheritance`
    * when there is a `clear relationship` between a class and its subclasses. For example, there is a more general entity (parent class) and there is a more specialized variation or specification of that entity (child class).
    * if there is `similarity between children`, so that the similarity can become a parent
    * if the `relationship is loose coupling`, means that doesn't need modification on parent in the future.

> [!NOTE]
> You can use composition or interface if the child need method or variable from another child

3. `Const` and `Readonly`, hmmm
    * `const` makes your variable value cannot be reassign and you must assign it when declare it. (must be assigned before compilation)

    ```
    public const int myVariable = 0;    // declare & assign
    public const string myVariale2;     // it will error
    ```

    * `readonly` makes your variable can be read but cannot be reassign, except in a constructor. (can be assigned **via constructor ONLY**)

    ```
        class Animal
        {
            public readonly int age = 0;    // it's ok 
            public readonly int leg;        // it's ok

            public Animal()
            {
                age = 10;       // it will reassign the readonly age
                leg = 3;        // it will assing the readonly leg
            }
        }
    ```

4. Imagine u have class Animal, and u have variable called `age`. You definitely don't want the age to be changed by influences outside the object. You want the age to increase according to the object itself. Then, u need to `encapsulate` it.
    * `Encapsulate` means Creates a boundary around the object, separating it from behavior outside the object (public). In other words, `private` (`access modifier`) 

    ```
        class Car      // Default Access Modifier: Internal --> On 1 Assembly Project
        {
            // For private variable best practice is using underscore "_"
            string _brand;       // Default Access Modifier: Private --> On Class Itself
            public int tire;    // Public --> All
            protected int wiper;    // protected --> Parent & Child

            void EngineTest()   // Default Access Modifier: Private --> On Class Itself
            {

            }
        }
    ```

    | Access Modifier | Who can access it | Inherit |
    | :---: | :---: | :---: |
    | `public` | All | True |
    | `internal` | One Assembly Project | True |
    | `protected` | Parent <-> Child | True |
    | `private` | Class Itself | false |

> [!NOTE]
> You can use public readonly as a substitute for private.

> [!NOTE]
> Best practice to using private variabel is using underscore like: `private int _myVar;`

5. Now what is `Polymorphism`? it allows an object to take many forms or appearances. Divide into two: `Overloading` and `Overriding`
    * Overloading: `Multiple Method`, `Same Name`, `Different Parameter` (Parameter must be different)
    
    ```
        public int Add (int a, int b){}
        public int Add (string a, string b){}
    ```

    * Overriding: 
        * `virtual` --> in Parent
        * `override` --> in Child
        * Method Hiding --> `new`

> [!NOTE]
> in virtual overriding, child method will replace Parent method. But if Method hiding Parent Method will still exist.

    ```
        // in Parent
        public virtual void MakeSound(){}

        // in Child
        public override void MakeSound(){}

        // in Child Method Hiding
        public new void MakeSound(){}
    ```

> [!NOTE]
> if you want to `override`, the Parent must be using `virtual`. but if you want to method hiding, the Parent can using `virtual` or not and u can `use new or not` for method hiding. `virtual` in Parent means child can replace or not replacing the method.
