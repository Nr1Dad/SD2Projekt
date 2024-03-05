using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Controller : MonoBehaviour
{
    public int enemyType;

    // Start is called before the first frame update
    void Start()
    {

        
        if (enemyType == 1) //sets enemy to basic melee
        {
            
           
        }
        else if(enemyType == 2) //sets enemy to basic range
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D EnemyToPlayer)
    {
        
    }

    public void OnCollisionEnter2D(Collision2D EnemyToWall)
    {
        if (EnemyToWall.gameObject.tag == "Wall")
        {

        }
    }
}

