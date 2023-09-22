using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.NeoFighters
{
    public class Korbat : NeoFighter
    {
        int _lifeStealAmount = 45; // this means 40% of its own attack is being healed
        int _chanceToPoison = 40;

        public Korbat()
        {
            Name = NeoFighterNames.Korbat;
            Description = "Evil Poisonous Bat";
            Health = 270;
            AttackPower = 25;
            CritRatio = 13;
            OldStatus = Statuses.Clear;
            Attack1Name = $"Life Steal - ({_lifeStealAmount}% Lifesteal)";
            Attack2Name = $"Strychine - (dmg*2 if enemy poisoned)";
            Attack3Name = $"Poison Bite - ({_chanceToPoison}% chance to poison)";
            Event = "";
        }

        public override int Attack1(Random rnd, NeoFighter enemyNeoFighter)
        {
            //LifeSteal
            //heal 40% of dealth damage
            int damage = Attack(rnd, AttackPower);
            int gainHealth = damage * 40 / 100;
            GainHealth(gainHealth);
            GainedHealth = gainHealth;
            Event += $"{Name} gained {gainHealth} health\n\n";
            return damage;
        }
        public override int Attack2(Random rnd, NeoFighter enemyNeoFighter)
        {
            //Strychine
            //double damage if enemy is poisoned
            int damage = Attack(rnd, AttackPower);
            if (enemyNeoFighter.Status == Statuses.Poisoned)
            {
                return damage *= 2;
            }
            else
            {
                return 0;
            }
        }
        public override int Attack3(Random rnd, NeoFighter enemyNeoFighter)
        {
            //PoisonBite
            //30% chance to poison
            int poisonChance = rnd.Next(1, 101);
            if (poisonChance <= _chanceToPoison)
            {
                enemyNeoFighter.SetPoisoned();
                Event += "Korbat has poisoned the enemy\n\n";
            }
            int damage = Attack(rnd, AttackPower);
            return damage;
        }
    }
}
