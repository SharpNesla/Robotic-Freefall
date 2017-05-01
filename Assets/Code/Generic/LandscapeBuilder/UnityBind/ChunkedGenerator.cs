using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Generic.LandscapeBuilder.UnityBind
{
    public class ChunkedGenerator : MonoBehaviour
    {
        private List<Chunk> _chunks;

        public int CurrentChunkPosition;
        public GameObject ChunkPrefab;
        public int ViewDistance;

        public Core<Cell, int, Chunk> Core;
        private List<Chunk> _refreshingChunks;
        private List<int> _refreshingPositions;

        public void Start()
        {
            var modifiers = Array.FindAll(
                gameObject.GetComponents<IModifier<Cell, Chunk>>(),
                modifier => ((MonoBehaviour) modifier).enabled);

            _chunks = CreateChunks();

            Core = new Core<Cell, int, Chunk>(x => new Cell(), modifiers);

            _refreshingChunks = new List<Chunk>();
            _refreshingPositions = new List<int>();
        }

        public List<Chunk> CreateChunks()
        {
            var chunks = new List<Chunk>(ViewDistance * 2 + 1);
            for (var i = -ViewDistance; i < ViewDistance; i++)
            {
                var @object = Instantiate(ChunkPrefab);
                var chunkComponent = @object.GetComponent<Chunk>();
                chunkComponent.Position = i;
                chunkComponent.Parent = this;
                chunks.Add(chunkComponent);
            }
            return chunks;
        }

        public void RefreshChunks()
        {
            _refreshingChunks.AddRange(_chunks);
            _refreshingPositions.Clear();
            for (var i = -ViewDistance + CurrentChunkPosition;
                i < ViewDistance + CurrentChunkPosition;
                i++)
            {
                var current = _refreshingChunks.Find(x => x.Position == i);
                if (current != null)
                {
                    _refreshingChunks.Remove(current);
                }
                else
                {
                    _refreshingPositions.Add(i);
                }
            }

            for (int i = 0; i < _refreshingPositions.Count; i++)
            {
                _refreshingChunks[i].Position = _refreshingPositions[i];
                _refreshingChunks[i].Refresh();
            }
            _refreshingChunks.Clear();
            _refreshingPositions.Clear();
        }
    }
}