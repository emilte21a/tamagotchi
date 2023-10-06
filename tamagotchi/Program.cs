using Raylib_cs;

Tamagotchi tamagotchi = new();


System.Console.WriteLine("Döp din tamagotchi!");
tamagotchi.Name = Console.ReadLine();


Console.Clear();




while (tamagotchi.GetAlive())
{
    tamagotchi.StartTimer();
    await tamagotchi.Tick();
    System.Console.WriteLine(tamagotchi.second);
    tamagotchi.PrintStats();
    
}
tamagotchi.StopTimer();

Console.ReadLine();