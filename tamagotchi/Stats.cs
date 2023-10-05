using System;
using System.Timers;
using System.Numerics;
public class Statistic
{
 
    private int hunger;
    private int boredom;
    private List<string> words;
    private bool isAlive;
    private Random randomGenerator;

    public string Name;

    System.Timers.Timer timer = new(interval: 1000);

    public void Feed(){}

    public void Hi(){
    }

    public void Teach(string word){}

    public void Tick(){
         timer.Elapsed += (sender, e) => HandleTimer();
    }

    public void PrintStats(){
    }
        
    public bool GetAlive(){
        return true;
    }

    private void ReduceBoredom(){}


    //Metod för vad som händer varje tick
    void HandleTimer()
    {

    }

}