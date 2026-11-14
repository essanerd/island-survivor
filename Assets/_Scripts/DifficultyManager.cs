
public enum GameDifficulty
{
    Easy,
    Medium,
    Hard
}

public static class DifficultyManager
{
    public static GameDifficulty CurrentDifficulty { get; private set; }
        = GameDifficulty.Medium;

    public static int MaxHits
    {
        get
        {
            switch (CurrentDifficulty)
            {
                case GameDifficulty.Easy:
                    return 3;

                case GameDifficulty.Medium:
                case GameDifficulty.Hard:
                    return 1;

                default:
                    return 1;
            }
        }
    }

    public static int SpawnPointCount
    {
        get
        {
            switch (CurrentDifficulty)
            {
                case GameDifficulty.Easy:
                    return 3;

                case GameDifficulty.Medium:
                    return 5;

                case GameDifficulty.Hard:
                    return 7;

                default:
                    return 5;
            }
        }
    }

    public static int EnemyCount
    {
        get
        {
            return SpawnPointCount;
        }
    }

    public static void SetDifficulty(GameDifficulty difficulty)
    {
        CurrentDifficulty = difficulty;
    }
}
