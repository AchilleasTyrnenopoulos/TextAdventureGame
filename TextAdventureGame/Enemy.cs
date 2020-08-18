using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame
{
    public  class Enemy
    {


        //rpg type stats
        //int strength; handles health and baseDmg
        //int agility; handles critical chances, random and luck etc

       


        //character name 
        public string name;
        
        public double dmg = 1;//OR baseDmg = 1 + str/2
        public double weaponDmg = 1;
        //public int weaponDamage;// it depends on the weapon equipped, is == Item.damage
        public double critical =1;//critical is == to a random between 0 - 1 float (0% - 100%), could assign an agility variable to it 1 agility point +5%

        public double enemyHealth = 10;

        //CONSTRUCTORS
        public Enemy()
        { }

        public Enemy(string _name)
        {
            _name = name;
        }

        public Enemy(string _name, double _dmg, double _critical, double _weaponDmg)
        {
            _name = name;
            _dmg = dmg;
            _critical = critical;
            _weaponDmg = weaponDmg;
        }

        public void TakeDamage(double _playerDamage)
        {
            enemyHealth -= _playerDamage;
            if (enemyHealth <= 0)
            {
                enemyHealth = 0;
            }
        }

        public double DoDamage()
        {
            double criticalPercentage = critical + Dice.RollDice(10);
            if (criticalPercentage/10 > 1)
            {
                criticalPercentage = 10;
            }
            double damageDone = (dmg + weaponDmg)  * (criticalPercentage/5);
            return damageDone;
        }


        //character health, base damage 
        //character damage method


    }
}

