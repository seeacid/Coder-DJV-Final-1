using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    private bool isPlayerOnRange ;
    public bool didDialogueStart;
    private int lineIndex ; 
    [SerializeField , TextArea(4,6)]  private string[] dialogueLines;
    private AudioSource audioSource ;
    [SerializeField] private AudioClip npcVoice;
    [SerializeField] private AudioClip playerVoice;
    [SerializeField] private int charsToPlay;
    [SerializeField] private bool isPlayerTalking; 

    [SerializeField] private bool IsHostile ;


    private GameObject dialoguePanel ;
    private GameObject actionMark ;
    private GameObject activePanel;

    private TextMeshProUGUI dialogueText;

    [SerializeField]private float typingTime ;

    public 
    void Update()
    {
        if(isPlayerOnRange && Input.GetKeyDown( KeyCode.E) ) {
            if(!didDialogueStart){
                StartDialogue();
            }else if (dialogueText.text == dialogueLines[lineIndex]){
                NextDialogueLine();
            }else{
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
               
            }
        }

         
    }

    private void Start() {
        dialoguePanel  = GameObject.Find("Canvas");
        activePanel = dialoguePanel.transform.GetChild(0).gameObject;
        dialogueText = activePanel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        audioSource =  GetComponent<AudioSource>();
        audioSource.clip = npcVoice;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            isPlayerOnRange = true;
            actionMark = transform.GetChild(0).gameObject;
            actionMark.SetActive(true);
            
             
            
            
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            isPlayerOnRange = false;
            actionMark = transform.GetChild(0).gameObject;
            actionMark.SetActive(false);
        }
    }

    private void StartDialogue(){
        didDialogueStart = true ;
        activePanel.SetActive(true);
        actionMark.SetActive(false);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine(){
        lineIndex++;
        if(lineIndex < dialogueLines.Length){
            StartCoroutine(ShowLine());
        }else{
            didDialogueStart = false;
            activePanel.SetActive(false);
            actionMark.SetActive(true);
            if(IsHostile){
                SceneManager.LoadScene(2);
            }
        }
    }

    private void SelectAudioClip(){

        if(lineIndex !=0){
            isPlayerTalking = !isPlayerTalking;
        }

        audioSource.clip = isPlayerTalking ? playerVoice : npcVoice ;

       
    }

    private IEnumerator ShowLine(){
        SelectAudioClip();
        dialogueText.text = string.Empty;
        int charIndex = 0;
        foreach(char ch in dialogueLines[lineIndex]){
            dialogueText.text +=ch;
            if(charIndex % charsToPlay == 0 ){
                audioSource.Play();
            }
            charIndex++ ;
            yield return new WaitForSeconds(typingTime);
        }
    }
}
