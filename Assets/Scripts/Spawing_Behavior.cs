using UnityEngine;

public class Spawning_Behavior : MonoBehaviour
{
    [Header("Settings")]
    public GameObject[] ball_Variants;
    public GameObject targetObject;
    GameObject newObject;
    public float startTime;
    public float ratioMin = 1f;
    public float ratioMax = 5f;
    private float spawnRatio;
    [Header("Information")]
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnBall();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;
        float timeElapsed = currentTime - startTime;
        spawnRatio = getSpawnRatio();
        if (timeElapsed > spawnRatio)
        {
            spawnBall();
        }
    }



    void spawnBall()
    {
        int numVariants = ball_Variants.Length;
        if (numVariants > 0 )
        {
            int selection = Random.Range(0, numVariants);
            newObject = Instantiate(ball_Variants[selection], new Vector3(0,0,0), Quaternion.identity);
            Ball_Behavior ballBehavior = newObject.GetComponent<Ball_Behavior>();
            ballBehavior.setBounds(minX, maxX, minY, maxY);
            ballBehavior.initialPosition();
        }
        startTime = Time.time;
    }

    private float getSpawnRatio()
    {
        float SRout = Random.Range(ratioMin, ratioMax);
        return SRout;
    }
}
