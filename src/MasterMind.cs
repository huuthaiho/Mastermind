
namespace Mastermind
{
    public class MasterMind
    {
        int _tryCount = 0;
        int _codeLength;
        int _answerNumber;
        Dictionary<int, List<int>> _answerDict;

        public Board GameBoard { get;}

        public MasterMind(int codeLength,int attempts) {

            _codeLength = codeLength;
            _answerDict = new Dictionary<int, List<int>>();

            GameBoard = new Board(attempts);

            CreateAnswer();
        }
        private void CreateAnswer()
        {
            var strNumber = "";
            Random rnd = new Random();
            for (var i = 0; i < _codeLength; i++)
            {
                var randValue = rnd.Next(1, 6);
                strNumber += randValue; 
                if (_answerDict.ContainsKey(randValue))
                {
                    var lstIndex = _answerDict[randValue];
                    lstIndex.Add(i);
                }
                else
                {
                    _answerDict.Add(randValue, new List<int>() {i});
                }
            }
            _answerNumber = int.Parse(strNumber);
        }
        private string CreateHint(int guessNumber)
        {
           
            string minusSign = "", plusSign = "";
            int guessIndex = _codeLength - 1;

            while (guessNumber > 0)
            {
                var degit = guessNumber % 10;

                if (_answerDict.ContainsKey(degit))
                {
                    var lstIndex = _answerDict[degit];
                    if (lstIndex.Contains(guessIndex))
                    {
                        plusSign += "+";
                    }
                    else
                    {
                        minusSign += "-";
                    }
                }
                guessNumber = guessNumber / 10;
                guessIndex--;
            }

            return $"({plusSign}{minusSign})";
        }
        public bool IsValidGuess(int guessNumber)
        {
            if(guessNumber== _answerNumber)
            {
                return true;
            }

            var hint = CreateHint(guessNumber);
            GameBoard.InsertGuessResult(guessNumber, _tryCount, hint);
            _tryCount++;
            return false;
        }
        public void DisplayBoard()
        {
            GameBoard.DisplayBoard();
        }
        public bool IsMaxAttemptReached()
        {
            return _tryCount < 10;
        }
    }
}
