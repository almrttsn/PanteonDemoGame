using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterMovementBehaviour : MonoBehaviour
{
    [SerializeField] private float _circularMovementRadius;
    [SerializeField] private SlotController _slotController;
    private Vector3 _startPos;
    private Vector3 _endPos;
    private Vector3 _centerOfCircle;


    private void Start()
    {
        _startPos = transform.position;
        SlotMatching();
        _centerOfCircle = new Vector3((_endPos.x - _startPos.x) / 2 - _circularMovementRadius, (_endPos.y - _startPos.y) / 2, 0);
    }

    private void Update()
    {
        transform.position = Vector3.Slerp(transform.position - _centerOfCircle, _endPos - _centerOfCircle, Time.deltaTime) + _centerOfCircle;
    }

    private void SlotMatching()
    {
        for (int i = 0; i < _slotController.Slots.Count; i++)
        {
            if (_slotController.Slots[i].tag == this.tag)
            {
                _endPos.x = _slotController.Slots[i].transform.position.x;
                _endPos.y = _slotController.Slots[i].transform.position.y + 1f; //offset for letter slot
            }
        }
    }
}
