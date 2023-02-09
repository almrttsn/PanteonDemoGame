using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPopulator : MonoBehaviour
{
    [SerializeField] private List<LetterBehaviour> _letters;
    private Vector3 _letterTransform;
    private LetterBehaviour _letterBehaviour;
    private TextMesh _text;

    private void Start()
    {
        for (int i = 0; i < _letters.Count; i++)
        {
            _letters[i].OnLetterTransformReady += LetterTransformReady;
        }
    }

    private void LetterTransformReady(Vector3 letterTransform,LetterBehaviour letterBehaviour)
    {
        _letterTransform = letterTransform;
        _letterBehaviour = letterBehaviour;
        _text = _letterBehaviour.GetComponentInChildren<TextMesh>();
        Instantiate(_letterBehaviour, _letterTransform, Quaternion.identity);
        _text.text = _letterBehaviour.tag.ToString();
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _letters.Count; i++)
        {
            _letters[i].OnLetterTransformReady -= LetterTransformReady;
        }
    }
}
