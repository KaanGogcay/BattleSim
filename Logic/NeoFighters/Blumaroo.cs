using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.NeoFighters
{
    public class Blumaroo : NeoFighter
    {        
        // Summary
        NeoFighterNames _name = NeoFighterNames.Blumaroo;
        string _description = "Wooden Ninja with extremely offensive moves";
        // Stats
        int _health = 300;
        int _attackPower = 27;
        int _critRatio = 8;
        // Attack Effect Chances
        int _woodenFistBoostAttackChance = 15;
        int _woodenFistAttackBoost = 14;
        int _flyingKneeBasePower = 25;
        int _flyingKneeRecoilPercentage = 20;
       
        // Methods
        public Blumaroo()
        {
            Attack1Name = $"Wooden Fist - ({_woodenFistBoostAttackChance}% chance for {_woodenFistAttackBoost} pwr boost)";
            Attack2Name = $"Tornado Kick - (Triples damage but attack power gets halved)";
            Attack3Name = $"Flying Knee - (attack with always {_flyingKneeBasePower} attack power, but {_flyingKneeRecoilPercentage}% recoil)";
            
            // Don't Touch
            Name = _name;
            Description = _description;
            Health = _health;
            AttackPower = _attackPower;
            CritRatio = _critRatio;
            OldStatus = Statuses.Clear;
            Event = "";
        }
        public override int Attack1(Random rnd, NeoFighter enemyNeoFighter)
        {
            //wooden fist
            //10% to increase attackPower by 1 stage?
            int attackBoostChance = rnd.Next(1, 101);
            if (attackBoostChance <= _woodenFistBoostAttackChance)
            {
                GainAttackPower(_woodenFistAttackBoost);
                Event = $"Power increased by {_woodenFistAttackBoost}\n\n";
            }
            int damage = Attack(rnd, AttackPower);
            return damage;
        }
        public override int Attack2(Random rnd, NeoFighter enemyNeoFighter)
        {
            //Tornado Kick
            //triples damage but halves attack power
            int damage = Attack(rnd, AttackPower);
            damage *= 3;
            HalveAttackPower();
            return damage;
        }
        public override int Attack3(Random rnd, NeoFighter enemyNeoFighter)
        {
            //Flying Knee
            //x1.4 dmg but recoil
            int damage = Attack(rnd, _flyingKneeBasePower);
            int recoil = (_flyingKneeRecoilPercentage * damage) / 100;
            LoseHealth(recoil);
            return damage;
        }
    }
}
