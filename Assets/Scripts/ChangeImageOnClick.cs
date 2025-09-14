using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeImageOnClick : MonoBehaviour
{
    public Image targetImage;   // the image that should change
    public Sprite normalSprite; // default sprite
    public Sprite pressedSprite; // sprite while pressed

    void Awake()
    {
        targetImage = GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        targetImage.sprite = pressedSprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        targetImage.sprite = normalSprite;
    }

}
