using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class Utils
{
    public static Vector3 Vec2To3(Vector2 inputVector)
    {
        return new Vector3(inputVector.x, inputVector.y, 0);
    }
}

