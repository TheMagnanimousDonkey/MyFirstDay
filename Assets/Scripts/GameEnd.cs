using UnityEditor.SceneManagement;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 2f;

    public void EndGame()
    {
        Debug.Log("This Far");
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);

        }
    
    }

    void Restart()
    {
        EditorSceneManager.LoadScene(EditorSceneManager.GetActiveScene().name);
    }
}
