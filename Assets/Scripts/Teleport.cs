using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private GameObject teleport;
    private Rigidbody ballRigidBody;
    private CharacterController controller;

    private GameObject plane;
    // Start is called before the first frame update
    void Start()
    {
        if(CompareTag("Ball"))
        {
            ballRigidBody = GetComponent<Rigidbody>();
        }
        else if(CompareTag("Player"))
        {
            controller = GetComponent<CharacterController>();
        }

        plane = GameObject.Find("TeleportPlane");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "TeleportPlane" && CompareTag("Ball"))
        {
            transform.position = teleport.transform.position;
            ballRigidBody.velocity = Vector3.zero;
        }   
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.name == "TeleportPlane")
        {
            transform.position = teleport.transform.position;
            Vector3 newVelocity = controller.velocity;
            newVelocity = Vector3.zero;
            transform.rotation = teleport.transform.rotation;
        }
    }
}
