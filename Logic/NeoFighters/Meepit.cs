using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.NeoFighters
{
    public class Meepit : NeoFighter
    {
        public Meepit()
        {
            Name = NeoFighterNames.Meepit;
            Description = "Little Pink Homie which got bullied because he's pink, has more of a passive moveset.";
            Health = 360;
            AttackPower = 20;
            CritRatio = 20;
        }

        public override int Attack1(Random rnd, NeoFighter enemyNeoFighter)
        {
            //toxic fang - poison chance
            throw new NotImplementedException();
        }
        public override int Attack2(Random rnd, NeoFighter enemyNeoFighter)
        {
            //Rest - gain 150 hp but fall asleep
            throw new NotImplementedException();
        }
        public override int Attack3(Random rnd, NeoFighter enemyNeoFighter)
        {
            // ocarina sleep thing
            throw new NotImplementedException();
        }
    }
}
