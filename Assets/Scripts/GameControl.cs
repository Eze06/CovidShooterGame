using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{

    public GameObject fpsCam;
    
    public GameObject winScreen;
    public GameObject pauseScreen;

    bool gameHasEnded = false;
    bool gameIsPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                resume();
            }
            else
            {
                pauseGame();
            }
        }
    }



    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Restart();
        }
    }

    public void WinGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            win();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("TutorialLevel");
    }


    void win()
    {
        fpsCam.GetComponent<CameraLook>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        winScreen.SetActive(true);
    }

    public void pauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        fpsCam.GetComponent<CameraLook>().enabled = false;
        pauseScreen.SetActive(true);
        gameIsPaused = true;
    }

    public void resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fpsCam.GetComponent<CameraLook>().enabled = true;
        pauseScreen.SetActive(false);
        gameIsPaused = false;
    }
    
}
