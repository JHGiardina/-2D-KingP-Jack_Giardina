using UnityEngine;

public class Ball_Behavior : MonoBehaviour
{
            public float minX = -10f;
            public float maxX = 10f;
            public float minY = -4.27f;
            public float maxY = 5.11f;
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // secondsToMaxSpeed = 30;
        // minSpeed = 2f;
        // maxSpeed = 17f;

        targetPosition = getRandomposition();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = gameObject.GetComponent<Transform>().position;
        if (launching == false && onCooldown() == false)
        {
            launch();
        }
        float distance = Vector2.Distance((Vector2)transform.position, targetPosition);
        if (distance > 0.1f)
        {
            float difficulty = getDifficultyPercentage();
            float currentSpeed;
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
            transform.position = newPosition;
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
        targetPosition = target.transform.position;
        if (launching == false)
        {
            targetPosition = target.transform.position;
            launching = true;
        }
        Debug.Log("launching");
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
    } 