using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    public int Row { get; set; }
    public int Column { get; set; }
    //public BlockBehaviour CurrentBlockBehaviour { get; set; }
    public bool IsOccupied;
}
