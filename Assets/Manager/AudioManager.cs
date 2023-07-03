using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundEffect
{
    Click,
    Select,
}
public enum BackgroundMusic
{
    TitleScene,
    IntroScene,
}
public class AudioManager : Singleton<AudioManager>
{
    [Header("Sound Effects")]
    public AudioSource[] sfx;
    [Header("Background Music")]
    public AudioSource[] bgm;
    public void PlaySFX(SoundEffect soundEffectenum)
    {
        if((int)soundEffectenum < sfx.Length)
        {
            sfx[(int)soundEffectenum].Play();
        }
    }
    public void PlayBGM(BackgroundMusic backgroundMusicenum)
    {
        if((int)backgroundMusicenum < bgm.Length)
        {
            bgm[(int)backgroundMusicenum].Play();
        }
    }

}
