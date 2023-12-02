using UnityEngine;

public class Mover : MonoBehaviour
{
    private bool _isMoving;

    public string facing = "right";
    
    private bool IsEmpty(Vector2 direction)
    {
        // Debug.Log("Checking if empty");
        float checkRadius = 0.2f;
        Vector2 checkPosition = (Vector2)transform.position + direction;

        Collider2D[] results = new Collider2D[10]; // Example size, adjust as needed

        int hits = Physics2D.OverlapCircleNonAlloc(checkPosition, checkRadius, results);
        // Debug.Log("Hits: " + hits);
        for (int i = 0; i < hits; i++)
        {
            // Debug.Log("Hit: " + results[i].gameObject.name);
            if (results[i].gameObject.GetComponentInParent<ICharacter>() != null) return false;
        }

        return true;
    }

    private void Flip()
    {
        facing = (facing == "right") ? "left" : "right";
        this.transform.Rotate(Vector3.up, 180);
    }

    public void Move(Vector3 direction)
    {
        if (NotFacing(direction)) {
            Flip();
            return;
        }
        if (IsEmpty(direction)) transform.position += direction;
    }

    public void MoveTowards(GameObject o)
    {
        var oPos = o.transform.position;
        var myPos = transform.position;
        var xGap = oPos.x - myPos.x;
        var yGap = oPos.y - myPos.y;

        if (Mathf.Abs(xGap) > Mathf.Abs(yGap))
        {
            FixX(xGap);
        }
        else
        {
            FixY(yGap);
        }
    }

    private void FixX(float xGap)
    {
        var fix = xGap > 0 ? Vector3.right : Vector3.left;
        Move(fix);
    }

    private void FixY(float yGap)
    {
        var fix = yGap > 0 ? Vector3.up : Vector3.down;
        Move(fix);
    }

    private bool NotFacing(Vector3 direction)
    {
        return (direction == Vector3.right && facing == "left") ||
               (direction == Vector3.left && facing == "right");
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
