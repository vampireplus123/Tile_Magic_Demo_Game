using UnityEngine;

public class Board : MonoBehaviour
{
    void OnMouseDown()
    {
        // Kiểm tra trạng thái của game trước khi thực hiện hành động
        if (GameController.Instance.isGameRunning)
        {
            Debug.Log("Touched Board");
            GameController.Instance.GameOver("Touch The Board");
        }
        // Debug.Log("Touched Board");
    }
}
