using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SyncTextureRect : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    [SerializeField] private RectTransform container;
    [SerializeField] private RawImage texture;
    
    private RectTransform textureRt;

    private void Awake()
    {
        textureRt = texture.GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData) => SyncRect(eventData.position.y);

    public void OnPointerDown(PointerEventData eventData) => SyncRect(eventData.position.y);

    private void SyncRect(float y)
    {
        var heightDelta = y / container.rect.height;
        texture.uvRect = new Rect(texture.uvRect.x, heightDelta, texture.uvRect.width, 1 - heightDelta);

        textureRt.offsetMax = Vector2.zero;
        textureRt.offsetMin = new Vector2(textureRt.offsetMin.x, y);
    }
}
