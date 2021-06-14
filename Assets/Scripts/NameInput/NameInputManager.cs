using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameInputManager : MonoBehaviour, IMove
{
	private static NameInputManager instance;

    public NameInput letters;

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

    public string getName()
    {
		return letters.Characters;
    }

    public void handleMovement()
    {
        throw new System.NotImplementedException();
    }

    public void move(float x = 0, float y = 0)
    {
        throw new System.NotImplementedException();
    }

	public void sendToDatabase()
	{
		FinalSceneManager temp = new FinalSceneManager();
		string time = temp.convertTimeToNormal(GameManager.Instance.Timer);
		GameManager.Instance.sendToDatabase(getName(), time, GameManager.Instance.Lose.ToString());
	}
}
