public interface IPlayerState
{
    void Eat(PlayerFish player, int foodSize);
    void TakeDamage(PlayerFish player, int damage);
}

public class NormalState : IPlayerState
{
    public void Eat(PlayerFish player, int foodSize)
    {
        Console.WriteLine("You feel satisfied after eating.");
        // Implement eating logic
    }

    public void TakeDamage(PlayerFish player, int damage)
    {
        player.Health -= damage;
        Console.WriteLine($"You took {damage} damage. Health is now {player.Health}.");
    }
}

public class ShieldedState : IPlayerState
{
    private IPlayerState previousState;

    public ShieldedState(IPlayerState prevState)
    {
        previousState = prevState;
    }

    public void Eat(PlayerFish player, int foodSize)
    {
        previousState.Eat(player, foodSize);
    }

    public void TakeDamage(PlayerFish player, int damage)
    {
        Console.WriteLine("Your Bubble Shield absorbed the damage!");
        player.State = previousState; // Revert to previous state
    }
}

public class BoostedState : IPlayerState
{
    private IPlayerState previousState;
    private int boostDuration = 3;

    public BoostedState(IPlayerState prevState)
    {
        previousState = prevState;
    }

    public void Eat(PlayerFish player, int foodSize)
    {
        previousState.Eat(player, foodSize);
    }

    public void TakeDamage(PlayerFish player, int damage)
    {
        previousState.TakeDamage(player, damage);
    }

    public void Update()
    {
        boostDuration--;
        if (boostDuration <= 0)
        {
            PlayerFish.Instance.State = previousState;
            Console.WriteLine("Speed Boost has worn off.");
        }
    }
}
