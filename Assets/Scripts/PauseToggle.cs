using UnityEngine;

public class PauseToggle : MonoBehaviour
{
    [Header("UI")]
    public GameObject pauseMenuRoot;     
    [Header("Gameplay")]
    public MonoBehaviour cameraLookScript; 
    public bool pauseTime = true;         

    bool isPaused;

    void Start()
    {
        SetPaused(false); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPaused(!isPaused);
        }
    }

    void SetPaused(bool pause)
    {
        isPaused = pause;

        if (pauseMenuRoot) pauseMenuRoot.SetActive(pause);
        if (cameraLookScript) cameraLookScript.enabled = !pause;
        Cursor.lockState = pause ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = pause;

        if (pauseTime) Time.timeScale = pause ? 0f : 1f;
    }

    public void ResumeOnQuit()
    {
        SetPaused(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume() => SetPaused(false);
}
