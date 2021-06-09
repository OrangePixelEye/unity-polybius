using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IInput
{
    [SerializeField]
    private GameObject bullet = null;
    bool shooting = false;
    int life = 3;

    void Update()
    {
        handleInput();
    }

    public void handleInput()
    {
        float input = Input.GetAxis("Fire1");
        if(input > 0)
        {
            useInput();
        }
    }

    public void useInput()
    {
        if(!shooting) StartCoroutine(shoot());
    }

    private IEnumerator shoot()
    {
        shooting = true;
        GameObject tmp = (GameObject)Instantiate(bullet, this.gameObject.transform.position, Quaternion.identity, gameObject.transform);
        yield return new WaitForSeconds(0.3f);
        shooting = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag != "Bullet")
        {
            PolybiusManager.Instance.setLive();
        }
    }
}
