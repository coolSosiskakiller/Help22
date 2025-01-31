using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class InputButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool Active;

    private Image _image;

    public void Awake()
    {
        _image = GetComponent<Image>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
       _image.color = Color.gray;
        Active = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _image.color = Color.white;
        Active = false;
    }
}
