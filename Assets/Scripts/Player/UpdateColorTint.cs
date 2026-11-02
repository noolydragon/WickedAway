using UnityEngine;

public class UpdateColorTint : MonoBehaviour
{
    public Material colorTintMaterial;
    //Pass the scale in so it flickers with the light

    // Update is called once per frame
    void Update()
    {
        colorTintMaterial.SetVector("_SpherePosition", transform.position);
    }
}
