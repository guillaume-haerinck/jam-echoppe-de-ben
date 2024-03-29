﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour 
{
    public Text nameText;
    public Text dialogText;

	private Queue<string> sentences;

	void Start () 
	{
		sentences = new Queue<string>();
	}
	
	public void StartDialog(Dialog dialog)
	{
        nameText.text = dialog.name;

		sentences.Clear();

		foreach (string sentence in dialog.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}
	
	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
            //SceneManager.LoadScene("Echoppe");
			return;
		}

		string sentence = sentences.Dequeue();
        dialogText.text = sentence;
	}

	void EndDialogue()
	{
		Debug.Log("End of conversation.");
        SceneManager.LoadScene("Echoppe");
    }
}
