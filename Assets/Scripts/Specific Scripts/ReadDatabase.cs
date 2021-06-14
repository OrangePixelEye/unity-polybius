using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadDatabase : MonoBehaviour
{
	[SerializeField]
	private Text text;

    // Start is called before the first frame update
    void Start()
    {
		//read database
		text.text = (GameManager.Instance.getDatabaseData() + 
					"\n Your time : " + GameManager.Instance.Timer.ToString());
		//put you in the end
    }
}
