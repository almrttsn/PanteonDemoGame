using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlantBehaviour : MonoBehaviour
{
    private void Start()
    {
        InputController.OnDrag += Drag;
    }

    private void Drag(Vector2 dragVector)
    {        
        transform.position += new Vector3(dragVector.x * 100f, dragVector.y * 100f) * Time.deltaTime;
    }

    private void OnDestroy()
    {
        InputController.OnDrag -= Drag;
    }
}
