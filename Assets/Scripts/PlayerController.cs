using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float fastFallGravity = 10f;
    //private float _initialPosY;
    private float _initialGravity;
    private Rigidbody2D Rigidbody2D => GetComponent<Rigidbody2D>();

    private void Start()
    {
        //_initialPosY = transform.position.y;
        _initialGravity = Rigidbody2D.gravityScale;
    }

    private void Update()
    {
        if (transform.position.y <= 0f)
        {            
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                Rigidbody2D.gravityScale = _initialGravity;
                Rigidbody2D.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
            }
        }
        else
        {
            if (!Input.GetKeyDown(KeyCode.DownArrow)) return;
            Rigidbody2D.gravityScale = fastFallGravity;
            //var transformTemp = transform;
            //transformTemp.position = new Vector2(transformTemp.position.x, _initialPosY);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
