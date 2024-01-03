using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : Singleton<AudioManager>
{ /*
    private AudioSource bgm_player;
    private AudioSource sfx_player;

    public Slider BGMSlider;
    public Slider SFXSlider;

    public AudioClip[] audio_clips;

    void Awake()
    {
        bgm_player = GameObject.Find("BGMPlayer").GetComponent<AudioSource>();
        sfx_player = GameObject.Find("SFXPlayer").GetComponent<AudioSource>();

        BGMSlider = BGMSlider.GetComponent<Slider>();
        SFXSlider = SFXSlider.GetComponent<Slider>();

        BGMSlider.onValueChanged.AddListener(ChangeBgmSound);
        SFXSlider.onValueChanged.AddListener(ChangeSfxSound);
    }

    void ChangeBgmSound(float value)
    {
        bgm_player.volume = value;
    }

    void ChangeSfxSound(float value)
    {
        sfx_player.volume = value;
    }

    public void PlaySound(int i)
    {
        sfx_player.clip = audio_clips[i];
        sfx_player.Play();
    } */
}
