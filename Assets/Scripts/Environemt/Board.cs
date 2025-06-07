using UnityEngine;

public class Board : MonoBehaviour
{
    void OnMouseDown()
    {
        if (GameController.Instance.isGameRunning)
        {
            Debug.Log("Touched Board");
            GameController.Instance.GameOver("Touch The Board");
        }
    }
}
