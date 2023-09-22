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


namespace BattleSim_v3._0
{
    public partial class FRM_Battle : Form
    {
        Random rnd = new Random();
        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }
        bool _gameOver = false;
        string _event = "";
        Player _deadPlayer;

        // Visuals
        // Events
        private void FRM_Battle_Load(object sender, EventArgs e)
        {
            LoadCorrectNeoFighterImage(PB_Player1_NeoFighter, Player1);
            LoadCorrectNeoFighterImage(PB_Player2_NeoFighter, Player2);
            LoadAttacks();
            MirrorImage(PB_Player2_NeoFighter);
            UpdateHealthLabels();
            LBL_Events.Text = "";
            LBL_Damage.Text = "";
        }
        void LoadCorrectNeoFighterImage(PictureBox PB_Player_NeoFighter, Player player)
        {
            if (player.NeoFighter.Name == NeoFighterNames.Korbat)
            {
                PB_Player_NeoFighter.Image = Properties.Resources.Korbat;
            }
            else if (player.NeoFighter.Name == NeoFighterNames.Grarrl)
            {
                PB_Player_NeoFighter.Image = Properties.Resources.Grarrl;
            }
            else if (player.NeoFighter.Name == NeoFighterNames.Blumaroo)
            {
                PB_Player_NeoFighter.Image = Properties.Resources.Blumaroo;
            }
        } // not nice
        void MirrorImage(PictureBox PB_Player_NeoFighter)
        {
            PB_Player_NeoFighter.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            PB_Player_NeoFighter.Invalidate();
        }
        void SwitchTurn()
        {
            BTN_Player1_Attack.Enabled = !BTN_Player1_Attack.Enabled;
            BTN_Player2_Attack.Enabled = !BTN_Player2_Attack.Enabled;
        }
        void UpdateHealthLabels()
        {
            LBL_Player1_Health.Text = "Health: " + Player1.NeoFighter.Health.ToString();
            LBL_Player2_Health.Text = "Health: " + Player2.NeoFighter.Health.ToString();
        }
        void LoadAttacks()
        {
            GB_P1.Text = Player1.NeoFighter.Name.ToString();
            RB_P1_Attack1.Text = Player1.NeoFighter.Attack1Name;
            RB_P1_Attack2.Text = Player1.NeoFighter.Attack2Name;
            RB_P1_Attack3.Text = Player1.NeoFighter.Attack3Name;

            GB_P2.Text = Player2.NeoFighter.Name.ToString();
            RB_P2_Attack1.Text = Player2.NeoFighter.Attack1Name;
            RB_P2_Attack2.Text = Player2.NeoFighter.Attack2Name;
            RB_P2_Attack3.Text = Player2.NeoFighter.Attack3Name;
        }
        void DisableAttackingButtons()
        {
            BTN_Player1_Attack.Enabled = false;
            BTN_Player2_Attack.Enabled = false;
        }
        void UpdateDamageLabel(int damage)
        {
            if (LBL_Damage.Text == damage.ToString())
            {
                LBL_Damage.Text = damage.ToString() + " again";
            }
            else
            {
                LBL_Damage.Text = damage.ToString();
            }
        }
        void CheckEvent(NeoFighter myNeoFighter, int damage)
        {
            if(myNeoFighter.Event.Length > 0)
            {
                _event += myNeoFighter.Event + "\n\n";
                myNeoFighter.ClearEvent();
            }
            // Check who died
            if (_gameOver)
            {
                if (Player1.NeoFighter.Health < 1)
                {
                    PB_Player1_NeoFighter.BackColor = Color.Black;
                }
                if (Player2.NeoFighter.Health < 1)
                {
                    PB_Player2_NeoFighter.BackColor = Color.Black;
                }
                _deadPlayer.NeoFighter.SetDead();
                _event += _deadPlayer.NeoFighter.Name + " died\n\n";
            }
            Player1.NeoFighter.OldStatus = Player1.NeoFighter.Status;
            Player2.NeoFighter.OldStatus = Player2.NeoFighter.Status;
        }
        void UpdateStatusLabel()
        {
            LBL_Status_P1.Text = "Status: " + Player1.NeoFighter.Status.ToString();
            LBL_Status_P2.Text = "Status: " + Player2.NeoFighter.Status.ToString();
            if (Player1.NeoFighter.Status == Statuses.Clear)
            {
                PB_Player1_NeoFighter.BackColor = SystemColors.Control;
            }
            if (Player2.NeoFighter.Status == Statuses.Clear)
            {
                PB_Player2_NeoFighter.BackColor = SystemColors.Control;
            }
        }
        void UpdateEventLabel()
        {
            LBL_Events.Text = _event;
            _event = "";
        }
        void UpdateTotalDamageChange(Label LBL_Health, int damage)
        {
            LBL_Health.Text += ($" (-{damage})");
        }
        void UpdateTotalHealthChange(Player player, Label LBL_Health, int heal)
        {
            if (heal > 0)
            {
                LBL_Health.Text += ($" (+{heal})");
            }
            player.NeoFighter.ResetGainedHealth();
        }

