using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Controller : MonoBehaviour
{
    public int enemyType;
    private Rigidbody2D rb;
    private Vector2 startPoint;
    public Vector2 endPoint;
    private Vector2 targetPoint;
    public int speed = 1;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPoint = transform.position;
        targetPoint = endPoint;
    }

    // Start is called before the first frame update
    void Start()
    {

        
        if (enemyType == 1) //sets enemy to basic melee
        {
            Debug.Log("I'm a melee enemy!");           
        }
        else if(enemyType == 2) //sets enemy to basic range
        {
            Debug.Log("I'm a ranged enemy!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 currentPosition = transform.position;               

        if (currentPosition == endPoint)
        {
            targetPoint = startPoint;
            Debug.Log("Changed target to start point");
        }
        else if (currentPosition == startPoint)
        {
            targetPoint = endPoint;
            Debug.Log("Changed target to end point");
        }

        Vector2 targetDirection = (targetPoint - currentPosition).normalized; 
        rb.MovePosition(currentPosition + targetDirection * speed * Time.deltaTime);
    }
}

