using UnityEngine;




public class Player : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 newPosition;
    public Vector3 mousePosG;
    Camera cam;
    public bool isDead = false;

    public float dashSpeed;
    public float baseSpeed;
    public float dashDur;
    private bool isDashing;
    private float dashStart;
    public float dashCooldown;
    public float cooldownRate;
    private float dashEnd;
 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        isDashing = false;
    }

    // Update is called once per frame
    void Update()
    {

        mousePosG = cam.ScreenToWorldPoint(Input.mousePosition);

        newPosition = Vector2.MoveTowards(transform.position, mousePosG, speed * Time.fixedDeltaTime);
        transform.position = newPosition;
        Dash();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(gameObject);
            isDead = true;
        }
    }

    private void Dash()
    {
                if (isDashing)
        {
            float howLong = Time.time - dashStart;
            if (howLong > dashDur)
            {
                isDashing = false;
                speed = baseSpeed;
                dashEnd = Time.time;
                dashCooldown = cooldownRate;
            }
        }else if (Input.GetMouseButtonDown(0) && ((dashCooldown - Time.deltaTime) <= 0))
        {
            
            isDashing = true;
            speed = dashSpeed;
            dashStart = Time.time;

        }
        {
            
        }
    }

}   

