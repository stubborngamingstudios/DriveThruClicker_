using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAudioController : MonoBehaviour
{
    AudioSource myCashAudioSource;
    public AudioClip myCashAudioClip;


    public List<float> myKeys = new List<float>();
    public int currentKeyIndex = -1;


    private void OnEnable()
    {
        ScaleUpDo.onCashGaied += PlayClip;
    }
    private void OnDisable()
    {
        ScaleUpDo.onCashGaied -= PlayClip;

    }
    private void Start()
    {
        myCashAudioSource = GetComponent<AudioSource>();
    }


    public void PlayClip()
    {
        if (myCashAudioSource.isPlaying) return;

        currentKeyIndex++;
        if (currentKeyIndex > myKeys.Count - 1) currentKeyIndex = 0;


        HarmonizePitchUp();
        myCashAudioSource.PlayOneShot(myCashAudioClip);
    }

    public void HarmonizePitchUp()
    {
        myCashAudioSource.pitch = myKeys[currentKeyIndex];



    }


}
