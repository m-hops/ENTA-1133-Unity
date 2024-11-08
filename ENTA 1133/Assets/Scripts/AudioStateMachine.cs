using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStateMachine : MonoBehaviour
{
    public GameObject SoundtrackOutput;
    public GameObject SFXOutput;
    public AudioClip MainTheme_Loop;
    public AudioClip TRUMAN_Loop;
    public AudioClip UIButton_SFX;

    public void Start()
    {
        SoundtrackStateMachine(0);
    }

    public void SFX_UIButton()
    {
        SFXOutput.GetComponent<AudioSource>().PlayOneShot(UIButton_SFX, 1F);
    }

    public void SoundtrackStateMachine(int track, float pitchAdjust = 1)
    {
        AudioSource currentTrack = SoundtrackOutput.GetComponent<AudioSource>();
        currentTrack.Stop();

        switch (track)
        {
            //MAIN THEME//
            case 0:
                currentTrack.pitch = pitchAdjust;
                currentTrack.clip = MainTheme_Loop;
                currentTrack.Play();
                break;
            //THE TRUMAN THEME//
            case 1:
                currentTrack.pitch = pitchAdjust;
                currentTrack.clip = TRUMAN_Loop;
                currentTrack.Play();
                break;
            default:
                break;
        }

    }

}
