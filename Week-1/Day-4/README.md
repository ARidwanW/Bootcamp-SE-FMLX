# What is Day 4
Ok, so it's time for abstraction also interface and static.

<picture>
  <source media="(prefers-color-scheme: dark)" srcset="https://user-images.githubusercontent.com/25423296/163456776-7f95b81a-f1ed-45f7-b7ab-8fa810d529fa.png">
  <source media="(prefers-color-scheme: light)" srcset="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
  <img alt="Shows an illustrated sun in light mode and a moon with stars in dark mode." src="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
</picture>

## In Detail
1. Abstraction: A concept where we focus on relevant or important information while **`hiding unnecessary details`** of an object or system.
    ```
        abstract class ClassName
        {
            public abstract void MethodName();
        }

        // the child Must override the method, if there's `abstract` keyword
    ```

> [!NOTE]
> Abstraction divide into two: `abstract` and `interface`. in `abstract` there is class (base class) and method. in Interface we called it contract

        * abstract class can containt:
            * abstract method
            * non abstract method
            * variable

        * more about abstract class:
            * cannot build instance from itself
            * child only override the father not grandfather
            * grand child doesn't require to override the grandfather if the father already override it

        * When to use abstract:
            * when we want to provide default implementations for abstract methods that must be implemented by derived classes
            * when we need general feature or a template
            * when we need the child must be override the method

2. Interface: a contract, or like a port in a computer.
    * it cannot declaire and contain variable
    * only method
    * can multiple inherit
    * the method must be override by its child
    * interface method that is overridden by its child must be embedded with its method.
    * best practice is using public access modifier

    ```
        public interface InterfaceName
        {
            void MethodName();
            //or is the same
            public void MethodName();
        }
    ```

    ```
        // there's diff between
        void MethodName();
        
        //with
        void MethodName(int a);

        // so to implement the interface, the method must be the same
    ```

    * when to use interface:
        * when overloading cannot handle parameter
        * when class have multiple inheritance
        * when u need a contract or future proof for classes

3. Interface Segregation Principle ( 1 of 5 SOLID principle). It means that the interface must be spesific to a client. so the client only relies on what is needed, not on what is not needed. It also splitting a large interface into several smaller, specific interfaces helps avoid excessive dependencies.

4. Static : own by class not by instance (simple right? hehe)