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
        // Fields
        // Fields
        Random rnd = new Random();
        public Form FRM_ChooseNeoFighter { get; private set; }
        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }
        bool _gameOver = false;
        string _event = "";
        Player _deadPlayer;
        Color _poisonColor = Color.Purple;
        Color _sleepColor = Color.DarkBlue;
        Color _flinchColor = Color.DimGray;
        Color _noStatusColor = SystemColors.Control;

        // Visuals
        // Visuals
        private void FRM_Battle_Load(object sender, EventArgs e)
        {
            LoadCorrectNeoFighterImage(PB_NeoFighter_P1, Player1);
            LoadCorrectNeoFighterImage(PB_NeoFighter_P2, Player2);
            LoadAttacks();
            MirrorImage(PB_NeoFighter_P2);
            UpdateHealthLabels();
            UpdateAttackPowerLabels();
            LBL_Events.Text = "";
            LBL_Damage.Text = "";
        }
        void CheckEvent(NeoFighter myNeoFighter, NeoFighter enemyNeoFighter, int damage)
        {
            if (myNeoFighter.Event.Length > 0)
            {
                _event += myNeoFighter.Event;
                myNeoFighter.ClearEvent();
            }
            if (enemyNeoFighter.Event.Length > 0)
            {
                _event += enemyNeoFighter.Event;
                enemyNeoFighter.ClearEvent();
            }
            // Check who died
            if (_gameOver)
            {
                if (Player1.NeoFighter.Health < 1)
                {
                    PB_NeoFighter_P1.BackColor = Color.Black;
                }
                if (Player2.NeoFighter.Health < 1)
                {
                    PB_NeoFighter_P2.BackColor = Color.Black;
                }
                _deadPlayer.NeoFighter.SetDead();
                _event += _deadPlayer.NeoFighter.Name + " died\n\n";
            }
            Player1.NeoFighter.OldStatus = Player1.NeoFighter.Status;
            Player2.NeoFighter.OldStatus = Player2.NeoFighter.Status;
        }
        void DisableAttackingButtons()
        {
            BTN_Player1_Attack.Enabled = false;
            BTN_Player2_Attack.Enabled = false;
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
        // Hardcode
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
            else if (player.NeoFighter.Name == NeoFighterNames.Meepit)
            {
                PB_Player_NeoFighter.Image = Properties.Resources.Meepit;
            }
            else if (player.NeoFighter.Name == NeoFighterNames.Kacheek)
            {
                PB_Player_NeoFighter.Image = Properties.Resources.Kacheek;
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
        void UpdateEventLabel()
        {
            LBL_Events.Text = _event;
            _event = "";
        }
        void UpdateHealthLabels()
        {
            LBL_Player1_Health.Text = "Health: " + Player1.NeoFighter.Health.ToString();
            LBL_Player2_Health.Text = "Health: " + Player2.NeoFighter.Health.ToString();
        }
        void UpdateStatusLabels(NeoFighter nf, PictureBox pb, Label lbl)
        {
            lbl.Text = "Status: " + nf.Status.ToString();
            if (nf.Status == Statuses.Clear)
            {
                pb.BackColor = _noStatusColor;
            }
            else if (nf.Status == Statuses.Poisoned)
            {
                pb.BackColor = _poisonColor;
            }

        }
        void UpdateTotalDamageChange(Label LBL_Health, int damage)
        {
            if (damage > 0)
            {
                LBL_Health.Text += ($" (-{damage})");
            }
        }
        void UpdateTotalHealthChange(Player player, Player enemy, Label LBL_Health, int heal)
        {
            if (heal > 0)
            {
                LBL_Health.Text += ($" (+{heal})");
            }
            else if (heal < 0)
            {
                LBL_Health.Text += ($" ({heal})");
            }
            player.NeoFighter.ResetGainedHealth();
            enemy.NeoFighter.ResetGainedHealth();
        }
        void UpdateAttackPowerLabels()
        {
            LBL_Player1_AttackPower.Text = $"Attack Power: {Player1.NeoFighter.AttackPower}";
            LBL_Player2_AttackPower.Text = $"Attack Power: {Player2.NeoFighter.AttackPower}";
        }

        // Logic
        // Logic
        public FRM_Battle(Form frm_chooseNeoFighter, Player player1, Player player2)
        {
            InitializeComponent();
            FRM_ChooseNeoFighter = frm_chooseNeoFighter;
            Player1 = player1;
            Player2 = player2;
        }
        /// <summary>Status Effects that get checked before an Attack</summary>
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
            // To prevent that negative numbers will be shown in the battle screen

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
        void PreAttackStatusEffects(NeoFighter enemy, PictureBox PB_NeoFighter)
        {
            if (enemy.Status == Statuses.Flinched)
            {
                enemy.CureStatus();
            }
            else if (enemy.Status == Statuses.Asleep)
            {
                PB_NeoFighter.BackColor = _sleepColor;
            }
        }
        void Turn(Player player, PictureBox PB_Player_NeoFighter, Label LBL_Player_Health, Player enemy, PictureBox PB_Enemy_NeoFighter, Label LBL_Enemy_Health, int damage)
        {
            // damage
            enemy.NeoFighter.LoseHealth(damage);
            UpdateDamageLabel(damage);
            // post attack status
            PostAttackStatusEffectPlayer(player.NeoFighter, PB_Player_NeoFighter);
            int statusDamage = PostAttackStatusEffectsEnemy(player.NeoFighter, enemy.NeoFighter, PB_Enemy_NeoFighter);
            int totalDamage = damage + statusDamage;
            // events
            CheckIfGameOver();
            CheckEvent(player.NeoFighter, enemy.NeoFighter, damage);
            // update canvas
            UpdateStatusLabels(Player1.NeoFighter, PB_NeoFighter_P1, LBL_Status_P1);
            UpdateStatusLabels(Player2.NeoFighter, PB_NeoFighter_P2, LBL_Status_P2);
            UpdateEventLabel();
            UpdateHealthLabels();
            UpdateAttackPowerLabels();
            UpdateTotalDamageChange(LBL_Enemy_Health, totalDamage);
            UpdateTotalHealthChange(player, enemy, LBL_Player_Health, player.NeoFighter.GainedHealth);
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
        int PostAttackStatusEffectsEnemy(NeoFighter me, NeoFighter enemy, PictureBox PB_EnemyNeoFighter)
        {
            int statusDamage = 0;
            if (enemy.Status == Statuses.Flinched)
            {
                statusDamage = 0;
                SwitchTurn(); // makes enemy skip turn
                PB_EnemyNeoFighter.BackColor = _flinchColor;
            }
            else if (enemy.Status == Statuses.Asleep)
            {
                enemy.AddSleepTurn();
                if (enemy.Status == Statuses.Asleep) // if still asleep skip turn
                {
                    if (me.Status == Statuses.Asleep) // if both asleep wake up the enemy
                    {
                        int i = 0;
                        while (enemy.Status == Statuses.Asleep)
                        {
                            enemy.AddSleepTurn();
                        }
                    }
                    else
                    {
                        SwitchTurn(); // makes enemy skip turn
                        PB_EnemyNeoFighter.BackColor = _sleepColor;
                    }
                }
            }
            return statusDamage;
        }
        void PostAttackStatusEffectPlayer(NeoFighter me, PictureBox PB_MyNeoFighter)
        {
            int statusDamage = 0;
            if (me.Status == Statuses.Poisoned)
            {
                statusDamage = 5;
                me.LoseHealth(statusDamage); // poison damage
                me.AddPoisonTurn();
                PB_MyNeoFighter.BackColor = _poisonColor;
            }
            else if (me.Status == Statuses.Asleep)
            {
                PB_MyNeoFighter.BackColor = _sleepColor;
            }
        }


        // Events
        // Events
        private void FRM_Battle_FormClosed(object sender, FormClosedEventArgs e)
        {
            FRM_ChooseNeoFighter.Show();
        }
        private void BTN_Player1_Attack_Click(object sender, EventArgs e)
        {
            // pre attack status
            PreAttackStatusEffects(Player2.NeoFighter, PB_NeoFighter_P2);
            Turn(Player1, PB_NeoFighter_P1, LBL_Player1_Health, Player2, PB_NeoFighter_P2, LBL_Player2_Health, Attack_Player1());
        }
        private void BTN_Player2_Attack_Click(object sender, EventArgs e)
        {
            // pre attack status
            PreAttackStatusEffects(Player1.NeoFighter, PB_NeoFighter_P1);
            Turn(Player2, PB_NeoFighter_P2, LBL_Player2_Health, Player1, PB_NeoFighter_P1, LBL_Player1_Health, Attack_Player2());
        }
    }
}
