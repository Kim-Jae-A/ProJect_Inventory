using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryMove : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [SerializeField]
    private Transform _targetTr; // �̵��� UI
    [SerializeField]
    private Transform _targetTogeter; // ���� �̵��� UI
    [SerializeField]
    private Transform _targetTogeter1; // ���� �̵��� UI


    private Vector2 _beginPoint;
    private Vector2 _beginPoint1;
    private Vector2 _beginPoint2;
    private Vector2 _moveBegin;

    private void Awake()
    {
        // �̵� ��� UI�� �������� ���� ���, �ڵ����� �θ�� �ʱ�ȭ
        if (_targetTr == null)
            _targetTr = transform.parent;
    }

    // �巡�� ���� ��ġ ����
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        _beginPoint = _targetTr.position;
        _beginPoint1 = _targetTogeter.position;
        _beginPoint2 = _targetTogeter1.position;
        _moveBegin = eventData.position;
    }

    // �巡�� : ���콺 Ŀ�� ��ġ�� �̵�
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        _targetTr.position = _beginPoint + (eventData.position - _moveBegin);
        _targetTogeter.position = _beginPoint1 + (eventData.position - _moveBegin);
        _targetTogeter1.position = _beginPoint2 + (eventData.position - _moveBegin);
    }
}
