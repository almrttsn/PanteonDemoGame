using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    public List<SlotBehaviour> Slots => _slots;
    [SerializeField] private List<SlotBehaviour> _slots;
    [SerializeField] private LetterController _letterController;
    private SlotBehaviour _letterToOpen;

    private void Start()
    {
        _letterController.OnRelatedTagArrived += RelatedTagArrived;
    }

    private void RelatedTagArrived(string relatedTag)
    {
        for (int i = 0; i < _slots.Count; i++)
        {
            if (_slots[i].tag == relatedTag)
            {
                StartCoroutine(SlotActivateCo());
                _letterToOpen = _slots[i];
            }
        }
    }

    private IEnumerator SlotActivateCo()
    {
        yield return new WaitForSeconds(3f);
        _letterToOpen.Text.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        _letterController.OnRelatedTagArrived -= RelatedTagArrived;
    }
}
