using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame
{
    public class Item
    {

        //name
        public string itemName;

        //weapon damage
        public int damage;

        //state, if on inventory or not
        public bool state = false;

        //if equipped or not 
        public bool equipped = false;

        //inventory list
        public static List<Item> Inventory = new List<Item>();
        
        //PROPERTIES?
        
        //CONSTRUCTORS
        public Item()
        { }

        public Item(string _itemName)
        {
            itemName = _itemName;

        }

        public Item(string _itemName, int _damage)
        {
            itemName = _itemName;
            damage = _damage;
        }


        //METHODS
        //get item method, add to inventory list
        public void GetItem()
        {
            if (Inventory.Count < 2)
            {
                state = true;

                Console.WriteLine("You picked up " + itemName);
            }
            else
            {
                state = false;
                bool loop = true;
                do
                {
                    Console.WriteLine("\nNot enough space in inventory.Do you want to remove an item?\n");
                    Console.WriteLine("\n1.Yes\n2.No\n");
                    string answer = Console.ReadLine();
                    if (answer == "1")
                    {
                        //replace item from inventory 
                        loop = false;
                        Console.WriteLine("Which item would you like to remove?");
                        Console.WriteLine($"\n1.{Item.Inventory[0].itemName}\n2.{Item.Inventory[1].itemName}\n");
                        string choice = Console.ReadLine();
                        if (choice == "1")
                        {
                            RemoveFromInventory(Item.Inventory[0]);
                        }
                        else if (choice == "2")
                        {
                            RemoveFromInventory(Item.Inventory[1]);
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Try again.");
                        }
                    }
                    else if (answer == "2")
                    {
                        loop = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice, try again.");
                    }
                } while (loop);
            }
        }

        //remove item from inventory list
        public static void RemoveFromInventory(Item _item)
        {
            Game.Dialog($"The {_item.itemName} has been removed from your inventory.\n", "red");
            Inventory.Remove(_item);
        }

        //tells you what's in the inventory
        public static void CallInventory()
        {
            if (Inventory.Count > 0)
            {
                Game.Dialog($"There are {Inventory.Count} out of 2 item(s) in inventory.\n", "green");
                foreach (Item item in Inventory)
                {
                    Game.Dialog("Item: " + item.itemName + "\n" + "Damage: " + item.damage + "\n", "green");
                }
            }
            else
            {
                Console.WriteLine("No items in inventory.");
            }

        }
        //equip weapon method
    }
}
