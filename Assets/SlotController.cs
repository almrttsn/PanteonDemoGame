using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    [SerializeField] private List<SlotBehaviour> _slots;
    [SerializeField] private LetterController _letterController;

    private void Start()
    {
        _letterController.TagToOpenLetter += IsRelatedTagArrived;
    }

    private void IsRelatedTagArrived(string relatedTag)
    {
        for (int i = 0; i < _slots.Count; i++)
        {
            if(_slots[i].tag == relatedTag)
            {
                _slots[i].Text.gameObject.SetActive(true);
            }
        }
    }
}
