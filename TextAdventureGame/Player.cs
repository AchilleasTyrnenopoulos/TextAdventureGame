using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml;

namespace TextAdventureGame
{
    public class Player
    {
        //VARIABLES
        //character name 
        public static string name = "";

        //rpg type stats variables
        public static int strength = 2;
        public static int agility = 2;
        public static int charisma = 2;

        //stats
        public static double baseDmg = 1 + strength/2;
        public static double critical = agility/2;//random between 0 - 1, represents the % 1== 100%, 0,5 == 50% etc
        public static double health = 5*strength;//make property
        
        public static int noWeaponDamage;//control from Item script(create bool equipped) and Game script if equipped change value to correspodent weapon damage value 

        //diceObjects
        //private Dice dice = new Dice();

        //level and XP points
        public static int xpPoints = 0;
        public static int xpForNextLevel = 100;
        public static int level = 1;

        //METHODS
        //take user input to name his/her character
        public static void NameCharacter()
        {
            Console.WriteLine("Name the main character: ");
            name = Console.ReadLine();
            if (name == "manos" || name == "Manos" || name == "MANOS")
            {
                Console.WriteLine("\nReally?? That's the name that you could come up with? Anyway. . . ");
            }
            Console.WriteLine("Great! Your characters name is " + name + ".");
        }

        //method for assigning the points to the player stats
        public static void AssignPoints()
        {
            int availPoints = 3;
            Console.WriteLine("\n\nYou have points to spend. \n\n");
            Console.WriteLine("*********************************");
            Console.WriteLine("Agility: " + agility + "\nStrength: " + strength + "\nCharisma: " + charisma);
            do
            {
                bool boolStat = false;
                Console.WriteLine($"\nYou have {availPoints} points to spend.\n");

                do
                {
                    Console.WriteLine("Write 'a' to assign a point to agility, 's' for strength and 'c' for charisma(lowercase letters)");
                    string stat = Console.ReadLine();

                    if (stat == "a")
                    {
                        boolStat = true;
                        availPoints--;
                        agility++;
                        Console.WriteLine("Agility: " + agility + "\nStrength: " + strength + "\nCharisma: " + charisma);

                    }
                    else if (stat == "s")
                    {
                        boolStat = true;
                        availPoints--;
                        strength++;
                        Console.WriteLine("Agility: " + agility + "\nStrength: " + strength + "\nCharisma: " + charisma);
                    }
                    else if (stat == "c")
                    {
                        boolStat = true;
                        availPoints--;
                        charisma++;
                        Console.WriteLine("Agility: " + agility + "\nStrength: " + strength + "\nCharisma: " + charisma);
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Try again.");
                    }
                } while (!boolStat);

                health = 5 * strength;
                baseDmg = 1 + strength / 2;
                critical = agility / 2;

               

            } while (availPoints > 0);

            DisplayStats();
        }


        //method for gaining XP points 
        public static void GainXp(int _xpPoints)
        {
            xpPoints += _xpPoints;
            Game.Dialog($"\nYou gained {_xpPoints} xp points.");
            Game.Dialog($"\nXP Points: {xpPoints}/{xpForNextLevel}\n");
            if (xpPoints >= xpForNextLevel)
            {
                LevelUp();
            }
        }
        //method for level up 
        public static void LevelUp()
        {
            level++;
            Game.Dialog($"\nYou gained a level. \nYou 're now Level {level}!");

            xpForNextLevel += level*xpForNextLevel;
            Game.Dialog($"\nXP Points: {xpPoints}/{xpForNextLevel}\n");

            AssignPoints();

        }
        //player takes damage, loses health
        public static void TakeDamage(double _damage)
        {
            health -= _damage;
        }

        public static double DoDamage(double _weaponDamage)//which wiil be the Item.damage, for example for the sword DoDamage(sword.damage);
        {
            double _criticalPercentage = Dice.RollDice(10) + critical;
            if (_criticalPercentage/10 > 1)
            {
                _criticalPercentage = 10;
            }
            Console.WriteLine(_criticalPercentage); 
            double _damageDone = (baseDmg + _weaponDamage) * _criticalPercentage/10;
            return _damageDone;
        }

        //escape method
        public static void Run()
        {
            int chanceToRun = agility + Dice.RollDice(6);

            if (chanceToRun > 5)
            {
                Console.WriteLine("You managed to escape!");
            }
            else
            {
                Console.WriteLine("You got caught.");
                Game.GameOver();
                
                //Game.Dialog("What do you do?");
                //Console.WriteLine("\n1.Fight.\n2.Surrender.\n");
                //string answer = Console.ReadLine();
                //if (answer == "1")
                //{
                    
                //}
                //else if (answer == "2")
                //{
                //    Game.GameOver();
                //}
                //else
                //{
                //    Console.WriteLine("Invalid choice. Try again.");
                //}
            }
        }

        public static void DisplayStats()
        {
            Game.Dialog("\n**********STATS**********\n", "green");
            Console.WriteLine($"Agility: {agility}");
            Console.WriteLine($"Strength: {strength}");
            Console.WriteLine($"Charisma: {charisma}");
            Console.WriteLine("\n-------------------------\n");
            Console.WriteLine($"Health: {health}");
            Console.WriteLine($"Base Damage (without weapon): {baseDmg}");
            Console.WriteLine($"Base Critical chance: {critical}");

            Game.Dialog("\n*************************\n", "green");
        }
    }
}
