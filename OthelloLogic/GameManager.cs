using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloLogic
{
    public class GameManager
    {
        private readonly Game r_Game;
        private Player m_ActivePlayer;
        private int m_NumOfRounds = 1;

        public event EventHandler<CellEventArgs> CellSelected;
        public event EventHandler<GameOverEventArgs> GameOver;
        public event EventHandler<TurnEventArgs> TurnSwitched;

        private Game Game
        {
            get
            {
                return r_Game;
            }
        }

        private Player ActivePlayer
        {
            get
            {
                return m_ActivePlayer;
            }
        }

        private int NumOfRounds
        {
            get
            {
                return m_NumOfRounds;
            }          
        }

        public GameManager()
        {
            r_Game = new Game();            
        }        

        public void InitializeBoard(int i_Size)
        {
            r_Game.GameBoard = new Board(i_Size, i_Size);
            r_Game.GameBoard.CellSelected += GameBoard_CellSelected;
            r_Game.GameBoard.InitialMiddlePieces();
        }

        public void InitializeGamePlayers(ePlayerType i_PlayerType)
        {
            r_Game.Player1 = new Player(ePlayerType.Human, eColor.Red);
            r_Game.Player2 = new Player(i_PlayerType, eColor.Yellow);
            m_ActivePlayer = r_Game.Player1;
        }

        public void ManageGame()
        {
            if (!OtheloGameUtils.HasValidMoveOption(r_Game.GameBoard, ActivePlayer))
            {
                switchActivePlayer();
            }
           
            if (!shouldGameOver())
            {                                
                setupTurnForActivePlayer();
            }
            else
            {
                OnGameOver();
            }                    
        }

        private void setupTurnForActivePlayer()
        {
            setInvalidCells();

            if (ActivePlayer.Type == ePlayerType.Computer)
            {
                manageComputerMove();
            }

            setValidMovesForPlayer(m_ActivePlayer);
        }

        private void manageComputerMove()
        {
            Cell selectedCellByComputer = ActivePlayer.SelectCell(r_Game.GameBoard);
            HandlePlayerMove(selectedCellByComputer.RowIndex, selectedCellByComputer.ColIndex);
        }

        public void HandlePlayerMove(int i_CellRow, int i_CellCol)
        {
            Cell cell = r_Game.GameBoard.BoardMatrix[i_CellRow, i_CellCol];

            r_Game.GameBoard.UpdateCellColor(i_CellRow, i_CellCol, ActivePlayer.Color);
            updateGameBoardAfterPlayerMove(ActivePlayer, cell);
            switchActivePlayer();
            ManageGame();
        }

        private void switchActivePlayer()
        {
            m_ActivePlayer = m_ActivePlayer == r_Game.Player1? r_Game.Player2: r_Game.Player1;
            OnTurnSwitched();
        }

        private void setInvalidCells()
        {
            foreach(Cell cell in r_Game.GameBoard.BoardMatrix)
            {
                if (cell.Color == eColor.None || cell.Color == eColor.Green)
                {
                    r_Game.GameBoard.UpdateCellColor(cell, eColor.Grey);
                }
            }
        }

        private bool shouldGameOver()
        {
            return OtheloGameUtils.HasNoAvailableMoves(r_Game) ||
                r_Game.GameBoard.NumOfEmptyCells == 0;
        }

        private void updateGameBoardAfterPlayerMove(Player i_Player, Cell i_SelectedCell)
        {           
            OtheloGameUtils.ApplyMoveAndFlip(r_Game.GameBoard, i_SelectedCell, i_Player);
        }

        private void setValidMovesForPlayer(Player i_CurrentPlayer)
        {
            List<Cell> validCellsForPlayer = OtheloGameUtils.GetAllValidMoves(r_Game.GameBoard, i_CurrentPlayer);

            foreach (Cell cell in validCellsForPlayer)
            {
                r_Game.GameBoard.UpdateCellColor(cell, eColor.Green); 
            }
        }

        private void GameBoard_CellSelected(object sender, CellEventArgs e)
        {
            OnCellSelected(e.SelectedCell);
        }

        protected virtual void OnCellSelected(Cell i_SelectedCell)
        {
            CellSelected?.Invoke(this, new CellEventArgs(i_SelectedCell));         
        }

        protected virtual void OnGameOver()
        {
            string results = declareResult();
            GameOver?.Invoke(this, new GameOverEventArgs(results));
        }

        protected virtual void OnTurnSwitched()
        {
            TurnSwitched?.Invoke(this, new TurnEventArgs(ActivePlayer.Color.ToString()));
        }

        private string declareResult()
        {
            Player winner = OtheloGameUtils.GetWinner(r_Game);
            winner.NumOfWins++;
            Player loser = winner == r_Game.Player1 ? r_Game.Player2 : r_Game.Player1;
            string results;

            if (isTie(winner, loser))
            {
                 results = string.Format(@"Results:
It's a tie! 
Both players have {0} points.
Would you like another round?", winner.PointsNumber);
            }
            else
            {
                results = string.Format(@"
Results:
{0} Won!! ({1}\{2}) ({3}\{4})
Would you like another round?",
                winner.Color, winner.PointsNumber, loser.PointsNumber,
                winner.NumOfWins, NumOfRounds);
            }

            return results;
        }

        private bool isTie(Player i_Winner, Player i_Loser)
        {
            return i_Winner.PointsNumber == i_Loser.PointsNumber;
        }

        public void ResetGame()
        {
            r_Game.GameBoard.ResetBoard();
            resetPlayersPoints(r_Game.Player1, r_Game.Player2);
            m_ActivePlayer = r_Game.Player1;
            m_NumOfRounds++;
            ManageGame();
        }

        private void resetPlayersPoints(Player i_Player1, Player i_Player2)
        {
            i_Player1.ResetPoints();
            i_Player2.ResetPoints();
        }
    }
}
