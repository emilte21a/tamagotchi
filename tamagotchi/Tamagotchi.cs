using System;
using System.Runtime.Intrinsics.Arm;
using System.Timers;

public class Tamagotchi
{
    private List<string> words = new List<string>();

    Action[] methods;

    int second = 0;
    private int hunger;
    private int boredom;
    private bool isAlive;
    private Random randomGenerator = new Random();

    public string Name;

    private int maxHungerOrBoredom = 10;



    System.Timers.Timer timer = new(interval: 1000);

    public Tamagotchi()
    {
        hunger = 0;
        boredom = 0;
        isAlive = GetAlive();
        methods = new Action[] { Hi, Feed, PrintStats, Tick, ReduceBoredom };
    }


    public void Hi()
    {
        System.Console.WriteLine(words[randomGenerator.Next(0, words.Count)]);
        ReduceBoredom();
    }

    public void Teach(string word) { }

    public void Tick()
    {
        timer.Elapsed += (sender, e) => IncreaseStats();
        System.Console.WriteLine(second);
    }

    public void PrintStats()
    {
        if (isAlive)
        {
            System.Console.WriteLine($"{Name} är vid liv");
        }
        else
        {
            System.Console.WriteLine($"{Name} är död..");
        }

        System.Console.WriteLine(Name + "s hunger: ", hunger);
        System.Console.WriteLine(Name + "s Boredom: ", boredom);
    }

    public bool GetAlive()
    {
        if (hunger > maxHungerOrBoredom || boredom > maxHungerOrBoredom)
        {
            return false;
        }
        return true;
    }

    private void ReduceBoredom()
    {
        boredom -= 1;
    }

    public void Feed()
    {
        hunger -= 1;
    }


    //Metod för vad som händer varje tick
    private void IncreaseStats()
    {
        hunger += 1;
        boredom += 1;
        second++;
    }

}