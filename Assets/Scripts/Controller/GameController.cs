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
        StartCoroutine(CheckMusicEnd());
    }

    public void GameOver(string Reasion)
    {
        isGameRunning = false;
        Debug.Log(Reasion);
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
}
