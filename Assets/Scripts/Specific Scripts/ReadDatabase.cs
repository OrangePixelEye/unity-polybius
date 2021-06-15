using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ReadDatabase : MonoBehaviour
{
	[SerializeField]
	private Text text;

	

    // Start is called before the first frame update
    public void OnEnable()
    {
		//read database
		text.text = (parse_json(GameManager.Instance.getDatabaseData()) + 
					"\n Your time : " + GameManager.Instance.Timer.ToString());
		//put you in the end
    }

	public string parse_json(string json)
	{
		Players stuff = JsonUtility.FromJson<Players>(json);
		//nome + tempo + final
		string names = "";

		for (int i = 0; i < stuff.objetos.Length; i++)
		{
			names = names + "\n name: " + stuff.objetos[i].name + " time: " + stuff.objetos[i].time + "  end: " + stuff.objetos[i].final;
		}
		return names;
	}
}

class Players
{
	[System.Serializable]
    public struct LinhaPontuacao
    {
        public string name;
        public string time;
		public string final;
    }

    public LinhaPontuacao[] objetos;
}