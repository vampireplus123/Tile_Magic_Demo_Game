using UnityEngine;

public class Destination : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TileBase tile = collision.GetComponent<TileBase>();

        if (tile != null)
        {
            if (tile.isTouched)
            {
                Debug.Log("Tile đã được nhấn và đã vượt qua điểm đích. Trả tile về pool.");
                TileManager.Instance.ReturnTile(tile.gameObject);
            }
            else
            {
                GameController.Instance.GameOver("Touch Destination");
                Debug.Log("Tile chưa được nhấn và đã vượt qua điểm đích. Game Over!");
            }
        }
    }
}
