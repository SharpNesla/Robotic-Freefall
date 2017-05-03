using UnityEngine;

namespace Code.Generic.LandscapeBuilder.UnityBind
{
    public class Chunk : MonoBehaviour
    {
        public int Position;
        public Storage Store;
        public ChunkedGenerator Parent;
        private Cell _leftCorner, _rightCorner;

        public void Start()
        {
            Store = new Storage(1f);
            gameObject.GetComponent<MeshFilter>().mesh = Store.Mesh;
            Refresh();
            //gameObject.AddComponent<PolygonCollider2D>().points;
        }

        public void Refresh()
        {
            gameObject.transform.position = new Vector3(Position * 1f,0, -1);
            Store.Refresh(Parent.Core.GetCell(Position).Height,
                Parent.Core.GetCell(Position + 1).Height);
        }
    }
}