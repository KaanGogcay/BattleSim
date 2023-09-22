using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.NeoFighters
{
    public class Grarrl : NeoFighter
    {
        int _chanceToFlinch = 25;
        int _gainPowerWithFocus = 9;
        int _dragonRushExtraDamage = 25;

        public Grarrl()
        {
            Name = NeoFighterNames.Grarrl;
            Description = "Bulky Dragon which mainly focusses on dealing damage";
            Health = 360;
            AttackPower = 32;
            CritRatio = 6;
            Attack1Name = $"Focus - (Increase Attack by {_gainPowerWithFocus})";
            Attack2Name = $"Bite - ({_chanceToFlinch}% chance to flinch)";
            Attack3Name = $"Dragon Rush - ({_dragonRushExtraDamage}% stronger attack)";
            OldStatus = Statuses.Clear;
            Event = "";
        }

        public override int Attack1(Random rnd, NeoFighter enemyNeoFighter)
        {
            //focus
            //increase attackPower by x
            GainAttackPower(_gainPowerWithFocus);
            Event += $"{Name} increased its attack power by {_gainPowerWithFocus}";
            return 0;
        }
        public override int Attack2(Random rnd, NeoFighter enemyNeoFighter)
        {
            //bite
            //30% chance for enemy to flinch
            int flinchChance = rnd.Next(1, 101);
            if (flinchChance <= _chanceToFlinch)
            {
                enemyNeoFighter.SetFlinched();
                Event += $"{Name} made its opponent Flinch\n\n";
            }
            int damage = Attack(rnd, AttackPower);
            return damage;
        }
        public override int Attack3(Random rnd, NeoFighter enemyNeoFighter)
        {
            //dragon rush
            //25% extra damage boost // but chance to miss (not added)
            int damage = Attack(rnd, AttackPower);
            damage = damage * (100 + _dragonRushExtraDamage) / 100; // not clear enough
            return damage;
        }
    }
}
