using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Breakplatform : MonoBehaviour
{
    public float fallDelay = 0.1f;
    public float destroyDelay = 2.0f; 

    [SerializeField] private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            StartCoroutine(Fall()); 
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay); 
    }
}
