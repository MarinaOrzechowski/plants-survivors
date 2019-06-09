using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene((currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings);
        if ((currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings == 0)
        {
            PlayAgain();
        }

        else if (currentSceneIndex == 8)
        {
            if (FindObjectOfType<GameStatus>().Lost() == false)
            {
                Won();
            }
        }
    }
   
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SkipIntro()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Won()
    {
        SceneManager.LoadScene("Won");
    }
}
 