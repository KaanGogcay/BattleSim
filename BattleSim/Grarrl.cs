using System;
using System.Collections.Generic;
using System.Text;

namespace BattleSim
{
    class Grarrl
    {
        // create fields
        private int health = 320;
        private bool evade = false;
        private bool poisoned = false;
        private bool attackTripled = false;

        // Properties
        public int Health { get { return health; } }
        public bool Evade { get { return evade; } }
        public bool Poisoned { get { return poisoned; } }
        public bool AttackTripled { get { return attackTripled; } }

        // Methods

        public void LoseHealth(int damage)
        {
            this.health = this.health - damage;
        }

        public void ResetGrarrlWillEvade()
        {
            this.evade = false;
        }

        public void IsPoisoned()
        {
            this.poisoned = true;
        }

        public void RecoveredFromPoison()
        {
            this.poisoned = false;
        }

        public int NormalAttack(Random rnd)
        {
            // generate random number (0-30)
            int attack = rnd.Next(0, 31);

            return attack;
        }

        public int ChanceToTriple(Random rnd)
        {
            int tripleDamageChance = rnd.Next(1, 101);
            if (tripleDamageChance <= 20)
            {
                this.attackTripled = true;
                return NormalAttack(rnd) * 3;
            }
            return NormalAttack(rnd);
        }

        public int DamageBoostAttack(Random rnd)
        {
            // generate random number (0-30)
            int attack = rnd.Next(0, 43);

            return attack;
        }

        public void WillGrarrlEvadeNextHit(Random rnd)
        {
            int grarrlEvasionChance = rnd.Next(1, 101);
            if (grarrlEvasionChance <= 35)
            {
                this.evade = true;
            }
        }

        public void ResetAttackHasBeenTripled()
        {
            this.attackTripled = false;
        }
    }
}
