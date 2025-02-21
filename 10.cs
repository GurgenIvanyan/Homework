namespace Task10_21;

class Program
{
    public static string LongestWord(params string[] words){
        string longestWord = " ";
        foreach (string longest in words)
        {
            if (longest.Length > longestWord.Length)
            {
                longestWord = longest;
            }
        }
        return longestWord;
         
        
    }
    static void Main()
    {
       string input=Console.ReadLine();
       string[] words=input.Split(" ");
       
       Console.WriteLine(LongestWord(words));
       
       
       
       
       
    }
}