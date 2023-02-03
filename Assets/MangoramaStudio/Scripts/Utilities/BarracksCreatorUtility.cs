using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksCreatorUtility : MonoBehaviour
{
    [SerializeField] BlockBehaviour _barracksMaterial;
    [SerializeField] int _gridWidthPositive;
    [SerializeField] int _gridHeightPositive;
    [SerializeField] int _gridWidthNegative;
    [SerializeField] int _gridHeightNegative;
    [SerializeField] float _spacing = 1.12f;

    [Button]
    private void CreateGrid()
    {
        var parentObject = new GameObject();
        parentObject.name = "Barracks";

        for (int i = 0; i < _gridHeightPositive; i++)
        {
            for (int j = 0; j < _gridWidthPositive; j++)
            {
                var block = Instantiate(_barracksMaterial, new Vector3((_gridHeightPositive - i) * _spacing - 0.56f, (_gridWidthPositive - j) * _spacing - 0.56f, -2), Quaternion.identity, parentObject.transform);
            }
        }

        for (int i = _gridHeightNegative; i < 0; i++)
        {
            for (int j = _gridWidthNegative; j < 0; j++)
            {
                var block = Instantiate(_barracksMaterial, new Vector3((_gridHeightNegative - i) * _spacing - 0.56f, (_gridWidthNegative - j) * _spacing - 0.56f, -2), Quaternion.identity, parentObject.transform);
            }
        }

        for (int i = 0; i < _gridHeightPositive; i++)
        {
            for (int j = _gridWidthNegative; j < 0; j++)
            {
                var block = Instantiate(_barracksMaterial, new Vector3((_gridHeightPositive - i) * _spacing - 0.56f, (_gridWidthNegative - j) * _spacing - 0.56f, -2), Quaternion.identity, parentObject.transform);
            }
        }

        for (int i = _gridHeightNegative; i < 0; i++)
        {
            for (int j = 0; j < _gridWidthPositive; j++)
            {
                var block = Instantiate(_barracksMaterial, new Vector3((_gridHeightNegative - i) * _spacing - 0.56f, (_gridWidthPositive - j) * _spacing - 0.56f, -2), Quaternion.identity, parentObject.transform);
            }
        }
    }
}
