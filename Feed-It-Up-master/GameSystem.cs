public class GameSystem
{
    private MissionManager missionManager;

    public GameSystem()
    {
        missionManager = new MissionManager();
    }

    // Method to save the game state, including missions
    public void SaveGame()
    {
        using (StreamWriter writer = new StreamWriter("savegame.txt"))
        {
            writer.WriteLine(PlayerFish.Instance.Name);
            writer.WriteLine(PlayerFish.Instance.Size);
            writer.WriteLine(PlayerFish.Instance.Health);
            writer.WriteLine(PlayerFish.Instance.Level);

            // Save mission data
            foreach (var mission in missionManager.Missions)
            {
                writer.WriteLine($"{mission.Name},{mission.Status},{mission.Progress}");
            }
            Console.WriteLine("Game saved successfully.");
        }
    }

    // Method to load the game state, including missions
    public void LoadGame()
    {
        using (StreamReader reader = new StreamReader("savegame.txt"))
        {
            PlayerFish.Instance.Name = reader.ReadLine();
            PlayerFish.Instance.Size = int.Parse(reader.ReadLine());
            PlayerFish.Instance.Health = int.Parse(reader.ReadLine());
            PlayerFish.Instance.Level = int.Parse(reader.ReadLine());

            // Load mission data
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(',');
                string missionName = parts[0];
                MissionStatus status = (MissionStatus)Enum.Parse(typeof(MissionStatus), parts[1]);
                int progress = int.Parse(parts[2]);

                var mission = new Mission(missionName, "Description Placeholder", "Objective Placeholder");
                mission.Status = status;
                mission.Progress = progress;

                missionManager.AddMission(mission);
            }
            Console.WriteLine("Game loaded successfully.");
        }
    }

    // Other methods like saving/loading for other game states can go here...
}
