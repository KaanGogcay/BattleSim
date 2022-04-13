using System;
using System.Collections.Generic;
using System.Text;

namespace BattleSim
{
    
    class Fighter
    {
        // create random object (rnd)
        Random rnd = new Random();

        // create field
        public int health;

        // normal attack
        public int Attack()
        {
            // generate random number (0-30)
            int attack = rnd.Next(0, 31);

            return attack;
        }

        public int Attack_NeverMiss()
        {
            // generate random number (0-30)
            int attack = rnd.Next(1, 31);

            return attack;
        }

        // 40% dmg boost
        public int Attack_DamageBoost()
        {
            // generate random number (0-30)
            int attack = rnd.Next(0, 31);

            // add 40%
            attack = attack * 40 / 100 + attack;

            return attack;
        }

        // 20% chance to triple damage
        public int Attack_ChanceToX3Damage()
        {
            // generate damage number
            int attack = rnd.Next(0, 31);

            // check if attack will be doubled
            int tripleDamageChance = rnd.Next(1, 101);

            // check if the attack will be doubled
            if (tripleDamageChance >= 1 && tripleDamageChance <= 20)
            {
                return attack * 3;
            }
            return attack;
        }
    }
}
