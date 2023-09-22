using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.NeoFighters
{
    public class Blumaroo : NeoFighter
    {
        int _woodenFistChanceToBoostAttack = 15;
        int _woodenFistAttackBoost = 14;
        int _tornadoKickAttackPowerNerf = 27; // -27
        int _flyingKneeBasePower = 20; // 40%
        int _flyingKneeRecoil = 5;           // 30%
        public Blumaroo()
        {
            Name = NeoFighterNames.Blumaroo;
            Description = "Wooden Ninja with extremely offensive moves";
            Health = 300;
            AttackPower = 27;
            CritRatio = 8;
            OldStatus = Statuses.Clear;
            Attack1Name = $"Wooden Fist - ({_woodenFistChanceToBoostAttack}% chance for {_woodenFistAttackBoost} pwr boost)";
            Attack2Name = $"Tornado Kick - (Triples damage but attack power gets halved)";
            Attack3Name = $"Flying Knee - (attack with always {_flyingKneeBasePower} attack power, but {_flyingKneeRecoil} recoil)";
            Event = "";
        }

        public override int Attack1(Random rnd, NeoFighter enemyNeoFighter)
        {
            //wooden fist
            //10% to increase attackPower by 1 stage?
            int attackBoostChance = rnd.Next(1, 101);
            if (attackBoostChance <= _woodenFistChanceToBoostAttack)
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
            Event += "Blumaroos attack power has been halved\n\n";
            return damage;
        }
        public override int Attack3(Random rnd, NeoFighter enemyNeoFighter)
        {
            //Flying Knee
            //x1.4 dmg but recoil
            int damage = Attack(rnd, _flyingKneeBasePower);
            int recoil = damage * (100 + _flyingKneeRecoil) / 100;
            LoseHealth(recoil);
            GainedHealth = -recoil;
            Event = "Blumaroo is een kanker megool";
            return damage;
        }
    }
}
