using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FogOfWar
{
    public class FieldOfView : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _obstacleLayers; 
        [SerializeField] [Range (1, 360)]
        private float _fov;
        [SerializeField] [Range (1, 200)]
        private int _rayCount;
        [SerializeField] [Range (1, 50)]
        float viewDistance;
        private Vector3 _origin;
        [SerializeField]
        private Transform _transform;
        private Mesh _mesh;
        private int _counter;
        private MeshFilter _meshFilter;

        public void SetOrigin(Transform transf)
        {
            _transform = transf;
        }
        
        private void Start()
        {
            _mesh = new Mesh();
            _meshFilter = GetComponent<MeshFilter>();
            _meshFilter.mesh = _mesh; 
            _counter = 0;
        }
        
        private void LateUpdate()
        {
            if(_counter >= 40) GenerateNewMesh();
            else _counter++;
            
            float angle = 0f;
            float angleIncrease = _fov / _rayCount;
            if(_transform == null) return;
            _origin = _transform.position;

            Vector3[] vertices = new Vector3[_rayCount + 1 + 1];
            Vector2[] uv = new Vector2[vertices.Length];
            int[] triangles = new int[_rayCount * 3];

            vertices[0] = _origin;

            int vertexIndex = 1;
            int triangleIndex = 0;
            for (int i = 0; i <= _rayCount; i++)
            {
                Vector3 vertex;
                
                RaycastHit2D raycastHit2D = Physics2D.Raycast(_origin, GetVectorFromAngle(angle), viewDistance, _obstacleLayers);
                if(raycastHit2D.collider == null)
                    vertex = _origin + GetVectorFromAngle(angle) * viewDistance;
                else
                    vertex = raycastHit2D.point;
                vertices[vertexIndex] = vertex;

                if(i > 0)
                {
                    triangles[triangleIndex + 0] = 0;
                    triangles[triangleIndex + 1] = vertexIndex - 1;
                    triangles[triangleIndex + 2] = vertexIndex;

                    triangleIndex += 3;
                }

                vertexIndex++;
                angle -= angleIncrease;
            }
            
            _mesh.vertices = vertices;
            _mesh.uv = uv;
            _mesh.triangles = triangles;
        }

        private void GenerateNewMesh()
        {
            _mesh = new Mesh();
            _meshFilter.mesh = _mesh;
            _counter = 0;
        }

        private Vector3 GetVectorFromAngle(float angle)
        {
            float angleRad = angle * (Mathf.PI / 180f);
            return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
        }
    }
}