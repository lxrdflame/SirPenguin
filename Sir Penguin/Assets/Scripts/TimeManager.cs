using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public float matchTime = 120f;
    private float currentTime;

    public TextMeshProUGUI player1TimerText;
    public TextMeshProUGUI player2TimerText;

    public CashBox player1CashBox;
    public CashBox player2CashBox;

    private bool gameEnded = false;

    void Start()
    {
        currentTime = matchTime;
    }

    void Update()
    {
        if (gameEnded) return;

        currentTime -= Time.deltaTime;

        if (currentTime < 0)
            currentTime = 0;

        UpdateTimerUI();

        if (currentTime <= 0)
        {
            EndGame();
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        string timeString = minutes.ToString("00") + ":" + seconds.ToString("00");

        if (player1TimerText != null)
            player1TimerText.text = timeString;

        if (player2TimerText != null)
            player2TimerText.text = timeString;
    }

    void EndGame()
    {
        gameEnded = true;

        int p1Score = player1CashBox.GetScore();
        int p2Score = player2CashBox.GetScore();

        if (p1Score > p2Score)
        {
            SceneManager.LoadScene("Player1Win");
        }
        else if (p2Score > p1Score)
        {
            SceneManager.LoadScene("Player2Win");
        }
        else
        {
            SceneManager.LoadScene("DrawScene");
        }
    }
}
