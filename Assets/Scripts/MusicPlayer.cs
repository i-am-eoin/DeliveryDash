using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource music;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        music = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (music.isPlaying) return;
        music.Play();
    }

    public void StopMusic()
    {
        music.Stop();
    }
}