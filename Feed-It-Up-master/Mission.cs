public enum MissionStatus
{
    Active,
    Completed,
    Failed
}

public class Mission
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Objective { get; set; } // E.g., "Defeat 3 BigFish"
    public MissionStatus Status { get; set; }
    public int Progress { get; set; } // Tracks how many objectives have been completed

    public Mission(string name, string description, string objective)
    {
        Name = name;
        Description = description;
        Objective = objective;
        Status = MissionStatus.Active;
        Progress = 0;
    }

    // Method to update the progress of the mission
    public void UpdateProgress(int progress)
    {
        Progress += progress;
        if (Progress >= 100) // Consider it completed if progress is 100% or more
        {
            Status = MissionStatus.Completed;
        }
    }

    // Method to reset the mission (for example, if the player fails)
    public void Reset()
    {
        Status = MissionStatus.Active;
        Progress = 0;
    }
}
