using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceReceiver : MonoBehaviour
{
    private float verticalVelocity;

    [SerializeField] private CharacterController characterController;

    public Vector3 Movement => Vector3.up * verticalVelocity; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (verticalVelocity < 0f && characterController.isGrounded)
        {
            verticalVelocity = Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }
    }

    public void Jump(float jumpForce)
    {
        verticalVelocity += jumpForce;
    }
}
