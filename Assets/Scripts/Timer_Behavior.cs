using UnityEngine;
using TMPro;

public class Timer_Behavior : MonoBehaviour
{
    private float timer = 0.0f;
    private TextMeshProUGUI textField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textField = GetComponent<TextMeshProUGUI>();
        if (textField == null)
        {
            Debug.LogError("TextMeshProUGUI component not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.time;
        textField.text = timer.ToString();
        //Debug.Log(timer);
        if (textField != null)
        {
            int minutes = Mathf.FloorToInt(timer / 60F);
            int seconds = Mathf.FloorToInt(timer % 60);
            string timeLabel = string.Format("Time: {0:0}:{1:00}", minutes, seconds);
            textField.SetText(timeLabel);
        }
    }
}
