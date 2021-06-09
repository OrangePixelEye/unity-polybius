using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPanel : MonoBehaviour
{
    void OnEnable() => StartCoroutine("wait");

    void OnDisable() => StopCoroutine("wait");
    
    private IEnumerator wait()
    {
        while(true)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            if(Input.GetMouseButton(0))
            {
                this.gameObject.SetActive(false);
                InteractionManager.Instance.textClosed();
            }    
        }
    }
}
