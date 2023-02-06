using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : MonoBehaviour
{
    public event Action<string> TagToOpenLetter;
    [SerializeField] private List<LetterBehaviour> _letters;
    private float _letterXPos;

    private void Start()
    {
        for (int i = 0; i < _letters.Count; i++)
        {
            _letters[i].ClickedOnALetter += IsClickedOnALetter;
        }
    }

    private void IsClickedOnALetter(LetterBehaviour clickedLetter)
    {
        Debug.Log("from event: " + clickedLetter.tag.ToString());
        TagToOpenLetter?.Invoke(clickedLetter.tag);
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _letters.Count; i++)
        {
            _letters[i].ClickedOnALetter -= IsClickedOnALetter;
        }

    }
}
