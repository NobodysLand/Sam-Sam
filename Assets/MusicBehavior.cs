using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MusicBehavior : MonoBehaviour
{
    public AudioClip pinkSamSong;
    public AudioClip purpleSamSong;
    private AudioSource songPlayer;

    void Awake ()
    {
        songPlayer = gameObject.GetComponent<AudioSource>();
        Debug.Log(AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Sounds/musica1.mp3"));
        pinkSamSong = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Sounds/musica1.mp3"); 
        purpleSamSong = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Sounds/musica2.wav");
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
