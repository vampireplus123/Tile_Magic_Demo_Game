using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [Header("Thresholds for Reaction Time")]
    public float perfectThreshold = 0.2f; // Thời gian dưới 0.5 giây => Perfect
    public float goodThreshold = 0.5f;     // Thời gian dưới 1 giây => Good

    private int score = 0;  // Điểm số hiện tại

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
    }

    /// <summary>
/// Tính điểm dựa trên thời gian phản ứng
/// </summary>
/// <param name="reactionTime">Thời gian phản ứng (giây)</param>
/// <returns>Số điểm tương ứng</returns>
    private int CalculateScore(float reactionTime)
    {
        if (reactionTime <= perfectThreshold)
        {
            return 10; // Điểm tối đa cho phản ứng nhanh
        }
        else if (reactionTime <= goodThreshold)
        {
            return 5; // Điểm trung bình cho phản ứng vừa phải
        }
        else
        {
            return 1; // Điểm tối thiểu cho phản ứng chậm
        }
    }
    //Thêm điểm
   public void AddScore(float reactionTime, bool isCorrectTile)
    {
        if (!isCorrectTile)
        {
            Debug.Log("Missed! No points awarded.");
            UIManager.Instance.ShowFeedback("Miss!"); // Thông báo người chơi nhấn sai
            return; // Nếu không đúng ô, không thưởng điểm
        }

        // Tính điểm dựa trên thời gian phản ứng
        int points = CalculateScore(reactionTime);

        // Cập nhật điểm
        score += points;

        // Xác định thông báo phản hồi dựa trên số điểm
        string feedbackMessage = points == 10 ? "Perfect!" :
                                points == 5 ? "Good!" :
                                "Nice!";

        // Cập nhật giao diện người dùng
        UIManager.Instance.UpdateScore(score);
        UIManager.Instance.ShowFeedback(feedbackMessage);

        // Debug để kiểm tra logic
        Debug.Log($"Reaction Time: {reactionTime}, Points Awarded: {points}, New Score: {score}");
    }
  // Lấy điểm
    public int GetScore()
    {
        return score;
    }
    //Reset lại điểm
    public void ResetScore()
    {
        score = 0;
        UIManager.Instance.UpdateScore(score); // Đảm bảo UI cũng được cập nhật
    }
}
