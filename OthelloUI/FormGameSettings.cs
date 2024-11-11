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
    public partial class FormGameSettings : Form
    {
        private int m_BoardSize = 6;

        public int BoardSize
        {
            get
            {
                if (m_BoardSize < 6 || m_BoardSize > 12)
                {
                    m_BoardSize = 6;
                }

                return m_BoardSize;
            }
            private set
            {
                m_BoardSize = value;
            }
        }

        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void m_ButtonSetBoardSize_Click(object sender, EventArgs e)
        {
            BoardSize += 2;
            m_ButtonSetBoardSize.Text = string.Format("Board Size: {0}x{0} (click to increase)", BoardSize);
        }
    }
}
