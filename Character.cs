using UnityEngine;

public class Character : MonoBehaviour
{
    public int healthPoints;
    public int attackPower;
    public int defense;
    public int level;
    public int experiencePoints;

    private void Start()
    {
        healthPoints = 100;
        attackPower = 10;
        defense = 5;
        level = 1;
        experiencePoints = 0;
    }

    public void TakeDamage(int damage)
    {
        healthPoints -= Mathf.Max(0, damage - defense);
    }

    public void LevelUp()
    {
        level++;
        healthPoints += 20;
        attackPower += 5;
        defense += 3;
    }

    public void GainExperience(int points)
    {
        experiencePoints += points;
        if (experiencePoints >= level * 100)
        {
            experiencePoints = 0;
            LevelUp();
        }
    }
}
