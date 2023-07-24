using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public float moveSpeed, runSpeed;
    public float xInput;
    public float zInput;
    public float rotationSpeed;
    public bool isKicking;
    public bool isWalking;
    bool isPunching;
    bool isCrossPunching;
    bool isKneeing;
    bool isBlocking;
    bool isLeftBlocking;
    bool isRightBlocking;
    public Animator animator;





    // Update is called once per frame


    public void Move()

    {
        xInput =
            Input.GetAxis("Horizontal");
        zInput =
            Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xInput, 0, zInput);
        characterController.Move(transform.rotation * moveDirection * moveSpeed * Time.deltaTime);
    }




    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("isMovingForward", true);
            //animator.SetTrigger("Walking");

            isWalking = true;
            isPunching = false;
            isKicking = false;
            isCrossPunching = false;
            animator.SetBool("isMovingBack", false);
            animator.SetBool("isMovingLeft", false);
            animator.SetBool("isMovingRight", false);
            Move();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("isMovingLeft", true);
            //animator.SetTrigger("Walking");

            isWalking = true;
            isPunching = false;
            isKicking = false;
            isCrossPunching = false;
            animator.SetBool("isMovingForward", false);
            animator.SetBool("isMovingBack", false);
            animator.SetBool("isMovingRight", false);
            Move();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("isMovingRight", true);
            //animator.SetTrigger("Walking");

            isWalking = true;
            isPunching = false;
            isKicking = false;
            isCrossPunching = false;
            animator.SetBool("sMovingForward", false);
            animator.SetBool("isMovingBack", false);
            animator.SetBool("isMovingLeft", false);
            Move();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("isMovingBack", true);
            //animator.SetTrigger("Walking");

            isWalking = true;
            isPunching = false;
            isKicking = false;
            isCrossPunching = false;
            animator.SetBool("isMovingForward", false);
            animator.SetBool("isMovingLeft", false);
            animator.SetBool("isMovingRight", false);
            Move();
        }

        if (isWalking)
        {
            Move();
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            isWalking = false;
            isPunching = false;
            isKicking = false;
            isCrossPunching = false;
            animator.SetBool("isMovingForward", false);
            animator.SetBool("isMovingLeft", false);
            animator.SetBool("isMovingRight", false);
            animator.SetBool("isMovingBack", false);
        }

        if (isPunching) { horizontalInput = 0; verticalInput = 0; }
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.position = new(transform.position.x, 1.27f, transform.position.z);

        if (isPunching)
        {
            animator.SetBool("Kicking", false);
            isKicking = false;
            isWalking = false;
            isKneeing = false;
            isCrossPunching = false;
            animator.SetBool("isMovingForward", false);
        }

        if (isKicking)
        {
            animator.SetBool("Punching", false);
            isPunching = false;
            isWalking = false;
            isCrossPunching = false;
            isKneeing = false;
            animator.SetBool("isMovingForward", false);

        }
        if (isKneeing)
        {
            animator.SetBool("Kneeing", false);
            isPunching = false;
            isWalking = false;
            isCrossPunching = false;
            isKicking = false;
            animator.SetBool("isMovingForward", false);

        }
        if (isBlocking)
        {
            animator.SetBool("Blocking", false);
            isPunching = false;
            isWalking = false;
            isCrossPunching = false;
            isKicking = false;
            isKneeing = false;
            isLeftBlocking = false;
            isRightBlocking = false;
            animator.SetBool("isMovingForward", false);

        }
        if (isLeftBlocking)
        {
            animator.SetBool("LeftBlocking", false);
            isPunching = false;
            isWalking = false;
            isCrossPunching = false;
            isKicking = false;
            isKneeing = false;
            isBlocking = false;
            isRightBlocking = false;


            animator.SetBool("isMovingForward", false);

        }
        if (isRightBlocking)
        {
            animator.SetBool("RightBlocking", false);
            isPunching = false;
            isWalking = false;
            isCrossPunching = false;
            isKicking = false;
            isKneeing = false;
            isBlocking = false;
            isLeftBlocking = false;


            animator.SetBool("isMovingForward", false);

        }

        if (Input.GetKeyDown(KeyCode.Q) && !isPunching)
        {
            StartCoroutine(Punch());
        }

        if (Input.GetKeyDown(KeyCode.E) && !isCrossPunching)
        {
            StartCoroutine(CrossPunch());
        }
        if (Input.GetKey(KeyCode.Alpha1) && !isBlocking)
        {
            StartCoroutine(Blocking());
        }
        if (Input.GetKey(KeyCode.R) && !isKneeing)
        {
            StartCoroutine(Kneeing());
        }
        if (Input.GetKey(KeyCode.Alpha2) && !isLeftBlocking)
        {
            StartCoroutine(LeftBlocking());
        }
        if (Input.GetKey(KeyCode.Alpha3) && !isRightBlocking)
        {
            StartCoroutine(RightBlocking());
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isKicking)
        {
            StartCoroutine(Kicking());
        }








        //float waitTime = Random.Range(0.5f, 2.5f);

        //yield return new WaitForSeconds(waitTime);

        //if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        //{
        //    if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        //    {
        //        isWalking = false;
        //        animator.SetBool("isWalking", false);
        //    }

        //}

        //if (isWalking)
        //{
        //    /// Running Disabled(to re - enable, you need to select all of the green text, and press 'Cmd + /')
        //    //animator.SetTrigger("Run");
        //}
        //else
        //{
        //    animator.SetBool("R", false);
        //    isKicking = false;
        //}
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    animator.SetBool("Kicking", true);
        //    isKicking = true;

        //}

        //if (Input.GetKeyUp(KeyCode.LeftShift))
        //{
        //    animator.SetBool("Kicking", false);
        //    isKicking = false;
        //}


    }

    [SerializeField][Range(1, 10)] float attackRange = 3;

    IEnumerator Punch()
    {
        float distanceFromEnemy = Vector3.Distance(FindObjectOfType<Enemy>().transform.position, transform.position);

        if (distanceFromEnemy <= attackRange)
        {
            FindObjectOfType<Enemy>().health -= 5;
        }
         

        animator.SetTrigger("Punch");
        animator.SetBool("isPunching", true);
        yield return new WaitForSeconds(.5f);
        isPunching = false;
        animator.SetBool("isPunching", false);

    }

    IEnumerator CrossPunch()
    {
        float distanceFromEnemy = Vector3.Distance(FindObjectOfType<Enemy>().transform.position, transform.position);

        if (distanceFromEnemy <= attackRange)
        {
            FindObjectOfType<Enemy>().health -= 5;
        }

        isCrossPunching = true;
        animator.SetTrigger("CrossPunch");
        animator.SetBool("isCrossPunching", true);
        yield return new WaitForSeconds(2f);
        isCrossPunching = false;
        animator.SetBool("isCrossPunching", false);

    }
    IEnumerator Kicking()
    {
        float distanceFromEnemy = Vector3.Distance(FindObjectOfType<Enemy>().transform.position, transform.position);

        if (distanceFromEnemy <= attackRange)
        {
            FindObjectOfType<Enemy>().health -= 5;
        }

        isKicking = true;
        animator.SetTrigger("Kicking");
        animator.SetBool("isKicking", true);
        yield return new WaitForSeconds(2.2f);
        isKicking = false;
        animator.SetBool("isKicking", false);

    }
    IEnumerator Kneeing()
    {
        float distanceFromEnemy = Vector3.Distance(FindObjectOfType<Enemy>().transform.position, transform.position);

        if (distanceFromEnemy <= attackRange)
        {
            FindObjectOfType<Enemy>().health -= 5;
        }

        isKneeing = true;
        animator.SetTrigger("Kneeing");
        animator.SetBool("isKneeing", true);
        yield return new WaitForSeconds(2.267f);
        isKneeing = false;
        animator.SetBool("isKneeing", false);

    }
    IEnumerator Blocking()
    {
        isBlocking = true;
        animator.SetTrigger("Blocking");
        animator.SetBool("isBlocking", true);
        yield return new WaitForSeconds(2.867f);
        isBlocking = false;
        animator.SetBool("isBlocking", false);

    }
    IEnumerator LeftBlocking()
    {
        isLeftBlocking = true;
        animator.SetTrigger("LeftBlocking");
        animator.SetBool("isLeftBlocking", true);
        yield return new WaitForSeconds(1.5f);
        isLeftBlocking = false;
        animator.SetBool("isLeftBlocking", false);

    }
    IEnumerator RightBlocking()
    {

        isRightBlocking = true;
        animator.SetTrigger("RightBlocking");
        animator.SetBool("isRightBlocking", true);
        yield return new WaitForSeconds(1.433f);
        isRightBlocking = false;
        animator.SetBool("isRightBlocking", false);

    }



}

