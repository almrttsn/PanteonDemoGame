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

    private void ClickedOnALetter(LetterBehaviour clickedLetter, Vector3 letterTransform)
    {
        OnRelatedTagArrived?.Invoke(clickedLetter.tag);
        StartCoroutine(DisableClickLetterCo());
    }

    private IEnumerator DisableClickLetterCo()
    {
        for (int i = 0; i < _letters.Count; i++)
        {
            _letters[i].PlayerCanClick = false;
        }
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < _letters.Count; i++)
        {
            _letters[i].PlayerCanClick = true;
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _letters.Count; i++)
        {
            _letters[i].OnClickedALetter -= ClickedOnALetter;
        }
    }
}
