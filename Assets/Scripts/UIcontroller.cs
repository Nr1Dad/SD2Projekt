using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIcontroller : MonoBehaviour
{
    public TMP_Text healthBarTemp;
    PlayerHealth playerHealth;
    private int playerCurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = GameObject.Find("Player").GetComponent<PlayerHealth>().currentHealth;
        healthBarTemp.SetText(playerCurrentHealth.ToString() + "HP");
    }

    // Update is called once per frame
    void Update()
    {
        //This should be called when player takes damage rather than every frame
        playerCurrentHealth = GameObject.Find("Player").GetComponent<PlayerHealth>().currentHealth;
        healthBarTemp.SetText(playerCurrentHealth.ToString() + " HP");
    }
}
