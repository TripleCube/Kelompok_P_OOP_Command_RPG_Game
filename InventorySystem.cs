using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private List<string> items = new List<string>();
    public Character player;

    public void AddItem(string item)
    {
        items.Add(item);
    }

    public void UseItem(string item)
    {
        if (items.Contains(item))
        {
            switch (item)
            {
                case "Potion":
                    player.healthPoints += 20;
                    break;
                case "Attack Boost":
                    player.attackPower += 5;
                    break;
            }
            items.Remove(item);
        }
    }
}
