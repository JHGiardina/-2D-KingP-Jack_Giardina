using UnityEngine;




public class Player : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 newPosition;
    public Vector3 mousePosG;
    Camera cam;
    public bool isDead = false;
 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        mousePosG = cam.ScreenToWorldPoint(Input.mousePosition);

        newPosition = Vector2.MoveTowards(transform.position, mousePosG, speed * Time.fixedDeltaTime);
        transform.position = newPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(gameObject);
            isDead = true;
        }
    }

}   

