
/* 
    Encapsulation or Access Modifier
    * in Formulatrix we always private the variable
 */

 class Program
 {
    static void Main()
    {
        Car honda = new Car();

        // !This will error because brand of Car is private
        // Console.WriteLine(honda._brand);

        // !This will error too
        // honda.brand = "honda";

        // ??This will work cause public
        honda.tire = 4;
        Console.WriteLine(honda.tire);

        // !This will error cause its protected (like private but can inherit)
        // Console.WriteLine(honda.wiper);

        // !This also error
        // honda.wiper = 10;

        Toyota toyota = new Toyota();

        // !This will error cause brand is not inherit
        // Console.WriteLine(toyota.brand);

        // !This will work cause tire is inherit
        toyota.tire = 6;
        Console.WriteLine(toyota.tire);

        // !This will error but wiper is in toyota
        // Console.WriteLine(toyota.wiper);

        // ??We will check if wiper is in toyota
        Console.WriteLine(toyota.GetWiper());   // output: 0 --> cause we not assigned it

        // ??what about brand
        /* Console.WriteLine(toyota.GetBrand());   // !error */

    }
 }

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

 class Toyota : Car
 {
    // public and protected Access Modifier will be inherit to this class
    public int GetWiper()
    {
        Console.WriteLine();
        return wiper;
    }
   /*  public string GetBrand()    // !this will error cause brand is not inherit
    {
        return _brand;
    } */
 }
