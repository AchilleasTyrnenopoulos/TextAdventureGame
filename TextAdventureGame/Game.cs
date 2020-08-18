using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame
{
    public class Game
    {
        //public bool bSword, bOil, bJewel, bStick;

        //bools for beginning & Act1
        bool choice3_sf = false;
        
        //create Item objects
        private Item sword = new Item("Father's Sword", 5);
        private Item jewel = new Item("Mother's Jewelry");
        private Item oil = new Item("Oil Flask");
        private Item stick = new Item("Wooden Stick", 1);
        
        private Dice dice;

        //create enemies
        private Enemy westGuard = new Enemy("West Guard", 3, 1, 5);
        private Enemy eastGuard = new Enemy("East Guard", 3, 1, 5);
        private Enemy OldNelly = new Enemy("Old Nelly", 1, 1, 1);

        //bools for world states
        bool oldNelly = true;
        bool playerWanted = false;
        static bool playerDead = false;
        bool invitation = false;

        //print game title and overview
        public static void StartGame()
        {
            Dialog("WELCOME TO THE ADVENTURE!\n\n", "red");
            Player.NameCharacter();
            //call method for assigning the points to the player stats
            Player.AssignPoints();
        }
        
        //FUNCTIONS FOR DIDDERENT TEXT COLORS
        public static void Dialog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(message);
            Console.ResetColor();
        }

        public static void Dialog(string message, string clr)
        {
            if (clr == "red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (clr == "green")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else if (clr == "blue")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else if (clr == "player")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write(message);
            Console.ResetColor();
        }

        //function for the beginning section of the game
        public void Beginning()
        {
            bool firstChoice = false, grab = false;
            
            Console.WriteLine("\nYou come home after a long day's work. After you eat dinner with your family, \nwhich consists of your parents, your little sister and your baby brother, " +
                "you go to bed and soon you fall asleep. Soon after,  strange nightmares haunt your sleep, so when you wake up drenched in sweat, and you notice the room, the horror intensifies. " +
                "The house seems empty, the door is open and the fire is still on meaning that your folks left in a hurry. But where could they be?" +
                "\nThe most logical answer to this question, is what really started to twist your insides ");

            do
            {
                Dialog("\nYou get up immediately. What do you do next?\n", "blue");
                Console.WriteLine("1.Go out\n2.Look around\n");

                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    firstChoice = true;
                    Console.WriteLine("As you exit the house, you notice that your door has been marked with white chalk, with \nthe insignia of the Church. " +
                        "Your worst fears, have now been confirmed.");
                }
                else if (answer == "2")
                {
                    firstChoice = true;
                    Console.WriteLine("Noone is here with a quick look you see that no valuables were taken and the old sword of your father is still in its place in the corner. " +
                        "No signs of struggle, as far as you can tell. This sucks");
                    do
                    {
                        Dialog("\nYou can grab something or go out right now\n", "blue");
                        Console.WriteLine("1.Grab sword\n2.Grab jewelry\n3.Grab both\n4.Leave\n");

                        string answer2 = Console.ReadLine();
                        switch (answer2)
                        {
                            case "1":
                                grab = true;
                                sword.GetItem(); //error because Beginning method is static, if not static cannot call from Program
                                Item.Inventory.Add(sword);
                                Item.CallInventory();
                                NoticeDoor();
                                break;

                            case "2":
                                grab = true;
                                jewel.GetItem();
                                Item.Inventory.Add(jewel);
                                Item.CallInventory();
                                NoticeDoor();
                                break;

                            case "3":
                                grab = true;
                                sword.GetItem();
                                Item.Inventory.Add(sword);
                                jewel.GetItem();
                                Item.Inventory.Add(jewel);
                                Item.CallInventory();
                                NoticeDoor();
                                break;

                            case "4":
                                grab = true;
                                NoticeDoor();
                                break;

                            default:
                                grab = false;
                                Console.WriteLine("Invalid choice. Try again.");
                                break;
                        }
                    } while (grab == false);
                }
                else
                {
                    Invalid();
                }
            } while (firstChoice == false);
        }

        public void NoticeDoor()
        {
            Console.WriteLine("As you exit the house, you notice that your door has been marked with white chalk, with the insignia of the Church. Your worst fears, have now been confirmed.\n");
        }
        
        /*
        *ACT I methods with different choices that end with the confrontation in the tavern
        */
        public void ActI()
        {
            Dialog("**********ACT I**********");

            bool direction = false;
            Console.WriteLine("\nYou are right outside your home.\n");
            do
            {
                Dialog("Where do you go?", "blue");
                Console.WriteLine("\n1.Go right\n2.Go straight\n3.Go left\n");

                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    direction = true;
                    GoRight();
                }
                else if (answer == "2")
                {
                    direction = true;
                    GoStraight();
                    
                }
                else if (answer == "3")
                {
                    direction = true;
                    GoLeft();
                }
                else
                {
                    Invalid();
                }
            } while (direction != true);
        }

        //Go right methods
        private void GoRight()
        {
            bool choiceAfterRight = false;

            
            Console.WriteLine("You go right. As you walk along the path you walk right outside old Nelly's house. You see him from the window looking nervously around the street. When he sees you, he comes \noutside immediately.\n");
            do
            {
                Dialog("\"Are you alright boy?I heard what happened.\"", "blue");
                Console.WriteLine("\n1.What happened?\n2.I'm alright, I just need to find my folks.\n3.No, I woke up and everybody was gone. I need to find my family, tell me what you know \nabout this immediately!\n");
                string answer1 = Console.ReadLine();
                if (answer1 == "1")
                {
                    
                    choiceAfterRight = true;
                    WhatHappened();
                }
                else if (answer1 == "2")
                {
                    choiceAfterRight = true;
                    Alright();
                }
                else if (answer1 == "3")
                {
                    choiceAfterRight = true;
                    Agitated();
                }
               
                else
                {
                    Invalid();
                }
            } while (choiceAfterRight == false);
        }

        private void WhatHappened()
        {
            bool whatHappened = false;
            //What? Block/Method
            do
            {
                Dialog("\"Right..., I gotcha you. It's better if we don't really talk about it..\"", "blue");
                Console.WriteLine("\n1.What?!\n2.Do you know what happened to my family?\n");

                string answer1_ = Console.ReadLine();
                if (answer1_ == "1")
                {
                    whatHappened = true;
                    What();
                }
                else if (answer1_ == "2")
                {
                    whatHappened = true;
                    AskONel();
                }
                else
                {
                    Invalid();
                }
            } while (whatHappened == false);
        }

        private void What()

        {
            bool what = false;
            Dialog("\"Right. Bye-bye!\"");
            do
            {


                Console.WriteLine("'\n1.continue along the path.\n");
                string answer1_1 = Console.ReadLine();
                if (answer1_1 == "1")
                {
                    what = true;
                    WestContinue();

                }
                else
                {
                    Invalid();
                }
            } while (what == false);

        }

        private void AskONel()

        {
            bool ask = false;
            do
            {
                Dialog("\"Maybe you should go see your mother, she's at the \"Golden Fleece\"\"", "blue");

                Console.WriteLine("\n1.Head to the \"Golden Fleece\".\n2.Continue along the path.");
                string answer1_2 = Console.ReadLine();
                if (answer1_2 == "1")
                {
                    ask = true;
                    ToBeContinued();
                }
                else if (answer1_2 == "2")
                {
                    ask = true;

                    WestContinue();
                }
                else
                {
                    Invalid();
                }
            } while (ask == false);

        }

        private void Alright()
        {
            bool alright = false;

            do
            {
                Dialog("\"Find your folks?...Well..I think your mother is at the tavern, you should go there.\"", "blue");
                Console.WriteLine("\n1.Head to the \"Golden Fleece\".\n2.Continue along the path.\n");
                string answerGF_Al = Console.ReadLine();
                if (answerGF_Al == "1")
                {
                    alright = true;

                }
                else if (answerGF_Al == "2")
                {
                    alright = true;

                    WestContinue();
                }
                else
                {
                    Invalid();
                }
            } while (alright == false);

        }

        private void Agitated()
        {
            bool agitated = false, scared = false;
            bool charismatic = false;

            if (sword.state)
            {                                
                Dialog("\"Oh, alright there boy, calm down. ...Where did you find that sword?.. Wha-.. I-I, ah, I think I better go inside..Have a good night now!\"");

                do
                {
                    Console.WriteLine("\nOld Nelly seems freightened and rushes to get back into his home.");
                    Dialog("\nWhat do you do?");
                    Console.WriteLine("\n1.Try to calm him down.\n2.Try to stop him.\n3.Threaten him.\n");
                    string answerScared = Console.ReadLine();
                    if (answerScared == "1")
                    {
                        scared = true;
                        Dialog("\"Wait! I mean you no harm, I just want to ask some questions!\"", "player");
                        int dice = Dice.RollDice(10);
                        if (Player.charisma + dice > 10)
                        {
                            Player.GainXp(50);
                            Dialog($"Check: {Player.charisma + dice}/10");
                            Dialog("\"Oh, -ah, you got me real scared there boye, what are you doing with a sword hanging around like that.Are you out of your mind?\"\n");
                            Dialog("Please I need some answers quick, do you now what happened to my family?", "player");
                            Dialog("I see you 're not ready to talk really. Your mother is at the \"Golden Fleece\", I'd suggest you go there. Later come back at my house, I want to talk to you.");
                            Invitation();
                            do
                            {
                                Dialog("\nWhat do you do?");
                                Console.WriteLine("\n1.Go to the \"Golden Fleece\".\n2.Continue along the road\n");
                                string answerCharismatic = Console.ReadLine();

                                if (answerCharismatic == "1")
                                {
                                    charismatic = true;
                                    //Head to Golden Fleece
                                    ToBeContinued();
                                }
                                else if (answerCharismatic == "2")
                                {
                                    charismatic = true;
                                    WestContinue();
                                }
                                else
                                {
                                    Invalid();
                                }
                            } while (!charismatic);

                        }
                        else
                        {
                            Dialog($"Check: {Player.charisma + dice}/10");
                            Console.WriteLine("\nBefore you even finish your sentence he has gotten inside and locked the door behind him.\n");
                            WestContinue();
                        }
                    }
                    else if (answerScared == "2")
                    {
                        bool fight = false;
                        scared = true;
                        Console.WriteLine("You to try to grab the old man by his hands. He gets really scared by your action and punches you in the stomach.");
                        do
                        {
                            Dialog("\nWhat do you do?");
                            Console.WriteLine("\n1.Release him.\n2.Kill him.\n");
                            string fightNelly = Console.ReadLine();
                            if (fightNelly == "1")
                            {
                                fight = true;
                                Console.WriteLine("\"As you get a sense of what you 're actually doing you release the old man.\"");
                                Dialog("\n\"I'm sorry.. umm-,.. , I just don't know what's going on...\"\n", "player");
                                WestContinue();


                            }
                            else if (fightNelly == "2")
                            {
                                bool murder = false;
                                fight = true;
                                Fight(OldNelly, sword);
                                if (!playerDead)
                                {
                                    oldNelly = false;
                                    Console.WriteLine("\nYou 've killed Old Nelly. You 've never even held a weapon before 5 minutes and now you've killed a man. \nMaybe an innocent man, if they ever existed here at all.");
                                    Player.GainXp(50);
                                    do
                                    {
                                        Dialog("\nWhat do you do next?");
                                        Console.WriteLine("\n1.Put him in his house and continue.\n2.Continue and let the ol' bastard lying here like the dog he was.\n");
                                        string answerMurder = Console.ReadLine();
                                        if (answerMurder == "1")
                                        {
                                            murder = true;
                                            Console.WriteLine("\nYou hide him inside his home.\n");
                                            WestContinue();
                                        }
                                        else if (answerMurder == "2")
                                        {
                                            murder = true;
                                            playerWanted = true;
                                            WestContinue();
                                        }
                                        else
                                        {
                                            Invalid();
                                        }
                                    } while (!murder);
                                }
                                else
                                {
                                    GameOver();
                                }
                            }
                            else
                            {
                                Invalid();
                            }
                        } while (!fight);
                    }
                    else if (answerScared == "3")
                    {
                        int dice = Dice.RollDice(10);
                        scared = true;
                        if (Player.strength + dice>10)
                        {
                            Player.GainXp(50);
                            bool nelNelly = false;
                            Dialog("Make another step and you're dead old man!", "player");
                            Dialog($"Check: {Player.strength + dice}/10");

                            Console.WriteLine("\nOld Nelly freezes in his position.");
                            do
                            {
                                Dialog($"\"I only know your mother is at the \"Golden Fleece\". Please, you're acting crazy {Player.name}. I know you since you were little. What's gotten in to you?\"");
                                Console.WriteLine("\n1.Tell me the truth or you die.\n2.I'm sorry I just have no time fooling around when my family's gone missing!\n");
                                string answerNelly = Console.ReadLine();
                                if (answerNelly == "1")
                                {
                                    nelNelly = true;
                                    bool nelDead = false;
                                    Console.WriteLine("Old Nelly seems to have trouble accepting what you're telling him.");
                                    do
                                    {
                                        Dialog("\"Well, I suggest you just do it then, if that's the man you're becoming to be.\"\n");
                                        Console.WriteLine("\n1.Kill him.\n2.Run.\n");
                                        string answerConfronted = Console.ReadLine();
                                        if (answerConfronted == "1")
                                        {
                                            nelDead = true;
                                            Console.WriteLine("You slice Old Nelly's throat. A clear cut, releases a gush of blood and the old man just drops dead in front of your feet.");
                                            bool murder = false;
                                            
                                            
                                            Console.WriteLine("\nYou 've killed Old Nelly. You 've never even held a weapon before 5 minutes and now you've killed a man. \nMaybe an innocent man, if they ever existed here at all.");
                                            Player.GainXp(50);
                                            oldNelly = false;
                                            do
                                            {
                                                Dialog("\nWhat do you do next?");
                                                Console.WriteLine("\n1.Put him in his house and continue.\n2.Continue and let the ol' bastard lying here like the dog he was.\n");
                                                string answerMurder = Console.ReadLine();
                                                if (answerMurder == "1")
                                                {
                                                    murder = true;
                                                    Console.WriteLine("\nYou hide him inside his home.\n");
                                                    WestContinue();
                                                }
                                                else if (answerMurder == "2")
                                                {
                                                    murder = true;
                                                    playerWanted = true;
                                                    WestContinue();
                                                }
                                                else
                                                {
                                                    Invalid();
                                                }
                                            } while (!murder);
                                        }
                                        else if (answerConfronted == "2")
                                        {
                                            nelDead = true;
                                            Console.WriteLine("\nConfronted with the reality of your actions, you start to run away.");
                                            WestContinue();
                                        }
                                        else
                                        {
                                            Invalid();
                                        }
                                    } while (!nelDead);

    {

                                    }
                                }
                                else if (answerNelly == "2")
                                {
                                    nelNelly = true;
                                }
                                else
                                {
                                    Invalid();
                                }
                            } while (!nelNelly);
                            
                        }
                        else
                        {
                            Dialog($"Check: {Player.strength + dice}/10");
                            Dialog("\nBefore you even finish your sentence he has gotten inside and locked the door behind him.\n");
                            WestContinue();
                        }
                    }
                    else
                    {
                        Invalid();
                    }
                } while (scared == false);
            }
            else
            {                
                Dialog("\"Calm down boy, I'll tell you but you won't get anywhere with that attitude I'll tell you that. I'll cut you some slack given the circumstances. Also, I think you know too what's going on but you don't want to admit it. Am I right?\"");

                do
                {
                    Console.WriteLine("\n1.. . .\n2.Answer him.\n");
                    string answerAgit = Console.ReadLine();
                    if (answerAgit == "1")
                    {
                        agitated = true;
                        Console.WriteLine("\n Old Nelly smiles at you as he goes back into his house.");
                        WestContinue();
                    }
                    else if (answerAgit == "2")
                    {
                        agitated = true;
                        Dialog("\n\"Right about an assumption or something more? It's true I have a suspicion about what happened to my family, \nbut if you KNOW what happened I'd like to know the truth. Speak clearly.\"", "player");
                        Dialog("\n\". . .Well, I'll be damned. Ha, alright boy, the only thing I'm gonna tell you is that you probably assume correctly. I don't want to mess with you, that's the last thing I wanna do. But I think YOU KNOW, more than just suspect. \nWhen you'll have found the courage to face the truth come speak to me again.\"\n");
                        Invitation();
                        WestContinue();
                        
                        
                    }
                    else
                    {
                        Invalid();
                    }
                } while (agitated == false);
                
            }
        }

        private void WestContinue()
        {
            bool westContinue = false;
            Console.WriteLine("As you pass by Old Nelly's house, you turn left to continue along the path. The road brought you in front of the West guard post.At your left it's the village's square");

            do
            {
                Dialog("\nWhere do you go?");
                Console.WriteLine("\n1.Turn left towards the \"Golden Fleece\".\n2.Turn right to the guard post.\n");

                string answer1_2_ = Console.ReadLine();
                if (answer1_2_ == "1")
                {
                    westContinue = true;
                    //GoldenFleece();
                }
                else if (answer1_2_ == "2")
                {
                    westContinue = true;
                    Dialog("\"Hey there, what do you want?\"");
                    if (sword.state == true)
                    {

                        WestGuardPost();

                    }
                    else 
                    {
                        Dialog($"\n\"Oh, you're {Player.name}, aren't you? You know, your daddy used to be a guard not too long ago. \nAnd now .. . Anyways, you should be worrying about your mother, she's at the tavern. \nGo now, scram!\"");
                        //GoldenFleece();
                        ToBeContinued();
                    }
                    

                }
                else
                {
                    Invalid();
                }
            } while (westContinue == false); 
        }
       
        private void WestGuardPost()
        {
            Console.WriteLine("The guard notices the sword hanging from your waist.");
            Dialog("\"Are you kidding me?? Is that a sword you 're wearing? Well, you're in a lot of trouble!!\"");

            if (jewel.state == true)
            {
                HasJewel();
            }
            else
            {
                Dialog("what do you do?");
                Console.WriteLine("\n1.Fight.\n2.Run\n");

                string answerToWGwSword = Console.ReadLine();
                if (answerToWGwSword == "1")
                {
                    bool killedWGuard = false;
                    Fight(westGuard, sword);
                    if (!playerDead)
                    {


                        Player.GainXp(50);
                        do
                        {

                            Console.WriteLine("You killed a guard of the village. You 're going to be in a lot of trouble.\nWhat do you do?");
                            Console.WriteLine("\n1.Head to the village square.\n2.Hide the body and then head to village square.\n");
                            string afterKill = Console.ReadLine();
                            if (afterKill == "1")
                            {
                                killedWGuard = true;
                                playerWanted = true;
                                ToBeContinued();
                            }
                            else if (afterKill == "2")
                            {
                                killedWGuard = true;
                                ToBeContinued();
                            }
                            else
                            {
                                Invalid();
                            }
                        } while (!killedWGuard);
                    }
                    else
                    {
                        GameOver();
                    }
                }
                else if (answerToWGwSword == "2")
                {
                    Player.Run();
                    Player.GainXp(50);
                    Console.WriteLine("You managed to escape. You are now at the center of the village.");
                    ToBeContinued();
                }
                else
                {
                    Invalid();
                }
            }
        }

        private void HasJewel()
        {
            bool hasJewel2 = false;
            {
                bool hasJewel = false;
                
                do
                {   
                    Dialog("What do you do?", "blue");
                    Console.WriteLine("\n1.Bribe.\n2.Run.\n3.Fight\n");
                    string hasJewelDilema = Console.ReadLine();
                    if (hasJewelDilema == "1")
                    {
                        hasJewel = true;
                        Console.WriteLine("As he's heading towards you, you shake your mother's jewelry in your pocket.");

                        do
                        {

                            Dialog("\"what's that?\"");
                            Console.WriteLine("\n1.\"It's my mother's jewelry.If I give you these, will you let this pass?\"\n2.While he's distracted start running.\n");
                            string answer1_2_2_ = Console.ReadLine();
                            if (answer1_2_2_ == "1")
                            {
                                hasJewel2 = true;
                                Dialog("\"so what exactly does it stop me from just taking them?Hmm?...\nI'm joking, of course. Give them and scram.\"");
                                Item.RemoveFromInventory(jewel);
                                Item.CallInventory();
                                Player.GainXp(50);
                                Dialog("I heard your mother is in the \"Golden Fleece\". They are people there, trying to calm her down. You should go see how she is.");
                            }
                            else if (answer1_2_2_ == "2")
                            {
                                hasJewel2 = true;
                                //Random rRun = new Random();
                                //int chanceToRun = rRun.Next(0, 4);
                                if (Player.agility + Dice.RollDice(4) >= 5)
                                {
                                    Player.GainXp(50);
                                    Console.WriteLine("You managed to escape. You are now in the towns square and you see a lot of people gathering at the \"Golden Fleece\". You should head there but that guard may follow you");
                                    playerWanted = true;
                                    ToBeContinued();
                                }
                                else
                                {
                                    bool wGuardChoice = false;
                                    do
                                    {
                                        
                                        Console.WriteLine("You didn't manage to escape. The guard holds you.");
                                        Dialog("What will you do?");
                                        Console.WriteLine("\n1.Fight him.\n2.Surrender.\n");
                                        string answer1_WGuard_Run = Console.ReadLine();
                                        if (answer1_WGuard_Run == "1")
                                        {
                                            bool killedWGuard = false;
                                            wGuardChoice = true;
                                            Fight(westGuard, sword);
                                            if (!playerDead)
                                            {
                                                Player.GainXp(50);
                                                do
                                                {

                                                    Console.WriteLine("You killed a guard of the village. You 're going to be in a lot of trouble.\nWhat do you do?");
                                                    Console.WriteLine("\n1.Head to the village square.\n2.Hide the body and then head to village square.\n");
                                                    string afterKill = Console.ReadLine();
                                                    if (afterKill == "1")
                                                    {
                                                        killedWGuard = true;
                                                        playerWanted = true;
                                                        ToBeContinued();
                                                    }
                                                    else if (afterKill == "2")
                                                    {
                                                        killedWGuard = true;
                                                        ToBeContinued();
                                                    }
                                                    else
                                                    {
                                                        Invalid();
                                                    }
                                                } while (!killedWGuard);
                                            }

                                        }
                                        else if (answer1_WGuard_Run == "2")
                                        {
                                            wGuardChoice = true;
                                            GameOver();
                                        }
                                        else
                                        {
                                            Invalid();
                                        }
                                    } while (wGuardChoice == false);
                                }

                            }
                            else
                            {
                                Invalid();
                            }
                        } while (hasJewel2 == false);

                    }
                    else if (hasJewelDilema == "2")
                    {
                        hasJewel = true;
                        hasJewel2 = true;

                        if (Player.agility + Dice.RollDice(4) >= 5)
                        {
                            Player.GainXp(50);
                            Console.WriteLine("You managed to escape. You are now in the towns square and you see a lot of people gathering at the \"Golden Fleece\". You should head there but be careful. That guard maybe's following you");
                            ToBeContinued();
                        }
                        else
                        {
                            bool wGuardEscape = false;
                            do
                            {
                                Console.WriteLine("You didn't manage to escape. The guard holds you.");
                                Dialog("What will you do?");
                                Console.WriteLine("\n1.Fight him.\n2.Surrender.");
                                string answer1_WGuard_Run = Console.ReadLine();
                                if (answer1_WGuard_Run == "1")
                                {
                                    wGuardEscape = true;
                                    Fight(westGuard, sword);
                                    if (!playerDead)
                                    {
                                        bool killedWGuard = false;
                                        do
                                        {

                                            Console.WriteLine("You killed a guard of the village. You 're going to be in a lot of trouble.\nWhat do you do?");
                                            Console.WriteLine("\n1.Head to the village square.\n2.Hide the body and then head to village square.\n");
                                            string afterKill = Console.ReadLine();
                                            if (afterKill == "1")
                                            {
                                                killedWGuard = true;
                                                playerWanted = true;
                                                ToBeContinued();
                                            }
                                            else if (afterKill == "2")
                                            {
                                                killedWGuard = true;
                                                ToBeContinued();
                                            }
                                            else
                                            {
                                                Invalid();
                                            }
                                        } while (!killedWGuard);
                                    }
                                }
                                else if (answer1_WGuard_Run == "2")
                                {
                                    wGuardEscape = true;
                                    GameOver();
                                }
                                else
                                {
                                    Invalid();
                                }
                            } while (wGuardEscape == false);
                        }

                    }
                    else if (hasJewelDilema == "3")
                    {
                        bool killedWGuard = false;
                        Fight(westGuard, sword);
                        if (!playerDead)
                        {
                            Player.GainXp(50);
                            do
                            {
                                Console.WriteLine("You killed a guard of the village. You 're going to be in a lot of trouble.\nWhat do you do?");
                                Console.WriteLine("\n1.Head to the village square.\n2.Hide the body and then head to village square.\n");
                                string afterKill = Console.ReadLine();
                                if (afterKill == "1")
                                {
                                    killedWGuard = true;
                                    playerWanted = true;
                                    ToBeContinued();
                                }
                                else if (afterKill == "2")
                                {
                                    killedWGuard = true;
                                    ToBeContinued();
                                }
                                else
                                {
                                    Invalid();
                                }
                            } while (!killedWGuard);
                        }
                    }
                    else
                    {
                        Invalid();
                    }
                } while (hasJewel == false);
            }
        }

        //Go straight Methods
        private void GoStraight()
        {
            bool straight = false;
            Console.WriteLine("You go straight. You enter the village's square. You see the well in the center of the square and stretched high above it, in a large banner which stretches from the one side of the village to the other the official motto \"BE GRATEFUL, AND ENJOY LIFE\".");
            Console.WriteLine("You were alwways feeling icky about that motto, but now you seem to understand why. When seemingly put out of context, it sounds logigal and modest, it doesn't work that way as an answer to your problems. \"Be grateful and enjoy life\", sounds more like \"Oh, did your whole family gone missing?Just be grateful you're alive\",   now");
            do
            {
                Console.WriteLine("At your left, you see that there are a lot of people gathering in the 'Golden Fleece' tavern. If you are to find out what happened you need to go in there.");

                Dialog("\n 1.Go in the tavern.\n", "white");

                string answer2 = Console.ReadLine();

                if (answer2 == "1")
                {
                    straight = true;
                    ToBeContinued();
                    //choice2 = true;Go to End of Act1 Confrontation at the Golden Fleece
                }
                else
                {
                    Invalid();
                }
            } while (straight== false);
        }

        //Go left methods
        private void GoLeft()
        {
            bool choice3 = false;

            Console.WriteLine("You go left. As you walk along the path you see a wooden stick in the ground.");
            do
            {
                Dialog("\nWhat do you do?", "blue");
                Console.WriteLine("\n1.Pick it up\n2.Continue\n");

                string answer3 = Console.ReadLine();
                if (answer3 == "1")
                {
                    choice3 = true;
                    stick.GetItem();
                    if (Item.Inventory.Count < 2) { Item.Inventory.Add(stick); }
                    Item.CallInventory();
                    Console.WriteLine("You turn right to continue along the path.");
                }
                else if (answer3 == "2")
                {
                    choice3 = true;
                    Console.WriteLine("You turn right to continue along the path.");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Choose again.");
                }
            } while (choice3 == false);

            Console.WriteLine("You reach the middle of the road. At your left there is the eastern guard post of the village. At your right there is an alley that leads to the \"Golden Fleece\" tavern.");
            bool leftGuard = false;
            do
            {
                
                Dialog("Where do you go?", "blue");
                Console.WriteLine("\n1.Turn left to the guard post.\n2.Head for the \"Golden Fleece\" tavern.");

                string answer3_ = Console.ReadLine();
                if (answer3_ == "1")
                {
                     leftGuard = true;
                    LeftGuardPost();

                }
                else if (answer3_ == "2")
                {
                    leftGuard= true;
                    ToBeContinued();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Choose again.");
                }
            } while (leftGuard == false);
        }

        public void LeftGuardPost()
        {
            Console.WriteLine("As you reach the guard post, you realize that the wooden wall that surrounds the village seems so much taller when you get close to it. " +
                "You haven't actually been outside that much, or any of the villagers actually");
            Console.WriteLine("As you approach the post the guard sees you.");

            Dialog("\n\"Hey there lad, how you 're doin'?\nYou know what stupid of me to ask. Actually now that you're here can you do me a favor?" +
                " It maybe take your mind of... certain things too, you know. Keepin' busy.\"", "blue");

            if (sword.state == true)
            {
                Console.WriteLine("\nThe guard notices your father's sword that's hanging from your belt.");
                bool inTrouble = false;
                do
                {
                    Dialog("\nHey! Where did you find this, and why are wearing it?! You have some explaining to do right now!", "blue");

                    Console.WriteLine("\n1.Wait I will explain.\n2.Draw sword.\n3.Run.\n");
                    string answer3_st = Console.ReadLine();
                    if (answer3_st == "1")
                    {
                        bool explain = false;
                        inTrouble = true;
                        do
                        {
                            Console.WriteLine("The guard is climbing down the stairs. He seems really upset.");
                            Console.WriteLine("\n1.Explain yourself.\n2.Run.\n");
                            string explaining = Console.ReadLine();
                            if (explaining == "1")
                            {          
                                explain = true;
                                if (Player.charisma + Dice.RollDice(4) > 5)
                                {
                                    Player.GainXp(50);
                                    Dialog("\"Oh, Sir, this happens to be my father's sword, whom you 've sure have heard is missing, along with my two sisters.\nYou know my father was a guard and was allowed to have a sword and to keep it in his house even after retirement.\nI just thought I could protect my mother with it.\" ", "player");
                                    Dialog("\"You are foolish boy. I'll pretend this never happened but don't think that things like these won't cost you your head around here, just because of your age. \"");
                                    Item.RemoveFromInventory(sword);
                                    Console.WriteLine("The guard took your father's sword.");
                                    Dialog("Go find your mother at the \"Golden Fleece\".");
                                    ToBeContinued();
                                }
                                else
                                {
                                    bool runFight = false;
                                    bool noWeapons = true;
                                    do
                                    {
                                        do
                                        {
                                            Dialog("\"Dont even bother talking, you're coming with me.\"");
                                            Console.WriteLine("\n1.Fight\n2.Run\n");
                                            string runOrFight = Console.ReadLine();
                                            if (runOrFight == "1")
                                            {
                                                runFight = true;                                                                                            
                                                noWeapons = false;
                                                Fight(eastGuard, sword);
                                                Player.GainXp(50);                                                
                                            }
                                            else if (runOrFight == "2")
                                            {
                                                runFight = true;
                                                Player.Run();
                                                Player.GainXp(50);
                                                playerWanted = true;
                                                Console.WriteLine("...for now. You are now in the villagers square and you see people gathering in the \"Golden Fleece\". " +
                                                    "Maybe you should go in there. But be careful because the guard will probably not let this pass by.");
                                            }
                                            else
                                            {
                                                Invalid();
                                            }
                                        } while (noWeapons);
                                    } while (runFight);
                                }
                            }
                            else if (explaining == "2")
                            {
                                explain = true;
                                Player.Run();
                            }
                            else
                            {
                                Invalid();
                            }
                        } while (!explain);

                    }
                    else if (answer3_st == "2")
                    {
                        inTrouble = true;
                        Fight(eastGuard, sword);
                    }
                    else if (answer3_st == "3")
                    {
                        inTrouble = true;
                        Player.Run();
                        Player.GainXp(50);
                        playerWanted = true;
                        Console.WriteLine("...for now. You are now in the villagers square and you see people gathering in the \"Golden Fleece\". " +
                            "Maybe you should go in there. But be careful because the guard will probably not let this pass by.");
                    }
                    else
                    {
                        Invalid();
                    }
                } while (inTrouble == false);
            }
            else
            {
                do
                {
                    Dialog("I need you to bring me some oil flasks from the apothecary. It's right over here, just go in grab five o' them, and climb up. Will ya' lad?", "blue");

                    Console.WriteLine("\n1.My whole's family's missing. And you think I can forget that by doing you errands?\n2.Sure...., why not?...");
                    string answer3_sf = Console.ReadLine();
                    if (answer3_sf == "1")
                    {
                        choice3_sf = true;
                        bool go = false, go_ = false;

                        Console.WriteLine("Alright, now lad. You better watch your tone with me. Your mother is at the \"Golden Fleece\". I suggest you leave my sight now. ");
                        do
                        {
                            Console.WriteLine("1.Head to the \"Golden Fleece\".");
                            string answer_sf_1 = Console.ReadLine();
                            if (answer_sf_1 == "1")
                            {
                                go = true;
                                Console.WriteLine("At your right, you see that there are a lot of people gathering in the 'Golden Fleece' tavern. " +
                                    "If you are to find out what happened you need to go in there.");

                                do
                                {
                                    Dialog("\n 1.Go in the tavern.\n", "white");

                                    string answer_sf_1_ = Console.ReadLine();

                                    if (answer_sf_1_ == "1")
                                    {
                                        go_ = true;
                                        ToBeContinued();

                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid choice. Choose again.");
                                    }
                                } while (go_ == false);
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice. Choose again.");
                            }
                        } while (go == false);

                    }
                    else if (answer3_sf == "2")
                    {
                        choice3_sf = true;
                        Console.WriteLine("You enter the small apothecary. In large craters there are countless of oil flasks.");

                        Dialog("\nHow many do you take?", "blue");
                        Console.WriteLine("\n1.Take 6.\n2.Take 5.\n");
                        string answer_sf_2 = Console.ReadLine();

                        if (answer_sf_2 == "1")
                        {
                            Console.WriteLine("You take the 5 flasks the guard asked you, and keep one for yourself.");
                            oil.GetItem();
                            if (Item.Inventory.Count < 2) Item.Inventory.Add(oil);
                            Item.CallInventory();

                            Console.WriteLine("You go outside and hand the guard the flasks he asked you.");

                            //charisma check to see if guard notices you're stealing
                            if (Player.charisma + Dice.RollDice(4) > 5)
                            {
                                Player.GainXp(50);
                                Dialog("\"Thank you boy, I must keep an eye for the bad guys to keep you safe, right? No time for these little errands. " +
                                "Anyway, your mother is at the \"Golden Fleece\", you should probably go find her.\"");
                                ToBeContinued();
                            }
                            else
                            {
                                bool fightOrRun = false;
                                do
                                {
                                    bool hasWeapon = false;
                                    Dialog("\"What do you got there? Are you trying to steal lil' boy?\"");
                                    do
                                    {
                                        Dialog("What do you do?\n");
                                        Console.WriteLine("\n1.Fight \n2.Run");
                                        string fightOrFlight = Console.ReadLine();
                                        if (fightOrFlight == "1")
                                        {
                                            fightOrRun = true;
                                            if (sword.state)
                                            {
                                                hasWeapon = true;
                                                Fight(eastGuard, sword);
                                            }
                                            else if (stick.state)
                                            {
                                                hasWeapon = true;
                                                Fight(eastGuard, stick);
                                            }
                                            else
                                            {
                                                Console.WriteLine("You have no weapon to fight with.");
                                            }
                                        }
                                        else if (fightOrFlight == "2")
                                        {
                                            fightOrRun = true;
                                            hasWeapon = true;
                                            Player.Run();
                                            playerWanted = true;
                                            Console.WriteLine("...for now. You are now in the villagers square and you see people gathering in the \"Golden Fleece\". " +
                                            "Maybe you should go in there. But be careful because the guard will probably not let this pass by.");
                                            Player.GainXp(50);
                                            ToBeContinued();
                                        }
                                        else
                                        {
                                            Invalid();
                                        }
                                    } while (!hasWeapon);
                                } while (!fightOrRun);
                            }
                        }
                        else if (answer_sf_2 == "2")
                        {
                            Console.WriteLine("You take the 5 flasks the guard asked you.");
                            Console.WriteLine("You go outside and hand the guard the flasks he asked you.");
                            Dialog("\"Thank you boy, I must keep an eye for the bad guys to keep you safe, right? No time for these little errands. " +
                                "Anyway, your mother is at the \"Golden Fleece\", you should probably go find her.\"");
                            Player.GainXp(50);
                            ToBeContinued();
                        }
                        else
                        {
                            Invalid();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Choose again.");
                    }
                } while (choice3_sf == false);
            }
        }
        //End of ActI: confrontation at the Golden Fleece tavern
        public void TheGoldenFleece()
        {

        }
        public void Invalid()
        {
            Dialog("\nInvalid choice. Choose again.\n", "red");
        }

        public void Invitation()
        {
            invitation = true;
            Dialog("\nYou got an invitation from Old Nelly. Come back at his house later, if you have the chance.\n");
        }

        //fight method needs fixing never stops
        public void Fight(Enemy _enemy, Item _equippedWeapon)
        {
            string answer;
            //bool attemptToLeave = false;
            bool escaped = false;
            
            bool enemyDead = false;
            do
            {
                double enemyDamage = _enemy.DoDamage();
                Console.WriteLine($"The enemy {_enemy.name} attacks you.");

                Player.TakeDamage(enemyDamage);
                if (enemyDamage > 0)
                {
                    Console.WriteLine($"The {_enemy.name} deals {enemyDamage} damage.");
                    Console.WriteLine($"You have {Player.health} health.");
                }

                if (Player.health <= 0)
                {
                    Console.WriteLine("You are dead.");
                    GameOver();
                    playerDead = true;
                }
                if (!playerDead)
                {
                    double playerDamage = Player.DoDamage(_equippedWeapon.damage);

                    Console.WriteLine($"You attack with {_equippedWeapon.itemName}.\nYou deal {playerDamage} damage.");

                    _enemy.TakeDamage(playerDamage);
                    Console.WriteLine($"The enemy {_enemy.name} has {_enemy.enemyHealth} health.");
                    if (_enemy.enemyHealth <= 0)
                    {
                        Console.WriteLine($"The enemy {_enemy.name} is dead.");
                        enemyDead = true;

                    }
                }
                /////////
                if (!enemyDead && !playerDead)
                {

                    do
                    {
                        //Dialog("Do you continue or try to leave?");
                        //Console.WriteLine("\n1.Continue.\n2.Try to leave.\n");
                        Console.WriteLine("\n1.Continue.\n");
                        answer = Console.ReadLine();

                        if (answer != "1" /*&& answer != "2"*/)
                        {
                            Invalid();
                        }
                        //if (answer == "2")
                        //{
                        //    //attemptToLeave = true;
                        //    Player.Run();
                        //    escaped = true;
                        //    Player.GainXp(50);
                        //}
                    } while (/*answer != "2" &&*/ answer != "1");
                }
                
            } while (/*!escaped && */ !enemyDead && !playerDead);

            
        }

        public static bool GameOver()
        {
            Dialog("\nYOU LOST\n\nGAME OVER\n", "red");
            playerDead = true;
            Program.gameOVer = true;
            return true;

        }

        static void ToBeContinued()
        {
            Dialog("\n.....TO BE CONTINUED.....\n");
            Console.WriteLine("Press any key to exit");
        }
    }
}






