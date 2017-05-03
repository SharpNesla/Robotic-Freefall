using Code.Generic.LandscapeBuilder.UnityBind;
using UnityEngine;

namespace Code.Generic.LandscapeBuilder.Modifiers
{
    public class CliffPlacer: MonoBehaviour, IModifier<Cell, Storage>
    {
        public GameObject[] Cliff;
        public void Start()
        {

        }
        public void ApplyToStorage(Cell current, Storage storage)
        {
            storage.Cliff.Add(Instantiate(Cliff[Random.Range(0, Cliff.Length)]));
        }
        public void Callback(Cell current)
        {

        }
    }
}