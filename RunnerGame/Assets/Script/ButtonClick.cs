using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Image = UnityEngine.UI.Image;
using TMPro;

public class ButtonClick : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    Image buttonImage;

    [SerializeField] private Sprite buttonDown;
    [SerializeField] private Sprite buttonUp;
    [SerializeField] private GameObject text;
    Vector3 vector;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        vector = text.transform.position;
    }

    public void OnPointerDown ( PointerEventData eventData )
    {
        buttonImage.sprite = buttonDown;
        vector = vector + new Vector3 ( 0, -0.4f, 0 );
        text.gameObject.transform.position = vector;
    }
    public void OnPointerUp ( PointerEventData eventData )
    {
        buttonImage.sprite = buttonUp;
        vector = vector + new Vector3 ( 0, 0.4f, 0 );
        text.gameObject.transform.position = vector;

    }
}
