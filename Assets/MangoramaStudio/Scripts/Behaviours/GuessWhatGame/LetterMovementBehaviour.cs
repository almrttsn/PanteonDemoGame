using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterMovementBehaviour : MonoBehaviour
{
    [SerializeField] private SlotController _slotController;
    [SerializeField] private float _circularMovementRadius;
    [SerializeField] private LetterPopulator _letterPopulator;
    private Vector3 _startPos;
    private Vector3 _endPos;
    private Vector3 _centerOfCircle;
    private LetterBehaviour _letterBehaviour;
    private bool _isLetterReadyToMove;


    private void Start()
    {
        _letterPopulator.OnLetterReadyToMove += LetterReadyToMove;
        _startPos = transform.position;
        _centerOfCircle = new Vector3((_endPos.x - _startPos.x) / 2 - _circularMovementRadius, (_endPos.y - _startPos.y) / 2, 0);
    }

    private void LetterReadyToMove(LetterBehaviour movingLetter,bool isLetterReadyToMove)
    {
        _letterBehaviour = movingLetter;
        _isLetterReadyToMove = isLetterReadyToMove;
        SlotMatching();
    }

    private void Update()
    {
        if (_isLetterReadyToMove == true)
        {
             _letterBehaviour.transform.position = Vector3.Slerp(transform.position - _centerOfCircle, _endPos - _centerOfCircle, Time.deltaTime) + _centerOfCircle;
        }
    }

    private void SlotMatching()
    {
        for (int i = 0; i < _slotController.Slots.Count; i++)
        {
            if (_slotController.Slots[i].tag == _letterBehaviour.tag)
            {
                _endPos.x = _slotController.Slots[i].transform.position.x;
                _endPos.y = _slotController.Slots[i].transform.position.y + 1f; //offset for letter slot
            }
        }
    }
}
