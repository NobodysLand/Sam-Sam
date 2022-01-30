using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBehavior : MonoBehaviour
{
    public AudioClip pinkSamSong;
    public AudioClip purpleSamSong;
    private AudioSource songPlayer;

    void Awake ()
    {
        string path = Application.dataPath;
        Debug.Log(path + "/Sounds/musica1");
        songPlayer = gameObject.GetComponent<AudioSource>();
    }

    public void SwitchSongs (bool world)
    {
        float songTime = songPlayer.time;
        Debug.Log("Tempo: " + songTime);
        if (!world)
        {
            songPlayer.clip = pinkSamSong;
            songPlayer.time = songTime;
            songPlayer.Play();
        }
        else
        {
            songPlayer.clip = purpleSamSong;
            songPlayer.time = songTime;
            songPlayer.Play();
        }
    }
     
    
}
