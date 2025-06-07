using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
    // public float spawnTime;  // Thời gian spawn của tile
    // public bool isActive = true;  // Trạng thái hoạt động của tile
    // public float extraReactionTime = 1f; // Hệ số tăng thời gian phản ứng (tuỳ chỉnh nếu cần)
    // private SpriteRenderer spriteRenderer;  // SpriteRenderer để thay đổi sprite
    // public Sprite newSprite;  // Sprite mới thay đổi khi nhấn
    // public Sprite OriginalSprite;
    // public float shakeIntensity = 0.1f;  // Cường độ rung
    // public float shakeDuration = 0.2f;  // Thời gian rung
    // public bool isTouched;
    // public GameObject particlePoint;

    // void Awake()
    // {
    //     spriteRenderer = GetComponent<SpriteRenderer>();
    //     if(spriteRenderer.sprite != null)
    //     {
    //         spriteRenderer.sprite = OriginalSprite;
    //     }
    // }
    // void OnMouseDown()
    // {
    //     // Kiểm tra nếu tile đã được nhấn
    //     if (isTouched) return;  // Nếu đã nhấn rồi thì không làm gì thêm

    //     // Cộng điểm khi tile được nhấn
    //     Collider2D hitCollider = GetComponent<Collider2D>();
    //     if (hitCollider != null && hitCollider.gameObject == gameObject)
    //     {
    //         Tile tile = hitCollider.gameObject.GetComponent<Tile>();
    //         if (tile != null && tile.gameObject.activeInHierarchy)
    //         {
    //             // Tính toán thời gian phản ứng và cộng điểm
    //             float reactionTime = (Time.time - tile.spawnTime) * extraReactionTime;
    //             if (tile.isActive)
    //             {
    //                 isTouched = true;
    //                 spriteRenderer.sprite = newSprite;
    //                 StartCoroutine(ShakeTile());
    //                 ScoreManager.Instance.AddScore(reactionTime, true);
    //                 ParticleSystemManager.Instance.PlayParticleEffect("Explosed",particlePoint.transform.position,1f);
    //                 Debug.Log("Tile active true - Reaction Time: " + reactionTime);
    //             }
    //             else
    //             {
    //                 Debug.Log("Tile active false");
    //                 isTouched = false;
    //                 return;
    //             }
    //         }
    //     }
    // }


    // // Coroutine để tạo hiệu ứng rung
    // private IEnumerator ShakeTile()
    // {
    //     Vector3 originalPosition = transform.position;  // Lưu vị trí ban đầu của tile

    //     float elapsedTime = 0f;
    //     while (elapsedTime < shakeDuration)
    //     {
    //         float xOffset = Random.Range(-shakeIntensity, shakeIntensity);
    //         float yOffset = Random.Range(-shakeIntensity, shakeIntensity);
    //         transform.position = originalPosition + new Vector3(xOffset, yOffset, 0);

    //         elapsedTime += Time.deltaTime;
    //         yield return null;
    //     }

    //     // Đặt lại vị trí ban đầu của tile sau khi rung
    //     transform.position = originalPosition;
    // }

    // public void ResetTile()
    // {
    //     spriteRenderer.sprite = OriginalSprite;
    //     isTouched = false;
    // }
}
