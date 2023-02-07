using MangoramaStudio.Scripts.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterBehaviour : MonoBehaviour
{
    public bool _freeToMove { get; set; }
    public event Action<LetterBehaviour> OnClickedALetter;
    [SerializeField] private TextMesh text;


    private void Start()
    {
        text.text = gameObject.tag.ToString();
    }

    private void OnMouseDown()
    {
        OnClickedALetter?.Invoke(this);
        StartCoroutine(LetterMoveCo());
        PlayerData.PlayerMoney -= 100;
    }

    private IEnumerator LetterMoveCo()
    {
        _freeToMove = true;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);

    }
}
