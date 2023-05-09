using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Function to load Level 1 scene
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    // Function to load Level Select scene
    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("Level Select");
    }

    // Function to quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Beginning()
    {
        SceneManager.LoadScene("Beginning");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

