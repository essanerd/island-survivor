
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;

    private int _score = 0;

    void Start()
    {
        UpdateScoreText();
    }

    public void AddPoints(int points)
    {
        _score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        _scoreText.text = "Score: " + _score;
    }
}
