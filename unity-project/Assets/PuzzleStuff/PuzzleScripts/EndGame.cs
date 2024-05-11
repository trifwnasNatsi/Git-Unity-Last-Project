using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    SocketScript socket;

    private bool isOpen = false;
    [SerializeField] Canvas win;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {   if (isOpen == false)
        {
            if (other.CompareTag("Player"))
            {
                win.GetComponent<Canvas>().gameObject.SetActive(true);
                isOpen = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                Time.timeScale = 0;
                //SocketScript.socketCount = 0;
            }
        }
    }
}
