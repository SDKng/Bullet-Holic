using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{

    public Slider master;
    public Slider music;
    public Slider effects;

    public AudioMixer mixer;

    private bool gameStart = true;

    // Start is called before the first frame update
    void Start()
    {
        if(gameStart == true)
        {
            PlayerPrefs.SetFloat("masterVolume", 0.0f);
            PlayerPrefs.SetFloat("musicVolume", 0.0f);
            PlayerPrefs.SetFloat("effectsVolume", 0.0f);
            gameStart = false;
        }
        else
        {
            master.value = PlayerPrefs.GetFloat("masterVolume");
            music.value = PlayerPrefs.GetFloat("musicVolume");
            effects.value = PlayerPrefs.GetFloat("effectsVolume");

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // master.onValueChanged.AddListener(delegate { UpdateMasterVolume(); });
      //  music.onValueChanged.AddListener(delegate { UpdateMusicVolume(); });
       // effects.onValueChanged.AddListener(delegate { UpdateEffectsVolume(); });
    }

    public void UpdateMasterVolume()
    {
        PlayerPrefs.SetFloat("masterVolume", Mathf.Log10(master.value) * 20);
        mixer.SetFloat("MasterVol", Mathf.Log10(master.value) * 20);
    }

    public void UpdateMusicVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", Mathf.Log10(music.value) * 20);
        mixer.SetFloat("MusicVol", Mathf.Log10(music.value) * 20);
    }

    public void UpdateEffectsVolume()
    {
        PlayerPrefs.SetFloat("effectsVolume", Mathf.Log10(effects.value) * 20);
        mixer.SetFloat("EffectsVol", Mathf.Log10(effects.value) * 20);
    }
}
