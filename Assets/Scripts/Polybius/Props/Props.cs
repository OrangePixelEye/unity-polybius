using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Props : MonoBehaviour
{
    protected Vector2 direction;
    protected float speed = 0.01f;

    protected float totalTime = 0f;
    protected float timeRemaining = 0f;

    protected enum State
    {
        NORMAL,
        BACK,
        WAIT
    }

    protected State actual_state = State.NORMAL;

    protected virtual void Start()
    {
        direction = new Vector2(Random.Range(-1.1f, 1.1f), Random.Range(-1.1f, 1.1f) );
        float mathToTimer = 1;//to-do
        totalTime = Random.Range(3f * mathToTimer, 5f * mathToTimer);
        //direction = new Vector2(0.1f, .1f );
        timeRemaining = totalTime;
    }

    void Update()
    {
        handleMovement();
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    protected virtual void handleMovement()
    {
        move(direction.x, direction.y);
    }

    protected virtual void move(float x = 0, float y = 0)
    {
        float x_pos = gameObject.transform.localPosition.x;
        float y_pos = gameObject.transform.localPosition.y;
        gameObject.transform.localPosition = new Vector3(x_pos + (x * speed), y_pos + (y * speed), 0);
    }
    
    protected void rotateObject()
    {
        
    }

    protected void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Bullet")
            DestroyThis();
    }

    protected virtual void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
