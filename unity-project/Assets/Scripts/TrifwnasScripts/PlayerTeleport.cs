using System.Collections;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    MovementStateManager playerController;
    CharacterController characterController;
    public Transform[] checkpoints;
    private int currentCheckpointIndex = 1;
    private Coroutine teleportCoroutine;

    void Start()
    {
        playerController = GetComponent<MovementStateManager>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (teleportCoroutine == null)
            {
                teleportCoroutine = StartCoroutine(Teleport());
            }
            else
            {
                Debug.Log("Already teleporting");
            }
        }
    }

    IEnumerator Teleport()
    {
        playerController.disabled = true;
        characterController.enabled = false;

        yield return null; // Wait for end of frame

        // Teleport to the current checkpoint position
        gameObject.transform.position = checkpoints[currentCheckpointIndex].position;

        currentCheckpointIndex = (currentCheckpointIndex + 1) % checkpoints.Length;

        yield return null; // Wait for end of frame

        playerController.disabled = false;
        characterController.enabled = true;

        teleportCoroutine = null; // Reset coroutine reference
    }
}
