using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class NumberInputManager : MonoBehaviour
{
    private static NumberInputManager instance;

    [SerializeField]
    private Codes[] codes;

    [System.Serializable]
    struct Codes{
        public int[] code;
    }

    public static NumberInputManager Instance
	{
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<NumberInputManager>();
            }
            return instance;
        }
    }

    public void useCode(int[] code)
    {
        for(int i = 0; i < codes.Length; i++)
        {
            if(Enumerable.SequenceEqual(codes[i].code, code))
            {
                //do stuff
            }
        }
    }
}