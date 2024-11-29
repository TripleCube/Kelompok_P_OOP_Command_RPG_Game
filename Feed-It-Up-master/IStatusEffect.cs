public interface IStatusEffect
{
    string Name { get; }
    string Description { get; }
    int Duration { get; set; } // Remaining turns
    void Apply(Entity target);
    void Remove(Entity target);
}

public class ScaleRot : IStatusEffect
{
    public string Name => "Scale Rot";
    public string Description => "Defense reduced by 5.";
    public int Duration { get; set; }

    public void Apply(Entity target)
    {
        target.Defense -= 5;
    }

    public void Remove(Entity target)
    {
        target.Defense += 5;
    }
}

// Power Up (Attack Boost)
public class PowerUpEffect : IStatusEffect
{
    public string Name => "Power Up";
    public string Description => "Attack increased by 5.";
    public int Duration { get; set; }

    public void Apply(Entity target)
    {
        target.Attack += 5;
    }

    public void Remove(Entity target)
    {
        target.Attack -= 5;
    }
}

// Scent Trail (Enemy Attraction)
public class ScentTrail : IStatusEffect
{
    public string Name => "Scent Trail";
    public string Description => "Attracts enemies, increasing encounter chances.";
    public int Duration { get; set; }

    public void Apply(Entity target)
    {
        // No immediate stats change; affects encounter logic externally
    }

    public void Remove(Entity target)
    {
        // Logic for removing scent effects in encounter mechanics
    }
}

// Paralyze (Action Restriction)
public class Paralyze : IStatusEffect
{
    public string Name => "Paralyze";
    public string Description => "Cannot attack or move.";
    public int Duration { get; set; }

    public void Apply(Entity target)
    {
        target.Speed = 0; // Stop movement/action
    }

    public void Remove(Entity target)
    {
        target.Speed = 5; // Restore to default or previous speed
    }
}

// Toxic Slime (Gradual Health Reduction)
public class ToxicSlime : IStatusEffect
{
    public string Name => "Toxic Slime";
    public string Description => "Health reduced by 2 each turn.";
    public int Duration { get; set; }

    public void Apply(Entity target)
    {
        // No immediate health reduction; effect occurs during turns
    }

    public void Remove(Entity target)
    {
        // No removal logic needed
    }
}

// Supporting new status effects for buffs
public class TemporaryDefenseBoost : IStatusEffect
{
    public string Name => "Temporary Defense Boost";
    public string Description => "Defense increased by 5 temporarily.";
    public int Duration { get; set; }

    public void Apply(Entity target)
    {
        target.Defense += 5;
    }

    public void Remove(Entity target)
    {
        target.Defense -= 5;
    }
}

public class TemporarySpeedBoost : IStatusEffect
{
    public string Name => "Temporary Speed Boost";
    public string Description => "Speed increased by 5 temporarily.";
    public int Duration { get; set; }

    public void Apply(Entity target)
    {
        target.Speed += 5;
    }

    public void Remove(Entity target)
    {
        target.Speed -= 5;
    }
}

// Example game loop to demonstrate usage
/* 
public class Program
{
    public static void Main()
    {
        PlayerFish player = PlayerFish.Instance;
        EnemyFish enemy = new BigFish { Name = "Enemy Shark", Health = 80, Defense = 12, Attack = 20, Speed = 3 };

        // Apply status effects
        player.ApplyStatusEffect(new ScaleRot { Duration = 3 });
        player.ApplyStatusEffect(new PowerUpEffect { Duration = 2 });
        enemy.ApplyStatusEffect(new ToxicSlime { Duration = 4 });
        enemy.ApplyStatusEffect(new Paralyze { Duration = 1 });

        // Simulate turns
        for (int turn = 1; turn <= 5; turn++)
        {
            Console.WriteLine($"\n--- Turn {turn} ---");
            player.TickStatusEffects();
            enemy.TickStatusEffects();

            Console.WriteLine(player);
            Console.WriteLine(enemy);
        }
    }
}
*/
