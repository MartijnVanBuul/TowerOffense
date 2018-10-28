using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour {

	public static E_Direction DetermineDirection(Vector3 direction)
    {
        if (direction.x > Mathf.Sqrt(2) / 2)
            return E_Direction.Right;
        else if (direction.x < -Mathf.Sqrt(2) / 2)
            return E_Direction.Left;
        else if (direction.z > Mathf.Sqrt(2) / 2)
            return E_Direction.Up;
        else if (direction.z < -Mathf.Sqrt(2) / 2)
            return E_Direction.Down;
        else if (direction.x > 0 && direction.z > 0)
            return E_Direction.UpRight;
        else if (direction.x > 0 && direction.z < 0)
            return E_Direction.DownRight;
        else if (direction.x < 0 && direction.z > 0)
            return E_Direction.UpLeft;
        else if (direction.x < 0 && direction.z < 0)
            return E_Direction.DownLeft;
        else
            return E_Direction.Undetermined;
    }
}
