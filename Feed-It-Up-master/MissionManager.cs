public class MissionManager
{
    public List<Mission> Missions { get; private set; }

    public MissionManager()
    {
        Missions = new List<Mission>();
    }

    // Method to add a new mission
    public void AddMission(Mission mission)
    {
        Missions.Add(mission);
    }

    // Method to get all active missions
    public List<Mission> GetActiveMissions()
    {
        return Missions.Where(m => m.Status == MissionStatus.Active).ToList();
    }

    // Method to mark a mission as completed
    public void CompleteMission(string missionName)
    {
        var mission = Missions.FirstOrDefault(m => m.Name == missionName);
        if (mission != null && mission.Status != MissionStatus.Completed)
        {
            mission.Status = MissionStatus.Completed;
            Console.WriteLine($"Mission '{mission.Name}' completed!");
        }
    }

    // Method to handle mission failure (e.g., player didn't defeat the required enemy in time)
    public void FailMission(string missionName)
    {
        var mission = Missions.FirstOrDefault(m => m.Name == missionName);
        if (mission != null && mission.Status != MissionStatus.Failed)
        {
            mission.Status = MissionStatus.Failed;
            Console.WriteLine($"Mission '{mission.Name}' failed.");
        }
    }

    // Method to update mission progress
    public void UpdateMissionProgress(string missionName, int progress)
    {
        var mission = Missions.FirstOrDefault(m => m.Name == missionName);
        if (mission != null)
        {
            mission.UpdateProgress(progress);
            Console.WriteLine($"Mission '{mission.Name}' progress updated.");
        }
    }
}
