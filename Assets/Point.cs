using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point
{
    private Vector3 _coord;

    public Point(float x, float z)
    {
        _coord = new Vector3(x, 0, z);
    }
    
    public Point(Vector3 coord)
    {
        _coord = coord;
    }

    public Vector3 GetVector3()
    {
        return _coord;
    }
}
