using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int healthPoints;
    public int attackPower;
    public int defense;
    public string enemyType;

    public void InitializeEnemy(string type)
    {
        enemyType = type;
        switch (type)
        {
            case "Goblin":
                healthPoints = 50;
                attackPower = 8;
                defense = 2;
                break;
            case "Skeleton Warrior":
                healthPoints = 80;
                attackPower = 12;
                defense = 4;
                break;
            case "Dark Mage":
                healthPoints = 100;
                attackPower = 15;
                defense = 5;
                break;
        }
    }

    public void TakeDamage(int damage)
    {
        healthPoints -= Mathf.Max(0, damage - defense);
    }
}
