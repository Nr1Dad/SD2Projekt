using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIWater : MonoBehaviour
{
    public GameObject Water;
    public bool interacted;
    // Start is called before the first frame update
    void Start()
    {
        interacted = false;
        Water.gameObject.SetActive(false);
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
            Water.gameObject.SetActive(true);
        }
    }

}
