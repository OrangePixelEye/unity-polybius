using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityController : MonoBehaviour
{
    private static SanityController instance;
    
    [SerializeField]
    private Text sanity_text;
    public static SanityController Instance
	{
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<SanityController>();
            }
            return instance;
        }
    }

    public void setSanity(int sanity) => sanity_text.text = GameManager.Instance.Sanity.ToString();
    
}
