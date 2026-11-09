
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _startPanel;

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private GameObject _enemyController;

    [SerializeField]
    private GameObject _scoreText;

    private void Start()
    {
        _player.SetActive(false);
        _enemyController.SetActive(false);
        _scoreText.SetActive(false);
    }

    public void StartGame()
    {
        _startPanel.SetActive(false);

        _scoreText.SetActive(true);
        _player.SetActive(true);
        _enemyController.SetActive(true);
    }
}
