using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Text killCounterText; // Text hiển thị số kill

    private int killCount1 = 0; // Số enemy bị tiêu diệt

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void OnEnable()
    {
        EnemyManager.OnEnemyKilled += UpdateKillCount; // Lắng nghe sự kiện Enemy bị giết
    }

    void OnDisable()
    {
        EnemyManager.OnEnemyKilled -= UpdateKillCount; // Hủy lắng nghe sự kiện
    }

    void UpdateKillCount()
    {
        killCount1++;
        killCounterText.text = killCount1.ToString(); // Cập nhật UI

        GameManager.Instance.EnemyKilled(); // Báo cho GameManager biết enemy bị tiêu diệt
    }
}