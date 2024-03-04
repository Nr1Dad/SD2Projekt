using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MovingPlatform : MonoBehaviour 
{
    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 1.0f;

    int direction = 1;

    private void Update()
    {
        //Finder om vores target point er end eller start
        Vector2 target = currentMovementTarget();

        // Lerp, som får platformen til at bevæge sig på en "linje" lavet udfra plaformens position og target.
        //Lerp = lineær interpolation

        platform.position = Vector2.Lerp(platform.position, target, speed * Time.deltaTime);

        //For at kunne få ændret vores target skal vi først finde distancen mellem plarform og target
        float distance = (target - (Vector2)platform.position).magnitude;

        //Hvis distancen er lille nok så ganger vi direction med -1 for at skifte target.
        if (distance <= 0.1f) 
        {
            direction *= -1; 
        }
    }

    Vector2 currentMovementTarget()
    {
        if (direction == 1)
        {
            return startPoint.position; 
        } 
        else 
        {
            return endPoint.position;
        }
    }


    private void OnDrawGizmos()
    {
        //debug visualization 

        if (platform != null && startPoint!=null && endPoint != null)
        {
            Gizmos.DrawLine(platform.transform.position, startPoint.position);
            Gizmos.DrawLine(platform.transform.position, endPoint.position);
        }
    }


}
