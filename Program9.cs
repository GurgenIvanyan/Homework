using System;

public partial class Character
{
    public string CharacterName;
    public int CharacterLevel;
}

public partial class Character
{
    public void ShowCharacterInfo()
    {
        Console.WriteLine($"Name: {this.CharacterName}, Level: {this.CharacterLevel}");
    }
}

class Program
{
    public static void Main()
    {
        Character character = new Character();
        character.CharacterName = "Alex";
        character.CharacterLevel = 99;
        character.ShowCharacterInfo();
    }
}