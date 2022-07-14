using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCount : MonoBehaviour
{
    private int ballCount;
    [SerializeField]
    private GameObject clear;

    // Start is called before the first frame update
    void Start()
    {
        ballCount = 0;
        clear.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(ballCount == 6)
        {
            clear.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            ballCount++;
            other.gameObject.SetActive(false);
        }
        
    }
}
