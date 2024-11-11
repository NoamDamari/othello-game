using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloLogic
{
    public class Player
    {        
        private ePlayerType m_Type;
        private eColor m_Color;
        private int m_PointsNumber;
        private int m_NumOfWins;
       
        public ePlayerType Type
        {
            get 
            {
                return m_Type;
            }
            set 
            { 
                m_Type = value;
            }
        }

        public eColor Color
        {
            get 
            { 
                return m_Color;
            }
            set 
            { 
                m_Color = value;
            }
        }

        public int PointsNumber
        {
            get 
            { 
                return m_PointsNumber;
            }
            set 
            {
                m_PointsNumber = value; 
            }
        }

        public int NumOfWins
        {
            get
            {
                return m_NumOfWins;
            }
            set
            {
                m_NumOfWins = value;
            }
        }

        public Player(ePlayerType i_PlayerType, eColor i_PlayerColor)
        {            
            m_Type = i_PlayerType;
            m_Color = i_PlayerColor;
        }

        public Cell SelectCell(Board i_GameBoard)
        {
            Cell selectedCell = new Cell();

            if (m_Type == ePlayerType.Computer)
            {
                selectedCell = OtheloGameUtils.GetRandomMove(i_GameBoard, this);
            }           
            
            return selectedCell;
        }
      
        public void ResetPoints()
        {
            m_PointsNumber = 0;
        }
    }
}
