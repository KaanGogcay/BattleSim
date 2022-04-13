using System;
using System.Collections.Generic;
using System.Text;

namespace BattleSim
{
    class Korbat
    {
        // create fields
        private int health = 240;
        private bool attackDoubled = false;

        // Properties
        public int Health { get { return health; } }
        public bool AttackDoubled { get { return attackDoubled; } }

        // Methods
        public bool WillAttackPoison(Random rnd, bool GrarrlWillEvade)
        {
            int poisonChance = rnd.Next(1, 101);
            // chance to poison vv
            if (poisonChance <= 45 && GrarrlWillEvade == false)
            {
                return true;
            }
            return false;
        }

        public void Heal(int stolenHealth)
        {
            this.health = this.health + stolenHealth;
        }

        public void LoseHealth(int damage)
        {
            this.health = this.health - damage;
        }

        public int NeverMissAttack(Random rnd)
        {
            return rnd.Next(1, 31);
        }

        public int NormalAttack(Random rnd)
        {
            return rnd.Next(0, 31);
        }

        public int DoubleDamageIfPoisoned(Random rnd, bool grarrlIsPoisoned)
        {
            if (grarrlIsPoisoned)
            {
                attackDoubled = true;
                return NormalAttack(rnd) * 2;
            }
            return NormalAttack(rnd);
        }

        public void ResetAttackHasBeenDoubled()
        {
            this.attackDoubled = false;
        }
    }
}
