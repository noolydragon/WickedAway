using UnityEngine;

public class MaterialScriptExample : MonoBehaviour
{
    public float speed = 0.0f;
    public float active = 0.0f;
    public bool isActive = false;
    private Renderer renderer;
    private Material material;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<Renderer>();
        material = renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        material.SetFloat("_Speed", speed);
        if (Input.GetKeyDown(KeyCode.Space) && !isActive)
        {
            isActive = true;
            SetArrowActive();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isActive)
        {
            isActive = false;
            SetArrowInactive();
        }
    }

    void SetArrowActive()
    {
        material.SetFloat("_Active", 1.0f);
    }

    void SetArrowInactive()
    {
        material.SetFloat("_Active", 0.0f);
    }
}
