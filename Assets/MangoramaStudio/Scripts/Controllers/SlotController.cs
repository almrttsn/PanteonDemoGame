using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    [SerializeField] private List<SlotBehaviour> _slots;
    [SerializeField] private LetterController _letterController;

    private void Start()
    {
        _letterController.OnRelatedTagArrived += RelatedTagArrived;
    }

    private void RelatedTagArrived(string relatedTag)
    {
        for (int i = 0; i < _slots.Count; i++)
        {
            if(_slots[i].tag == relatedTag)
            {
                _slots[i].Text.gameObject.SetActive(true);
            }
        }
    }

    private void OnDestroy()
    {
        _letterController.OnRelatedTagArrived -= RelatedTagArrived;
    }
}
