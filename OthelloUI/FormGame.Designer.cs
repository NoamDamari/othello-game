using System.Drawing;
using System;
using System.Windows.Forms;
using OthelloLogic;

namespace OthelloUI
{
    partial class FormGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private TableLayoutPanel m_Board;

        private void InitializeComponent()
        {
            this.m_Board = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // m_Board
            // 
            this.m_Board.AutoSize = true;
            this.m_Board.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_Board.BackColor = System.Drawing.Color.Green;
            this.m_Board.ColumnCount = 6;
            this.m_Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.m_Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.m_Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.m_Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.m_Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.m_Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.m_Board.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_Board.Location = new System.Drawing.Point(12, 12);
            this.m_Board.Name = "m_Board";
            this.m_Board.Padding = new System.Windows.Forms.Padding(2);
            this.m_Board.RowCount = 6;
            this.m_Board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.m_Board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.m_Board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.m_Board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.m_Board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.m_Board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.m_Board.Size = new System.Drawing.Size(258, 229);
            this.m_Board.TabIndex = 0;
            // 
            // FormGame
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.m_Board);
            this.Name = "FormGame";
            this.Padding = new System.Windows.Forms.Padding(12);            
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void createBoard()
        {
            this.SuspendLayout();

            if (m_Board != null)
            {
                this.Controls.Clear();
            }

            m_Board = new TableLayoutPanel();
            m_Board.ColumnCount = m_Size;
            m_Board.RowCount = m_Size;
            m_Board.BackColor = Color.Green;
            m_Board.Dock = DockStyle.Fill;
            m_Board.AutoSize = true;
            m_Board.Padding = new Padding(2);
            m_Board.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            createBoardCells();

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Padding = new Padding(12);

            this.Controls.Add(m_Board);
            this.Refresh();
            this.PerformLayout();
            this.ResumeLayout(false);
        }

        private void createBoardCells()
        {
            setCellsSize();

            for (int rowIndex = 0; rowIndex < RowsNumber; rowIndex++)
            {
                for (int colIndex = 0; colIndex < ColsNumber; colIndex++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.BackColor = Color.Blue;
                    pictureBox.Dock = DockStyle.Fill;
                    pictureBox.Click += new EventHandler(PictureBox_Click);

                    m_Board.Controls.Add(pictureBox, colIndex, rowIndex);
                }
            }
        }
      
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}