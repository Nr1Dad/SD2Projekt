using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour 
{
    private float min;
    private float max;
    private float speed;
    [SerializeField]
    public GameObject platform1;
    public bool goingRight;
    // Start is called before the first frame update
   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MoveHoz()
    {
        if (platform1.transform.position.x < max)
        {
            platform1.transform.Translate(Time.deltaTime * speed, 0f, 0f);
        } else if (platform1.transform.position.x > min)
            {
                platform1.transform.Translate(-Time.deltaTime * speed, 0f, 0f);
            }
    }
}
