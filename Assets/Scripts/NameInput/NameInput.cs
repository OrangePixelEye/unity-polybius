using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameInput : NumberInput
{
	[SerializeField]
	private InputLetters[] character;

	public string Characters { 
		get 
		{
			char[] name = new char[character.Length];
			for(int i = 0; i < character.Length ; i++)
			{

				name[i] = alpha[character[i].actual_letter];
			}
			return(new string(name));
		}
	}

	private char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

	[System.Serializable]
	struct InputLetters
	{
		public Text character;
		[HideInInspector]
		public int actual_letter;

		public void setCharacter(char letter)
		{
			character.text = letter.ToString();
		}
	}
	
    //private int letter = 0;

    public char getLetter() => alpha[selected_text];

    //public void up() => changeLetter(true);
    //public void down() => changeLetter(false);

	void Start() => total_texts = character.Length;

	protected override void changeText(bool next)
	{
		character[selected_text].actual_letter = newAlphaPosition(next, character[selected_text].actual_letter);
		StartCoroutine(updateName());
	}

	protected IEnumerator updateName()
    {
        yield return new WaitForSecondsRealtime(.25f);
		
		int alpha_n = character[selected_text].actual_letter;
		character[selected_text].character.text = alpha[alpha_n].ToString();
		//character[selected_text].setCharacter(alpha[alpha_n]);
    }

    /*private void changeLetter(bool up)
    {
        letter = newAlphaPosition(up);
		//character[letter].setCharacter();
        //character.text = alpha[letter].ToString();
    }
*/
    private int newAlphaPosition(bool up, int letter)
    {
        int temp_letter = letter;
        if(up)
        {
            temp_letter++;
            if(temp_letter > 25) temp_letter = 0; 
        }
        else 
        {
           temp_letter--;
            if(temp_letter < 0) temp_letter = 25;//25 = Z 
        }
        return temp_letter;
    }

	protected override void enterGame()
    {}

	protected override void changeNumberSelected(bool next)
    {
        character[selected_text].character.color = Color.gray;
        if(next)
        {
            selected_text++;
            if(selected_text > character.Length - 1) selected_text = 0;
        }
        else
        {
            selected_text--;
            if(selected_text < 0) selected_text = character.Length - 1;
        }
        
        StartCoroutine("wait");
        character[selected_text].character.color = Color.white;
    }
}
