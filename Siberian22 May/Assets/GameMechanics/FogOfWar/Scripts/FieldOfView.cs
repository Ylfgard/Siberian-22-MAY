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
        private float fov;
        [SerializeField] [Range (1, 200)]
        private int rayCount;
        [SerializeField] [Range (1, 15)]
        float viewDistance;
        private Vector3 origin;
        [SerializeField]
        private Transform _transform;
        private Mesh _mesh;
        
        private void Awake()
        {
            _mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = _mesh; 
        }
        
        private void LateUpdate()
        {
            float angle = 0f;
            float angleIncrease = fov / rayCount;
            origin = _transform.position;

            Vector3[] vertices = new Vector3[rayCount + 1 + 1];
            Vector2[] uv = new Vector2[vertices.Length];
            int[] triangles = new int[rayCount * 3];
            
            vertices[0] = origin;

            int vertexIndex = 1;
            int triangleIndex = 0;
            for (int i = 0; i <= rayCount; i++)
            {
                Vector3 vertex;
                
                RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, _obstacleLayers);
                if(raycastHit2D.collider == null)
                    vertex = origin + GetVectorFromAngle(angle) * viewDistance;
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

        private Vector3 GetVectorFromAngle(float angle)
        {
            float angleRad = angle * (Mathf.PI / 180f);
            return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
        }
    }
}