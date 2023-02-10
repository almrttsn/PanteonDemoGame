using MangoramaStudio.Scripts.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterBehaviour : MonoBehaviour
{
    public bool PlayerCanClick;
    public event Action<LetterBehaviour, Vector3> OnClickedALetter;
    [SerializeField] private TextMesh text;
    [SerializeField] private LetterController _letterController;

    private void Start()
    {
        text.text = gameObject.tag.ToString();
        PlayerCanClick = true;
    }

    private void OnMouseDown()
    {
        if (PlayerCanClick == true)
        {
            OnClickedALetter?.Invoke(this, transform.position);
            gameObject.SetActive(false);
            PlayerData.PlayerMoney -= 100;
        }
    }
}
