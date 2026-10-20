using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlameWheelButtonController : MonoBehaviour
{
    public int ID;
    private Animator anim;
    public string itemName;
    public TextMeshProUGUI itemText;
    public Image selectedItem;
    public bool selected = false;
    public Sprite icon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            selectedItem.sprite = icon;
            itemText.text = itemName;
        }
    }

    public void Selected()
    {
        selected = true;
        FlameWheelController.flameID = ID;
    }

    public void Deselected()
    {
        selected = false;
        FlameWheelController.flameID = 0;
    }

    public void HoverEnter()
    {
        anim.SetBool("Hovered", true);
        itemText.text = itemName;
    }

    public void HoverExit()
    {
        anim.SetBool("Hovered", false);
        itemText.text = "";
    }
}
