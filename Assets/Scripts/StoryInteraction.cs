using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryInteraction : MonoBehaviour
{
    public GameObject StoryElement;
    public bool interacted;
    // Start is called before the first frame update
    void Start()
    {
        interacted = false;
        StoryElement.gameObject.SetActive(false);
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
            StoryElement.gameObject.SetActive(true);
            Invoke("TurnOff", 5.0f); 
        }
    }

    private void TurnOff()
    {
        StoryElement.gameObject.SetActive(false);
        interacted=false;
    }
}
