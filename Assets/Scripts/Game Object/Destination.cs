using UnityEngine;

public class Destination : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu GameObject là Tile và có tag "Tile"
        Tile tile = collision.GetComponent<Tile>();

        if (tile != null && collision.CompareTag("Tile"))
        {
            // Nếu tile đã được nhấn, trả lại tile vào pool
            if (tile.isTouched)
            {
                Debug.Log("Tile đã được nhấn và đã vượt qua điểm đích. Trả tile về pool.");
                tile.ResetTile();
                TileManager.Instance.ReturnTile(tile.gameObject);  // Trả tile về pool
            }
            else
            {
                // Nếu tile chưa được nhấn, kết thúc game
                Debug.Log("Tile chưa được nhấn và đã vượt qua điểm đích. Game Over!");
                GameController.Instance.EndGame("Touch Destination");  // Kết thúc game
            }
        }
    }
}
