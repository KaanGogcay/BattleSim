using Logic;
using Logic.NeoFighters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// currently working on SetAgent

namespace BattleSim_v3._0
{
    public partial class FRM_ChooseNeoFighter : Form
    {
        public FRM_ChooseNeoFighter(Form frm_titleScreen)
        {
            InitializeComponent();
            FRM_TitleScreen = frm_titleScreen;
        }

        public Form FRM_TitleScreen { get; set; }

        private void FRM_Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            FRM_TitleScreen.Show();
        }

        // Hardcoded (dynamically fill a list with radio buttons based of their name)
        private void BTN_Start_Click(object sender, EventArgs e)
        {
            Player player1 = new Player();
            SetNeoFighterPlayer(player1, RB_Player1_Korbat, RB_Player1_Grarrl, RB_Player1_Blumaroo, RB_Player1_Meepit, RB_Player1_Kacheek, RB_Player1_KikoAndChia);
            // set agent 1
            Player player2 = new Player();
            SetNeoFighterPlayer(player2, RB_Player2_Korbat, RB_Player2_Grarrl, RB_Player2_Blumaroo, RB_Player2_Meepit, RB_Player2_Kacheek, RB_Player2_KikoAndChia);
            SetAgent(player2, RB_Agent2_Disabled, RB_Agent2_Random, RB_Agent2_RL);
            this.Hide();
            new FRM_Battle(this, player1, player2).Show();
        }
        // Hardcode
        void SetNeoFighterPlayer(Player player, RadioButton RB_Korbat, RadioButton RB_Grarrl, RadioButton RB_Blumaroo, RadioButton RB_Meepit, RadioButton RB_Kacheek, RadioButton RB_KikoAndChia) // Radio button list
        {
            if (RB_Korbat.Checked)
            {
                player.SetNeoFighter(new Korbat());
            }
            else if (RB_Grarrl.Checked)
            {
                player.SetNeoFighter(new Grarrl());
            }
            else if (RB_Blumaroo.Checked)
            {
                player.SetNeoFighter(new Blumaroo());
            }
            else if (RB_Meepit.Checked)
            {
                player.SetNeoFighter(new Meepit());
            }
            else if (RB_Kacheek.Checked)
            {
                player.SetNeoFighter(new Kacheek());
            }
            else if (RB_KikoAndChia.Checked)
            {
                player.SetNeoFighter(new KikoAndChia());
            }
            else
            {
                throw new Exception();
            }
        }
        void SetAgent(Player player, RadioButton RB_Agent_Disabled, RadioButton RB_Agent_Random, RadioButton RB_Agent_ReinforcementLearning)
        {
            if (RB_Agent_Disabled.Checked)
            {
                player.SetAgent(AgentType.Disabled);
            }
            else if (RB_Agent_Random.Checked)
            {
                player.SetAgent(AgentType.Random);
            }
            else if (RB_Agent_ReinforcementLearning.Checked)
            {
                player.SetAgent(AgentType.ReinforcementLearning);
            }
        }
        // Player 1 NeoFighter Stats - Hardcode (idea, foreachloop for all radiobuttons, based of their name, give them events)
        private void RB_Player1_Korbat_CheckedChanged(object sender, EventArgs e)
        {
            SetLabels(LBL_Player1_Health, LBL_Player1_AttackPower, LBL_Player1_Description, PB_Player1_NeoFighter, new Korbat());
        }
        private void RB_Player1_Grarrl_CheckedChanged(object sender, EventArgs e)
        {
            SetLabels(LBL_Player1_Health, LBL_Player1_AttackPower, LBL_Player1_Description, PB_Player1_NeoFighter, new Grarrl());
        }
        private void RB_Player1_Blumaroo_CheckedChanged(object sender, EventArgs e)
        {
            SetLabels(LBL_Player1_Health, LBL_Player1_AttackPower, LBL_Player1_Description, PB_Player1_NeoFighter, new Blumaroo());
        }
        private void RB_Player1_Meepit_CheckedChanged(object sender, EventArgs e)
        {
            SetLabels(LBL_Player1_Health, LBL_Player1_AttackPower, LBL_Player1_Description, PB_Player1_NeoFighter, new Meepit());
        }
        private void RB_Player1_Kacheek_CheckedChanged(object sender, EventArgs e)
        {
            SetLabels(LBL_Player1_Health, LBL_Player1_AttackPower, LBL_Player1_Description, PB_Player1_NeoFighter, new Kacheek());
        }
        private void RB_KikoAndChia_Player1_CheckedChanged(object sender, EventArgs e)
        {
            SetLabels(LBL_Player1_Health, LBL_Player1_AttackPower, LBL_Player1_Description, PB_Player1_NeoFighter, new KikoAndChia());
        }

        // Player 2 NeoFighter Stats - Hardcode
        private void RB_Player2_Korbat_CheckedChanged(object sender, EventArgs e)
        {
            SetLabels(LBL_Player2_Health, LBL_Player2_AttackPower, LBL_Player2_Description, PB_Player2_NeoFighter, new Korbat());
        }
        private void RB_Player2_Grarrl_CheckedChanged(object sender, EventArgs e)
        {
            SetLabels(LBL_Player2_Health, LBL_Player2_AttackPower, LBL_Player2_Description, PB_Player2_NeoFighter, new Grarrl());
        }
        private void RB_Player2_Blumaroo_CheckedChanged(object sender, EventArgs e)
        {
            SetLabels(LBL_Player2_Health, LBL_Player2_AttackPower, LBL_Player2_Description, PB_Player2_NeoFighter, new Blumaroo());
        }
        private void RB_Player2_Meepit_CheckedChanged(object sender, EventArgs e)
        {
            SetLabels(LBL_Player2_Health, LBL_Player2_AttackPower, LBL_Player2_Description, PB_Player2_NeoFighter, new Meepit());
        }
        private void RB_Player2_Kacheek_CheckedChanged(object sender, EventArgs e)
        {
            SetLabels(LBL_Player2_Health, LBL_Player2_AttackPower, LBL_Player2_Description, PB_Player2_NeoFighter, new Kacheek());
        }
        private void RB_KikoAndChia_Player2_CheckedChanged(object sender, EventArgs e)
        {
            SetLabels(LBL_Player2_Health, LBL_Player2_AttackPower, LBL_Player2_Description, PB_Player2_NeoFighter, new KikoAndChia());
        }
        // Hardcode
        void SetLabels(Label LBL_Health, Label LBL_AttackPower, Label LBL_Description, PictureBox PB_NeoFighter, NeoFighter neoFighter)
        {
            LBL_Health.Text = $"Health: {neoFighter.Health}";
            LBL_AttackPower.Text = $"Attack Power: {neoFighter.AttackPower}";
            LBL_Description.Text = $"Description: {neoFighter.Description}";

            // Hardcode
            if (neoFighter is Korbat)
            {
                PB_NeoFighter.Image = Properties.Resources.Korbat;
            }
            else if (neoFighter is Grarrl)
            {
                PB_NeoFighter.Image = Properties.Resources.Grarrl;
            }
            else if (neoFighter is Blumaroo)
            {
                PB_NeoFighter.Image = Properties.Resources.Blumaroo;
            }
            else if (neoFighter is Meepit)
            {
                PB_NeoFighter.Image = Properties.Resources.Meepit;
            }
            else if (neoFighter is Kacheek)
            {
                PB_NeoFighter.Image = Properties.Resources.Kacheek;
            }
            else if (neoFighter is KikoAndChia)
            {
                PB_NeoFighter.Image = Properties.Resources.KikoAndChia;
            }
        }

    }
}
