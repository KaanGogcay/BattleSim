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
    public partial class FRM_BattleSim : Form
    {
        public FRM_BattleSim()
        {
            InitializeComponent();
        }

        // Create Fighters
        Fighter Korbat = new Fighter();
        Fighter Grarrl = new Fighter();

        // Create Random
        Random rngGrarrl = new Random();
        Random rngKorbat = new Random();

        // Create Variables
        static int grarrlEvasionChance = 0;
        static int korbatPoisonChance = 0;
        static int criticalHitsInARow = 0;
        static int grarrlPoisonTurns = 0;
        static int ChanceToTripleHit = 0;
        static int grarrlAttack = 0;
        static int korbatAttack = 0;
        bool grarrlWillEvadeNextTurn = false;
        bool grarrlIsPoisoned = false;
        bool korbatsTurn;

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

            // give fighters health
            Korbat.health = 240;
            Grarrl.health = 320;

        }//BTN_Start



        //--------------//
        //---[KORBAT]---//
        //--------------//
        private void BTN_KorbatAttacks_Click(object sender, EventArgs e)
        {
            // korbats turn starts
            korbatsTurn = true;

            // turn off notification
            LBL_GrarrlTripleAttack.Visible = false;
            LBL_CriticalHit.Visible = false;

            // repeated notifications
            if (grarrlIsPoisoned == true)
            {
                LBL_PoisonNotification.Visible = true;
            }



            //---------------------//
            //---[CHOOSE ATTACK]---//
            //---------------------//

            //------------------------//
            //---[CHANCE TO POISON]---//
            //------------------------//
            if (RB_Kor_Poison.Checked)
            {
                // normal attack (0-30)
                korbatAttack = Korbat.Attack();

                // check if poisoned
                korbatPoisonChance = rngKorbat.Next(1, 101);
                // chance to poison enemy vv
                if (korbatPoisonChance <= 45 && grarrlWillEvadeNextTurn == false) // (grarrl can't get poisoned while evading an attack)
                {
                    // grarrl is poisoned
                    grarrlIsPoisoned = true;

                    // make poison visible with notifications and colors
                    LBL_PoisonNotification.Visible = true;
                    LBL_GrarrlHasBeenPoisoned.Visible = true;
                    PB_Grarrl.BackColor = Color.Purple;

                    // set poison turns on 3
                    grarrlPoisonTurns = 3;
                }
            }
            //-----------------//
            //---[LIFESTEAL]---//
            //-----------------//
            else if (RB_Kor_LifeSteal.Checked)
            {
                // normal attack (1-30)
                korbatAttack = Korbat.Attack_NeverMiss();

                // 40% lifesteal
                Korbat.health = Korbat.health + korbatAttack * 40 / 100;

                // update korbat health
                TB_KorbatHitpoints.Text = Convert.ToString(Korbat.health);

                // notification
                LBL_Lifesteal.Text = "+ " + korbatAttack * 40 / 100 + " health";
                LBL_Lifesteal.Visible = true;

            }
            //---------------------------------//
            //---[DOUBLE DAMAGE IF POISONED]---//
            //---------------------------------//
            else if (RB_Kor_DoubleDamagePoison.Checked)
            {
                // normal attack
                korbatAttack = Korbat.Attack();

                // double it if grarrl is poisoned
                if (grarrlIsPoisoned == true && korbatAttack > 0 && grarrlWillEvadeNextTurn == false) // prevent notification if attack misses
                {
                    korbatAttack = korbatAttack * 2;

                    // give notification that attack will be doubled
                    LBL_DoubleKorbatAttack.Visible = true;
                }
            }
            else
            {
                // normal attack (0-30)
                korbatAttack = Korbat.Attack();
            }



            // check if grarrl will evade
            if (RB_Kor_LifeSteal.Checked || grarrlWillEvadeNextTurn == false)
            {
                // grarrl is poisoned
                if (grarrlIsPoisoned == true)
                {
                    // normal attack + 5 poison damage
                    Grarrl.health = Grarrl.health - (korbatAttack + 5);
                }
                // grarrl is not poisoned
                else if (grarrlIsPoisoned == false)
                {
                    // deal damage
                    Grarrl.health = Grarrl.health - korbatAttack;
                }
            }
            // grarrl will evade
            else if (grarrlWillEvadeNextTurn == true)
            {
                LBL_GrarrlHasEvaded.Visible = true;
                korbatAttack = 0;

                // deal poison damage even if Grarrl evades
                if (grarrlIsPoisoned == true)
                {
                    Grarrl.health = Grarrl.health - 5;
                }
            }

            // take 1 turn off the poison duration
            grarrlPoisonTurns--;

            // take away poison effect
            if (grarrlPoisonTurns == 0 && grarrlIsPoisoned == true)
            {
                LBL_GrarrlHasBeenRecovered.Visible = true;
                grarrlIsPoisoned = false;
                LBL_PoisonNotification.Visible = false;
                PB_Grarrl.BackColor = Color.FromArgb(229, 229, 229);
            }

            // update Grarrl's health
            TB_GrarrlHitpoints.Text = Convert.ToString(Grarrl.health);

            // show damage amount in label
            LBL_Damage.Text = "Korbat dealt " + korbatAttack + " damage";

            // Check if attack was higher than 0
            CheckIfHit();

            // critical hit message if attack > 30
            CheckCiriticalHit();

            // swap enabled button
            BTN_GrarrlAttacks.Enabled = true;
            BTN_KorbatAttacks.Enabled = false;

            // check if someone died
            CheckIfDead();

            // reset grarrl will evade
            grarrlWillEvadeNextTurn = false;

            // korbats turn is over
            korbatsTurn = false;

        }//BTN_KorbatAttacks



        //--------------//
        //---[GRARRL]---//
        //--------------//
        private void BTN_GrarrlAttacks_Click(object sender, EventArgs e)
        {
            // Grarrls turn starts
            korbatsTurn = false;

            // remove notifications
            LBL_GrarrlHasBeenPoisoned.Visible = false;
            LBL_GrarrlHasBeenRecovered.Visible = false;
            LBL_GrarrlHasEvaded.Visible = false;
            LBL_Lifesteal.Visible = false;
            LBL_PoisonNotification.Visible = false;
            LBL_DoubleKorbatAttack.Visible = false;

            // turn off critical hit message
            LBL_CriticalHit.Visible = false;

            //---------------------//
            //---[CHOOSE ATTACK]---//
            //---------------------//

            //--------------------//
            //---[DAMAGE BOOST]---//
            //--------------------//
            if (RB_Gra_DmgBoost.Checked)
            {
                // 40% Damage Boost (0-42)
                grarrlAttack = Grarrl.Attack_DamageBoost();
            }
            //---------------//
            //---[EVASION]---//
            //---------------//
            else if (RB_Gra_Evasion.Checked)
            { 
                // normal attack (0-30)
                grarrlAttack = Grarrl.Attack();

                // generate a random number to see if grarrl will take damage next turn
                grarrlEvasionChance = rngGrarrl.Next(1, 101);
                if (grarrlEvasionChance < 36)
                {
                    // grarrl will evade incoming hit
                    grarrlWillEvadeNextTurn = true;
                }
            }
            //--------------//
            //---[TRIPLE]---//
            //--------------//
            else if (RB_Gra_Triple.Checked)
            {
                // normal attack
                grarrlAttack = Grarrl.Attack();

                // chance to triple your hit
                ChanceToTripleHit = rngGrarrl.Next(1, 101);
                if (ChanceToTripleHit <= 20 && grarrlAttack > 0) // prevent triple attack on miss
                {
                    // triple the damage
                    grarrlAttack = grarrlAttack * 3;

                    // give notification for triple damage
                    LBL_GrarrlTripleAttack.Visible = true;
                }
            }
            else
            {
                // normal attack (0-30)
                grarrlAttack = Grarrl.Attack();
            }

            // deal damage
            Korbat.health = Korbat.health - grarrlAttack;
            TB_KorbatHitpoints.Text = Convert.ToString(Korbat.health);

            // show damage amount in textbox
            LBL_Damage.Text = "Grarrl dealt " + grarrlAttack + " damage";


            // Check if attack was higher than 0
            CheckIfHit();

            // critical hit message if attack > 25
            CheckCiriticalHit();

            // swap enabled button
            BTN_KorbatAttacks.Enabled = true;
            BTN_GrarrlAttacks.Enabled = false;

            // check if someone died
            CheckIfDead();

            // grarrls turn is over
            korbatsTurn = true;
        }



        //---------------//
        //---[METHODS]---//
        //---------------//

        public void CheckCiriticalHit()
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
        }//CheckCriticalHit

        public void CheckIfDead()
        {
            // check if anyone died
            if (Korbat.health <= 0 || Grarrl.health <= 0)
            {
                //disable Buttons
                BTN_GrarrlAttacks.Enabled = false;
                BTN_KorbatAttacks.Enabled = false;

                // check who died
                if (Korbat.health <= 0)
                {
                    // winner message
                    MessageBox.Show("Grarrl Wins!");
                }
                if (Grarrl.health <= 0)
                {
                    // winner message
                    MessageBox.Show("Korbat Wins!");
                }
            }
        }//CheckifDead

        public void CheckIfHit()
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

        private void LBL_CriticalHit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A hit of 30 or higher is a critical hit");
        }
    }
}


/*
//------------//
//---[BUGS]---//
//------------//



//----------------//
//---[OPDRACHT]---//
//----------------//



*/

