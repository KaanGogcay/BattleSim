using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.NeoFighters
{
    public class Korbat : NeoFighter
    {
        // Summary
        NeoFighterSpecies _species = NeoFighterSpecies.Korbat;
        string _description = "Evil Poisonous Bat";
        // Stats
        int _health = 270;
        int _attackPower = 24;
        int _critRatio = 13;
        // Attack Effect Chances
        int _lifeStealAmount = 45; // this means 40% of its own attack is being healed
        int _lifeStealGainedAttackPower = 10;
        int _chanceToPoison = 45;
        
        // Methods
        public Korbat()
        {
            Attack1Name = $"Life Steal - ({_lifeStealAmount}% Lifesteal and steal {_lifeStealGainedAttackPower}% attack power)";
            Attack2Name = $"Strychine - (dmg*2 if enemy poisoned)";
            Attack3Name = $"Poison Bite - ({_chanceToPoison}% chance to poison)";

            // Don't Touch
            Species = _species;
            Name = _species.ToString();
            Description = _description;
            Health = _health;
            AttackPower = _attackPower;
            CritRatio = _critRatio;
            OldStatus = Statuses.Clear;
            Event = "";
        }
        public override int Attack1(Random rnd, NeoFighter enemyNeoFighter)
        {
            //LifeSteal
            //heal 40% of dealth damage and steal 10% attacking power
            int damage = Attack(rnd, AttackPower);
            GainHealth(damage * _lifeStealAmount / 100);
            GainAttackPower(damage * _lifeStealGainedAttackPower / 100);
            enemyNeoFighter.GainAttackPower((damage * _lifeStealGainedAttackPower / 100) * -1);
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
            }
            int damage = Attack(rnd, AttackPower);
            return damage;
        }
    }
}
