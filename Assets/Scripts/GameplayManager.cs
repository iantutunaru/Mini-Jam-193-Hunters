using UnityEngine;
using UnityEngine.SceneManagement;  // For scene management

public class GameplayManager : MonoBehaviour
{
    public GameObject gameOverPanel;  // The Game Over panel (UI)
    public MonoBehaviour cameraMovementScript;  // The camera movement script to disable on game over

    private bool isGameOver = false;  // Flag to track if the game is over

    private void Start()
    {
        // Hide the Game Over Panel at the start
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    // Call this function to trigger Game Over
    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;

            Cursor.lockState = true ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = true;

            // Show Game Over Panel
            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
            }

            // Disable player controls (camera movement, etc.)
            if (cameraMovementScript != null)
            {
                cameraMovementScript.enabled = false;
            }
        }
    }

    // Respawn the player (restart the scene)
    public void Respawn()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Reactivate camera movement after respawn
        if (cameraMovementScript != null)
        {
            cameraMovementScript.enabled = true;
        }

        // Hide the Game Over panel after respawn
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        // Reset isGameOver to allow restarting the game
        isGameOver = false;
    }
}
