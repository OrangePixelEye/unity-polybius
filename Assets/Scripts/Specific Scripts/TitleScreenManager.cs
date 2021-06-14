using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenManager : MonoBehaviour
{
	//jogar
	public void play()
	{
		GameManager.Instance.ChangeScene(2);
	}
	
	//mudar lingua
	public void changeLanguage(bool english)
	{
		if(english) GameManager.Instance.Language = "English";
		else GameManager.Instance.Language = "Portuguese";
	}
	
	//sair
	public void exit()
	{
		Application.Quit(0);
	}
}
