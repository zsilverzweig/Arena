using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private bool _isMoving;
    private Player player;

    public string facing = "right";

    public void Flip()
    {
        facing = (facing == "right") ? "left" : "right";
        this.transform.Rotate(Vector3.up, 180);
    }

    public void MoveLeft()
    {
        if (facing == "right")
        {
            Flip();
            return;
        }

        transform.position += Vector3.left;
    }

    public void MoveRight()
    {
        if (facing == "left")
        {
            Flip();
            return;
        }

        transform.position += Vector3.right;
    }

    public void MoveUp()
    {
        transform.position += Vector3.up;
    }

    public void MoveDown()
    {
        transform.position += Vector3.down;
    }

    public void MoveTowards(GameObject o)
    {
        var xGap = o.transform.position.x - transform.position.x;
        var yGap = o.transform.position.y - transform.position.y;

        if (Mathf.Abs(xGap) > Mathf.Abs(yGap))
        {
            FixX(xGap);
        }
        else
        {
            FixY(yGap);
        }
    }

    public void FixX(float xGap)
    {
        if (xGap > 0)
        {
            MoveRight();
        }
        else if (xGap < 0)
        {
            MoveLeft();
        }
    }

    public void FixY(float yGap)
    {
        if (yGap > 0)
        {
            MoveUp();
        }
        else if (yGap < 0)
        {
            MoveDown();
        }
    }

    public bool IsFacing(GameObject o)
    {
        var xGap = o.transform.position.x - transform.position.x;

        if (facing == "right" && xGap > 0)
        {
            return true;
        }
        else if (facing == "left" && xGap < 0)
        {
            return true;
        }
        else
        {
            return false;

        }
    }
}
