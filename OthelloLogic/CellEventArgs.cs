using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloLogic
{
    public class CellEventArgs : EventArgs
    {
        private Cell m_SelectedCell;

        public Cell SelectedCell
        {
            get
            {
                return m_SelectedCell;
            }
        }

        public CellEventArgs(Cell i_SelectedCell) 
        {
            m_SelectedCell = i_SelectedCell;
        }
    }
}
