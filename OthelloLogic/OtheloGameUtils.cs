using System;
using System.Collections.Generic;

namespace OthelloLogic
{
    public static class OtheloGameUtils
    {
        private static readonly Random s_Random = new Random();

        public static void ApplyMoveAndFlip(Board i_GameBoard, Cell i_Cell, Player i_Player)
        {
            eColor playerColor = i_Player.Color;

            i_GameBoard.BoardMatrix[i_Cell.RowIndex, i_Cell.ColIndex].Color = playerColor;
            flipInDirection(i_GameBoard, i_Cell, playerColor, 0, 1);  // Right
            flipInDirection(i_GameBoard, i_Cell, playerColor, 0, -1); // Left
            flipInDirection(i_GameBoard, i_Cell, playerColor, 1, 0);  // Down
            flipInDirection(i_GameBoard, i_Cell, playerColor, -1, 0); // Up
            flipInDirection(i_GameBoard, i_Cell, playerColor, 1, 1);  // Down-right
            flipInDirection(i_GameBoard, i_Cell, playerColor, 1, -1); // Down-left
            flipInDirection(i_GameBoard, i_Cell, playerColor, -1, 1); // Up-right
            flipInDirection(i_GameBoard, i_Cell, playerColor, -1, -1);// Up-left
        }

        // Check all rows for valid moves
        public static bool CheckCellRow(Board i_GameBoard, Cell i_Cell, eColor i_PlayerColor)
        {
            return checkDirection(i_GameBoard, i_Cell, i_PlayerColor, 0, 1) || // Right
                   checkDirection(i_GameBoard, i_Cell, i_PlayerColor, 0, -1);  // Left
        }

        // Check all columns for valid moves
        public static bool CheckCellCol(Board i_GameBoard, Cell i_Cell, eColor i_PlayerColor)
        {
            return checkDirection(i_GameBoard, i_Cell, i_PlayerColor, 1, 0) || // Down
                   checkDirection(i_GameBoard, i_Cell, i_PlayerColor, -1, 0);  // Up
        }

        public static bool CheckCellDiagonals(Board i_GameBoard, Cell i_Cell, eColor i_PlayerColor)
        {
            return checkDirection(i_GameBoard, i_Cell, i_PlayerColor, 1, 1) ||  // Down-right
                   checkDirection(i_GameBoard, i_Cell, i_PlayerColor, 1, -1) || // Down-left
                   checkDirection(i_GameBoard, i_Cell, i_PlayerColor, -1, 1) || // Up-right
                   checkDirection(i_GameBoard, i_Cell, i_PlayerColor, -1, -1);  // Up-left
        }

        private static bool checkDirection(Board i_GameBoard, Cell i_Cell, eColor i_PlayerColor, int i_RowDir, int i_ColDir)
        {
            eColor opponentColor = (i_PlayerColor == eColor.Red) ? eColor.Yellow : eColor.Red;
            bool hasOpponentBetween = false;
            int row = i_Cell.RowIndex + i_RowDir;
            int col = i_Cell.ColIndex + i_ColDir;

            while (IsInBoardSizeRange(i_GameBoard, row, col) &&
                   i_GameBoard.BoardMatrix[row, col].Color == opponentColor)
            {
                hasOpponentBetween = true;
                row += i_RowDir;
                col += i_ColDir;
            }

            return hasOpponentBetween && IsInBoardSizeRange(i_GameBoard, row, col) &&
                i_GameBoard.BoardMatrix[row, col].Color == i_PlayerColor;
        }

