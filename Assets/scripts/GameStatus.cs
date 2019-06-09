using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    //config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] bool isAutoPlayEnabled;

    //state variables
    [SerializeField] int currentScore = 0;
    [SerializeField] int totalLives = 5;
    int currentLives;

    public bool Lost()
    {
        if (currentLives <= 0)
            return true;
        else
            return false;
    }

    private void Awake()
    {
              
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject); 
        }
    }
    // Start is called before the first frame update
    void Start()
    {            
        scoreText.text = "score: " + currentScore.ToString();
        currentLives = totalLives;

        livesText.text = currentLives.ToString();

    }


    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;

    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = "score: "+ currentScore.ToString();

    }

    public void DecreaseLives()
    {
        currentLives--;
        if (currentLives < 0)
            currentLives = 0;
        livesText.text = currentLives.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
