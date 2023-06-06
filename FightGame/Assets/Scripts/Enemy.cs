using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;


    public GameObject player;
    public float moveSpeed;
    public CharacterController characterController;
    // Start is called before the first frame update

    void Start()
    { 
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    
  



    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
        Move();
    }

    void TriggerPunch()
    {
        animator.SetTrigger("PunchCombo");
    }

    void TriggerElbow()
    {
        animator.SetTrigger("ElbowAttack");
    }

    //move function
    public void LookAtPlayer()
    {
        transform.LookAt(player.transform);
    }

   
    public void Move()
    {
        Vector3 targetDirection = player.transform.position - transform.position;

        characterController.Move(targetDirection * moveSpeed * .1f * Time.deltaTime);

    }
}

//nothing below here


