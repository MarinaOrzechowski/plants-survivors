using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    [SerializeField] int lives = 5;
     

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.name == "Stone")
        {
            FindObjectOfType<GameStatus>().DecreaseLives();

            if (FindObjectOfType<GameStatus>().Lost())
            {
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                FindObjectOfType<Stone>().hasStarted = false;

            }
        }
    }
}
