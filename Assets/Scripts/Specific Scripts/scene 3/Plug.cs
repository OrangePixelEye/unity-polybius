using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plug : Interactable
{
    private bool follow_mouse = false;
    new void OnMouseUp()
    {
        follow_mouse = !follow_mouse;
    }

    void FixedUpdate()
    {
        if(follow_mouse)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            gameObject.transform.position = position;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.gameObject.name == "socket" && !follow_mouse)
        {
            GameManager.Instance.ChangeScene(3);
        }
    }
}
