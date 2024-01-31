using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.NeoFighters;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Logic
{
    public enum AgentType
    {
        Disabled,
        Random, 
        ReinforcementLearning
    }
    public class Agent
    {
        public Agent(AgentType agentType)
        {
            AgentType = agentType;
        }
        public AgentType AgentType { get; set; }

        public void ChooseAttack(RadioButton rb1, RadioButton rb2, RadioButton rb3)
        {
            Random rnd = new Random();
            int r = rnd.Next(1, 4);
            if (r == 1)
            {
                rb1.Checked = true;
            }
            else if (r == 2)
            {
                rb2.Checked = true;
            }
            else if (r == 3)
            {
                rb3.Checked = true;
            }
        }

        public void SendGameState()
        {

        }

        public void ReceiveAction()
        {

        }
    }
}
