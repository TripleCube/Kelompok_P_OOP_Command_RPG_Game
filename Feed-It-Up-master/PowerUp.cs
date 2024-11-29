public abstract class PowerUp
{
    public abstract void ApplyEffect(PlayerFish player);
}

public class BubbleShield : PowerUp
{
    public override void ApplyEffect(PlayerFish player)
    {
        Console.WriteLine("Bubble Shield activated! You are protected from the next attack.");
        player.State = new ShieldedState(player.State);
    }
}

public class SpeedBoost : PowerUp
{
    public override void ApplyEffect(PlayerFish player)
    {
        Console.WriteLine("Speed Boost activated! You can avoid enemies more easily.");
        player.State = new BoostedState(player.State);
    }
}

public class Inventory
{
    private List<PowerUp> powerUps = new List<PowerUp>();

    public void AddPowerUp(PowerUp powerUp)
    {
        powerUps.Add(powerUp);
        Console.WriteLine($"{powerUp.GetType().Name} added to inventory.");
    }

    public void UsePowerUp(PowerUp powerUp)
    {
        if (powerUps.Contains(powerUp))
        {
            powerUps.Remove(powerUp);
            powerUp.ApplyEffect(PlayerFish.Instance);
            Console.WriteLine($"{powerUp.GetType().Name} used.");
        }
        else
        {
            Console.WriteLine("PowerUp not available in inventory.");
        }
    }
}
