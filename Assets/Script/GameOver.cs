using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;

    public void setGameOver(bool value)
    {
        gameOverUI.SetActive(value);
        Time.timeScale=0f;
    }
}
