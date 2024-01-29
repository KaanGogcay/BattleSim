using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.NeoFighters
{
    public class Meepit : NeoFighter
    {
        // Summary
        NeoFighterSpecies _species = NeoFighterSpecies.Meepit;
        string _description = "Little Pink Homie which got bullied because he's pink, has more of a passive moveset";
        // Stats
        int _health = 100;
        int _attackPower = 12;
        int _critRatio = 20;
        // Attack Effect Chances
        int _poisonFangPoisonChance = 75;
        int _enemyAttackLoweredWithPoisonFang = 3;
        int _goodnightKissSleepChance = 75;
        int _atttackPowerGainedWithRest = -2;
        int _healthGainedWithRest = 140;
        
        // Methods
        public Meepit()
        {
            Attack1Name = $"Poison Fang - ({_poisonFangPoisonChance}% chance to poison and lower enemy attack by {_enemyAttackLoweredWithPoisonFang})";
            Attack2Name = $"Goodnight Kiss - ({_goodnightKissSleepChance}% chance to make target sleep)";
            Attack3Name = $"Rest - (Fall asleep and gain {_healthGainedWithRest} health but lose {_atttackPowerGainedWithRest} attack power)";

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
            // Poison Fang
            //30% chance to poison
            int poisonChance = rnd.Next(1, 101);
            if (poisonChance <= _poisonFangPoisonChance)
            {
                enemyNeoFighter.SetPoisoned();
                enemyNeoFighter.GainAttackPower(-_enemyAttackLoweredWithPoisonFang);
            }
            int damage = Attack(rnd, AttackPower);
            return damage;
        }
        public override int Attack2(Random rnd, NeoFighter enemyNeoFighter)
        {
            // Gn kiss
            //
            int sleepChance = rnd.Next(1, 101);
            if (sleepChance <= _goodnightKissSleepChance)
            {
                enemyNeoFighter.SetAsleep();
            }
            return 0;
        }
        public override int Attack3(Random rnd, NeoFighter enemyNeoFighter)
        {
            //Rest
            //gain 150 hp but fall asleep
            GainHealth(_healthGainedWithRest);
            GainAttackPower(_atttackPowerGainedWithRest);
            Status = Statuses.Asleep;
            return 0;
        } // max use 3 times
    }
}
