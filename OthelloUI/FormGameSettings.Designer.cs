using System;
using System.Drawing;
using System.Windows.Forms;

namespace OthelloUI
{
    partial class FormGameSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Button m_ButtonPlayAgainstComputer;
        private Button m_ButtonPlayAgainstFriend;
        private Button m_ButtonSetBoardSize;

        public Button ButtonPlayAgainstComputer
        {
            get
            {
                return m_ButtonPlayAgainstComputer;
            }
        }

        public Button ButtonPlayAgainstFriend
        {
            get
            {
                return m_ButtonPlayAgainstFriend;
            }
        }

        public Button ButtonSetBoardSize
        {
            get
            {
                return m_ButtonSetBoardSize;
            }
        }

        private void InitializeComponent()
        {
            this.m_ButtonPlayAgainstComputer = new System.Windows.Forms.Button();
            this.m_ButtonPlayAgainstFriend = new System.Windows.Forms.Button();
            this.m_ButtonSetBoardSize = new System.Windows.Forms.Button();

            this.SuspendLayout();
            // 
            // m_ButtonPlayAgainstComputer
            // 
            this.m_ButtonPlayAgainstComputer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_ButtonPlayAgainstComputer.Location = new System.Drawing.Point(15, 98);
            this.m_ButtonPlayAgainstComputer.Name = "m_ButtonPlayAgainstComputer";
            this.m_ButtonPlayAgainstComputer.Size = new System.Drawing.Size(189, 46);
            this.m_ButtonPlayAgainstComputer.TabIndex = 0;
            this.m_ButtonPlayAgainstComputer.Text = "Play against the computer";
            this.m_ButtonPlayAgainstComputer.UseVisualStyleBackColor = true;
            // 
            // m_ButtonPlayAgainstFriend
            // 
            this.m_ButtonPlayAgainstFriend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_ButtonPlayAgainstFriend.Location = new System.Drawing.Point(216, 98);
            this.m_ButtonPlayAgainstFriend.Name = "m_ButtonPlayAgainstFriend";
            this.m_ButtonPlayAgainstFriend.Size = new System.Drawing.Size(189, 46);
            this.m_ButtonPlayAgainstFriend.TabIndex = 1;
            this.m_ButtonPlayAgainstFriend.Text = "Play against your friend";
            this.m_ButtonPlayAgainstFriend.UseVisualStyleBackColor = true;
            // 
            // m_ButtonSetBoardSize
            // 
            this.m_ButtonSetBoardSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_ButtonSetBoardSize.Location = new System.Drawing.Point(15, 26);
            this.m_ButtonSetBoardSize.Name = "m_ButtonSetBoardSize";
            this.m_ButtonSetBoardSize.Size = new System.Drawing.Size(390, 45);
            this.m_ButtonSetBoardSize.TabIndex = 2;
            this.m_ButtonSetBoardSize.Text = string.Format("Board Size: 6x6 (click to increase)");
            this.m_ButtonSetBoardSize.UseVisualStyleBackColor = true;
            this.m_ButtonSetBoardSize.Click += new EventHandler(this.m_ButtonSetBoardSize_Click);
            // 
            // FormGameSettings
            // 
            this.ClientSize = new System.Drawing.Size(423, 168);
            this.Controls.Add(this.m_ButtonSetBoardSize);
            this.Controls.Add(this.m_ButtonPlayAgainstFriend);
            this.Controls.Add(this.m_ButtonPlayAgainstComputer);
            this.Name = "FormGameSettings";
            this.Text = "Othello - GameSettings";
            this.ResumeLayout(false);
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