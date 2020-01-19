using UnityEngine;

public static class SaveGame
{
    public static void Save(int lastCompletedLevel)
    {
        var currentLevel = PlayerPrefs.GetInt("currentLevel", 0);
        if (lastCompletedLevel > currentLevel)
        {
            PlayerPrefs.SetInt("currentLevel", lastCompletedLevel);
        }
    }
}
