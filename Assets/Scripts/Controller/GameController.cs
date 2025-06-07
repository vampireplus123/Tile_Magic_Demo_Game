using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public float gameSpeed = 1f;
    public bool isGameRunning;
    public bool isPlayerWin;
    public AudioClip backgroundMusic;
    private AudioSource audioSource;
    public float beatInterval = 0.05f;
    private Coroutine spawnRoutine;

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
        }
    }

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        Debug.Log(backgroundMusic.length);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameStart();
        }
    }

    public void GameStart()
    {
        Debug.Log("Started");
        isGameRunning = true;
        isPlayerWin = false;
        audioSource.Play();
        spawnRoutine = StartCoroutine(SpawnTiles());
        StartCoroutine(CheckMusicEnd());
        StartCoroutine(IncreaseGameSpeed());
    }

    public void GameOver(string reason)
    {
        isGameRunning = false;
        Debug.Log(reason);
        audioSource.Stop();
        UIManager.Instance.ShowGameOverPanel(reason);
    }

    private void ChangeGameState(bool PlayerState)
    {
        if (!PlayerState)
        {
            Debug.Log("Loose!!");
        }
        Debug.Log("Win!!!");
        isGameRunning = false;
    }

    private void SpawnTile()
    {
        int randomIndex = Random.Range(0, TileManager.Instance.spawnPoints.Count);
        Vector3 spawnPos = TileManager.Instance.spawnPoints[randomIndex].transform.position;

        GameObject tile = TileManager.Instance.GetTile();
        TileBase tileBase = tile.GetComponent<TileBase>();
        if (tileBase != null)
        {
            tileBase.SetFallSpeed(gameSpeed * 0.05f);
        }
        tile.transform.position = spawnPos;
        tile.SetActive(true);
    }

    IEnumerator CheckMusicEnd()
    {
        yield return new WaitForSeconds(backgroundMusic.length);
        if (isGameRunning)
        {
            isPlayerWin = true;
            audioSource.Stop();
            ChangeGameState(isPlayerWin);
        }
    }
    IEnumerator SpawnTiles()
    {
        while (isGameRunning)
        {
            SpawnTile(); // Gọi spawn ở đây
            yield return new WaitForSeconds(beatInterval);
        }
    }
    IEnumerator IncreaseGameSpeed()
    {
        gameSpeed *= gameSpeed / backgroundMusic.length;
        yield return new WaitForSeconds(2f);
    }
}
