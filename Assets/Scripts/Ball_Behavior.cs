using UnityEngine;
using TMPro;

public class Ball_Behavior : MonoBehaviour
{
            Rigidbody2D body;
            public float minX = -10f;
            public float maxX = 10f;
            public float minY = -5f;
            public float maxY = 5f;
            private float i_minX;
            private float i_maxX;
            private float i_minY;
            private float i_maxY;
            public float minSpeed;
            public float maxSpeed;
            Vector2 targetPosition;
            public int secondsToMaxSpeed;

            public GameObject target;
            public float minLaunchSpeed;
            public float maxLaunchSpeed;
            public float minTimeToLaunch;
            public float maxTimeToLaunch;
            public bool launching;
            public float cooldown;
            public float launchDuration;
            public float timeLastLaunch;
            public float currentSpeed;
            public TextMeshProUGUI scoreText;
            public int score = 0;
            public Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // secondsToMaxSpeed = 30;
        // minSpeed = 2f;
        // maxSpeed = 17f;
  
        
            body = GetComponent<Rigidbody2D>();
            initialPosition();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void FixedUpdate()
    {
        body = GetComponent<Rigidbody2D>();
        Vector2 currentPosition = body.position;
        if (launching == false && onCooldown() == false)
        {
            launch();
        }
        float distance = Vector2.Distance((Vector2)transform.position, targetPosition);
        if (distance > 0.1f)
        {
            float difficulty = getDifficultyPercentage();
            if (launching == true)
            {
                float launchingForHowLong = Time.time - timeLastLaunch; 
                if (launchingForHowLong >= launchDuration)
                {
                    startCooldown();
                }
                currentSpeed = Mathf.Lerp(minLaunchSpeed, maxLaunchSpeed, getDifficultyPercentage());
            }
            else
            {
                currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, getDifficultyPercentage());
            }
            currentSpeed *= Time.deltaTime;
            Vector2 newPosition = Vector2.MoveTowards(currentPosition, targetPosition, currentSpeed);
            body.MovePosition(newPosition);
        }else
        {
            if (launching == true)
            {
                startCooldown();
            }
            targetPosition = getRandomposition();
        }

    }

    private float getDifficultyPercentage(){
        float difficulty =  Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxSpeed);
        return difficulty;
    }

    public void launch(){
        Rigidbody2D targetBody = target.GetComponent<Rigidbody2D>();
        targetPosition = targetBody.position;
        if (launching == false)
        {
            targetPosition = targetBody.position;
            launching = true;
            if (player.isDead == false)
            {
                score++;
                scoreText.text = "Score: \n" + score;
            }
        }
        //Debug.Log("launching");
    }

    bool onCooldown() 
    {
        bool onCooldown = true;
        float timeSinceLastLaunch = Time.time - timeLastLaunch;
        if (timeSinceLastLaunch >= cooldown) {
            onCooldown = false;
        }
        return onCooldown;
    }

    void startCooldown()
    {
        launching = false;
        timeLastLaunch = Time.time;
    }

        Vector2 getRandomposition(){
        float randomX = Random.Range(minX, maxX);

        float randomY = Random.Range(minY, maxY);

        Vector2 v = new Vector2(randomX, randomY);

        return v;
        
        }
    private void OnCollisionEnter2D(Collision2D collision)
        {
            //Debug.Log(this + " hit " + collision.gameObject.name);
            Vector2 currentPosition = body.position;
            currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, getDifficultyPercentage());
            currentSpeed *= Time.deltaTime;
            targetPosition = getRandomposition();
            Vector2 newPosition = Vector2.MoveTowards(currentPosition, targetPosition, currentSpeed);
            body.MovePosition(newPosition);

        }

        public void initialPosition()
        {
            transform.position = getInitialPosition();
            targetPosition = getRandomposition();
            launching = false;
        }

        public void setBounds(float miX, float miY, float maX, float maY)
        {
            i_minX = miX;
            i_minY = miY;
            i_maxX = maX;
            i_maxY = maY;
        }
        public Vector2 getInitialPosition()
        {
        float randomX = Random.Range(i_minX, i_maxX);

        float randomY = Random.Range(i_minY, i_maxY);

        Vector2 i_v = new Vector2(randomX, randomY);

        return i_v;
        }
    } 