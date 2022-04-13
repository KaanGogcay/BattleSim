using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleSim
{
    public partial class FRM_Battle : Form
    {
        public FRM_Battle()
        {
            InitializeComponent();
        }

        // create fighters
        Korbat korbat = new Korbat();
        Grarrl grarrl = new Grarrl();

        // create objects
        Random rnd = new Random();

        // Create Variables
        static int criticalHitsInARow = 0;
        static int grarrlPoisonTurns = 0;
        static int grarrlAttack = 0;
        static int korbatAttack = 0;
        const int poisonDamage = 5;
        bool korbatsTurn = true;

        // start button
        private void BTN_Start_Click(object sender, EventArgs e)
        {
            // make visible what has to be visible
            LBL_KorbatHitpoints.Visible = true;
            LBL_GrarrlHitpoints.Visible = true;
            TB_KorbatHitpoints.Visible = true;
            TB_GrarrlHitpoints.Visible = true;
            BTN_KorbatAttacks.Visible = true;
            BTN_GrarrlAttacks.Visible = true;
            GB_KorbatAbility.Visible = true;
            GB_GrarrlAbility.Visible = true;
            LBL_KorbatName.Visible = true;
            LBL_GrarrlName.Visible = true;
            LBL_Damage.Visible = true;
            PB_Korbat.Visible = true;
            PB_Grarrl.Visible = true;

            // make invisible what has to be invisible
            PB_DjKhaledOnCoach.Visible = false;
            LBL_GameTitle.Visible = false;
            BTN_Start.Visible = false;

        }//BTN_Start



        //--------------//
        //---[KORBAT]---//
        //--------------//
        private void BTN_KorbatAttacks_Click(object sender, EventArgs e)
        {
            RemoveNotifications();

            // repeated notifications
            if (grarrl.Poisoned == true)
            {
                LBL_PoisonNotification.Visible = true;
            }



            //---------------------//
            //---[CHOOSE ATTACK]---//
            //---------------------//

            if (RB_ChanceToPoison.Checked)
            {
                korbatAttack = korbat.NormalAttack(rnd);
                CheckIfGrarrlWillEvade();
                if (korbat.WillAttackPoison(rnd, grarrl.Evade) && korbatAttack > 0)
                {
                    grarrl.IsPoisoned();
                    MakePoisonVisible();
                    grarrlPoisonTurns = 3;
                }
            }
            else if (RB_Lifesteal.Checked)
            {
                korbatAttack = korbat.NeverMissAttack(rnd);
                korbat.Heal(korbatAttack * 40 / 100); // 40% lifesteal
                MakeLifestealVisible();
            }
            else if (RB_DoubleDamageIfPoisoned.Checked)
            {
                korbatAttack = korbat.DoubleDamageIfPoisoned(rnd, grarrl.Poisoned);
                CheckIfGrarrlWillEvade();
                MakeDoubleDamageVisible();
            }

            DealDamageToGrarrl();
            grarrlPoisonTurns--;
            TakeAwayPoisonEffect();
            DisplayDamage();
            UpdateHealth();
            CheckIfHit();
            CheckCiriticalHit();
            CheckIfDead();
            grarrl.ResetGrarrlWillEvade();
            korbat.ResetAttackHasBeenDoubled();
            ChangeTurn();

        }//BTN_KorbatAttacks


        //--------------//
        //---[GRARRL]---//
        //--------------//
        private void BTN_GrarrlAttacks_Click(object sender, EventArgs e)
        {
            RemoveNotifications();

            //---------------------//
            //---[CHOOSE ATTACK]---//
            //---------------------//

            if (RB_DamageBoost.Checked)
            {
                grarrlAttack = grarrl.DamageBoostAttack(rnd);
            }
            else if (RB_ChanceToEvade.Checked)
            { 
                grarrlAttack = grarrl.NormalAttack(rnd);
                grarrl.WillGrarrlEvadeNextHit(rnd);
            }
            else if (RB_ChanceToTriple.Checked)
            {
                grarrlAttack = grarrl.ChanceToTriple(rnd);
                if (grarrl.AttackTripled)
                {
                    LBL_GrarrlTripleAttack.Visible = true;
                }
            }
            korbat.LoseHealth(grarrlAttack);
            UpdateHealth();
            DisplayDamage();
            CheckIfHit();
            CheckCiriticalHit();
            CheckIfDead();
            grarrl.ResetAttackHasBeenTripled();
            ChangeTurn();
        }



        //---------------//
        //---[METHODS]---//
        //---------------//

        private void CheckCiriticalHit()
        {
            // show label critical hit if attack > 25, also counts critical hits in a row
            if (korbatAttack >= 30 && korbatsTurn == true || grarrlAttack >= 30 && korbatsTurn == false)
            {
                LBL_CriticalHit.Visible = true;
                criticalHitsInARow++;
            }
            else
            {
                criticalHitsInARow = 0;
            }

            // show ... if critical hits in a row reaches at least 2
            if (criticalHitsInARow > 2)
            {
                PB_AndAnotherOne.Visible = true;
            }
            else if (criticalHitsInARow == 2)
            {
                PB_AnotherOne.Visible = true;
            }
            else if (criticalHitsInARow == 0)
            {
                PB_AnotherOne.Visible = false;
                PB_AndAnotherOne.Visible = false;
            }
        }//CheckCriticalHi
        private void CheckIfDead()
        {
            // check if anyone died
            if (korbat.Health <= 0 || grarrl.Health <= 0)
            {
                //disable Buttons
                BTN_GrarrlAttacks.Enabled = false;
                BTN_KorbatAttacks.Enabled = false;

                // check who died
                if (korbat.Health <= 0)
                {
                    // winner message
                    MessageBox.Show("Grarrl Wins!");
                }
                if (grarrl.Health <= 0)
                {
                    // winner message
                    MessageBox.Show("Korbat Wins!");
                }
            }
        }//CheckifDead
        private void CheckIfHit()
        {
            // if attack power 0 and its your turn 'Miss!' label is visible (this prevents ex. 'korbatAttack == 0 && korbatsTurn == false')
            if (korbatAttack == 0 && korbatsTurn == true || grarrlAttack == 0 && korbatsTurn == false)
            {
                LBL_MissedAttack.Visible = true;
            }
            // Attack hits, 'Miss!' label won't be visible
            else
            {
                LBL_MissedAttack.Visible = false;
            }
        }//CheckIfHit
        private void CheckIfGrarrlWillEvade()
        { 
            if (grarrl.Evade == true)
            {
                LBL_GrarrlHasEvaded.Visible = true;
                korbatAttack = 0;
            }
        }
        private void DealDamageToGrarrl()
        {
            grarrl.LoseHealth(korbatAttack);
            if (grarrl.Poisoned)
            {
                LBL_PoisonNotification.Visible = true;
                grarrl.LoseHealth(poisonDamage);
            }
        }

        // Methods that update the form by changing/removing stuff
        public void UpdateHealth()
        {
            TB_GrarrlHitpoints.Text = Convert.ToString(grarrl.Health);
            TB_KorbatHitpoints.Text = Convert.ToString(korbat.Health);
        }
        private void MakePoisonVisible()
        {
            LBL_PoisonNotification.Visible = true;
            LBL_GrarrlHasBeenPoisoned.Visible = true;
            PB_Grarrl.BackColor = Color.Purple;
        }
        private void MakeLifestealVisible()
        {
            LBL_Lifesteal.Text = "+ " + korbatAttack * 40 / 100 + " health";
            LBL_Lifesteal.Visible = true;
        }
        private void MakeDoubleDamageVisible()
        {
            if (korbat.AttackDoubled && korbatAttack > 0)
            {
                LBL_DoubleKorbatAttack.Visible = true;
            }
        }
        private void RemoveNotifications()
        {
            if (korbatsTurn)
            {
                LBL_GrarrlTripleAttack.Visible = false;
            }
            else if (!korbatsTurn)
            {
                LBL_GrarrlHasBeenPoisoned.Visible = false;
                LBL_GrarrlHasBeenRecovered.Visible = false;
                LBL_GrarrlHasEvaded.Visible = false;
                LBL_Lifesteal.Visible = false;
                LBL_PoisonNotification.Visible = false;
                LBL_DoubleKorbatAttack.Visible = false;
            }
            LBL_CriticalHit.Visible = false;
        }
        private void ChangeTurn()
        {
            if (korbatsTurn)
            {
                BTN_GrarrlAttacks.Enabled = true;
                BTN_KorbatAttacks.Enabled = false;
                korbatsTurn = false;
            }
            else if (!korbatsTurn)
            {
                BTN_GrarrlAttacks.Enabled = false;
                BTN_KorbatAttacks.Enabled = true;
                korbatsTurn = true;
            }

        }
        private void DisplayDamage()
        {
            if (korbatsTurn)
            {
                LBL_Damage.Text = "Korbat dealt " + korbatAttack + " damage";
            }
            else if (!korbatsTurn)
            {
                LBL_Damage.Text = "Grarrl dealt " + grarrlAttack + " damage";
            }
        }
        private void TakeAwayPoisonEffect()
        {
            if (grarrlPoisonTurns == 0)
            {
                LBL_GrarrlHasBeenRecovered.Visible = true;
                PB_Grarrl.BackColor = Color.FromArgb(229, 229, 229);
                grarrl.RecoveredFromPoison();
            }
        }
    }
}


/*
//------------//
//---[BUGS]---//
//------------//
- altijd doubled attack
- altijd tripled attack hint kijk classes properties attackdoubled/tripled


//----------------//
//---[OPDRACHT]---//
//----------------//



*/

