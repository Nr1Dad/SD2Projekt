using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Controller : MonoBehaviour
{
    public int enemyType;
    private Rigidbody2D rb;
   // private Vector2 startPoint;
   // public Vector2 endPoint;
   // private Vector2 targetPoint;
    public float speed = 1.5f;
   // public int distance;
    private SpriteRenderer meleeEnemyRenderer;
    public int startingPoint;
    public Transform[] movePoints;
    //j i tilfælde af at nogen laver et for loop på et tidspunkt.
    private int j;
    public int enemyDMG=20;

    PlayerHealth playerhealthscript;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        meleeEnemyRenderer = gameObject.GetComponent<SpriteRenderer>();

        /*
        startPoint = transform.position;
        endPoint.y = transform.position.y;
        endPoint.x = transform.position.x + distance;
        targetPoint = endPoint; */ 
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = movePoints[startingPoint].position;

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
        //Movement for the enemy. Enemy moves back and forth always starting left to right.
        /*Vector2 currentPosition = transform.position;
        
        if (currentPosition == endPoint || currentPosition.x > endPoint.x)
        {
            targetPoint = startPoint;
            meleeEnemyRenderer.flipX = false;
            //Debug.Log("Changed target to start point");
        }
        else if (currentPosition == startPoint || currentPosition.x < startPoint.x)
        {
            targetPoint = endPoint;
            meleeEnemyRenderer.flipX = true;
            //Debug.Log("Changed target to end point");
        }

        Vector2 targetDirection = (targetPoint - currentPosition).normalized; 
        rb.MovePosition(currentPosition + targetDirection * speed * Time.deltaTime); */
        if (Vector2.Distance(transform.position, movePoints[j].position) < 0.02f)
        {
            j++;
            if (j == movePoints.Length)
            {
                j = 0;
            }

            if (j == 0)
            {
                meleeEnemyRenderer.flipX = false;
            } else
            {
                meleeEnemyRenderer.flipX = true;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, movePoints[j].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit a player");
            collision.gameObject.GetComponent<PlayerHealth>().Damage(enemyDMG);
        }
    }
}

