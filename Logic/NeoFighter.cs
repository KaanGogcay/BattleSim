using System;
using System.Collections.Generic;
using System.Drawing;
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
        Asleep
    }
    public enum NeoFighterSpecies
    {
        Korbat = 0,
        Grarrl = 1,
        Blumaroo,
        Meepit,
        Kacheek,
        KikoAndChia
    }

    abstract public class NeoFighter
    {
        int _attackRange = 5;
        int _minimalAttackPower = 10;
        int _wakeUpChance = 45; // 30
        int _poisonDamage = 5;
        public Random rnd = new Random();
        public NeoFighterSpecies Species { get; internal set; } // req
        public string Name { get; internal set; }
        public string Description { get; internal set; } // req
        public int Health { get; internal set; } // req
        /// <summary>The base attacking power. Each hit will range between attackingPower-5 and attackingPower+5</summary>
        public int AttackPower { get; internal set; } // req
        /// <summary>Chance in percentage. Example 30 means 30% (max 100)</summary>
        public int CritRatio { get; internal set; } // req
        public string Attack1Name { get; internal set; } // req
        public string Attack2Name { get; internal set; } // req
        public string Attack3Name { get; internal set; } // req
        public Statuses OldStatus { get; set; } // req clear
        public Statuses Status { get; internal set; }
        public int GainedHealth { get; internal set; }
        public int PoisonTurns { get; internal set; }
        public int SleepTurns { get; internal set; }
        public string Event { get; internal set; }

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
            if (attackPower > 0)
            {
                Event += $"{Species} gained {attackPower} attack power\n\n";
            }
            else
            {
                if (AttackPower < _minimalAttackPower)
                {
                    AttackPower = _minimalAttackPower; // minimal attacking power
                    Event += $"{Species}'s attack power can't be lowered more\n\n";
                }
                else
                {
                    Event += $"{Species} lost {attackPower} attack power\n\n";
                }
            }
        }
        public void HalveAttackPower()
        {
            AttackPower /= 2;
            if (AttackPower < _attackRange)
            {
                AttackPower = 0; // minimal attacking power
                Event += $"{Species}'s attack power has been halved";
            }
        }
        // Health
        public void LoseHealth(int damage)
        {
            if (damage != 0)
            {
                Health -= damage;
                GainedHealth += -damage;
                Event += $"{Species} lost {damage} health\n\n";
            }
        }
        public void GainHealth(int health)
        {
            Health += health;
            GainedHealth += health;
            Event += $"{Species} gained {health} health\n\n";
        }
        public void ResetGainedHealth()
        {
            GainedHealth = 0;
        }
        public void PoisonDamage()
        {
            if (_poisonDamage != 0)
            {
                Health -= _poisonDamage;
                GainedHealth += -_poisonDamage;
                Event += $"{Species} lost {_poisonDamage} health due to poison\n\n";
            }
            AddPoisonTurn();
        }
        // Status
        public void SetPoisoned()
        {
            if (Status == Statuses.Clear)
            {
                Status = Statuses.Poisoned;
                Event += $"{Species} has been Poisoned\n\n";
            }
            else
            {
                Event += $"{Species} can't be poisoned if it's already {Status}\n\n";
            }
        }
        public void SetAsleep()
        {
            if (Status == Statuses.Clear)
            {
                Status = Statuses.Asleep;
                Event += $"{Species} fell Asleep\n\n";
            }
            else
            {
                Event += $"{Species} can't fall Asleep if it's already {Status}\n\n";
            }
        }
        public void SetDead()
        {
            Status = Statuses.Dead;
        }
        public void SetFlinched()
        {
            Status = Statuses.Flinched;
            Event += $"{Species} Flinched\n\n";
        }
        public void CureStatus()
        {
            Status = Statuses.Clear;
        }
        void AddPoisonTurn()
        {
            PoisonTurns += 1;
            if (PoisonTurns > 3)
            {
                CureStatus();
                PoisonTurns = 0;
            }
        }
        public void AddSleepTurn()
        {
            int wakeUpChance = rnd.Next(1, 101);
            if (wakeUpChance <= _wakeUpChance && SleepTurns > 0)
            {
                CureStatus();
                Event += $"{Species} Woke Up!\n\n";
                SleepTurns = 0;
            }
            else
            {
                SleepTurns++;
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

