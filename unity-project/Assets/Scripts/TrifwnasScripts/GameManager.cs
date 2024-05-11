using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int winTime = 30;
    public SpawnHandler spawnHandler;
    public TargetHandler targetHandler;
    [SerializeField] Canvas winCanvas;
    [SerializeField] Canvas loseCanvas;
    [SerializeField] Canvas nextLevelCanvas;
    public bool isLostGame = false;
    public bool isWinGame = false;
    //public PlayerHandler playerHandler;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        StartCoroutine(WaitForWin());
        Time.timeScale = 1;
    }

    IEnumerator WaitForWin()
    {
        
        yield return new WaitForSeconds(winTime);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int sceneCountInBuildSettings = SceneManager.sceneCountInBuildSettings;

        if (currentSceneIndex < sceneCountInBuildSettings - 1)
            NextLevel();
        else
            GameWon();
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }

    
    private void GameOver()
    {
        if (!targetHandler.isActive())
        {
            isLostGame = true;
            Debug.Log("Game Over");
            Cursor.visible = true;
            loseCanvas.GetComponent<Canvas>().gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
        }

    }
    public void GameWon()
    {
        winCanvas.GetComponent<Canvas>().gameObject.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        //yield return new WaitForSeconds(3);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NextLevel()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        nextLevelCanvas.GetComponent<Canvas>().gameObject.SetActive(true);
    }

}

//private bool getPlayerAliveStatus()
//{
//    return playerHandler.isActive();
//}
