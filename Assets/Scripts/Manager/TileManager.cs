using UnityEngine;
using System.Collections.Generic;

public class TileManager : MonoBehaviour
{
    public static TileManager Instance;

    public GameObject tilePrefab;
    private Queue<GameObject> tilePool = new Queue<GameObject>();
    public List<SpawnPoint> spawnPoints;
    public int tilePoolSize = 5;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (spawnPoints == null || spawnPoints.Count == 0)
        {
            spawnPoints = new List<SpawnPoint>(FindObjectsOfType<SpawnPoint>());
        }
    }

    void Start()
    {
        for (int i = 0; i < tilePoolSize; i++)
        {
            GameObject tile = Instantiate(tilePrefab);
            tile.SetActive(false);
            tilePool.Enqueue(tile);
        }
    }

    public GameObject GetTile()
    {
        if (tilePool.Count > 0)
        {
            return tilePool.Dequeue();
        }
        else
        {
            return Instantiate(tilePrefab);
        }
    }

    public void ReturnTile(GameObject tile)
    {
        var tileBase = tile.GetComponent<TileBase>();
        if (tileBase != null)
        {
            tileBase.ResetState();
        }

        tile.SetActive(false);
        tilePool.Enqueue(tile);
    }

}
