using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileManager : MonoBehaviour
{
    // public static TileManager Instance;
    // public GameObject tilePrefab;
    // public List<SpawnPoint> spawnPoints;
    // public float fallSpeed = 2f;
    // public int maxActiveTiles = 5;

    // private Queue<GameObject> tilePool = new Queue<GameObject>();
    // private int activeTiles = 0;
    // private bool isSpawning = false;
    // private float spawnInterval = 1f; // Khoảng thời gian spawn mặc định
    // public Transform DestinationOjectPosition;

    // void Awake()
    // {
    //     if (Instance == null)
    //     {
    //         Instance = this;
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }

    //     if (spawnPoints == null || spawnPoints.Count == 0)
    //     {
    //         spawnPoints = new List<SpawnPoint>(FindObjectsOfType<SpawnPoint>());
    //     }
    // }
    // //lấy TIle từ pool
    // public GameObject GetTile()
    // {
    //     if (tilePool.Count > 0)
    //     {
    //         return tilePool.Dequeue();
    //     }
    //     else
    //     {
    //         return Instantiate(tilePrefab);
    //     }
    // }
    // //Trả Tiles lại pool
    // public void ReturnTile(GameObject tile)
    // {
    //     tile.SetActive(false);
    //     tilePool.Enqueue(tile);
    //     activeTiles--;
    // }
    // //Sinh ra Tiles
    // public void SpawnTile()
    // {
    //     if (!GameController.Instance.IsGameRunning || activeTiles >= maxActiveTiles) return;

    //     int randomIndex = Random.Range(0, spawnPoints.Count);
    //     SpawnPoint randomSpawnPoint = spawnPoints[randomIndex];

    //     GameObject tile = GetTile();
    //     tile.transform.position = randomSpawnPoint.GetSpawnPointPosition();
    //     tile.SetActive(true);

    //     Tile tileComponent = tile.GetComponent<Tile>();
    //     if (tileComponent != null)
    //     {
    //         tileComponent.spawnTime = Time.time;
    //     }

    //     activeTiles++;
    // }
    // //Di chuyển tiles
    // public void MoveTiles()
    // {
    //     if (!GameController.Instance.IsGameRunning) return;

    //     foreach (var tile in tilePool)
    //     {
    //         if (tile.activeInHierarchy)
    //         {
    //             tile.transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

    //             // if (tile.transform.position.y <= DestinationOjectPosition.position.y)
    //             // {
    //             //     Tile tileComponent = tile.GetComponent<Tile>();
    //             //     if (tileComponent != null && !tileComponent.hasReachedDestination)
    //             //     {
    //             //         tileComponent.OnHitDestination();
    //             //         tileComponent.hasReachedDestination = true;
    //             //         ReturnTile(tile);
    //             //     }
    //             // }
    //             // ReturnTile(tile);
    //         }
    //     }
    // }
    // //Thay đổi tốc độ của Tiles dựa trên tốc độ game
    // public void UpdateFallSpeedThroughGameSpeed(float gameSpeed)
    // {
    //     fallSpeed = gameSpeed*2;
    //     Debug.Log("Tốc độ đã tăng:" +  fallSpeed);
    // }
    // //Bắt đầu sinh ra Tiles
    // public void StartSpawning()
    // {
    //     if (!isSpawning)
    //     {
    //         isSpawning = true;
    //         StartCoroutine(SpawnTilesCoroutine());
    //     }
    // }
    // //Khoảng cách giũa các lần sinh ra Tiles
    // private IEnumerator SpawnTilesCoroutine()
    // {
    //     while (GameController.Instance.IsGameRunning)
    //     {
    //         SpawnTile();
    //         yield return new WaitForSeconds(spawnInterval);
    //     }
    // }
    // //Cập nhật thời gian sinh ra Tiles dựa trên gamespeed
    // public void UpdateSpawnInterval(float gameSpeed)
    // {
    //     spawnInterval = Mathf.Max(0.5f, 1f / gameSpeed);
    //     Debug.Log("Khoảng thời gian spawn đã cập nhật: " + spawnInterval);
    // }
}
