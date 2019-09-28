using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audioPlayer;

    private bool isPlaying = true;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        audioPlayer.Play(0);
    }

    public void ToggleMusicStop()
    {
        if (isPlaying){
            audioPlayer.Stop();
        }
        else{
            audioPlayer.Play(0);
        }

        isPlaying = !isPlaying;
    }

    public void ToggleMusicPause()
    {
        if (isPlaying){
            audioPlayer.Pause();
        }
        else{
            audioPlayer.UnPause();
        }

        isPlaying = !isPlaying;
    }
}
