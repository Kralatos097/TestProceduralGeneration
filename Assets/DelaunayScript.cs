using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class DelaunayScript : MonoBehaviour
{
    public Transform Map;

    private List<Transform> _roomList = new List<Transform>();
    private List<Triangle> _triangleList = new List<Triangle>();

    // Start is called before the first frame update
    void Start()
    {
        float maxX = 0, minX = 0, maxY = 0, minY = 0;
        foreach (Transform room in Map)
        {
            _roomList.Add(room);

            if (room.position.x < minX)
            {
                minX = room.position.x;
            }
            else if (room.position.x > maxX)
            {
                maxX = room.position.x;
            }
            if (room.position.y < minY)
            {
                minY = room.position.y;
            }
            else if (room.position.y > maxY)
            {
                maxY = room.position.y;
            }
        }

        _triangleList.Add(GenerateSupraTriangle(maxX, maxY));
    }
    
    private Triangle GenerateSupraTriangle(float maxX, float maxY)
    {
        float margin = 500;
        Point point1 = new Point(0.5f * maxX, -2 * maxX - margin);
        Point point2 = new Point(-2 * maxY - margin, 2 * maxY + margin);
        Point point3 = new Point(2 * maxX + maxY + margin, 2 * maxY + margin);
        return new Triangle(point1, point2, point3);
    }

    /*public void AffTriangle(Triangle triangle)
    {
        Point[] points = triangle.GetPoints();
    }*/

    private void OnDrawGizmos()
    {
        Debug.Log("ddddddddddd");
        Gizmos.color = Color.red;
        
        Gizmos.DrawCube(Vector3.zero, Vector3.one);
        
        Gizmos.DrawLine(_triangleList[0].GetPoints()[0].GetVector3(), _triangleList[0].GetPoints()[1].GetVector3());
        Gizmos.DrawLine(_triangleList[0].GetPoints()[0].GetVector3(), _triangleList[1].GetPoints()[2].GetVector3());
        Gizmos.DrawLine(_triangleList[0].GetPoints()[0].GetVector3(), _triangleList[0].GetPoints()[2].GetVector3());

    }
}
