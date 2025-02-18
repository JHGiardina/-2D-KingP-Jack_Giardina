using UnityEngine;

[CreateAssetMenu(fileName = "Pins", menuName = "Scriptable Objects/Pins")]
public class Pins : ScriptableObject
{
    public Pin[] pins;

    public int count(){
        return pins.Length;
    }

    public Pin getInx(int index)
    {
        return pins[index];
    }
}
