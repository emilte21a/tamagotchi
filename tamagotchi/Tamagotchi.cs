using System;
using System.Collections.Generic;
using System.Timers;
using System.Threading.Tasks;

public class Tamagotchi
{
    private List<string> words = new List<string>();
    private Action[] methods;

    public int second = 0;
    private int hunger;
    private int boredom;
    private bool isAlive;
    private Random randomGenerator = new Random();
    public string Name;
    
    private int maxHungerOrBoredom = 9;
    private System.Timers.Timer timer;
    private TaskCompletionSource<bool> tickCompletionSource;

    public Tamagotchi()
    {
        isAlive = true;
        hunger = 0;
        boredom = 0;
        methods = new Action[] { Hi, Feed, PrintStats, ReduceBoredom };
        ConfigureTimer();
    }

    private void ConfigureTimer()
    {
        timer = new System.Timers.Timer(interval: 1000); // Set the timer interval to 1 second (1000 milliseconds) for faster updates
        timer.Elapsed += (sender, e) => OnTimerElapsed();
        tickCompletionSource = new TaskCompletionSource<bool>(); // Create a new task completion source for each tick
    }

    public void StartTimer()
    {
        timer.Start();
    }  
    public void StopTimer(){
        timer.Stop();
    }

    public async Task Tick()
    {
        await tickCompletionSource.Task;
        tickCompletionSource = new TaskCompletionSource<bool>(); // Create a new task completion source for the next tick
    }

    private void OnTimerElapsed()
    {
        IncreaseStats();
        tickCompletionSource.SetResult(true);
    }

    public void Hi()
    {
        System.Console.WriteLine(words[randomGenerator.Next(0, words.Count)]);
        ReduceBoredom();
    }

    public void Teach(string word) { }

    private void IncreaseStats()
    {
        hunger += 1;
        boredom += 1;
        second++;

        System.Console.WriteLine("BLABLA kacll");
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

        System.Console.WriteLine($"{Name}s hunger: {hunger}");
        System.Console.WriteLine($"{Name}s Boredom: {boredom}");
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
}