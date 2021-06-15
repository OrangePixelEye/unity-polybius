using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Database
{
	public event EventHandler FormSent;
	public event EventHandler ReceivedInfo;
	private string result = "";
	public string Result { get=> result; }
    public IEnumerator sendData(string name, string time, int ending)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
		form.AddField("time", time);
		form.AddField("final", ending);
		

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/polybius/inserir.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                FormSent?.Invoke(this, EventArgs.Empty);
            }
        }
	}

    //public string showDatabase() => result;

	public IEnumerator getText() 
	{
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/polybius/lista_jogadores.php");
        yield return www.SendWebRequest();
 
        if (www.isHttpError) 
		{
            Debug.Log(www.error);
        }
        else 
		{
			
            // Show results as text
			result = (www.downloadHandler.text);
			ReceivedInfo?.Invoke(this, EventArgs.Empty);
        }
    }
}