        // Logic
        // Methods
        public FRM_Battle(Player player1, Player player2)
        {
            InitializeComponent();
            Player1 = player1;
            Player2 = player2;
        }
        void PreAttackStatusEffects(NeoFighter enemy, PictureBox PB_NeoFighter)
        {
            if (enemy.Status == Statuses.Flinched)
            {
                enemy.CureStatus();
            }
        }
        int PostAttackStatusEffects(NeoFighter enemy, PictureBox PB_NeoFighter, int damage)
        {
            int statusDamage = 0;
            if (enemy.Status == Statuses.Poisoned)
            {
                statusDamage = 5;
                enemy.LoseHealth(statusDamage);
                enemy.AddPoisonTurn();
                PB_NeoFighter.BackColor = Color.Purple;
            }
            else if (enemy.Status == Statuses.Flinched)
            {
                statusDamage = 0;
                SwitchTurn(); // makes enemy skip turn
                PB_NeoFighter.BackColor = Color.DimGray;
            }
            return statusDamage;
        }
        void CheckIfGameOver()
        {
            if (Player1.NeoFighter.Health <= 0 | Player2.NeoFighter.Health <= 0)
            {
                GameOver();
            }
        }
        void GameOver()
        {
            _gameOver = true;
            DisableAttackingButtons();
            MakeNegativeHealthZero();
        }
        void MakeNegativeHealthZero()
        {
            if (Player1.NeoFighter.Health <= 0)
            {
                Player1.NeoFighter.GainHealth(Player1.NeoFighter.Health * -1);
                _deadPlayer = Player1;
            }
            if (Player2.NeoFighter.Health <= 0)
            {
                Player2.NeoFighter.GainHealth(Player2.NeoFighter.Health * -1);
                _deadPlayer = Player2;
            }
        }


        // Events
        private void BTN_Player1_Attack_Click(object sender, EventArgs e)
        {
            // pre attack status
            PreAttackStatusEffects(Player2.NeoFighter, PB_Player2_NeoFighter);
            Turn(Player1, PB_Player1_NeoFighter, LBL_Player1_Health, Player2, PB_Player2_NeoFighter, LBL_Player2_Health, Attack_Player1());
        }
        private void BTN_Player2_Attack_Click(object sender, EventArgs e)
        {
            // pre attack status
            PreAttackStatusEffects(Player1.NeoFighter, PB_Player1_NeoFighter);
            Turn(Player2, PB_Player2_NeoFighter, LBL_Player2_Health, Player1, PB_Player1_NeoFighter, LBL_Player1_Health, Attack_Player2());
        }
        void Turn(Player player, PictureBox PB_Player_NeoFighter, Label LBL_Player_Health, Player enemy, PictureBox PB_Enemy_NeoFighter, Label LBL_Enemy_Health, int damage)
        {
            // damage
            enemy.NeoFighter.LoseHealth(damage);
            UpdateDamageLabel(damage);
            // post attack status
            int statusDamage = PostAttackStatusEffects(enemy.NeoFighter, PB_Enemy_NeoFighter, damage);
            int totalDamage = damage + statusDamage;
            // event
            CheckIfGameOver();
            CheckEvent(player.NeoFighter, damage);
            UpdateStatusLabel();
            UpdateEventLabel();
            // other
            UpdateHealthLabels();
            UpdateTotalDamageChange(LBL_Enemy_Health, totalDamage);
            UpdateTotalHealthChange(player, LBL_Player_Health, player.NeoFighter.GainedHealth);
            if (!_gameOver)
            {
                SwitchTurn();
            }
        }
        int Attack_Player1()
        {
            if (RB_P1_Attack1.Checked)
            {
                return Player1.NeoFighter.Attack1(rnd, Player2.NeoFighter);
            }
            else if (RB_P1_Attack2.Checked)
            {
                return Player1.NeoFighter.Attack2(rnd, Player2.NeoFighter);
            }
            else if (RB_P1_Attack3.Checked)
            {
                return Player1.NeoFighter.Attack3(rnd, Player2.NeoFighter);
            }
            else
            {
                return 999999999;
            }
        }
        int Attack_Player2()
        {
            if (RB_P2_Attack1.Checked)
            {
                return Player2.NeoFighter.Attack1(rnd, Player1.NeoFighter);
            }
            else if (RB_P2_Attack2.Checked)
            {
                return Player2.NeoFighter.Attack2(rnd, Player1.NeoFighter);
            }
            else if (RB_P2_Attack3.Checked)
            {
                return Player2.NeoFighter.Attack3(rnd, Player1.NeoFighter);
            }
            else
            {
                return 999999999;
            }
        }
    }
}
