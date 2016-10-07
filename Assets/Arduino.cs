﻿
 using UnityEngine;
using System.Collections;
using System.IO.Ports;
public class Arduino: MonoBehaviour
{
    SerialPort stream = new SerialPort("COM6", 9600); //Set the port (com4) and the baud rate (9600, is standard on most devices)
    float[] lastRot = { 0, 0, 0 }; //Need the last rotation to tell how far to spin the camera
                                   //void Start () {
           
    void Awake()
    {
        stream.Open(); //Open the Serial Stream.
    }
    // Update is called once per frame
    void Update()
    {
        string value = stream.ReadLine(); //Read the information
        string[] vec3 = value.Split(','); //My arduino script returns a 3 part value (IE: 12,30,18)
                                          //if(vec3[0] != ""  vec3[1] != ""  vec3[2] != "") //Check if all values are recieved
        //Debug.Log("IM DOING SOMETHING");
        if (vec3[0] != "" && vec3[1] != "") //Check if all values are received
        {
            //transform.Rotate(           //Rotate the camera based on the new values
            // float.Parse(vec3[0])-lastRot[0],
            // float.Parse(vec3[1])-lastRot[1],
            // float.Parse(vec3[2])-lastRot[2],
            // Space.Self
            //);
            lastRot[0] = float.Parse(vec3[0]);  //Set new values to last time values for the next loop
            lastRot[1] = float.Parse(vec3[1]);
            //lastRot[2] = float.Parse(vec3[2]);
            stream.BaseStream.Flush(); //Clear the serial information so we assure we get new information.
            Debug.Log(value);
        }
    }
    void OnGUI()
    {
        string newString = "Connected: " + transform.rotation.x + ", " + transform.rotation.y + ", " + transform.rotation.z;
        GUI.Label(new Rect(10, 10, 300, 100), newString); //Display new values
                                                          // Though, it seems that it outputs the value in percentage O-o I don't know why.
    }
}