using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsTeleport : MonoBehaviour
{
    [SerializeField]
    private GameObject teleport;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "BallsTeleport")
        {
            transform.position = teleport.transform.position;
        }
    }
}
