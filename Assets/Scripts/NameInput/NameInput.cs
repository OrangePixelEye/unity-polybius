using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameInput : MonoBehaviour
{
    public NameInputIndividualLetter[] letters;

    public void getName()
    {
        char[] name = new char[letters.Length];
        for(int i = 0; i < letters.Length ; i++)
        {
            name[i] = letters[i].getLetter();
        }
        print(new string(name));
    }
}
