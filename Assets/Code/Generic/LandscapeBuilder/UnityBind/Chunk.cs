using UnityEngine;

namespace Code.Generic.LandscapeBuilder.UnityBind
{
    public class Chunk : MonoBehaviour
    {
        public int Position;
        public Mesh Mesh;
        private int[] _triangles;
        public ChunkedGenerator Parent;
        private Vector3[] _vertices;
        private Cell _leftCorner, _rightCorner;

        public void Start()
        {
            Mesh = new Mesh();
            gameObject.GetComponent<MeshFilter>().mesh = Mesh;
            _vertices = new Vector3[4];
            _triangles = new int[6];
            Refresh();
        }

        public void Refresh()
        {
            RefreshMesh();
        }

        public void RefreshMesh()
        {
            _vertices[0] = new Vector3(0, -11, -1);
            _vertices[1] = new Vector3(1, -11, -1);
            _vertices[2] = new Vector3(0, 1, -1);
            _vertices[3] = new Vector3(1, 1, -1);

            _triangles[0] = 0;
            _triangles[1] = 2;
            _triangles[2] = 1;

            _triangles[3] = 2;
            _triangles[4] = 3;
            _triangles[5] = 1;

            Mesh.vertices = _vertices;
            Mesh.triangles = _triangles;
        }
    }
}