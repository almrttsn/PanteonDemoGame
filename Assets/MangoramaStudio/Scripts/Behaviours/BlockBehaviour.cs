using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StartRaycasting();
        }
    }

    private void StartRaycasting()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.black);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
