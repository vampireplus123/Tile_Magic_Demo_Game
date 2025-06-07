using UnityEngine;
using TMPro;
using UnityEngine.UI;  // Thư viện UI

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; set; }
    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI feedbackText;
    public TextMeshProUGUI GameOverText; 
    public Button startButton; 
    public GameObject gameOverPanel; 

    private int score = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        feedbackText.gameObject.SetActive(false);  
        scoreText.gameObject.SetActive(false); 
        gameOverPanel.SetActive(false); 

        startButton.onClick.AddListener(OnStartButtonClicked);
    }

    public void OnStartButtonClicked()
    {
        startButton.gameObject.SetActive(false);
        Debug.Log("Game Started");
        gameOverPanel.SetActive(false);
        score = 0;

        scoreText.gameObject.SetActive(true); 
        UpdateScore(score);                   
        GameController.Instance.GameStart();
    }

    public void UpdateScore(int value)
    {
        score = value;
        scoreText.text = score.ToString(); 
    }
    public void ShowFeedback(string feedbackMessage, float duration = 0.2f)
    {
        if (!string.IsNullOrEmpty(feedbackMessage))
        {
            feedbackText.text = feedbackMessage;
            feedbackText.gameObject.SetActive(true);
            Invoke("HideFeedback", duration);
        }
        else
        {
            feedbackText.gameObject.SetActive(false);
        }
    }
    private void HideFeedback()
    {
        feedbackText.gameObject.SetActive(false);
    }
    public void ShowReasonEnd(string feedbackMessage)
    {
        GameOverText.text = feedbackMessage;
    }
    public void ShowGameOverPanel(string ReasonOver)
    {
        gameOverPanel.SetActive(true);
        ShowReasonEnd(ReasonOver);
        startButton.interactable = true;
    }
}
