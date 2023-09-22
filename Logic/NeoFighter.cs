using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public enum Statuses
    {
        Clear,
        Poisoned,
        Dead,
        Flinched,
    }
    public enum NeoFighterNames
    {
        Korbat,
        Grarrl,
        Blumaroo,
        Meepit
    }

    abstract public class NeoFighter
    {
        int _attackRange = 5;
        public Random rnd = new Random();
        public NeoFighterNames Name { get; internal set; }
        public string Description { get; internal set; }
        public Statuses Status { get; internal set; }
        public Statuses OldStatus { get; set; }
        public int GainedHealth { get; internal set; }
        public int Health { get; internal set; }
        /// <summary>The base attacking power. Each hit will range between attackingPower-5 and attackingPower+5</summary>
        public int AttackPower { get; internal set; }
        /// <summary>Chance in percentage. Example 30 means 30% (max 100)</summary>
        public int CritRatio { get; internal set; }
        public int PoisonTurns { get; internal set; }
        public string Event { get; internal set; }
        public string Attack1Name { get; internal set; }
        public string Attack2Name { get; internal set; }
        public string Attack3Name { get; internal set; }

        // Attack
        public int Attack(Random rnd, int attackpower)
        {
            int attackModifier = rnd.Next(-1 * _attackRange, _attackRange + 1);
            int damage = attackpower + attackModifier;
            if (damage < 0)
            {
                damage = 0;
            }

            int critChance = rnd.Next(1, 101);
            if (critChance <= CritRatio)
            {
                damage *= 2;
                if (damage > 0)
                {
                    Event += $"Critical Hit!\n\n";
                }
            }
            return damage;
        }
        public void GainAttackPower(int attackPower)
        {
            AttackPower += attackPower;
        }
        public void LoseAttackPower(int attackPower)
        {
            AttackPower -= attackPower;
            if (AttackPower < _attackRange)
            {
                AttackPower = 0; // minimal attacking power
            }
        }
        public void HalveAttackPower()
        {
            AttackPower /= 2;
            if (AttackPower < _attackRange)
            {
                AttackPower = 0; // minimal attacking power
            }
        }
        // Health
        public void LoseHealth(int damage)
        {
            Health -= damage;
        }
        public void GainHealth(int health)
        {
            Health += health;
        }
        public void ResetGainedHealth()
        {
            GainedHealth = 0;
        }
        // Status
        public void SetPoisoned()
        {
            Status = Statuses.Poisoned;
        }
        public void SetDead()
        {
            Status = Statuses.Dead;
        }
        public void SetFlinched()
        {
            Status = Statuses.Flinched;
        }
        public void CureStatus()
        {
            Status = Statuses.Clear;
        }
        public void AddPoisonTurn()
        {
            PoisonTurns += 1;
            if (PoisonTurns > 3)
            {
                CureStatus();
            }
        }
        // Event
        public void ClearEvent()
        {
            Event = "";
        }
        public void CheckIfCriticalHit(int damage)
        {
            if (damage > AttackPower + 5)
            {
                Event += $"Critical Hit!\n\n";
            }
        }


        abstract public int Attack1(Random rnd, NeoFighter enemyNeoFighter);
        abstract public int Attack2(Random rnd, NeoFighter enemyNeoFighter);
        abstract public int Attack3(Random rnd, NeoFighter enemyNeoFighter);
    }
}

