using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   
    [SerializeField]private AudioClip music;
    // Start is called before the first frame update
    private bool toggleText;
    void Start()
    {
        GameManager.Instance.playMusic(music);

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey){
            Application.Quit();
        }
    }

    
}
