using UnityEngine;
using TMPro;

public class Dash_Icon : MonoBehaviour

{
    public TextMeshProUGUI value;
    public Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //value = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        string message = "" + player.dashCooldown;
        value.SetText(message); 
        Debug.Log(message);
    }
}
