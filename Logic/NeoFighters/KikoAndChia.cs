using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.NeoFighters
{
    public class KikoAndChia : NeoFighter
    {
        // Summary
        NeoFighterSpecies _species = NeoFighterSpecies.KikoAndChia;
        string _name = "Kiko & Chia";
        string _description = "With the power of Fire and Water they are a destructive duo";
        // Stats
        int _health = 380;
        int _attackPower = 17;
        int _critRatio = 2;
        // Attack Effect Chances
        int _tsunamiChanceToFlinch = 30;
        int _tsunamiLostAttackPower = 25;
        int _tsunamiRecoilPercentage = 30;
        int _fireballChanceToBurn = 50;
        int _steamHealthLost = 200;
        int _steamGainedAttackPower = 30;
        int _fireballBoostAttackPowerChance = 10;
        int _fireballBoostAttackPowerAmount = 10;

        // Methods
        public KikoAndChia()
        {
            Attack1Name = $"Tsunami - x2 Damage but lowers own Attack Power by {_tsunamiLostAttackPower} and takes {_tsunamiRecoilPercentage}% recoil, {_tsunamiChanceToFlinch}% chance to flinch";
            Attack2Name = $"Fireball - {_fireballChanceToBurn}% Chance to burn the enemy, {_fireballBoostAttackPowerChance}% chance to boost attack power by {_fireballBoostAttackPowerAmount}";
            Attack3Name = $"Steam - Gain {_steamGainedAttackPower} Attack Power, but lose {_steamHealthLost} Health";

            // Don't Touch
            Species = _species;
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
            // Tsunami
            // *2 damage and chance to flinch but lowers attack by 10
            int damage = Attack(rnd, AttackPower) * 2;
            if (rnd.Next(1, 101) <= _tsunamiChanceToFlinch)
            {
                enemyNeoFighter.SetFlinched();
            }
            GainAttackPower(-_tsunamiLostAttackPower); // lose 10
            LoseHealth(damage * _tsunamiRecoilPercentage / 100);
            return damage;
        }
        public override int Attack2(Random rnd, NeoFighter enemyNeoFighter)
        {
            // Fireball
            // 50 Chance to burn the enemy
            if (rnd.Next(1, 101) <= _fireballChanceToBurn)
            {
                enemyNeoFighter.SetPoisoned();
            }
            if (rnd.Next(1, 101) <= _fireballBoostAttackPowerChance)
            {
                GainAttackPower(_fireballBoostAttackPowerAmount);
            }
            return Attack(rnd, AttackPower);
        }
        public override int Attack3(Random rnd, NeoFighter enemyNeoFighter)
        {
            // Steam
            // Lower hp by 200 but increase attack by 30
            LoseHealth(_steamHealthLost);
            GainAttackPower(_steamGainedAttackPower);
            return 0;
        }
    }
}
