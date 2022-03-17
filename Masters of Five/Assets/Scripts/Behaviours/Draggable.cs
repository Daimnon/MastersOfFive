using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject _3DCardPrefab;
    
    [SerializeField]
    private CanvasGroup _canvasGroup;

    [SerializeField]
    private float _onHoverOffsetHand = 160f, _onHoverOffsetBattleField = 80f;

    public bool IsCardInHand = true, IsHoldingCard = false;

    public Transform ParentToReturn = null;
    public Transform ParentToReturnPlaceholder = null;
    private GameObject _placeholder = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        print("Drag Began");

        IsHoldingCard = true;
        _placeholder = new GameObject($"{name}_Placeholder");
        _placeholder.transform.SetParent(transform.parent);
        LayoutElement le = _placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;

        _placeholder.transform.SetSiblingIndex(transform.GetSiblingIndex());

        ParentToReturn = transform.parent;
        ParentToReturnPlaceholder = ParentToReturn;
        transform.SetParent(transform.parent.parent);
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        print("Dragging");

        transform.position = eventData.position;

        if (_placeholder.transform.parent != ParentToReturnPlaceholder)
            _placeholder.transform.SetParent(ParentToReturnPlaceholder);

        int newSiblingIndex = ParentToReturnPlaceholder.childCount;

        for (int i = 0; i < ParentToReturnPlaceholder.childCount; i++)
        {
            if (transform.position.x < ParentToReturnPlaceholder.GetChild(i).position.x)
            {
                newSiblingIndex = i;

                if (_placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                    newSiblingIndex--;

                break;
            }
        }

        _placeholder.transform.SetSiblingIndex(newSiblingIndex);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        print("Stopped Dragging");

        transform.SetParent(ParentToReturn);
        transform.SetSiblingIndex(_placeholder.transform.GetSiblingIndex());
        _canvasGroup.blocksRaycasts = true;
        
        Destroy(_placeholder);
        IsHoldingCard = false;

        Instantiate(_3DCardPrefab, Input.mousePosition, Quaternion.identity);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("Hovering");

        if (IsHoldingCard)
            return;

        else if (!IsCardInHand)
            transform.position = new Vector2(transform.position.x, transform.position.y + _onHoverOffsetBattleField);

        else
            transform.position = new Vector2(transform.position.x, transform.position.y + _onHoverOffsetHand);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("Stopped Hovering");

        if (IsHoldingCard)
            return;

        else if (!IsCardInHand)
            transform.position = new Vector2(transform.position.x, transform.position.y - _onHoverOffsetBattleField);

        else
            transform.position = new Vector2(transform.position.x, transform.position.y - _onHoverOffsetHand);
    }
}
