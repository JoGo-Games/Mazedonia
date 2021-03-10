using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenuController : MonoBehaviour
{

    public AudioMixer audioMixer;

    public Slider sound_volume;
    public Slider music_volume;

    private void Start()
    {
        sound_volume.value = PlayerPrefs.GetFloat("sound_volume");
        music_volume.value = PlayerPrefs.GetFloat("music_volume");
    }

    public void Set_Music_Volume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetFloat("music_volume",volume);
    }

    public void Set_Sound_Volume(float volume)
    {
        audioMixer.SetFloat("SoundVolume", volume);
        PlayerPrefs.SetFloat("sound_volume", volume);
    }
}
