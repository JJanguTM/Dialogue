using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private DatabaseManager databaseManager;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Context;
    [SerializeField] private float CharSpeed = 0.05f;

    private Dialogue[] dialogues;
    private int cdindex; //current dialogue index
    private int ccindex; //current context index
    private string currentText;
    private float typingTimer;
    private int charIndex;
    private bool isTyping;
    private bool ContextFinished;

    private void Start()
    {
        
        dialogues = databaseManager.GetAllDialogues();
        DisplayCurrentDialogue();
    }

    private void Update()
    {
        if (ContextFinished)
            return;

        if (isTyping)
        {
            TypingEffect();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            ShowNextDialogue();
        }
    }

    private void DisplayCurrentDialogue()
    {
        if (cdindex < dialogues.Length)
        {
            Dialogue dialogue = dialogues[cdindex];
            Name.text = dialogue.Name;
            currentText = dialogue.Contexts[ccindex];
            Context.text = "";
            charIndex = 0;
            isTyping = true;
        }
    }

    private void TypingEffect()
    {
        if (charIndex < currentText.Length)
        {
            typingTimer += Time.deltaTime;
            if (typingTimer >= CharSpeed)
            {
                typingTimer = 0f;
                Context.text += currentText[charIndex];
                charIndex++;
            }
        }
        else
        {
            isTyping = false;
        }
    }

    private void ShowNextDialogue()
    {
        if (isTyping)
        {
            Context.text = currentText;
            isTyping = false;
            return;
        }
        ccindex = ccindex + 1; 

        if (ccindex >= dialogues[cdindex].Contexts.Length)
        {
            ccindex = 0;
            cdindex++;
        }

        if (cdindex < dialogues.Length)
        {
            DisplayCurrentDialogue();
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        ContextFinished = true;
        Name.text = "";
        Context.text = "Finish Speaking.";
    }
}