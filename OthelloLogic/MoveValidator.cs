using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloLogic
{
    public static class MoveValidator
    {
        public static bool IsValidMoveForPlayer(Board i_GameBoard, Player i_Player, Cell i_PlayerCellSelection)
        {
            bool isValidMoveByGameRules = false;
            bool isValidCellIndexSelection = isValidCellSelection(i_GameBoard, i_Player, i_PlayerCellSelection);

            if (isValidCellIndexSelection)
            {
                isValidMoveByGameRules = IsMoveValidByGameRules(i_GameBoard, i_PlayerCellSelection, i_Player.Color);        
            }

            return isValidCellIndexSelection && isValidMoveByGameRules;
        }

        public static Cell ValidateCellSelection(Board i_GameBoard, Player i_Player, Cell i_PlayerCellSelection)
        {           
            while (!IsValidMoveForPlayer(i_GameBoard, i_Player, i_PlayerCellSelection))             
            {            
                i_PlayerCellSelection = i_Player.SelectCell(i_GameBoard);
            }

            return i_PlayerCellSelection;
        }

        private static bool isValidCellSelection(Board i_GameBoard, Player i_Player, Cell i_PlayerCellSelection)
        {
            bool isValidCellSelection = false;
            bool isInBoardRange = OtheloGameUtils.IsInBoardSizeRange(i_GameBoard, i_PlayerCellSelection.RowIndex, i_PlayerCellSelection.ColIndex);

            if (isInBoardRange)
            {
                bool isValidEmptyCell = isEmptyCell(i_GameBoard, i_PlayerCellSelection.RowIndex, i_PlayerCellSelection.ColIndex);

                if (isValidEmptyCell)
                {
                    isValidCellSelection = true;
                }
            }
            
            return isValidCellSelection;           
        }
     
        private static bool isEmptyCell(Board i_GameBoard, int i_RowIndex, int i_ColIndex)
        {
            bool isEmptyCell = false;

            try
            {                
                isEmptyCell = i_GameBoard.BoardMatrix[i_RowIndex, i_ColIndex].Color != eColor.Red &&
                    i_GameBoard.BoardMatrix[i_RowIndex, i_ColIndex].Color != eColor.Yellow;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return isEmptyCell;
        }

        public static bool IsMoveValidByGameRules(Board i_GameBoard, Cell i_Cell, eColor i_PlayerColor)
        {
            return OtheloGameUtils.CheckCellRow(i_GameBoard, i_Cell, i_PlayerColor) ||
                   OtheloGameUtils.CheckCellCol(i_GameBoard, i_Cell, i_PlayerColor) ||
                   OtheloGameUtils.CheckCellDiagonals(i_GameBoard, i_Cell, i_PlayerColor);
        }      
    }
}
