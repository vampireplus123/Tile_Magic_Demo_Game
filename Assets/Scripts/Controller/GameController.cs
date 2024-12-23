using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public float gameSpeed = 1f; // Tốc độ game (điều chỉnh tốc độ spawn và rơi)
    public bool isGameRunning = false; // Trạng thái game, mặc định là không chạy
    public bool IsGameRunning => isGameRunning; // Property để kiểm tra trạng thái game
    public AudioClip backgroundMusic;
    public Transform ParticlePosition;

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

    void Update()
    {
        // Có thể bổ sung logic cập nhật tốc độ game theo yêu cầu nếu cần
    }

    // Hàm kết thúc game
    public void EndGame(string ReasonOver)
    {
        isGameRunning = false;
        Debug.Log("Game Over!");
        UIManager.Instance.ShowGameOver(ReasonOver);  // Hiển thị UI Game Over
        AudioManager.Instance.StopMusic();
    }

    // Hàm bắt đầu game
    public void StartGame()
    {
        isGameRunning = true;
        Debug.Log("Game Started");

        // Cập nhật spawn interval và bắt đầu sinh tile
        TileManager.Instance.UpdateSpawnInterval(gameSpeed);
        TileManager.Instance.StartSpawning();

        // Ẩn nút start và bắt đầu nhạc nền
        UIManager.Instance.startButton.gameObject.SetActive(false);
        AudioManager.Instance.PlayBackGroundMusic(backgroundMusic);

        //Mở Particle System
        ParticleSystemManager.Instance.PlayParticleEffect("FloatingMusic",ParticlePosition.transform.position);
        // Bắt đầu tăng tốc độ game theo thời gian
        StartCoroutine(IncreaseGameSpeedOverTime());
    }

    // Hàm tăng tốc độ game
    IEnumerator IncreaseGameSpeedOverTime()
    {
        while (isGameRunning)
        {
            yield return new WaitForSeconds(10f); // Tăng tốc độ mỗi 10 giây

            gameSpeed *= 2f; // Tăng tốc độ game
            Debug.Log("Tốc độ game đã tăng: " + gameSpeed);
            // Cập nhật tốc độ rơi của tiles
            TileManager.Instance.UpdateFallSpeedThroughGameSpeed(gameSpeed);
            // Cập nhật thời gian spawn trong TileManager
            TileManager.Instance.UpdateSpawnInterval(gameSpeed);
        }
    }
}
