using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPuzzleHandler : MonoBehaviour
{
    Interactable interactableWithinRange;
    PuzzlePieceScript currentPiece;


    private void OnTriggerEnter(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if(interactable != null)
        {
            interactableWithinRange = interactable;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();

        if (interactable == interactableWithinRange)
        {
            interactableWithinRange = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (interactableWithinRange != null && Input.GetKeyDown(KeyCode.E))
        {
            if(interactableWithinRange is PuzzlePieceScript)
            {
                currentPiece = interactableWithinRange as PuzzlePieceScript;
                currentPiece.ToggleOff();
            }

            if (interactableWithinRange is SocketScript)
            {
                SocketScript socket = interactableWithinRange as SocketScript;
                socket.TryConnect(currentPiece);
            }
        }
    }
}
