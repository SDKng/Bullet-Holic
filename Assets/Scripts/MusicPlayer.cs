using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicPlayer : MonoBehaviour
{

    public List<AudioClip> songs = new List<AudioClip>();

    public AudioSource audio;

    private int nextSong;

    static MusicPlayer instance = null;

    public static MusicPlayer Instance
    {
        get
        {
            if (!instance)
            {
                instance = new GameObject("MusicPlayer").AddComponent<MusicPlayer>();
            }
            return instance;
        }
    }
    void Awake()
    {
        if (instance && instance.GetInstanceID() != GetInstanceID())
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (audio.isPlaying == false)
        {
            StartAudio();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartAudio()
    {
        if(nextSong < songs.Count)
        {
            audio.clip = songs[nextSong];
            audio.Play();
            nextSong++;
        }
        else
        {
            nextSong = 0;
            audio.clip = songs[nextSong];
            audio.Play();
            nextSong++;
        }

        Invoke("StartAudio", audio.clip.length + 0.2f);
    }
}
