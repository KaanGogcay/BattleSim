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
using Newtonsoft.Json;
using System.Net.Sockets;

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
        // Fields
        int _agentDecisionDelay = 1000; // in ms

        // Properties
        public int AgentDecisionDelay { get { return _agentDecisionDelay; } }
        public AgentType AgentType { get; set; }

        // Methods
        public Agent(AgentType agentType)
        {
            AgentType = agentType;
        }

        public void ChooseRandomAttack(RadioButton rb1, RadioButton rb2, RadioButton rb3)
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

        public void SendGameState(Player p1, Player p2, NetworkStream stream)
        {
            // p1 data
            int p1_specie = (int)p1.NeoFighter.Species;
            int p1_health = p1.NeoFighter.Health;
            int p1_attackPower = p1.NeoFighter.AttackPower;
            int p1_status = (int)p1.NeoFighter.Status;
            // p2 data
            int p2_specie = (int)p2.NeoFighter.Species;
            int p2_health = p2.NeoFighter.Health;
            int p2_attackPower = p2.NeoFighter.AttackPower;
            int p2_status = (int)p2.NeoFighter.Status;
            // format data - attempt 1
            int[] p1_vars = { p1_specie, p1_health, p1_attackPower, p1_status };
            int[] p2_vars = { p2_specie, p2_health, p2_attackPower, p2_status };
            int[][] state1 = { p1_vars, p2_vars };
            // format data - attempt 2
            int[] state2 = { p1_specie, p1_health, p1_attackPower, p1_status, p2_specie, p2_health, p2_attackPower, p2_status };
            // Serialize the array to JSON
            string json = JsonConvert.SerializeObject(state2);
            // Convert the JSON string to bytes
            byte[] data = Encoding.UTF8.GetBytes(json);
            // Send the data
            stream.Write(data, 0, data.Length);

        }

        public void ReceiveAction()
        {

        }
    }
}
