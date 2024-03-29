using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryInteraction : MonoBehaviour
{
    public GameObject StoryElement1;
    public bool interacted;
    // Start is called before the first frame update
    void Start()
    {
        interacted = false;
        StoryElement1.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interacted = true;
        if (interacted)
        {
            StoryElement1.gameObject.SetActive(true);
            Invoke("TurnOff", 2.0f); 
        }
    }

    private void TurnOff()
    {
        StoryElement1.gameObject.SetActive(false);
        interacted=false;
    }
}
