using Animal;

class Program
{
    static void Main()
    {
        Cat pokari = new Cat("Pokari", "yellow", 2);
        Cat jiji = new Cat("Jiji", "black", 1);

        pokari.Eat();
        pokari.Sleep();
        pokari.Meow();

        jiji.Eat();
        jiji.Meow();
    }
}
