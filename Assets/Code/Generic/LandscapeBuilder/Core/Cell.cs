using System.Collections.Generic;
using Code.Generic.LandscapeBuilder.UnityBind;
using NUnit.Framework;

namespace Code.Generic.LandscapeBuilder
{
    public enum Side
    {
        Left, Right
    }

    public class Cell
    {
        public float Height;
        public readonly int Position;
        public Side Side;
        public List<IModifier<Cell, Storage>> Modifiers;
        public Cell(int position)
        {
            Position = position;
        }
    }
}