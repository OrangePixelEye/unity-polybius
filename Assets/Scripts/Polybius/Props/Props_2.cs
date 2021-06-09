using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Props_2 : Props
{
    // Update is called once per frame
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

    private void changeState()
    {
        switch(actual_state)
        {
            case State.NORMAL:
                actual_state = State.WAIT;
                break;
            case State.WAIT:
                actual_state = State.NORMAL;
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
        }
    } 
}
