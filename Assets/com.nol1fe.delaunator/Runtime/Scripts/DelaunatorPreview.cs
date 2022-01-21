using System.Collections.Generic;
using System.Linq;
using DelaunatorSharp;
using DelaunatorSharp.Unity.Extensions;
using UnityEngine;

namespace Runtime.Scripts {
    public class DelaunatorPreview : MonoBehaviour {
        
        [SerializeField] GameObject trianglePointPrefab;

        public List<Transform> Points = new List<Transform>();

        private List<IPoint> points = new List<IPoint>();
        private GameObject meshObject;

        private Delaunator _delaunator;

        private Transform PointsContainer;
        private Transform HullContainer;
        private Transform VoronoiContainer;
        private Transform TrianglesContainer;

        [SerializeField] float triangleEdgeWidth = .01f;
        [SerializeField] Color triangleEdgeColor = Color.black;
        [SerializeField] Material lineMaterial;
        [SerializeField] bool drawTrianglePoints = true;
        [SerializeField] bool drawTriangleEdges = true;

        private void Update() {
            List<Vector2> sampler = new List<Vector2>();
            foreach (Transform point in Points) {
                sampler.Add(point.position);
            }
            points = sampler.Select(point => new Vector2(point.x, point.y)).ToPoints().ToList();
            Create();
        }

        private void Create() {
            if (points.Count < 3) return;
            Clear();
            _delaunator = new Delaunator(points.ToArray());
            CreateTriangle();
            
            List<IEdge> edges = _delaunator.GetEdges().ToList();
            float[,] delaunay = new float[Points.Count,Points.Count];
            TriBulle(edges);
            foreach (IEdge edge in edges) {
                //A vous de jouer !
                
                
            }
        }

        private void TriBulle(List<IEdge> table)
        {
            int n = table.Count-1;
            for ( int i = n; i>=1; i--)
            for (int j = 2; j <= i; j++)
            {
                float distj = Vector2.Distance(table[j].P.ToVector2(),table[j].Q.ToVector2());
                float distjBis = Vector2.Distance(table[j - 1].P.ToVector2(), table[j - 1].Q.ToVector2());
                
                if (distjBis > distj)
                {
                    IEdge temp = table[j-1];
                    table[j-1] = table[j];
                    table[j] = temp;
                }
            }
        }

        private void Clear() {
            CreateNewContainers();

            if (meshObject != null)
            {
                Destroy(meshObject);
            }

            _delaunator = null;
        }

        private void CreateTriangle() {
            if (_delaunator == null) return;

            _delaunator.ForEachTriangleEdge(edge =>
            {
                if (drawTriangleEdges)
                {
                    CreateLine(TrianglesContainer, $"TriangleEdge - {edge.Index}", new Vector3[] { edge.P.ToVector3(), edge.Q.ToVector3() }, triangleEdgeColor, triangleEdgeWidth, 0);
                }

                if (drawTrianglePoints)
                {
                    var pointGameObject = Instantiate(trianglePointPrefab, PointsContainer);
                    pointGameObject.transform.SetPositionAndRotation(edge.P.ToVector3(), Quaternion.identity);
                }
            });
        }

        private void CreateLine(Transform container, string name, Vector3[] points, Color color, float width, int order = 1) {
            var lineGameObject = new GameObject(name);
            lineGameObject.transform.parent = container;
            var lineRenderer = lineGameObject.AddComponent<LineRenderer>();

            lineRenderer.SetPositions(points);

            lineRenderer.material = lineMaterial ?? new Material(Shader.Find("Standard"));
            lineRenderer.startColor = color;
            lineRenderer.endColor = color;
            lineRenderer.startWidth = width;
            lineRenderer.endWidth = width;
            lineRenderer.sortingOrder = order;
        }

        private void CreateNewContainers() {
            CreateNewPointsContainer();
            CreateNewTrianglesContainer();
            CreateNewVoronoiContainer();
            CreateNewHullContainer();
        }

        private void CreateNewPointsContainer() {
            if (PointsContainer != null)
            {
                Destroy(PointsContainer.gameObject);
            }

            PointsContainer = new GameObject(nameof(PointsContainer)).transform;
        }

        private void CreateNewTrianglesContainer() {
            if (TrianglesContainer != null)
            {
                Destroy(TrianglesContainer.gameObject);
            }

            TrianglesContainer = new GameObject(nameof(TrianglesContainer)).transform;
        }

        private void CreateNewHullContainer() {
            if (HullContainer != null)
            {
                Destroy(HullContainer.gameObject);
            }

            HullContainer = new GameObject(nameof(HullContainer)).transform;
        }

        private void CreateNewVoronoiContainer() {
            if (VoronoiContainer != null)
            {
                Destroy(VoronoiContainer.gameObject);
            }

            VoronoiContainer = new GameObject(nameof(VoronoiContainer)).transform;
        }
    }
}