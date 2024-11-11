using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloLogic
{
    public class Game
    {
        private Board m_GameBoard;
        private Player m_Player1;
        private Player m_Player2;

        public Player Player1
        {
            get
            {
                return m_Player1;
            }
            set
            {
                m_Player1 = value;
            }
        }

        public Player Player2
        {
            get
            {
                return m_Player2;
            }
            set
            {
                m_Player2 = value;
            }
        }

        public Board GameBoard
        {
            get
            {
                return m_GameBoard;
            }
            set
            {
                m_GameBoard = value;
            }
        }
    }
}
