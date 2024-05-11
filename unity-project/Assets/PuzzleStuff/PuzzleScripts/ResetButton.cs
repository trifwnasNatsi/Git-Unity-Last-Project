using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ResetButton : Interactable
{
    PuzzlePieceScript pieceMesh;
    public MeshRenderer blue;
    public MeshRenderer red;
    public MeshRenderer green;
    public MeshRenderer yellow;

    public MeshRenderer blueBase;
    public MeshRenderer redBase;
    public MeshRenderer greenBase;
    public MeshRenderer yellowBase;

    private bool isInsideTrigger;

    private void OnTriggerEnter(Collider other)
    {
        isInsideTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isInsideTrigger = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInsideTrigger == true)
        {
            Debug.Log("Hi");
            blue.enabled = true;
            red.enabled = true;
            green.enabled = true;
            yellow.enabled = true;

            blueBase.enabled = false;
            redBase.enabled = false;
            greenBase.enabled = false;
            yellowBase.enabled = false;
            //pieceMesh.mesh.enabled = false;
            SocketScript.socketCount = 0;
        }
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Hi");
            blue.enabled = true;
            red.enabled = true;
            green.enabled = true;
            yellow.enabled = true;

            blueBase.enabled = false;
            redBase.enabled = false;
            greenBase.enabled = false;
            yellowBase.enabled = false;
            //pieceMesh.mesh.enabled = false;
            SocketScript.socketCount = 0;
        }*/
    }
    /*private void OnTriggerEnter(Collision other)
    {
        pieceMesh.mesh.enabled = false;
        Debug.Log("Hi");
    }*/

