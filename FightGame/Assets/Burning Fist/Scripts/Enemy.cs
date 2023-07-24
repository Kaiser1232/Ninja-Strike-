using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.SceneManagement;



public class Enemy : MonoBehaviour





{


    public Animator animator;
    public bool isMoving;
    public int health = 100;
    [SerializeField][Range(1, 100)] float sightRange = 20, attackRange = 5, attackDelay = 2;

    [SerializeField][Range(0, 20)] int power;
    private Transform playerPos;
    private NavMeshAgent thisEnemy;

    bool isAttacking;
    bool isAttacking2;
    bool isAttacking3;
    bool isAttacking4;
    public bool isWalking;

    void Start()
    {
        playerPos = FindObjectOfType<PlayerHealth>().transform;
        thisEnemy = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distanceFromPlayer = Vector3.Distance(playerPos.position, transform.position);

        if (distanceFromPlayer <= sightRange && distanceFromPlayer > attackRange && !PlayerHealth.isDead)
        {
            StopAllCoroutines();
            isAttacking = false;
            isAttacking2 = false;
            isAttacking3 = false;
            isAttacking4 = false;
            thisEnemy.isStopped = false;

            ChasePlayer();
            

        }


        if (distanceFromPlayer <= attackRange && !isAttacking && !PlayerHealth.isDead)
        {
            thisEnemy.isStopped = true;
            StartCoroutine(AttackPlayer());
        }

        if (PlayerHealth.isDead)
        {
            thisEnemy.isStopped = true;
        }

        if (health<= 0)
        {
            SceneManager.LoadScene("Win");
        }

    }

    public void ChasePlayer()
    {
        
        animator.SetBool("isMoving", true);
        animator.SetTrigger("Move");
        animator.SetBool("isAttacking", false);
        animator.SetBool("isAttacking2", false);
        animator.SetBool("isAttacking3", false);
        animator.SetBool("isAttacking4", false);

        thisEnemy.SetDestination(playerPos.position);
    }

    private IEnumerator AttackPlayer()
    {
        isAttacking = true;

        int attack = Random.Range(1, 4);

        if (attack == 1)
        {
            animator.SetBool("isAttacking", true);
        }
        else if (attack == 2)
        {
            animator.SetBool("isAttacking2", true);
        }
        else if (attack == 3)
        {
            animator.SetBool("isAttacking3", true);
        }
        else if (attack == 4)
        {
            animator.SetBool("isAttacking4", true);
        }

      

        animator.SetBool("isMoving", false);
        animator.ResetTrigger("Move");

        yield return new WaitForSeconds(attackDelay);

    
        if (attack == 1)
        {
            FindObjectOfType<PlayerHealth>().TakeDamage(10);
        }
        else if (attack == 2)
        {
            FindObjectOfType<PlayerHealth>().TakeDamage(10);
        }
        else if (attack == 3)
        {
            FindObjectOfType<PlayerHealth>().TakeDamage(10);
        }
        else if (attack == 4)
        {
            FindObjectOfType<PlayerHealth>().TakeDamage(10);
        }

        isAttacking = false;

     
        animator.SetBool("isAttacking", false);
        animator.SetBool("isAttacking2", false);
        animator.SetBool("isAttacking3", false);
        animator.SetBool("isAttacking4", false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, sightRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
   




    
}