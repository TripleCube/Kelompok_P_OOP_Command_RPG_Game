class Program
{
    static void Main(string[] args)
    {
        // Inisialisasi permainan
        Console.WriteLine("Enter your fish's name:");
        PlayerFish.Instance.Name = Console.ReadLine();

        LevelUpSystem levelUpSystem = new LevelUpSystem();
        GameSystem gameSystem = new GameSystem();
        BattleSystem battleSystem = new BattleSystem();

        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Search for food");
            Console.WriteLine("2. Use PowerUp");
            Console.WriteLine("3. Save Game");
            Console.WriteLine("4. Load Game");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    EnemyFish enemy = EnemyFishFactory.CreateEnemyFish(PlayerFish.Instance.Level);
                    enemy.DisplayInfo();

                    Console.WriteLine("Choose your strategy:");
                    Console.WriteLine("1. Eat");
                    Console.WriteLine("2. Avoid");

                    string strategyChoice = Console.ReadLine();
                    if (strategyChoice == "1")
                    {
                        battleSystem.SetStrategy(new EatStrategy());
                    }
                    else
                    {
                        battleSystem.SetStrategy(new AvoidStrategy());
                    }

                    battleSystem.Engage(PlayerFish.Instance, enemy);

                    // Update level based on actions
                    levelUpSystem.AddExperience(20); // Example experience gain

                    break;

                case "2":
                    Console.WriteLine("Choose a PowerUp to use:");
                    Console.WriteLine("1. BubbleShield");
                    Console.WriteLine("2. SpeedBoost");

                    string powerUpChoice = Console.ReadLine();
                    PowerUp powerUp = null;

                    if (powerUpChoice == "1")
                    {
                        powerUp = new BubbleShield();
                    }
                    else if (powerUpChoice == "2")
                    {
                        powerUp = new SpeedBoost();
                    }

                    if (powerUp != null)
                    {
                        PlayerFish.Instance.Inventory.UsePowerUp(powerUp);
                    }

                    break;

                case "3":
                    gameSystem.SaveGame();
                    break;

                case "4":
                    gameSystem.LoadGame();
                    break;

                case "5":
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select again.");
                    break;
            }

            // Update any active states
            if (PlayerFish.Instance.State is BoostedState boostedState)
            {
                boostedState.Update();
            }

            // Check game over condition
            if (PlayerFish.Instance.Health <= 0)
            {
                Console.WriteLine("Game Over!");
                isRunning = false;
            }
        }
    }
}
