
using UnityEngine;

public class DifficultyButton : MonoBehaviour
{
    public void SelectEasy()
    {
        DifficultyManager.SetDifficulty(GameDifficulty.Easy);
    }

    public void SelectMedium()
    {
        DifficultyManager.SetDifficulty(GameDifficulty.Medium);
    }

    public void SelectHard()
    {
        DifficultyManager.SetDifficulty(GameDifficulty.Hard);
    }
}
