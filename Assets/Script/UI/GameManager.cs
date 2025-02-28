using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int killCount = 0;
    [SerializeField]
    private int maxKillCount = 10; // Số enemy cần giết để thắng
    private int lives = 3; // Mạng sống của Cannon
    private bool isGameOver = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void EnemyKilled()
    {
        if (isGameOver) return;
        killCount++;
        if (killCount >= maxKillCount)
        {
            EndGame(true); // Chuyển sang màn hình chiến thắng
        }
    }

    public void CannonHit()
    {
        if (isGameOver) return;
        lives--;

        if (lives <= 0)
        {
            StartCoroutine(DelayEndGame(0.6f)); // Gọi Coroutine để delay 0.6s
        }
    }
    private IEnumerator DelayEndGame(float delay)
    {
        yield return new WaitForSeconds(delay); // Chờ 0.6 giây
        EndGame(false); // Kết thúc game sau khi animation chạy xong
    }
    void EndGame(bool isWin)
    {
        isGameOver = true;
        PlayerPrefs.SetInt("Score", killCount);
        PlayerPrefs.SetInt("Win", isWin ? 1 : 0);

        SceneManager.LoadScene("GameOverScene"); // Chuyển sang scene kết thúc
    }
}