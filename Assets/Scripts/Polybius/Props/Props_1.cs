using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Props_1 : Props
{
    void Update()
    {
        if(timeRemaining <= 0)
        {
            changeState();
            timeRemaining = totalTime;
        }
        timeRemaining -= Time.deltaTime;
        runState();
    }

    private void moveNormal() => move(direction.x, direction.y);
    private void wait() => rotateObject();
    private void moveBack() => move(-direction.x, -direction.y);

    private void changeState()
    {
        switch(actual_state)
        {
            case State.NORMAL:
                actual_state = State.WAIT;
                break;
            case State.WAIT:
                actual_state = State.BACK;
                break;
            case State.BACK:
                Destroy(gameObject);
                break;
        }
    }

    private void runState()
    {
        switch(actual_state)
        {
            case State.NORMAL:
                moveNormal();
                break;
            case State.WAIT:
                wait();
                break;
            case State.BACK:
                moveBack();
                break;
        }
    }
}
