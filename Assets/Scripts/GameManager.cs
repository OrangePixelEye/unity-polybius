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

    public float Timer { get => time; }
    public int Sanity 
    { 
        get => sanity; 
        set
        {
            if(value <= 0) lose();
            sanity = value;
            SanityController.Instance.setSanity(sanity);    
        } 
    }

    private Lang game_language;
    private Database database;
    private string current_language = "Portuguese";

    public void ChangeScene(int scene_build_index) => SceneManager.LoadScene(scene_build_index);
    
    private void Start()
    {
        game_language = new Lang(Path.Combine(Application.dataPath, "Scripts/Languages/lang.xml"), current_language);
        database = new Database();
    }

    void FixedUpdate()
    {
        //timer();
    }

    public string getText(string name) => game_language.getString(name); 

    private void lose()
    {
        //to-do
    }

    private void timer() => time += Time.deltaTime;
     
}
