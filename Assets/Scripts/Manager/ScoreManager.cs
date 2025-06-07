using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [Header("Reaction Time Thresholds")]
    public float perfectThreshold = 1.2f;
    public float goodThreshold = 1.5f;

    private int score = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddScore(int basePoint, float reactionTime)
    {
        float multiplier = GetMultiplier(reactionTime);
        int totalPoint = Mathf.RoundToInt(basePoint * multiplier);
        score += totalPoint;
        Debug.Log($"Reaction Time: {reactionTime}, Base Point: {basePoint}, Multiplier: {multiplier}, Total: {totalPoint}, New Score: {score}");
        UIManager.Instance.UpdateScore(score);
        UIManager.Instance.ShowFeedback(GetFeedback(multiplier));
    }

    private float GetMultiplier(float reactionTime)
    {
        if (reactionTime <= perfectThreshold) return 2f;
        if (reactionTime <= goodThreshold) return 1.5f;
        return 1f;
    }

    private string GetFeedback(float multiplier)
    {

        switch (multiplier)
        {
            case 2f:
                return "Perfect";
            case 1.5f:
                return "Good!";
            default:
                return "Nice!";
        }
    }
}
