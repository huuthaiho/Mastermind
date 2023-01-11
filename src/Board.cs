
namespace Mastermind
{
    public class Board
    {
        readonly int _attempts;
        const int _detailLength = 2;
        string[][] _board;
        public Board(int attempts)
        {
            _attempts = attempts;
            _board = new string[attempts][];

            for (var i = 0; i < _attempts; i++)
            {
                _board[i] = new string[_detailLength];

                for (var j = 0; j < _detailLength; j++)
                {
                    _board[i][j] = string.Empty;
                }
            }
        }

        public void DisplayBoard()
        {
            Console.WriteLine("--------Board---------");
            for (var i = 0; i < _board.Length; i++)
            {
                Console.WriteLine($"Try:{i+1}: " + String.Join("|", _board[i]));
            }
            Console.WriteLine("----------------------");
        }

        public void InsertGuessResult(int guessNumber, int attemptNo, string hint)
        {
            _board[attemptNo][0] = guessNumber.ToString();
            _board[attemptNo][1] = hint;
        }
    }

}