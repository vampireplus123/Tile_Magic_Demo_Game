using UnityEngine;
using TMPro;
using UnityEngine.UI;  // Thư viện UI

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; set; }
    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI feedbackText; 
    public TextMeshProUGUI EndGameText; 
    public Button startButton; 
    public GameObject gameOverPanel; 

    public Slider checkpointSlider; 
    public Image[] checkpointStars; 

    private int score = 0;
    private int maxScore = 1000; 

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

        // Ẩn UI ban đầu
        feedbackText.gameObject.SetActive(false);  
        scoreText.gameObject.SetActive(true); 
        gameOverPanel.SetActive(false); 

        startButton.onClick.AddListener(OnStartButtonClicked);

        // Khởi tạo Slider
        if (checkpointSlider != null)
        {
            checkpointSlider.minValue = 0;
            checkpointSlider.maxValue = maxScore;
            checkpointSlider.value = 0; 
        }

        // Ẩn tất cả các ngôi sao ban đầu
        ResetCheckpointStars();
    }

    //Bắt sự kiện nút Start
    public void OnStartButtonClicked()
    {
        startButton.interactable = false;
        Debug.Log("Game Started");
        gameOverPanel.SetActive(false);
        score = 0;
        UpdateSlider();
        ResetCheckpointStars(); 
        GameController.Instance.GameStart();
    }
    public void UpdateScore(int value)
    {
        score = value;
        scoreText.text = score.ToString(); 
        UpdateSlider();
        UpdateCheckpointStars(); 
    }

    private void UpdateSlider()
    {
        if (checkpointSlider != null)
        {
            checkpointSlider.value = score;
        }
    }
   
    private void UpdateCheckpointStars()
    {
        if (checkpointStars != null && checkpointStars.Length > 0)
        {
            int starIndex = Mathf.FloorToInt((float)score / maxScore * checkpointStars.Length);

            for (int i = 0; i < checkpointStars.Length; i++)
            {
                // Bật các ngôi sao đạt được checkpoint
                checkpointStars[i].enabled = i < starIndex;
            }
        }
    }
    private void ResetCheckpointStars()
    {
        if (checkpointStars != null)
        {
            foreach (var star in checkpointStars)
            {
                star.enabled = false;
            }
        }
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
        if (!string.IsNullOrEmpty(feedbackMessage))
        {
            EndGameText.text = feedbackMessage;
            EndGameText.gameObject.SetActive(true);
        }
    }
    public void ShowGameOverPanel(string ReasonOver)
    {
        gameOverPanel.SetActive(true);
        ShowReasonEnd(ReasonOver);
        startButton.interactable = true;
    }
}
