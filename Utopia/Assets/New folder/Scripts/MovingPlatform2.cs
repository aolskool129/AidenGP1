using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform2 : MonoBehaviour
{
    public Transform[] platformposition = new Transform[2];
    int direction = 1;
    public float speed;
    Vector2 Target;
    // Update is called once per frame
    void Update()
    {
        Target = currentMovementTarget();
        //need to set our distance and change direction
        float distance = (Target - (Vector2)platformposition[0].position).magnitude;

        if(distance <= .5f)
        {
            direction *= -1;
        }
    }

    private void FixedUpdate()
    {
        platformposition[0].position = Vector2.Lerp(platformposition[0].position, Target, speed * Time.deltaTime);
    }
    Vector2 currentMovementTarget()
    {
        if(direction == 1)
        {
            return platformposition[1].position;
        }
        else
        {
            return platformposition[2].position;
        }
    }
    private void OnDrawGizmos()
    {
        //check to see if our references are null if they are not draw lines
        if(platformposition[0] != null && platformposition[1] != null && platformposition[2] != null)
        {
            Gizmos.DrawLine(platformposition[0].transform.position, platformposition[1].transform.position);
            Gizmos.DrawLine(platformposition[0].transform.position, platformposition[2].transform.position);
        }
    }
}
