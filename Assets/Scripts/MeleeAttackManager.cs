using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class MeleeAttackManager : MonoBehaviour
{
    //How much the player should move either downwards or horizontally when melee attack collides with a GameObject that has EnemyHealth script on it
    public float defaultForce = 300;
    //How much the player should move upwards when melee attack collides with a GameObject that has EnemyHealth script on it
    public float upwardsForce = 600;
    //How long the player should move when melee attack collides with a GameObject that has EnemyHealth script on it
    public float movementTime = .1f;
    //Input detection to see if the button to perform a melee attack has been pressed
    private bool meleeAttack;
    //The animator on the meleePrefab
    private Animator meleeAnimator;

    
    //The Animator component on the player
    //private Animator anim;
    //The Character script on the player; this script on my project manages the grounded state, so if you have a different script for that reference that script
    private PlayerMovement playerMovement;

    //Run this method instead of Initialization if you don't have any scripts inheriting from each other
    private void Awake()
    {
        //The Animator component on the player
        //anim = GetComponent<Animator>();
        //The Character script on the player; this script on my project manages the grounded state, so if you have a different script for that reference that script
        playerMovement = GetComponent<PlayerMovement>();
        //The animator on the meleePrefab
        meleeAnimator = GetComponentInChildren<MeleeWeapon>().gameObject.GetComponent<Animator>();
    }


    private void Update()
    {
        //Method that checks to see what keys are being pressed
        CheckInput();
    }

    private void CheckInput()
    {
        //Checks to see if L key is pressed which I define as melee attack; you can of course change this to anything you would want
        if (Input.GetKeyDown(KeyCode.L))
        {
            //Sets the meleeAttack bool to true
            meleeAttack = true;
        }
        else
        {
            //Turns off the meleeAttack bool
            meleeAttack = false;
        }

        // Chacks if player is moving backwards for a backwards attack
        if (meleeAttack && Input.GetAxis("Horizontal") < 0)
        {

            meleeAnimator.SetTrigger("BackwardsMeleeSwipe");
        }

        //chacks if player is moving forwards for a forwards attack
        if (meleeAttack && Input.GetAxis("Horizontal") > 0)
        {

            meleeAnimator.SetTrigger("ForwardMeleeSwipe");
        }


        //Checks to see if meleeAttack is true and pressing up
        if (meleeAttack && Input.GetAxis("Vertical") > 0)
        {
            //Turns on the animation for the player to perform an upward melee attack
            //anim.SetTrigger("UpwardMelee");
            //Turns on the animation on the melee weapon to show the swipe area for the melee attack upwards
            meleeAnimator.SetTrigger("UpwardMeleeSwipe");
        }
        //Checks to see if meleeAttack is true and pressing down while also not grounded
        if (meleeAttack && Input.GetAxis("Vertical") < 0 && !playerMovement.IsGrounded())
        {
            //Turns on the animation for the player to perform a downward melee attack
            //anim.SetTrigger("DownwardMelee");
            //Turns on the animation on the melee weapon to show the swipe area for the melee attack downwards
            meleeAnimator.SetTrigger("DownwardMeleeSwipe");
        }

        //Checks to see if meleeAttack is true and not pressing any direction
        if ((meleeAttack && Input.GetAxis("Horizontal") == 0)
        //OR if melee attack is true and pressing down while grounded
            || meleeAttack && (Input.GetAxis("Vertical") < 0 && playerMovement.IsGrounded()))
        {
            //Turns on the animation for the player to perform a forward melee attack
            //anim.SetTrigger("ForwardMelee");
            //Turns on the animation on the melee weapon to show the swipe area for the melee attack forwards
            if (playerMovement.faceingForward == true)
                { meleeAnimator.SetTrigger("ForwardMeleeSwipe"); }
            if (playerMovement.faceingForward == false)
            { meleeAnimator.SetTrigger("BackwardsMeleeSwipes"); }
        }
       

    }
}
