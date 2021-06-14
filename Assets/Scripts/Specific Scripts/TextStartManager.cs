using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextStartManager : MonoBehaviour
{
	[SerializeField]
    private Text text_reference;

	private bool can_exit = false;
	
	// Start is called before the first frame update
    void Start()
    {
        //change text
		text_reference.text = getText();
		StartCoroutine("wait");
    }

	IEnumerator wait()
	{
		yield return new WaitForSecondsRealtime(1f);
		can_exit = true;
	}

	void Update()
	{
		if(Input.anyKey && can_exit) exitScene();
	}

	void exitScene() => GameManager.Instance.ChangeScene(3);

	private string getText()
	{
		string s = "scene_00_";
		return(
			GameManager.Instance.getText(s + "0") +
			GameManager.Instance.getText(s + "1") + 
			"\n" +
			GameManager.Instance.getText(s + "2") +
			GameManager.Instance.getText(s + "3")
		);
	}
}
