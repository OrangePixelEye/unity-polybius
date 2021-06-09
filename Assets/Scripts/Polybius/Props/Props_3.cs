using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Props_3 : Props
{
    protected override void Start()
    {
        base.Start();
        move(direction.x / (speed * 4), direction.y / (speed * 4));
    }

    protected override void handleMovement()
    {
        move(-direction.x, -direction.y);
    }
}
