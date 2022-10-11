using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]private AudioSource sfxAudioSource , MusicAudioSource ;

    public static GameManager Instance {get ; private set ; }
    
    private void Awake() {
        if(Instance !=null && Instance !=this){
            Destroy(this);
        }else{
            Instance = this ; 
            DontDestroyOnLoad(this);
        }
    }


    public void playSfx(AudioClip audioClip){
        sfxAudioSource.PlayOneShot(audioClip);
    }

    public void playMusic (AudioClip audioClip){
        MusicAudioSource.clip = audioClip;
        MusicAudioSource.Play() ;
    }
}
