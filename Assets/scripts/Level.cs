using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;

    //cashed reference
    SceneLoader sceneloader;

    // Start is called before the first frame update
    void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        breakableBlocks++; 
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneloader.LoadNextScene();
        }
    }

}
