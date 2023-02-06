using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterBehaviour : MonoBehaviour
{
    public event Action<LetterBehaviour> ClickedOnALetter;
    [SerializeField] private TextMesh text;

    private void Start()
    {
        text.text = gameObject.tag.ToString();
    }

    private void OnMouseDown()
    {
        ClickedOnALetter?.Invoke(this);
        Destroy(gameObject);
    }
}
