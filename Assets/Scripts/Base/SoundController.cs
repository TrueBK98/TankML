using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class SoundController : MonoBehaviour
{
    AudioSource audioSource;
    Dictionary<string, AudioClip> dic_name_AudioClip = new Dictionary<string, AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        audioSource = GetComponent<AudioSource>();
        AudioClip[] audioClips = Resources.LoadAll<AudioClip>("Sounds");
        foreach (AudioClip audioClip in audioClips)
        {
            dic_name_AudioClip.Add(audioClip.name, audioClip);
        }
    }

    public void PlayMusic(string musicName)
    {
        if (!dic_name_AudioClip.ContainsKey(musicName))
        {
            Debug.LogError("Music Name: " + musicName + " does not exist");
        }
        audioSource.clip = dic_name_AudioClip[musicName];
        audioSource.Play();
    }

    public void PlaySound(string soundName)
    {
        if (!dic_name_AudioClip.ContainsKey(soundName))
        {
            Debug.LogError("Sound Name: " + soundName + " does not exist");
        }
        audioSource.PlayOneShot(dic_name_AudioClip[soundName]);
    }
}

public class Sound : SingletonMonoBehaviour<SoundController>
{
        
}