        private static void flipInDirection(Board i_GameBoard, Cell i_Cell, eColor i_PlayerColor, int i_RowDir, int i_ColDir)
        {
            eColor opponentColor = (i_PlayerColor == eColor.Red) ? eColor.Yellow : eColor.Red;
            int row = i_Cell.RowIndex + i_RowDir;
            int col = i_Cell.ColIndex + i_ColDir;
            List<(int, int)> positionsToFlip = new List<(int, int)>();

            while (IsInBoardSizeRange(i_GameBoard, row, col) &&
                   i_GameBoard.BoardMatrix[row, col].Color == opponentColor)
            {
                positionsToFlip.Add((row, col));
                row += i_RowDir;
                col += i_ColDir;
            }

            if (IsInBoardSizeRange(i_GameBoard, row, col) &&
                i_GameBoard.BoardMatrix[row, col].Color == i_PlayerColor)
            {
                foreach (var position in positionsToFlip)
                {
                    i_GameBoard.BoardMatrix[position.Item1, position.Item2].Color = i_PlayerColor;
                }
            }
        }

        public static bool IsInBoardSizeRange(Board i_GameBoard, int i_Row, int i_Col)
        {
            return i_Row >= 0 && i_Row < i_GameBoard.RowsNumber &&
                   i_Col >= 0 && i_Col < i_GameBoard.ColsNumber;
        }

        public static bool HasValidMoveOption(Board i_GameBoard, Player i_Player)
        {
            bool hasValidMoveOption = false;

            for (int row = 0; row < i_GameBoard.RowsNumber; row++)
            {
                for (int col = 0; col < i_GameBoard.ColsNumber; col++)
                {
                    Cell cell = i_GameBoard.BoardMatrix[row, col];

                    if (cell.Color != eColor.Red && cell.Color != eColor.Yellow)
                    {
                        if (MoveValidator.IsMoveValidByGameRules(i_GameBoard, cell, i_Player.Color))
                        {
                            hasValidMoveOption = true;                          
                            break;
                        }
                    }
                }
            }

            return hasValidMoveOption;
        }

        public static bool HasNoAvailableMoves(Game i_Game)
        {
            return !HasValidMoveOption(i_Game.GameBoard, i_Game.Player1) && !HasValidMoveOption(i_Game.GameBoard, i_Game.Player2);
        }

        public static Player GetWinner(Game i_Game)
        {
            int redCellsCount = countPlayerCells(i_Game.GameBoard, eColor.Red);
            int yellowCellsCount = countPlayerCells(i_Game.GameBoard, eColor.Yellow);

            i_Game.Player1.PointsNumber = (i_Game.Player1.Color == eColor.Red) ? redCellsCount : yellowCellsCount;
            i_Game.Player2.PointsNumber = (i_Game.Player2.Color == eColor.Red) ? redCellsCount : yellowCellsCount;

            return i_Game.Player1.PointsNumber > i_Game.Player2.PointsNumber ? i_Game.Player1 : i_Game.Player2;
        }

        private static int countPlayerCells(Board i_GameBoard, eColor i_Color)
        {
            int count = 0;

            foreach (Cell cell in i_GameBoard.BoardMatrix)
            {
                if (cell.Color == i_Color)
                {
                    count++;
                }
            }

            return count;
        }

        public static List<Cell> GetAllValidMoves(Board i_GameBoard, Player i_Player)
        {
            List<Cell> validMoves = new List<Cell>();
            eColor playerColor = i_Player.Color;

            for (int row = 0; row < i_GameBoard.RowsNumber; row++)
            {
                for (int col = 0; col < i_GameBoard.ColsNumber; col++)
                {
                    Cell cell = i_GameBoard.BoardMatrix[row, col];

                    if (cell.Color != eColor.Red && cell.Color != eColor.Yellow)
                    {
                        if (MoveValidator.IsMoveValidByGameRules(i_GameBoard, cell, i_Player.Color))
                        {
                            validMoves.Add(cell);
                        }
                    }
                }
            }

            return validMoves;
        }

        public static Cell GetRandomMove(Board i_GameBoard, Player i_Player)
        {
            List<Cell> validMoves = GetAllValidMoves(i_GameBoard, i_Player);
            Cell randomCell = new Cell();

            if (validMoves.Count != 0)
            {
                int randomIndex = s_Random.Next(validMoves.Count);
                randomCell = validMoves[randomIndex];
            }

            return randomCell;
        }
    }
}

