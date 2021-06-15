using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
	{
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    private int sanity = 10;
    private float time = 0;

	private bool end = false;

    public float Timer { get => time; }
    public int Sanity 
    { 
        get => sanity; 
        set
        {
            sanity = value;
            SanityController.Instance.setSanity(sanity);   
			if(sanity <= 0) lose(); 
        } 
    }

	public int Lose 
	{ 
		get 
		{
			if(positive_ending) return 0;
			return 1;
		} 
	}

	private bool positive_ending = false;
    private Lang game_language;
    public Database database;
    private string current_language = "Portuguese";

	public string Language 
	{ 
		get => current_language; 
		set 
		{
			current_language = value;
			game_language = new Lang(Path.Combine(Application.dataPath, "Scripts/Languages/lang.xml"), current_language);
		}
	}


    public void ChangeScene(int scene_build_index) => SceneManager.LoadScene(scene_build_index);
    
    private void Start()
    {
        game_language = new Lang(Path.Combine(Application.dataPath, "Scripts/Languages/lang.xml"), current_language);
        database = new Database();
    }

    void FixedUpdate()
    {
        //if(!ending)timer();
    }

	public void sendToDatabase(string name, string time, int ending) => StartCoroutine(database.sendData(name, time, ending));

	public string getDatabaseData() => database.Result;

    public string getText(string name) => game_language.getString(name); 

    private void lose()
	{
		positive_ending = false;	
		end = true;
		ChangeScene(4);
	}
    
	private void win()
	{
		positive_ending = true;
		end = true;
		ChangeScene(4);
	} 

    private void timer() => time += Time.deltaTime;
}
