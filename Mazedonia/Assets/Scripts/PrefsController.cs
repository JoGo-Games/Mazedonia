using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class PrefsController : MonoBehaviour
{
    public AudioMixer audioMixer;

    void Start()
    {
        int unlocked_level = PlayerPrefs.GetInt("unlocked_level", 1);
        float music_volume = PlayerPrefs.GetFloat("music_volume", 0f);
        float sound_volume = PlayerPrefs.GetFloat("sound_volume", 0f);
        audioMixer.SetFloat("MusicVolume", music_volume);
        audioMixer.SetFloat("SoundVolume", sound_volume);
    }
}
