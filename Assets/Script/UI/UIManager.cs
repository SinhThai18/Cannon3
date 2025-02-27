using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Text killCounterText; // Text hiển thị số kill

    private int killCount = 0; // Số enemy bị tiêu diệt

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void OnEnable()
    {
        EnemyManager.OnEnemyKilled += UpdateKillCount; // Đăng ký lắng nghe event
    }

    void OnDisable()
    {
        EnemyManager.OnEnemyKilled -= UpdateKillCount; // Hủy đăng ký event
    }

    void UpdateKillCount()
    {
        killCount++;
        killCounterText.text = killCount.ToString(); // Cập nhật UI
    }
}
