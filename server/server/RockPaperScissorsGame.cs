namespace server
{
    public class RockPaperScissorsGame
    {
        public enum Move
        {
            Rock,
            Paper,
            Scissors
        }

        public enum Result
        {
            PlayerWins,
            ComputerWins,
            Draw
        }

        public Result Play(Move playerMove)
        {
            Move computerMove = GetComputerMove();

            if (playerMove == computerMove)
            {
                return Result.Draw;
            }
            else if (
                (playerMove == Move.Rock && computerMove == Move.Scissors) ||
                (playerMove == Move.Paper && computerMove == Move.Rock) ||
                (playerMove == Move.Scissors && computerMove == Move.Paper)
            )
            {
                return Result.PlayerWins;
            }
            else
            {
                return Result.ComputerWins;
            }
        }

        private Move GetComputerMove()
        {
            // Hier kannst du die Logik implementieren, um den Zug des Computers zufällig zu generieren
            Random random = new Random();
            Move[] moves = Enum.GetValues(typeof(Move)) as Move[];
            return moves[random.Next(moves.Length)];
        }
    }

}