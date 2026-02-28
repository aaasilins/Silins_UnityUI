using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Image zoneImage;
    private Color originalColor;

    private void Awake()
    {
        zoneImage = GetComponent<Image>();
        if (zoneImage != null)
            originalColor = zoneImage.color;
    }

    public void OnDrop(PointerEventData eventData)
    {
        DraggableItem draggable = eventData.pointerDrag?.GetComponent<DraggableItem>();
        if (draggable != null)
        {
            draggable.isPlacedOnCharacter = true;
            draggable.transform.SetParent(transform);
            // Keep it where the player dropped it
        }

        if (zoneImage != null)
            zoneImage.color = originalColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && zoneImage != null)
            zoneImage.color = Color.green * 0.3f + originalColor * 0.7f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (zoneImage != null)
            zoneImage.color = originalColor;
    }
}