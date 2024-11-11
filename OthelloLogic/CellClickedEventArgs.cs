using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloLogic
{
    public class CellClickedEventArgs : EventArgs
    {
        private int m_ClickedCellRow;
        private int m_ClickedCellCol;

        public int ClickedCellRow
        {
            get
            {
                return m_ClickedCellRow;
            }
        }

        public int ClickedCellCol
        {
            get
            {
                return m_ClickedCellCol;
            }
        }

        public CellClickedEventArgs(int i_ClickedCellRow, int i_ClickedCellCol)
        {
            m_ClickedCellRow = i_ClickedCellRow;
            m_ClickedCellCol = i_ClickedCellCol;
        }
    }
}
