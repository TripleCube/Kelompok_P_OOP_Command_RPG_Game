using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string Name { get; private set; }
    public int HP { get; private set; }
    public int ATK { get; private set; }
    public int DEF { get; private set; }
    private List<Item> inventory;

    public Player(string name)
    {
        Name = name;
        HP = 100;
        ATK = 20;
        DEF = 10;
        inventory = new List<Item>();
    }

    public void DisplayStatus()
    {
        Console.WriteLine($"Status {Name} - HP: {HP}, ATK: {ATK}, DEF: {DEF}");
    }

    public void ShowInventory()
    {
        Console.WriteLine("Inventori Anda:");
        foreach (var item in inventory)
        {
            Console.WriteLine($"{item.Name} - {item.Description}");
        }
    }

    public void AddItem(Item item)
    {
        inventory.Add(item);
        Console.WriteLine($"{item.Name} ditambahkan ke inventori!");
    }

    public void UseItem(Item item)
    {
        if (inventory.Contains(item))
        {
            HP += item.Effect;
            inventory.Remove(item);
            Console.WriteLine($"{item.Name} digunakan, HP bertambah {item.Effect}!");
        }
        else
        {
            Console.WriteLine("Item tidak ada di inventori.");
        }
    }
}
