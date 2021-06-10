using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500 ,0));   
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
