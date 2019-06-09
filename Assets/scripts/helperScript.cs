using UnityEngine;

public class helperScript : MonoBehaviour
{
    
    float RotateSpeed = 0.5f;
    float Radius = 0.1f;
    bool launch = false;
    Vector2 _center;
    float _angle;
    Color tempColor;

    Rigidbody2D myRigidBody2D;
    Level level;
    SpriteRenderer helper;
    GameStatus gameStatus;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        helper = GetComponent<SpriteRenderer>();
        gameStatus = FindObjectOfType<GameStatus>();

        tempColor = helper.color;
        tempColor.a = 0f;
        helper.color = tempColor;

        _center = transform.position;
        level = FindObjectOfType<Level>();
    }

    // Update is called once per frame
    void Update()
    {
        LaunchOnHpress();

        if (launch)
        {
            _angle += RotateSpeed * Time.deltaTime;

            var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
            transform.position = _center + offset;
            Radius += 0.005f;
        }

        
    }

    public void LaunchOnHpress()
    {
        if (Input.GetKeyDown("h"))
        {
            launch = true;
            tempColor.a = 1f;
            helper.color = tempColor;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "breakable")
        {
            Destroy(collision.gameObject);
            level.BlockDestroyed();
            gameStatus.AddToScore();
        }
        else if (collision.gameObject.tag == "walls")
        {
            Destroy(gameObject);
        }  
    }
}
