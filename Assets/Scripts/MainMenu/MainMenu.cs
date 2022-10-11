using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro ;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]private AudioClip music;
    [SerializeField] private TextMeshProUGUI pressText;
    // Start is called before the first frame update
    private bool toggleText;
    void Start()
    {
        GameManager.Instance.playMusic(music);
        InvokeRepeating("ToggleText" , 0f, 0.3f);

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey){
            SceneManager.LoadScene(1);
        }
    }

    private void ToggleText(){
        toggleText = !toggleText;
        if(toggleText){
            pressText.text = "";
        }else{
            pressText.text = "[ Pulsa una tecla para comenzar ]";
        }
    }
}
