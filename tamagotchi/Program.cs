Tamagotchi tamagotchi = new();


System.Console.WriteLine("Döp din tamagotchi!");
tamagotchi.Name = Console.ReadLine();

Console.Clear();

while (tamagotchi.GetAlive())
{
    tamagotchi.PrintStats();


}


Console.ReadLine();