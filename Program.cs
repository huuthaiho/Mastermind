using Mastermind;
public class Program
{
    public static void Main()
    {
        int codeLength = 4;
        var masterMind = new MasterMind(codeLength, attempts: 10);
        int guessNumber = 0;
        bool isWin = false;


        while (masterMind.IsMaxAttemptReached())
        {
            Console.Clear();
            masterMind.DisplayBoard();
            Console.WriteLine("Input Guess Number:");
            var strInput = Console.ReadLine();

            if (int.TryParse(strInput, out guessNumber))
            { 
                if(guessNumber.ToString().Length> codeLength)
                {
                    continue;
                }
                if (masterMind.IsValidGuess(guessNumber))
                {
                    Console.WriteLine("You guessed conrrectly!");
                    isWin = true;
                    break;
                }
            }
        }

        if (!isWin)
        {
            Console.WriteLine("out of tries!");
        }
     
        Console.ReadLine();
    }

}
