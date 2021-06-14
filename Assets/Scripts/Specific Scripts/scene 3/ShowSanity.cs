using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSanity : MonoBehaviour
{
    [SerializeField]
    private GameObject sanity;

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(up());
    }

    private IEnumerator up()
    {
        bool up = true;
        RectTransform rect = sanity.GetComponent<RectTransform>();
        float x = rect.anchoredPosition.x;
        float y = rect.anchoredPosition.y;
        float z = 0;

        while(up)
        {
            yield return new WaitForSecondsRealtime(Time.deltaTime);
            y -= 0.2f;
            rect.anchoredPosition = new Vector3(x, y, z);
            if(y <= -40f)
            {
                Destroy(gameObject);
            } 
        } 
    }
}
