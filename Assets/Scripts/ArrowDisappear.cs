using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDisappear : MonoBehaviour
{
    [SerializeField]
    private GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        arrow.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            arrow.SetActive(false);
        }
    }
}
