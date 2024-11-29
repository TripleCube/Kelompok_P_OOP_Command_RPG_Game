public sealed class PlayerFish
{
    private static PlayerFish _instance = null;
    private static readonly object padlock = new object();

    public string Name { get; set; }
    public int Size { get; set; }
    public int Health { get; set; }
    public int Level { get; set; }
    public Inventory Inventory { get; set; }
    public IPlayerState State { get; set; }

    private PlayerFish()
    {
        Size = 1;
        Health = 100;
        Level = 1;
        Inventory = new Inventory();
        State = new NormalState();
    }

    public static PlayerFish Instance
    {
        get
        {
            lock (padlock)
            {
                if (_instance == null)
                {
                    _instance = new PlayerFish();
                }
                return _instance;
            }
        }
    }

    public void Eat(int foodSize)
    {
        State.Eat(this, foodSize);
    }

    public void TakeDamage(int damage)
    {
        State.TakeDamage(this, damage);
    }

    public void UsePowerUp(PowerUp powerUp)
    {
        powerUp.ApplyEffect(this);
    }

    public void LevelUp()
    {
        Level++;
        Size++;
        Console.WriteLine($"Congratulations! You've reached level {Level} and your size increased to {Size}.");
    }
}
