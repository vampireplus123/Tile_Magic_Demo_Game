using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource musicSource;     // AudioSource cho nhạc nền
    public AudioClip backgroundMusic;   // Tệp âm thanh cho nhạc nền

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Giữ AudioManager tồn tại qua các scene
        }
        else
        {
            Destroy(gameObject);  // Tránh trùng lặp AudioManager
        }
    }

    void Start()
    {
        // // Phát nhạc nền ngay khi AudioManager bắt đầu
        // if (backgroundMusic != null && musicSource != null)
        // {
        //     PlayBackGroundMusic(backgroundMusic);
        // }
    }

    // Phát nhạc nền
    public void PlayBackGroundMusic(AudioClip clip)
    {
        if (musicSource != null)
        {
            musicSource.clip = clip;
            musicSource.loop = true;  // Lặp lại nhạc nền
            musicSource.Play();
        }
    }

    // Dừng nhạc nền
    public void StopMusic()
    {
        if (musicSource != null && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    // Tắt/Bật âm thanh
    public void ToggleMute()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
