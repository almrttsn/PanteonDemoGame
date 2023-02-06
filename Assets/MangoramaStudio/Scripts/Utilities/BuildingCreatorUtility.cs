using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingTypes
{
    Barracks, PowerPlant
}

public class BuildingCreatorUtility : MonoBehaviour
{
    [SerializeField] private BlockBehaviour _buildingMaterial;
    [SerializeField] float _spacing = 1.12f;
    private int _positiveWidthAmount;
    private int _negativeWidthAmount;
    private int _positiveHeightAmount;
    private int _negativeHeightAmount;
    private GameObject _instantiatedBuilding;

    public void BuildBarracks() //for button
    {
        CreateBuilding(BuildingTypes.Barracks);
    }
    public void BuildPowerPlant() //for button
    {
        CreateBuilding(BuildingTypes.PowerPlant);
    }

    //private void Update()
    //{
    //    if (_instantiatedBuilding != null)
    //    {
    //        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        _instantiatedBuilding.transform.position = new Vector2(cursorPos.x, cursorPos.y);
    //        Debug.Log(_instantiatedBuilding.transform.position);
    //    }
    //}

    public void CreateBuilding(BuildingTypes buildingType)
    {
        var parentObject = new GameObject();
        parentObject.name = buildingType.ToString();
        if (buildingType == BuildingTypes.Barracks)
        {
            parentObject.AddComponent<BarracksBehaviour>();
            _positiveWidthAmount = 4;
            _negativeWidthAmount = 4;
            _positiveHeightAmount = 4;
            _negativeHeightAmount = 4;

        }
        else if (buildingType == BuildingTypes.PowerPlant)
        {
            parentObject.AddComponent<PowerPlantBehaviour>();
            _positiveWidthAmount = 2;
            _negativeWidthAmount = 2;
            _positiveHeightAmount = 3;
            _negativeHeightAmount = 3;
        }

        for (int i = 0; i < _positiveHeightAmount; i++)
        {
            for (int j = 0; j < _positiveWidthAmount; j++)
            {
                var block = Instantiate(_buildingMaterial, new Vector3((_positiveHeightAmount - i) * _spacing - 0.56f, (_positiveWidthAmount - j) * _spacing - 0.56f, -2), Quaternion.identity, parentObject.transform);
            }
        }

        for (int i = _negativeHeightAmount; i < 0; i++)
        {
            for (int j = _negativeWidthAmount; j < 0; j++)
            {
                var block = Instantiate(_buildingMaterial, new Vector3((_negativeHeightAmount - i) * _spacing - 0.56f, (_negativeWidthAmount - j) * _spacing - 0.56f, -2), Quaternion.identity, parentObject.transform);
            }
        }

        for (int i = 0; i < _positiveHeightAmount; i++)
        {
            for (int j = _negativeWidthAmount; j < 0; j++)
            {
                var block = Instantiate(_buildingMaterial, new Vector3((_positiveHeightAmount - i) * _spacing - 0.56f, (_negativeWidthAmount - j) * _spacing - 0.56f, -2), Quaternion.identity, parentObject.transform);
            }
        }

        for (int i = _negativeHeightAmount; i < 0; i++)
        {
            for (int j = 0; j < _positiveWidthAmount; j++)
            {
                var block = Instantiate(_buildingMaterial, new Vector3((_negativeHeightAmount - i) * _spacing - 0.56f, (_positiveWidthAmount - j) * _spacing - 0.56f, -2), Quaternion.identity, parentObject.transform);
            }
        }
        //parentObject = _instantiatedBuilding;
        //Debug.Log(_instantiatedBuilding.ToString());
    }
}
