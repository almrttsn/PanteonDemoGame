using MangoramaStudio.Scripts.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterBehaviour : MonoBehaviour
{

    public event Action<LetterBehaviour, Vector3> OnClickedALetter;
    [SerializeField] private TextMesh text;

    private void Start()
    {
        text.text = gameObject.tag.ToString();
    }

    private void OnMouseDown()
    {
        OnClickedALetter?.Invoke(this, transform.position);
        gameObject.SetActive(false);
        PlayerData.PlayerMoney -= 100;
    }
}
