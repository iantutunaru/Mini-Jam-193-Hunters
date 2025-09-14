using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class SceneNavigate : MonoBehaviour
{
    [SerializeField] private PauseToggle pauseToggle;
    
    // Credits Scene Load Func
    public void CreditsSceneLoad()
    {
        SceneManager.LoadScene("Credits");
    }
    
    // Main Menu Scene Load Func
    public void MainMenuSceneLoad()
    {
        pauseToggle.ResumeOnQuit();
        SceneManager.LoadScene("Main-Menu");
    }

    public void QuitCredits()
    {
        SceneManager.LoadScene("Main-Menu");
    }
    
    // Level 2 Scene Load Func
    public void PlaySceneLoad()
    {
        SceneManager.LoadScene("Level2FoxBoss");
    }
    
    // Exit Game to Desktop
    public void Exit()
    {
        Application.Quit();
    }
}
