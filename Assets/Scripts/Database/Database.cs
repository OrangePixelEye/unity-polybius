using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Database
{
	private string result = "";
	bool coroutine_finished = false;
    public IEnumerator sendData(string name, string time, string ending)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
		form.AddField("time", time);
		form.AddField("ending", ending);
		

        using (UnityWebRequest www = UnityWebRequest.Post("https://www.my-server.com/myform", form))
        {
            yield return www.SendWebRequest();

            if (www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
	}

    public string showDatabase() => result;

	public IEnumerator getText() 
	{
        UnityWebRequest www = UnityWebRequest.Get("https://www.my-server.com");
        yield return www.SendWebRequest();
 
        if (www.isHttpError) 
		{
            Debug.Log(www.error);
        }
        else 
		{
            // Show results as text
			result = (www.downloadHandler.text);
        }
    }
}
