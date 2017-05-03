using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA;

namespace Code.Generic.LandscapeBuilder.UnityBind
{
    public class Storage
    {
        public Mesh Mesh;
        public List<GameObject> Cliff;
        public readonly Vector3[] Vetices;
        public readonly float Scale;
        private int[] _triangles;
        public Storage(float scale)
        {
            Vetices = new Vector3[4];
            _triangles = new []{0,2,1,2,3,1};
            Scale = scale;
            Mesh = new Mesh
            {
                vertices = Vetices,
                triangles = _triangles
            };

            Refresh(1,1);
        }

        public void Refresh(float right, float left)
        {
            Vetices[0] = new Vector3(-Scale / 2, right - 10);
            Vetices[1] = new Vector3(Scale / 2, right - 10);
            Vetices[2] = new Vector3(-Scale / 2, right);
            Vetices[3] = new Vector3(Scale / 2, left);

            Mesh.vertices = Vetices;
            Mesh.RecalculateBounds();
        }
    }
}