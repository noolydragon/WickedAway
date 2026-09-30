using UnityEngine;

public class FlameColorUpdate : MonoBehaviour
{
    public Light lightSource;
    public string flameColor;

    void Update()
    {
        ChangeLightColor();
    }

    void ChangeLightColor()
    {
        switch (flameColor)
        {
            case "Lithium":
                lightSource.color = Color.red;
                break;
            case "Sodium":
                lightSource.color = Color.yellow;
                break;
            case "Barium":
                lightSource.color = Color.green;
                break;
            case "Copper":
                lightSource.color = Color.blue;
                break;
            case "Cesium":
                lightSource.color = Color.violet;
                break;
            case "MagnesiumSulfate":
                lightSource.color = Color.white;
                break;
            case "Potassium":
                lightSource.color = Color.pink;
                break;
            default:
                lightSource.color = Color.orange;
                break;
        }
    }
}
