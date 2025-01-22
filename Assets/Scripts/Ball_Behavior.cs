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
        float distance = Vector2.Distance(currentPosition, targetPosition);
        if(distance > 0.1){
            float currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, getDifficultyPercentage());
            currentSpeed *= Time.deltaTime;
            // Randomize speed based on difficulty percentage
            Vector2 newPosition = Vector2.MoveTowards(currentPosition, targetPosition, currentSpeed);
            transform.position = newPosition;
        }else{
            targetPosition = getRandomposition();
        }
    }

    Vector2 getRandomposition(){
        float randomX = Random.Range(minX, maxX);

        float randomY = Random.Range(minY, maxY);

        Vector2 v = new Vector2(randomX, randomY);

        return v;
    }

    private float getDifficultyPercentage(){
        float difficulty =  Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxSpeed);
        return difficulty;
    }

    public void launch(){
        launching = true;
    }
}