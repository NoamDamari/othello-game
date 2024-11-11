using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloLogic
{
    public class Cell
    {
        private int m_RowIndex;
        private int m_ColIndex;
        private eColor m_CellColor;
        private Board m_BoardReference;        

        public event EventHandler<CellEventArgs> Selected;

        public int RowIndex
        { 
            get 
            { 
                return m_RowIndex;
            }
            set
            {
                m_RowIndex = value;
            }
        }

        public int ColIndex
        {
            get
            {
                return m_ColIndex;
            }
            set
            {
                m_ColIndex = value;
            }
        }

        public eColor Color
        {
            get
            { 
                return m_CellColor;
            }
            set
            {
                if ((m_CellColor != eColor.Red && m_CellColor != eColor.Yellow)
                    && (value == eColor.Red || value == eColor.Yellow))
                {
                    // Cell is going from empty to occupied, decrease the empty cell count
                    m_BoardReference?.DecreaseEmptyCellCount();
                }
                else if ((m_CellColor == eColor.Red || m_CellColor == eColor.Yellow)
                    && (value != eColor.Red && value != eColor.Yellow))
                    {
                    // Cell is going from occupied to empty, increase the empty cell count
                    m_BoardReference?.IncreaseEmptyCellCount();
                }

                m_CellColor = value;
                OnSelected();              
            }
        }
        
        public Cell()
        {
        }

        public Cell(int i_RowIndex, int i_ColIndex, eColor i_CellColor, Board i_BoardReference)
        {
            m_RowIndex = i_RowIndex;
            m_ColIndex = i_ColIndex;
            m_CellColor = i_CellColor;
            m_BoardReference = i_BoardReference;           
        }
    
        protected virtual void OnSelected()
        {
            Selected?.Invoke(this, new CellEventArgs(this));                      
        }       
    } 
}
