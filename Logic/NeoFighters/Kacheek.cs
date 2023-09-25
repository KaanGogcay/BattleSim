using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.NeoFighters
{
    public class Kacheek : NeoFighter
    {
        // Summary
        NeoFighterNames _name = NeoFighterNames.Kacheek;
        string _description = "Little foxy boi who KNOWS how to hit it's enemy";
        // Stats
        int _health = 230;
        int _attackPower = 13;
        int _critRatio = 40;
        // Attack Effect Chances
        int _pokeFlinchChance = 45;
        int _tickleLowerAttackAmount = 6;
        int _focusIncreaseAttackPowerAmount = 6;

        // Methods
        public Kacheek()
        {
            Attack1Name = $"Poke - {_pokeFlinchChance}% chance to flinch the enemy";
            Attack2Name = $"Tickle - Lowers the opponents Attack Power by {_tickleLowerAttackAmount}";
            Attack3Name = $"Focus - Increases Attack Power by {_focusIncreaseAttackPowerAmount}";

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
            // Poke
            // Chance to Flinch
            if (rnd.Next(1, 101) <= _pokeFlinchChance)
            {
                enemyNeoFighter.SetFlinched();
            }
            return Attack(rnd, AttackPower);
        }
        public override int Attack2(Random rnd, NeoFighter enemyNeoFighter)
        {
            // Tickle
            // Lowers opp AP
            enemyNeoFighter.GainAttackPower(-_tickleLowerAttackAmount);
            return 0;
        }
        public override int Attack3(Random rnd, NeoFighter enemyNeoFighter)
        {
            // Focus
            // increase attack
            GainAttackPower(_focusIncreaseAttackPowerAmount);
            return 0;
        }
    }
}
