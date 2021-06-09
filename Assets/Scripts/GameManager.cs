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

    private Lang game_language;
    private string current_language = "Portuguese";

    public void ChangeScene(int scene_build_index)
    {
        SceneManager.LoadScene(scene_build_index);
    }

    private void Start()
    {
        game_language = new Lang(Path.Combine(Application.dataPath, "Scripts/Languages/lang.xml"), current_language);
    }

    public string getText(string name) => game_language.getString(name); 
     
}
