using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.interiorlighting.interactable;
using System;
using System.Globalization;
using PlaySound;

namespace com
{
    namespace interiorlighting
    {
        namespace interactor
        {
            public class SceneInteractor : MonoBehaviour
            {
                // Array to store all the lights GameObjects in the scene;
                private GameObject[] sceneLights;

                // Array to store all the intensity cubes GameObjects in the scene;
                private GameObject[] intensityCubes;

                // Initiliaze the Door object;
                private GameObject door;

                // Initialize all the colors that we are going to need for the lights;
                private Color blue = new Color(0.0f, 132.0f, 197.0f);
                private Color red = new Color(208.0f, 44.0f, 44.0f);
                private Color green = new Color(85.0f, 208.0f, 44.0f);
                private Color white = new Color(255.0f, 255.0f, 255.0f);


                // Initialize objects to use for audio calling.
                private GameObject blueCube;
                private GameObject redCube;
                private GameObject greenCube;
                private GameObject rug;

                // Initialize all the intensity cubes in the scene;
                private GameObject intensity0;
                private GameObject intensity005;
                private GameObject intensity01;
                private GameObject intensity015;
                private GameObject intensity02;

                // Start is called before the first frame update
                void Start()
                {
                    // Declare the door variable.
                    door = GameObject.FindGameObjectWithTag("Door");

                    // Fetch all the lights in the scene to store in the Array.
                    sceneLights = GameObject.FindGameObjectsWithTag("DynamicLights");

                    // Fetch all the intensity cubes in the scene to store in the Array.
                    intensityCubes = GameObject.FindGameObjectsWithTag("IntensityCubes");

                    blueCube = GameObject.Find("BlueCube");
                    redCube = GameObject.Find("RedCube");
                    greenCube = GameObject.Find("GreenCube");
                    rug = GameObject.Find("RugCarpet");

                    // Declare all the intensity cubes variables.
                    intensity0 = GameObject.Find("IntensityCube0.0");
                    intensity005 = GameObject.Find("IntensityCube0.05");
                    intensity01 = GameObject.Find("IntensityCube0.1");
                    intensity015 = GameObject.Find("IntensityCube0.15");
                    intensity02 = GameObject.Find("IntensityCube0.2");


                }

                // Update is called once per frame
                void Update()
                {

                }

                public void SetDoorOpen(GameObject door)
                {
                    /**
                        The argument "door" which is a GameObject datatype should contain the reference to "DoorRotationAxis" in the scene.
                        You then need to access the component "DoorInteraction" that is attached to this GameObject, which actually is a C# script
                        This script contains a function called "OpenDoor" that needs to be called for the door to open and you can go outside
                    **/

                    door.GetComponent<DoorInteraction>().OpenDoor();
                    
                }

                void SetLightingIntensity(GameObject go)
                {
                    /**
                         The argument "go" is a GameObject datatype that will contain a reference to either of the intensity cubes on the floor (the ones from white to black).
                         These GameObject cubes have a script attached to them called as "LightingIntensityValue". 
                         You need to access this script as a component and read the public float variable "intensity".
                         The value in the intensity will be set as the intensity to all the lights in the scene marked with the tag "DynamicLights".
                         To access all GameObjects in the scene with a tag you need to use GameObject.FindGameObjectsWithTag("DynamicLights")
                         Once you have all the GameObjects then you need to access their component "<Light>" to which you will set the intensity value.
                         To know how to set the value of intensity visit: https://docs.unity3d.com/ScriptReference/Light-intensity.html
                    **/

                    //float lightIntensity = go.GetComponent<LightingIntensityValue>().intensity;
                    //foreach (GameObject anyLight in sceneLights)
                    //{
                    //    anyLight.GetComponent<Light>().intensity = lightIntensity;
                    //}

                    string str = go.name.Substring(go.name.Length - 3);
                    float intensityOfCube = float.Parse(str, CultureInfo.InvariantCulture.NumberFormat);
                    foreach (GameObject anyLight in sceneLights)
                    {
                        anyLight.GetComponent<Light>().intensity = intensityOfCube;
                    }

                }

                void SetLightingColor(Color c)
                {
                    /**
                        The argument "c" is a Color datatype that will contain either of the values as Color.red, Color.green, or Color.blue.
                        To access all GameObjects in the scene with a tag you need to use GameObject.FindGameObjectsWithTag("DynamicLights")
                        Once you have all the GameObjects then you need to access their component "<Light>" to which you will set the color value.
                        To know how to set the value of intensity visit: https://docs.unity3d.com/ScriptReference/Light-color.html
                   **/

                    foreach (GameObject anyLight in sceneLights)
                    {
                        anyLight.GetComponent<Light>().color = c;
                    }
                }

                void OnTriggerEnter(Collider c)
                {
                    Debug.Log("HIT A COLLIDER " + c.gameObject.name);
                    string gameObjectThatWasHit = c.gameObject.name;
                    /**
                        This function is triggerred whenever your character collides with any of the colored cubes, intensity cubes, or the door, or the RugCarpet
                        You need to call the appropriate function when any of these collisions occur between your character and the interactables in the scene
                        The variable "gameObjectThatWasHit" contains the name of the GameObject your character collided with. 
                        You can use either if/else-if/else conditionals or switch/case conditional statements to handle what happens after a collisiin is detected
                            - When you hit any of the colored cubes or the RugCarpet
                                - Call the function "SetLightingColor" and pass 
                                    - Color.red if the collision is with RedCube
                                    - Color.green if the collision is with GreenCube
                                    - Color.blue if the collision is with BlueCube
                                    - Color.white if the collision is with the RugCarpet
                            - When you collide with any of the intensity cubes call the function "SetLightingIntensity" and  pass the argument c.gameObject 
                            - when you collide with the "DoorRotationAxis" call the function "SetDoorOpen" and pass the argument c.gameObject
                        
                    **/
                    switch (gameObjectThatWasHit)
                    {

                        case "DoorRotationAxis":
                            SetDoorOpen(door);
                            break;

                        case "BlueCube":
                            SetLightingColor(blue);
                            blueCube.GetComponent<PlayAudio>().Play();
                            //audioSource.PlayOneShot(audioBlue, 0.4f);
                            break;

                        case "RedCube":
                            SetLightingColor(red);
                            redCube.GetComponent<PlayAudio>().Play();
                            //audioSource.PlayOneShot(audioRed, 0.4f);
                            break;

                        case "GreenCube":
                            SetLightingColor(green);
                            greenCube.GetComponent<PlayAudio>().Play();
                            //audioSource.PlayOneShot(audioGreen, 0.4f);
                            break;

                        case "RugCarpet":
                            SetLightingColor(white);
                            rug.GetComponent<PlayAudio>().Play();
                            //audioSource.PlayOneShot(audioWhite, 0.4f);
                            break;

                        case "IntensityCube0.0":
                            SetLightingIntensity(intensity0);
                            //SetLightingIntensity(intensityCubes[0]);
                            break;

                        case "IntensityCube0.05":
                            SetLightingIntensity(intensity005);
                            //SetLightingIntensity(intensityCubes[1]);
                            break;

                        case "IntensityCube0.1":
                            SetLightingIntensity(intensity01);
                            //SetLightingIntensity(intensityCubes[2]);
                            break;

                        case "IntensityCube0.15":
                            SetLightingIntensity(intensity015);
                            //SetLightingIntensity(intensityCubes[3]);
                            break;

                        case "IntensityCube0.2":
                            SetLightingIntensity(intensity02);
                            //SetLightingIntensity(intensityCubes[4]);
                            break;
                    }
                    
                }
            }
        }
    }
}

