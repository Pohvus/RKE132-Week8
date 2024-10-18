string folderPath = @"C:\Users\username\Desktop\Data";
string heroFile = "heroes";
string villainFile = "villains";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));


//string[] heroes = { "Pohvus", "Chasper", "Chedo", "Oster" };
//string[] villains = { "Ekak", "Aimar", "Jääkaru", "Skibidi", "KSI" };
string[] weapon = { "Kivi", "Comically large spoon", "Diamond sword", "Surströmming" };


string hero = GetRandomValueFromArray(heroes);
string heroWeapon = GetRandomValueFromArray(weapon);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrength = heroHP;
Console.WriteLine($"Today {hero} ({heroHP} HP)with {heroWeapon} will save you from watching Simpsons!");


string villain = GetRandomValueFromArray(villains);
string villainWeapon = GetRandomValueFromArray(weapon);
int villainHP = GetCharacterHP(villain);
int villainStrikeStrength = heroHP;
Console.WriteLine($"Today {villain} ({villainHP} HP) with {villainWeapon} tries to make you watch all of Simpsons!");

while(heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrikeStrength);
    villainHP = villainHP - Hit(hero, heroStrikeStrength);
}

Console.WriteLine($"Hero {hero} HP: {heroHP}");
Console.WriteLine($"Villain {villain} HP: {villainHP}");

if(heroHP > 0)
{
    Console.WriteLine($"{hero} saves you from watching Simpsons!");
}
else if (villainHP > 0)
{
    Console.WriteLine($"You're watching Simpsons!");
}
else
{
    Console.WriteLine("Nothing ever happens!");
}


static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}

static int GetCharacterHP(string characterName)
{
    if (characterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}

static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);

    if(strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");
    }
    else if(strike == characterHP -1) 
    {
        Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}!");
    }

    return strike;

}

