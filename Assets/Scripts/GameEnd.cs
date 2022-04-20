using UnityEditor.SceneManagement;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    bool gameHasEnded = false;
    private int deaths = 1;
    public float restartDelay = 2f;

    public void EndGame()
    {
        Debug.Log("This Far");
        if (gameHasEnded == false)
        {
            
            GameManager.Instance.Score += deaths;
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);

        }
    
    }

    void Restart()
    {
        //EditorSceneManager.LoadScene(EditorSceneManager.GetActiveScene().name);
    }
}
