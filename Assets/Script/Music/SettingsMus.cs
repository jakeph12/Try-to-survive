using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class SettingsMus : MonoBehaviour
{
    public EventInstance MainTheme;

    public void Start()
    {
        MainTheme = FMODUnity.RuntimeManager.CreateInstance("event:/song main2");
        MainTheme.start();
        MainTheme.getPlaybackState(out PLAYBACK_STATE pl);
        StartCoroutine(ss());
        
    }
    IEnumerator ss()
    {
        yield return new WaitForSeconds(10);
        MainTheme.setPaused(true);
        yield return new WaitForSeconds(10);
        MainTheme.setPaused(false);
    }
}
