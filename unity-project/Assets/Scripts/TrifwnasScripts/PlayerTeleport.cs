using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    MovementStateManager playerController;
    CharacterController characterController;
    public Transform[] checkpoints; // Array to hold the positions of checkpoints
    private int currentCheckpointIndex = 0; // Index to track the current checkpoint
    Coroutine r;
    // Start is called before the first frame update
    void Start()
    {
        playerController=gameObject.GetComponent<MovementStateManager>();
        characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(r!=null)
            {
                r = StartCoroutine("Teleport");
                Debug.Log("teleport");
            } else
            Debug.Log("Already tping");
            //StopCoroutine(r); 
        }
    }

    IEnumerator Teleport()
    {
        playerController.disabled = true;
        characterController.enabled = false;
        yield return new WaitForSeconds(0.01f);
        gameObject.transform.position = checkpoints[currentCheckpointIndex].position;// Teleport to the current checkpoint position
        currentCheckpointIndex = (currentCheckpointIndex + 1) % checkpoints.Length;// Move to the next checkpoint index, cycling back to the start if reached the end
        yield return new WaitForSeconds(0.01f);
        playerController.disabled = false;
        characterController.enabled = true;
        r = null;
    }

}
