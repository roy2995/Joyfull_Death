using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class pause_manager : MonoBehaviour
{
    public AudioMixer master_mixer;
    public void setFxvolume(float fxvolume)
    {
        master_mixer.SetFloat("FX_volume",fxvolume);
    }
    public void setMusicvolume(float musicvolume)
    {
        master_mixer.SetFloat("music_volume", musicvolume);
    }

    public void musicvolumen()
    {
        
    }
}
