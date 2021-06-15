using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NameInputManager : MonoBehaviour
{
	private static NameInputManager instance;

    public NameInput letters;

	[SerializeField]
	private GameObject readDatabase;
	[SerializeField]
	private GameObject input_name_panel;

	public static NameInputManager Instance
	{
		get
		{
 			if(instance == null)
			{
				instance = FindObjectOfType<NameInputManager>();
			}
			return instance;
		}
	}

	void Start()
	{
		GameManager.Instance.database.FormSent += sent;
		GameManager.Instance.database.ReceivedInfo += receive;
	}

	void sent(object sender, EventArgs e)
	{
		StartCoroutine(GameManager.Instance.database.getText());
	}

	void receive(object sender, EventArgs e)
	{
		readDatabase.SetActive(true);
		input_name_panel.SetActive(false);
	}

    public string getName()
    {
		return letters.Characters;
    }

	public void sendToDatabase()
	{
		FinalSceneManager temp = new FinalSceneManager();
		string time = temp.convertTimeToNormal(GameManager.Instance.Timer);
		GameManager.Instance.sendToDatabase(getName(), time, GameManager.Instance.Lose);
	}
}
