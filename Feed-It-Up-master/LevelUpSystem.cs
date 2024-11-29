public class LevelUpSystem
{
    private int experience;
    private int experienceThreshold = 100;

    public void AddExperience(int amount)
    {
        experience += amount;
        Console.WriteLine($"Gained {amount} experience points.");

        if (experience >= experienceThreshold)
        {
            experience -= experienceThreshold;
            PlayerFish.Instance.LevelUp();
            experienceThreshold += 50; // Increase threshold for next level
        }
    }
}
