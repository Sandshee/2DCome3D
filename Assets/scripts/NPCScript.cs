using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCScript : MonoBehaviour
{

    public enum TalkOptions
    {  
        Interact,Distance
    }

    public string[] messages;
    public GameObject textDisplay;
    public GameObject player;
    public DialogueManager dialogueManager;

    private Text text;
    public TalkOptions talkChoice;
    private NPCDialogue dialogue;

    // Start is called before the first frame update
    void Start()
    {
        text = textDisplay.GetComponent<Text>();
        dialogue = GetComponent<NPCDialogue>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int i = Random.Range(0, messages.Length -1);
        text.text = messages[i];
        TalkToPlayer();
    }

    void TalkToPlayer() {
        if (talkChoice == TalkOptions.Interact) {

            if (dialogueManager.isTalking() && Input.anyKeyDown) {
                if (!dialogueManager.DisplayNextSentence())
                {
                    player.GetComponent<PaperMovement>().unFreezeMotion();
                }
            }

            else if((Vector3.Distance(transform.position, player.transform.position) < 1) && (Input.GetKeyDown(KeyCode.F)) && !dialogueManager.isTalking()) {
                dialogue.TriggerDialogue();
                player.GetComponent<PaperMovement>().freezeMotion();
            }
        }
    }

    void YellAtPlayer()
    {

    }
}
