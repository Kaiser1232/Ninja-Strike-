using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public float moveSpeed;
    public float xInput;
    public float zInput;
    public float rotationSpeed;



    public Transform playerModel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    //void Update()
    //{
    //    Move();
    //}

    //public void Move()
    //{
    //    xInput = Input.GetAxis("Horizontal");
    //    zInput = Input.GetAxis("Vertical");

    //    Vector3 moveDirection = new Vector3(xInput, 0, zInput);

    //    characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    //}
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * moveSpeed * Time.deltaTime,  Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

           playerModel.transform.rotation = Quaternion.RotateTowards(playerModel.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
   
    }

}
