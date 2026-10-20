using UnityEngine;
using UnityEngine.UI;

public class FlameWheelController : MonoBehaviour
{
    public Animator anim;
    private bool flameWheelSelected = false;
    public Light playerPointLight;
    public Image selectedItem;
    public Sprite noImage;
    public static int flameID;
    Color purple = new Color(0.50f, 0.00f, 0.80f, 0.00f);

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            flameWheelSelected = !flameWheelSelected;
        }

        if (flameWheelSelected)
        {
            anim.SetBool("OpenFlameWheel", true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            anim.SetBool("OpenFlameWheel", false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        switch (flameID)
        {
            case 0: //no flame selected
                selectedItem.sprite = noImage;
                break;
            case 1:
                playerPointLight.color = Color.red;
                break;
            case 2:
                playerPointLight.color = Color.orange;
                break;
            case 3:
                playerPointLight.color = Color.yellow;
                break;
            case 4:
                playerPointLight.color = Color.green;
                break;
            case 5:
                playerPointLight.color = Color.cyan;
                break;
            case 6:
                playerPointLight.color = Color.blue;
                break;
            case 7:
                playerPointLight.color = Color.magenta;
                break;
            case 8:
                playerPointLight.color = Color.white;
                break;
            case 9:
                playerPointLight.color = Color.black;
                break;
        }
    }
}
