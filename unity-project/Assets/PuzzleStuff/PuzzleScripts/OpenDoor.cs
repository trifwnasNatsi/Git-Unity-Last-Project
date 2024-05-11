using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] GameObject door;
    bool isOpened = false;

    public SocketScript socket;

    /*private void OnTriggerEnter(Collider other)
    {
        if (isOpened == false)
        {
            if (other.CompareTag("Player"))
            {
                    door.transform.position += new Vector3(0, 2, 0);
                    isOpened = true;
            }
        }
    }*/

    
    private void Update()
    {
        if (isOpened == false)
        {
            if (SocketScript.socketCount == 4) 
            { 
                door.transform.position += new Vector3(0, 2, 0);
                isOpened = true;
            }
        }
        
    }

}
