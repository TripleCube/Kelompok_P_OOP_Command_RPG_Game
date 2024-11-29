public sealed class PlayerFish
{
    private static PlayerFish _instance = null;
    private static readonly object padlock = new object();

    public string Name { get; set; }
    public int Size { get; set; }
    public int Health { get; set; }
    public int Level { get; set; }
    public Inventory Inventory { get; set; }
    public SkillInventory SkillInventory { get; set; }
    public IPlayerState State { get; set; }
    private List<IStatusEffect> ActiveEffects { get; set; } = new List<IStatusEffect>();

    private PlayerFish()
    {
        Size = 1;
        Health = 100;
        Level = 1;
        Inventory = new Inventory();
        SkillInventory = new SkillInventory();
        State = new NormalState();

        // Start with initial skills
        SkillInventory.AddSkill(new SpeedBoostSkill());
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

    public void UnlockSkillsForLevel()
    {
        switch (Level)
        {
            case 3:
                SkillInventory.AddSkill(new BubbleShieldSkill());
                break;
            case 5:
                SkillInventory.AddSkill(new HealSkill());
                break;
            case 7:
                SkillInventory.AddSkill(new RageSkill());
                break;
        }
    }

    public void ApplyStatusEffect(IStatusEffect effect)
    {
        effect.Apply(this);
        ActiveEffects.Add(effect);
    }

    public void UpdateEffects()
    {
        foreach (var effect in new List<IStatusEffect>(ActiveEffects)) // Copy to avoid modifying during iteration
        {
            if (effect is ToxicSlime toxicSlime)
            {
                toxicSlime.Tick(this); // Handle special behavior for Toxic Slime
            }
            effect.Update(this);
            if (effect.Duration <= 0)
            {
                ActiveEffects.Remove(effect);
            }
        }
    }

    // Existing methods remain the same
    public void Eat(int foodSize) => State.Eat(this, foodSize);
    public void TakeDamage(int damage) => State.TakeDamage(this, damage);
    public void UsePowerUp(PowerUp powerUp) => powerUp.ApplyEffect(this);

    public void LevelUp()
    {
        Level++;
        Size++;
        Console.WriteLine($"Congratulations! You've reached level {Level} and your size increased to {Size}.");
        UnlockSkillsForLevel();
    }

    public void InteractWithNPC(NPC npc)
    {
        npc.TalkToPlayer(this);
        npc.OfferMission(this);
        npc.GiveItem(this);
    }
}