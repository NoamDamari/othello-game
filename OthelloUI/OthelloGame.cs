using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OthelloLogic;
using System.Windows.Forms;

namespace OthelloUI
{
    public class OthelloGame
    {
        private GameManager m_GameManager;
        private FormGameSettings m_FormGameSettings;
        private FormGame m_FormGame;

        public FormGame GameForm
        {
            get
            {
                return m_FormGame;
            }
        }

        public OthelloGame()
        {
            m_GameManager = new GameManager();
            m_FormGameSettings = new FormGameSettings();
            m_FormGame = new FormGame();           

            m_GameManager.CellSelected += GameManager_CellSelected;
            m_GameManager.GameOver += GameManager_GameOver;
            m_GameManager.TurnSwitched += GameManager_TurnSwitched;
            m_FormGameSettings.ButtonPlayAgainstComputer.Click += new EventHandler(ButtonPlayAgainstComputer_Click);
            m_FormGameSettings.ButtonPlayAgainstFriend.Click += new EventHandler(ButtonPlayAgainstFriend_Click);
        }    

        public void Start()
        {
            m_FormGameSettings.ShowDialog();
        }

        private void ButtonPlayAgainstComputer_Click(object sender, EventArgs e)
        {
            m_FormGameSettings.Close();
            initializeGame(ePlayerType.Computer);
            startPlay();
        }

        private void ButtonPlayAgainstFriend_Click(object sender, EventArgs e)
        {
            m_FormGameSettings.Close();
            initializeGame(ePlayerType.Human);
            startPlay();
        }

        private void initializeGame(ePlayerType i_PlayerType)
        {
            initializeGameBoard(m_FormGameSettings.BoardSize);
            initializePlayers(i_PlayerType);
        }

        private void startPlay()
        {
           m_GameManager.ManageGame();            
        }

        private void initializeGameBoard(int i_Size)
        {           
            m_FormGame.InitializeBoard(i_Size);
            m_GameManager.InitializeBoard(i_Size);
            m_FormGame.CellClicked += FormGame_CellClicked;
            m_FormGame.UpdateFormTitle(string.Format("Othello - {0}'s Turn", eColor.Red));
        }

        private void FormGame_CellClicked(object sender, CellClickedEventArgs e)
        {
            m_GameManager.HandlePlayerMove(e.ClickedCellRow, e.ClickedCellCol);
        }

        private void initializePlayers(ePlayerType i_PlayerType)
        {
            m_GameManager.InitializeGamePlayers(i_PlayerType);
        }

        private void GameManager_CellSelected(object sender, CellEventArgs e)
        {           
            Cell selectedCell = e.SelectedCell;

            if (selectedCell != null)
            {
                m_FormGame.UpdateCell(selectedCell.RowIndex, selectedCell.ColIndex, selectedCell.Color);
            }           
        }

        private void GameManager_GameOver(object sender, GameOverEventArgs e)
        {
            showGameResults(e.GameResults);
        }

        private void GameManager_TurnSwitched(object sender, TurnEventArgs e)
        {
            string formText = string.Format("Othello - {0}'s Turn", e.ActivePlayerName);
            m_FormGame.UpdateFormTitle(formText);
        }

        private void showGameResults(string i_GameResults)
        {
            DialogResult dialogResult = MessageBox.Show(
                i_GameResults,
                "Othello",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if(dialogResult == DialogResult.Yes)
            {            
                m_GameManager.ResetGame();
            }
            else
            {
                m_FormGame.Close();
            }
        }
    }
}
