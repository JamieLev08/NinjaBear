using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio_manager : MonoBehaviour
{
    public AudioClip[] Sounds;
    public List<AudioSource> sources;
    public AudioMixerGroup mixer;

    void Start()
    {
        if(Sounds.Length > 0)
        {
            foreach (AudioClip clip in Sounds)
            {
                AudioSource source = gameObject.AddComponent<AudioSource>();
                source.clip = clip;
                sources.Add(source);
                source.outputAudioMixerGroup = mixer;
            }
            sources.ToArray();
            sources[0].pitch = 0.5f;
            sources[0].volume = 0.5f;
        }
    }
}


