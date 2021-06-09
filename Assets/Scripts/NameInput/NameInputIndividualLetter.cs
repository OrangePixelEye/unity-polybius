using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameInputIndividualLetter : MonoBehaviour
{
    [SerializeField]
    private Text character;

    [SerializeField]
    private Button up_button;

    [SerializeField]
    private Button down_button;
    private char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    private int letter = 0;

    public char getLetter() => alpha[letter];

    public void up() => changeLetter(true);
    public void down() => changeLetter(false);

    private void changeLetter(bool up)
    {
        letter = newAlphaPosition(up);
        character.text = alpha[letter].ToString();
    }

    private int newAlphaPosition(bool up)
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
}
