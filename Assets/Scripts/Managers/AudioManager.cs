using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioTrack[] tracks;
    void Awake ()
    {
        instance = this;
    }

    #region Structs
    [System.Serializable]
    public class AudioObject
    {
        public AudioTypes type;
        public AudioClip clip;
    }

    [System.Serializable]
    public class AudioTrack
    {
        public AudioSourceType sourceType;
        public AudioSource source;
        public AudioObject[] audio;
    }
    #endregion
    #region AudioControls
    public void PlayAudio (AudioTypes _type, AudioSourceType _sourceType)
    {
        AudioSource src = FindAudioSource(_sourceType);
        AudioClip clip = FindAudioClip(_type);
        src.clip = clip;
        src.Play();
    }

    public void StopAudio(AudioTypes _type, AudioSourceType _sourceType)
    {
        AudioSource src = FindAudioSource(_sourceType);
        AudioClip clip = FindAudioClip(_type);
        src.clip = clip;
        src.Stop();
    }

    #endregion

    #region Audio Search
    private AudioSource FindAudioSource (AudioSourceType _sourceType)
    {
        foreach (AudioTrack track in tracks)
        {
            if (track.sourceType == _sourceType)
            {
                return track.source;
            }
        }
        return null;
    }

    private AudioClip FindAudioClip (AudioTypes _type)
    {
        foreach (AudioTrack track in tracks)
        {
            for (int i = 0; i < track.audio.Length; i++)
            {
                if (track.audio[i].type == _type)
                {
                    return track.audio[i].clip;
                }
            }
        }
        return null;
    }
    #endregion


}
