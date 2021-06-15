using System.Collections;
using System;
using UnityEngine;

public class Spawn : MonoBehaviour, IMove
{
    [SerializeField]
    private GameObject[] objectsToSpawn;

    [SerializeField]
    private string[] code;
    private char[] code_char;
    private int current_letter = 0;
    Props_Text p = null;
    bool has_text = false;

    private int difficult = 0;

    public int Difficult{get => difficult; set=> difficult = value;}

    void OnEnable()
    {
        code_char = code[difficult].ToCharArray();
        //Props_Text.Instance.LetterNotDestroyed += letterNotDestroyed;
        //Props_Text.Instance.LetterDestroyed += letterDestroyed;
        StartCoroutine(spawnObjects());
    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
    }

    public void handleMovement()
    {
        float x = Input.GetAxis("Vertical");
        move(x);
    }

    public void move(float x = 0, float y = 0)
    {
        //gameObject.transform.rotation = new Vector3(0, 0, gameObject.transform.rotation.z + x);
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.z += x;
        transform.rotation = Quaternion.Euler(rotationVector);
    }

    private IEnumerator spawnObjects()
    {
		float temp_difficult = difficult;
		if(PolybiusManager.Instance.First) temp_difficult *= 12;
        while(true)
        {
            yield return new WaitForSecondsRealtime(0.9f - (temp_difficult * 0.3f));
            spawn();
        }
    }

    private void spawn()
    {
        GameObject tmp = (GameObject)Instantiate(objectsToSpawn[chooseProp()], this.gameObject.transform.position, Quaternion.identity, gameObject.transform);
        if(tmp.GetComponent<Props_Text>() != null)
        {
            if(!has_text)
            {
                has_text = true;
                p = tmp.GetComponent<Props_Text>();
                p.Initialize(code_char[current_letter]);
                p.LetterDestroyed += letterDestroyed;
                p.LetterNotDestroyed += letterNotDestroyed;
            }
            else Destroy(tmp);   
        }       
    }

    private int chooseProp() => UnityEngine.Random.Range(0, objectsToSpawn.Length);

    protected void letterNotDestroyed(object sender, EventArgs e)
	{
        has_text = false;
	}

    protected void letterDestroyed(object sender, EventArgs e)
	{
        current_letter++;
        has_text = false;
        if(current_letter >= code_char.Length - 1)
        {
            VictoryEvent();
        }
	}

    private void VictoryEvent()
    {
        current_letter = 0;
    }
}
