public interface IBattleStrategy
{
    void Execute(PlayerFish player, EnemyFish enemy);
}

public class EatStrategy : IBattleStrategy
{
    public void Execute(PlayerFish player, EnemyFish enemy)
    {
        if (player.Size > enemy.Size)
        {
            Console.WriteLine("You ate the enemy fish!");
            player.Eat(enemy.Size);
        }
        else
        {
            Console.WriteLine("The enemy fish is too big to eat!");
            player.TakeDamage(enemy.Damage);
        }
    }
}

public class AvoidStrategy : IBattleStrategy
{
    public void Execute(PlayerFish player, EnemyFish enemy)
    {
        Console.WriteLine("You avoided the enemy fish.");
        // Possibly implement chance of failing to avoid
    }
}

public class BattleSystem
{
    private IBattleStrategy _strategy;

    public void SetStrategy(IBattleStrategy strategy)
    {
        _strategy = strategy;
    }

    public void Engage(PlayerFish player, EnemyFish enemy)
    {
        _strategy.Execute(player, enemy);
    }
}
