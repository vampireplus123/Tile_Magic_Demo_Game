using System.Collections;
using UnityEngine;

public class LightDecor : MonoBehaviour
{
    public static LightDecor Instance { get; private set; }
    private SpriteRenderer spriteRenderer;

    // Màu mặc định và màu khi nhấn vào tile
    private Color defaultColor = new Color(1f, 1f, 1f, 0.588f);  // Alpha = 150/255
    private Color activeColor = new Color(1f, 1f, 1f, 1f);  // Alpha = 256/255
    private Coroutine blinkCoroutine; // Coroutine để điều khiển chớp sáng

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
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            spriteRenderer.color = defaultColor; // Đặt màu mặc định cho sprite renderer
        }
    }

    // Hàm thay đổi màu của LightDecor khi nhấn vào tile (và chớp sáng)
    public void ChangeLightContrast()
    {
        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine); // Nếu coroutine đang chạy, dừng lại trước
        }

        blinkCoroutine = StartCoroutine(BlinkLight()); // Bắt đầu hiệu ứng chớp sáng
    }

    // Coroutine để tạo hiệu ứng chớp sáng
    private IEnumerator BlinkLight()
    {
        if (spriteRenderer == null) yield break;

        // Đặt màu active
        spriteRenderer.color = activeColor;

        // Chờ 0.2 giây (hoặc bất kỳ khoảng thời gian nào bạn muốn)
        yield return new WaitForSeconds(0.2f);

        // Trả về màu mặc định
        spriteRenderer.color = defaultColor;

        // Chờ thêm trước khi chớp tiếp (nếu cần lặp lại)
        yield return new WaitForSeconds(0.2f);

        // Nếu muốn chớp nhiều lần, bạn có thể lặp logic này thêm tại đây
    }
}
