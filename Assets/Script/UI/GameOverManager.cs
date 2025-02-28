using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        int score = PlayerPrefs.GetInt("Score", 0);
        bool isWin = PlayerPrefs.GetInt("Win", 0) == 1;

        gameOverText.text = isWin ? "YOU WIN!" : "YOU LOSE!";
        scoreText.text = "Score: " + score/2;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene"); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
