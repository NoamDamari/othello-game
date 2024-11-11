using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloLogic
{
    public class TurnEventArgs : EventArgs
    {
        private string m_ActivePlayerName;

        public string ActivePlayerName
        {
            get
            {
                return m_ActivePlayerName;
            }
        }

        public TurnEventArgs(string i_ActivePlayerName)
        {
            m_ActivePlayerName = i_ActivePlayerName;
        }
    }
}
