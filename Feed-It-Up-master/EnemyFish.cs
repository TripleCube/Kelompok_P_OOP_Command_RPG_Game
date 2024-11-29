public abstract class EnemyFish
{
    public int Size { get; set; }
    public int Damage { get; set; }

    public abstract void DisplayInfo();
}

public class SmallFish : EnemyFish
{
    public SmallFish()
    {
        Size = 1;
        Damage = 10;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("A small fish appears!");
    }
}

public class MediumFish : EnemyFish
{
    public MediumFish()
    {
        Size = 2;
        Damage = 20;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("A medium fish swims by!");
    }
}

public class BigFish : EnemyFish
{
    public BigFish()
    {
        Size = 3;
        Damage = 30;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("A big fish looms ahead!");
    }
}

public class EnemyFishFactory
{
    public static EnemyFish CreateEnemyFish(int playerLevel)
    {
        Random rand = new Random();
        int fishType = rand.Next(1, 4); // Randomly selects fish type

        switch (fishType)
        {
            case 1:
                return new SmallFish();
            case 2:
                return new MediumFish();
            case 3:
                return new BigFish();
            default:
                return new SmallFish();
        }
    }
}
