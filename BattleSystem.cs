using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public Character player;
    public Enemy enemy;
    private bool isPlayerTurn;

    private void Start()
    {
        isPlayerTurn = true;
    }

    public void PlayerAttack()
    {
        if (isPlayerTurn)
        {
            enemy.TakeDamage(player.attackPower);
            isPlayerTurn = false;
            CheckBattleOutcome();
        }
    }

    public void EnemyAttack()
    {
        if (!isPlayerTurn)
        {
            player.TakeDamage(enemy.attackPower);
            isPlayerTurn = true;
            CheckBattleOutcome();
        }
    }

    private void CheckBattleOutcome()
    {
        if (enemy.healthPoints <= 0)
        {
            player.GainExperience(50); // XP reward
            Debug.Log("Enemy defeated!");
        }
        else if (player.healthPoints <= 0)
        {
            Debug.Log("Player defeated!");
        }
    }
}
