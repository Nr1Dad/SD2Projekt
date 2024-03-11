using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //Determines if this GameObject should receive damage or not
    [SerializeField]
    private bool damageable = true;
    //The total number of health points the GameObject should have
    [SerializeField]
    private int healthAmount = 100;
    //The max amount of time after receiving damage that the player can no longer receive damage; this is to help prevent the same melee attack dealing damage multiple times
    [SerializeField]
    private float invulnerabilityTime = .2f;
    //Bool that manages if the player can receive more damage
    private bool hit;
    //The current amount after receiving damage the player has
    private int currentHealth;

    private void Start() {
        //Sets the player to the max amount of health when the scene loads
        currentHealth = healthAmount;
    }

    public void Damage(int amount) {
        //First checks to see if the player is currently in an invulnerable state; if not it runs the following logic.
        if (damageable && !hit && currentHealth > 0) {
            //First sets hit to true
            hit = true;
            //Reduces currentHealthPoints by the amount value that was set by whatever script called this method, for this tutorial in the OnTriggerEnter2D() method
            currentHealth -= amount;
            //If currentHealthPoints is below zero, player is dead, and then we handle all the logic to manage the dead state
            if (currentHealth <= 0) {
                //Caps currentHealth to 0 for cleaner code
                currentHealth = 0;
                //Removes GameObject from the scene; this should probably play a dying animation in a method that would handle all the other death logic, but for the test it just disables it from the scene
                //gameObject.SetActive(false);
            }
            else {
                //Coroutine that runs to allow the player to receive damage again
                StartCoroutine(TurnOffHit());
            }
        } 
    } 

    //Coroutine that runs to allow the player to receive damage again
    private IEnumerator TurnOffHit() {
        //Wait in the amount of invulnerabilityTime, which by default is .2 seconds
        yield return new WaitForSeconds(invulnerabilityTime);
        //Turn off the hit bool so the player can receive damage again
        hit = false;
    }
}
