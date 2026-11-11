using UnityEngine;
using UnityEngine.UI;

public class FlameWheelController : MonoBehaviour
{
    public GameObject flameWheel;
    public Animator anim;
    private bool flameWheelSelected = false;
    public Light playerPointLight;
    public Image selectedItem;
    public Sprite noImage;
    public static string color;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            flameWheelSelected = !flameWheelSelected;
        }

        if (flameWheelSelected)
        {
            anim.SetBool("OpenFlameWheel", true);
            flameWheel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            anim.SetBool("OpenFlameWheel", false);
            flameWheel.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        switch (color)
        {
            case "": //no flame selected
                selectedItem.sprite = noImage;
                break;
            case "red":
                playerPointLight.color = Color.red;
                break;
            case "orange":
                playerPointLight.color = Color.orange;
                break;
            case "yellow":
                playerPointLight.color = Color.yellow;
                break;
            case "green":
                playerPointLight.color = Color.green;
                break;
            case "blue":
                playerPointLight.color = Color.cyan;
                break;
            case "purple":
                playerPointLight.color = Color.blue;
                break;
            case "pink":
                playerPointLight.color = Color.magenta;
                break;
            case "white":
                playerPointLight.color = Color.white;
                break;
        }
    }
}
