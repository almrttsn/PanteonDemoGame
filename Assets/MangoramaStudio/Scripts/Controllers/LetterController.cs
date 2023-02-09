using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : MonoBehaviour
{
    public event Action<string> OnRelatedTagArrived;
    [SerializeField] private List<LetterBehaviour> _letters;

    private void Start()
    {
        for (int i = 0; i < _letters.Count; i++)
        {
            _letters[i].OnClickedALetter += ClickedOnALetter;
        }
    }

    private void ClickedOnALetter(LetterBehaviour clickedLetter)
    {
        OnRelatedTagArrived?.Invoke(clickedLetter.tag);
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _letters.Count; i++)
        {
            _letters[i].OnClickedALetter -= ClickedOnALetter;
        }

    }
}
