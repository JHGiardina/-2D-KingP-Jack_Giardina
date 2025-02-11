using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dash_Icon : MonoBehaviour

{
    TextMeshProUGUI value;
    private Image overlay;
    public Player player;
    public float coolDownRate;
    public float _coolDown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        value = GetComponentInChildren<TextMeshProUGUI>();
        Image[] images = GetComponentsInChildren<Image>();
        for (int i = 0; i < images.Length; i++){
            //if (images[i].tag == "Overlay"){
                overlay = images[i];
            //}
        }
        coolDownRate = player.cooldownRate;
        overlay.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _coolDown = player.dashCooldown;
        string message = string.Empty;
        if (_coolDown >0){
            float fill = _coolDown / coolDownRate;
            message = string.Format("{0:#.0}", _coolDown);
            overlay.fillAmount = fill;
        }
        value.SetText(message); 
        //Debug.Log(message);
        
    }

}
