using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OthelloLogic
{
    public class Board
    {
        private readonly Cell[,] r_BoardMatrix;
        private readonly int r_RowsNumber;
        private readonly int r_ColsNumber;
        private int m_NumOfEmptyCells;

        public event EventHandler<CellEventArgs> CellSelected;

        public Cell[,] BoardMatrix
        {
            get
            {
                return r_BoardMatrix;
            }
        }
        
        public int RowsNumber
        {
            get 
            {
                return r_RowsNumber;
            }           
        }

        public int ColsNumber
        {
            get
            {
                return r_ColsNumber;
            }
        }

        public int NumOfEmptyCells
        {
            get 
            {
                return m_NumOfEmptyCells;
            }
            set
            { 
                m_NumOfEmptyCells = value;
            }
        }

        public Board(int i_RowsNumber, int i_ColsNumber)
        {
            r_RowsNumber = i_RowsNumber;
            r_ColsNumber = i_ColsNumber;
            r_BoardMatrix = new Cell[r_RowsNumber, r_ColsNumber];
            initializeBoard();
        }

        private void initializeBoard() 
        {
            for (int rowIndex = 0; rowIndex < r_RowsNumber; rowIndex++)
            {
                for (int colIndex = 0; colIndex < r_ColsNumber; colIndex++)
                {
                    r_BoardMatrix[rowIndex, colIndex] = new Cell(rowIndex, colIndex, eColor.None, this);
                    r_BoardMatrix[rowIndex, colIndex].Selected += Cell_Selected;
                }
            }

            m_NumOfEmptyCells = (r_RowsNumber * r_ColsNumber);
        }

        public void InitialMiddlePieces()
        {
            int midRow = (r_RowsNumber / 2) - 1;
            int midCol = (r_ColsNumber / 2) - 1;

            r_BoardMatrix[midRow, midCol].Color = eColor.Yellow; // Top-left of center
            r_BoardMatrix[midRow, midCol + 1].Color = eColor.Red; // Top-right of center
            r_BoardMatrix[midRow + 1, midCol].Color = eColor.Red; // Bottom-left of center
            r_BoardMatrix[midRow + 1, midCol + 1].Color = eColor.Yellow; // Bottom-right of center
        }
       
        public void UpdateCellColor(Cell i_Cell, eColor i_NewColor)
        {
            r_BoardMatrix[i_Cell.RowIndex,i_Cell.ColIndex].Color = i_NewColor;   
        }

        public void UpdateCellColor(int i_CellRow, int i_CellCol, eColor i_NewColor)
        {
            r_BoardMatrix[i_CellRow, i_CellCol].Color = i_NewColor;
        }

        public void DecreaseEmptyCellCount()
        {
            if (m_NumOfEmptyCells > 0)
            {
                m_NumOfEmptyCells--;
            }
        }

        public void IncreaseEmptyCellCount()
        {
            m_NumOfEmptyCells++;
        }

        public void ResetBoard()
        {
            foreach(Cell cell in BoardMatrix)
            {
                cell.Color = eColor.None;
            }

            m_NumOfEmptyCells = (r_RowsNumber * r_ColsNumber);
            InitialMiddlePieces();
        }

        private void Cell_Selected(object sender, CellEventArgs e)
        {
            OnCellSelected(e.SelectedCell);
        }

        protected virtual void OnCellSelected(Cell i_SelectedCell)
        {           
            CellSelected?.Invoke(this, new CellEventArgs(i_SelectedCell));
        }
    }
}


