using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_OccupantType
{
    Base,
    Blocking,
    Tower,
    Wall,
    Default
}

public class TileBase : MonoBehaviour {

    public bool IsOccupied;
    public E_OccupantType OccupantType;
    public bool IsAvailabe;
    public float TileCost;
}
