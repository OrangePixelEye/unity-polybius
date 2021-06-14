using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalSceneManager : MonoBehaviour
{
	[SerializeField]
	private GameObject panel;
	[SerializeField]
	private GameObject input_panel;

	[SerializeField]
	private Text timer_text;

	[SerializeField]
	private Reports[] reports = new Reports[4];

	[System.Serializable]
	struct Reports
	{
		public Sprite image;
		public string languages;
		public bool positive_ending;
	}

	[SerializeField]
	private Image image_language;

    // Start is called before the first frame update
	void tart()
    {
		//change picture to corresponding language
		changeImage();
		//change the text in the timer
		changeText();
	}

    private void changeImage()
	{
		foreach(Reports report in reports)
		{
			if(report.languages.Equals(GameManager.Instance.Language) && report.positive_ending == GameManager.Instance.Lose)
			{
				image_language.sprite = report.image;
				return;
			}
		}
	}

	private void changeText() => timer_text.text = convertTimeToNormal(GameManager.Instance.Timer);

	public string convertTimeToNormal(float time)
	{
		TimeSpan t = TimeSpan.FromSeconds(time);

		string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s", 
						t.Hours, 
						t.Minutes, 
						t.Seconds);
		return answer;
	}

	void Update()
	{
		if(Input.anyKey)
		{
			panel.SetActive(false);
			input_panel.SetActive(true);
			Destroy(this);
		}
	}
}
