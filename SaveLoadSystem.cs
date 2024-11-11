using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    public Character player;

    public void SaveGame()
    {
        PlayerPrefs.SetInt("Health", player.healthPoints);
        PlayerPrefs.SetInt("Level", player.level);
        PlayerPrefs.SetInt("Experience", player.experiencePoints);
    }

    public void LoadGame()
    {
        player.healthPoints = PlayerPrefs.GetInt("Health", 100);
        player.level = PlayerPrefs.GetInt("Level", 1);
        player.experiencePoints = PlayerPrefs.GetInt("Experience", 0);
    }
}
