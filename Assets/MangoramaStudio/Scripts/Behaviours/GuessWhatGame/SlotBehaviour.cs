using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotBehaviour : MonoBehaviour
{
    public TextMesh Text => _text;
    [SerializeField] private TextMesh _text;

    private void Start()
    {
        _text = GetComponentInChildren<TextMesh>();
        _text.gameObject.SetActive(false);
        _text.text = gameObject.tag.ToString();   
    }
}
