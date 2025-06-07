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
    public float beatInterval = 0.5f;
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
    }

    public void GameOver(string reason)
    {
        isGameRunning = false;
        Debug.Log(reason);
        audioSource.Stop();
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

    private void SpawnTile()
    {
        int randomIndex = Random.Range(0, TileManager.Instance.spawnPoints.Count);
        Vector3 spawnPos = TileManager.Instance.spawnPoints[randomIndex].transform.position;

        GameObject tile = TileManager.Instance.GetTile();
        tile.transform.position = spawnPos;
        tile.SetActive(true); 
    }
}
