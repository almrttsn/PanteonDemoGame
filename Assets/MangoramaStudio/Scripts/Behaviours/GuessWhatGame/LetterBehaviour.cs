using MangoramaStudio.Scripts.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterBehaviour : MonoBehaviour
{
    public event Action<LetterBehaviour> OnClickedALetter;
    [SerializeField] private TextMesh text;

    private void Start()
    {
        text.text = gameObject.tag.ToString();
    }

    private void OnMouseDown()
    {
        OnClickedALetter?.Invoke(this);
        PlayerData.PlayerMoney -= 100;
        Destroy(gameObject);
    }
}
