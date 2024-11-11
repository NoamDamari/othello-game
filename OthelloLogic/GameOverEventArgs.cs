using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloLogic
{
    public class GameOverEventArgs : EventArgs
    {
        private string m_GameResults;

        public string GameResults
        {
            get
            {
                return m_GameResults;
            }
        }

        public GameOverEventArgs(string i_GameResults)
        {
            m_GameResults = i_GameResults;
        }
    }
}
