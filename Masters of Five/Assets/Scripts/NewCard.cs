using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NewCard : MonoBehaviour
{
    #region Parents
    [Header("Parents")]
    [SerializeField] private Transform _currentParent;
    public Transform CurrentParent { get => transform.parent; set => value = _currentParent; }

    public Transform OldParent, NextParent;

    [SerializeField]
    private Transform _deckTransform, _handTransform, _battlefieldTransform, _tombTransform;
    #endregion

    #region UI
    [Header("UI")]
    [SerializeField] private CanvasGroup _canvasGroup;

    [SerializeField]
    private float _onHoverOffsetHand = 160f, _onHoverOffsetBattleField = 80f;
    #endregion

    #region State Machine
    private delegate void State();
    private State _state;
    #endregion

    private void Start()
    {
        _state = InDeck;
    }

    private void Update()
    {
        _state.Invoke();
    }

    private void InDeck()
    {

        Debug.Log("called: In Deck");

    }

    private void InHand()
    {

        Debug.Log("called: In Hand");

    }

    private void InBattlefield()
    {

        Debug.Log("called: In Battlefield");

    }

    private void InTomb()
    {

        Debug.Log("called: In Tomb");

    }

    private void StartDragging()
    {
        LayoutElement le = GetComponent<LayoutElement>();

        transform.SetParent(CurrentParent);

        le.flexibleWidth = 0;
        le.flexibleHeight = 0;

        transform.SetSiblingIndex(transform.GetSiblingIndex());

        OldParent = CurrentParent;

        transform.SetParent(transform.parent.parent);

        _canvasGroup.blocksRaycasts = false;
    }

    private void Drag()
    {
        if (transform.parent != CurrentParent)
            transform.SetParent(CurrentParent);

        int newSiblingIndex = CurrentParent.childCount;

        for (int i = 0; i < CurrentParent.childCount; i++)
        {
            if (transform.position.x < CurrentParent.GetChild(i).position.x)
            {
                newSiblingIndex = i;

                if (transform.GetSiblingIndex() < newSiblingIndex)
                    newSiblingIndex--;

                break;
            }
        }

        transform.SetSiblingIndex(newSiblingIndex);
    }

    private void EndDrag()
    {
        transform.SetParent(OldParent);
        transform.SetSiblingIndex(transform.GetSiblingIndex());
        _canvasGroup.blocksRaycasts = true;

        if (_currentParent != OldParent)
        {
            if (NextParent = _deckTransform)
            {
                _state = InDeck;
            }
            else if (NextParent = _handTransform)
            {
                _state = InHand;
            }
            else if (NextParent = _battlefieldTransform)
            {
                _state = InBattlefield;
            }
            else if (NextParent = _tombTransform)
            {
                _state = InTomb;
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("called: On Begin Drag");

        _state = StartDragging;

    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("called: On Drag");

        transform.position = eventData.position;

        _state = Drag;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("called: On End Drag");

        _state = EndDrag;

    }
}
