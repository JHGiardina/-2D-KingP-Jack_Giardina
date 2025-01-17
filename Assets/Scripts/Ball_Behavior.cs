using UnityEngine;

public class Ball_Behavior : MonoBehaviour
{
            public float minX = -9.67f;
            public float maxX = 10.63f;
            public float minY = -4.27;
            public float maxY = 5.11f;
            public float minSpeed;
            public float maxSpeed;
            Vector2 targetPosition;
            public int secondsToMaxSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        secondsToMaxSpeed = 30;
        minSpeed = .75f;
        maxSpeed = 2f;

        targetPosition = getRandomposition();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = gameObject.getcomponent<Transform>().position;
        if(targetPosition != currentPosition){
            float currentSpeed = minSpeed;
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
}