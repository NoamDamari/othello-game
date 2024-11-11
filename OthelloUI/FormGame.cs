using OthelloLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OthelloUI
{
    public partial class FormGame : Form
    {
        private const int k_CellSize = 50;
        private const int k_Gap = 12;
        private int m_Size = 6;

        public event EventHandler<CellClickedEventArgs> CellClicked;
            
        public int RowsNumber
        {
            get
            {
                return m_Board.RowCount;
            }
        }

        public int ColsNumber
        {
            get
            {
                return m_Board.ColumnCount;
            }
        }

        public FormGame()
        {
            InitializeComponent();
        }

        public void InitializeBoard(int i_Size)
        {
            m_Size = i_Size;
            createBoard();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;
            TableLayoutPanelCellPosition cellPosition = m_Board.GetPositionFromControl(clickedPictureBox);

            OnCellClicked(cellPosition.Row, cellPosition.Column);
        }

        protected virtual void OnCellClicked(int i_ClickedCellRow, int i_ClickedCellCol)
        {
            CellClicked?.Invoke(this, new CellClickedEventArgs(i_ClickedCellRow, i_ClickedCellCol));
        }

        private void setCellsSize()
        {
            setRowsSize();
            setColsSize();
        }

        private void setRowsSize()
        {
            m_Board.RowStyles.Clear();

            for (int i = 0; i < RowsNumber; i++)
            {
                m_Board.RowStyles.Add(new RowStyle(SizeType.Absolute, k_CellSize));
            }
        }

        private void setColsSize()
        {
            m_Board.ColumnStyles.Clear();

            for (int i = 0; i < ColsNumber; i++)
            {
                m_Board.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, k_CellSize));
            }
        }

        public void UpdateFormTitle(string i_Title)
        {
            this.Text = i_Title;
        }

        public void UpdateCell(int i_RowIndex, int i_ColumnIndex, eColor i_Color)
        {
            Control cell = m_Board.GetControlFromPosition(i_ColumnIndex, i_RowIndex);
            PictureBox pictureBox = cell as PictureBox;

            if (pictureBox != null)
            {
                switch (i_Color)
                {
                    case eColor.Red:
                        pictureBox.Enabled = false;
                        pictureBox.BackColor = Color.LightGray;
                        pictureBox.Image = Properties.Resources.CoinRed;
                        break;

                    case eColor.Yellow:
                        pictureBox.Enabled = false;
                        pictureBox.BackColor = Color.LightGray;
                        pictureBox.Image = Properties.Resources.CoinYellow;
                        break;

                    case eColor.Green:
                        pictureBox.Enabled = true;
                        pictureBox.BackColor = Color.LightGreen;
                        break;

                    case eColor.Grey:
                        pictureBox.Enabled = false;
                        pictureBox.BackColor = Color.LightGray;
                        break;

                    case eColor.None:
                        pictureBox.Image = null;
                        pictureBox.Enabled = true;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
