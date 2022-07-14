using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com
{
    namespace interiorlighting
    {
        namespace interactable
        {
            public class DoorInteraction : MonoBehaviour
            {
                private bool doorIsOpen = false;
                private float doorOpenedTime = 0.0f;
                // Start is called before the first frame update
                void Start()
                {
                    
                }

                // Update is called once per frame
                void Update()
                {
                    if (doorIsOpen && doorOpenedTime > 3.0)
                    {
                        doorIsOpen = false;
                        GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
                    }
                    doorOpenedTime += Time.deltaTime;
                }

                public void OpenDoor()
                {
                    doorIsOpen = true;
                    doorOpenedTime = 0.0f;
                    GetComponent<Transform>().rotation = Quaternion.Euler(0, 90, 0);

                    //GetComponent<Transform>().rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90, 0), 2 * Time.deltaTime);
                    // The Rotation = Smooth movement (FROM, TO, TIME);
                    // transform.rotation = the object's current rotation;
                    // Quaternion.Euler = Rotate the object;
                    // Quaternion.Euler is called like Quaternion.Euler(X, Y, Z);
                }
            }

        }
    }
}
