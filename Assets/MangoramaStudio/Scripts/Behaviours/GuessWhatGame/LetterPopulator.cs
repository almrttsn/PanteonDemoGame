using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPopulator : MonoBehaviour
{
    public event Action<LetterBehaviour,bool> OnLetterReadyToMove;
    [SerializeField] private List<LetterBehaviour> _letters;
    private Vector3 _letterTransform;
    private LetterBehaviour _letterBehaviour;
    private TextMesh _text;

    private void Start()
    {
        for (int i = 0; i < _letters.Count; i++)
        {
            _letters[i].OnClickedALetter += ClickedOnALetter;
        }
    }

    private void ClickedOnALetter(LetterBehaviour letterBehaviour, Vector3 letterTransform)
    {
        _letterTransform = letterTransform;
        _letterBehaviour = letterBehaviour;
        _text = _letterBehaviour.GetComponentInChildren<TextMesh>();
        var instantiatedLetter = Instantiate(_letterBehaviour, _letterTransform, Quaternion.identity);
        instantiatedLetter.transform.parent = gameObject.transform;
        _text.text = _letterBehaviour.tag.ToString();
        OnLetterReadyToMove?.Invoke(instantiatedLetter,true);
    }    

    //private IEnumerator LetterMoveCo(bool freeToMove)
    //{
    //    _freeToMove = freeToMove;
    //    yield return new WaitForSeconds(3f);
    //    Destroy(gameObject);
    //}

    private void OnDestroy()
    {
        for (int i = 0; i < _letters.Count; i++)
        {
            _letters[i].OnClickedALetter -= ClickedOnALetter;
        }
    }
}
