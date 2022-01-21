using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class Triangle
{
    private Point[] _vertices = new Point[3];

    public Triangle(Vector3 a, Vector3 b, Vector3 c)
    {
        _vertices[0] = new Point(a);
        _vertices[1] = new Point(b);
        _vertices[2] = new Point(c);
    }
    
    public Triangle(Point a, Point b, Point c)
    {
        _vertices[0] = a;
        _vertices[1] = b;
        _vertices[2] = c;
    }

    public Point[] GetPoints()
    {
        return _vertices;
    }

    public Vector3 GetOnePoint(int index)
    {
        return _vertices[index].GetVector3();
    }
}
