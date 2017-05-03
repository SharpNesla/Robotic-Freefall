using System;
using UnityEngine;

namespace Code.Generic.LandscapeBuilder
{
    public class Core<TCell, TCoordinate, TStorage> where TCell : Cell
    {
        protected readonly Func<TCoordinate,TCell> CellInitializer;
        protected readonly IModifier<TCell, TStorage>[] Modifiers;

        public Core(Func<TCoordinate,TCell> cellInitializer,
            params IModifier<TCell, TStorage>[] modifiers)
        {
            CellInitializer = cellInitializer;
            Modifiers = modifiers;
        }

        public void ApplyToStorage(TCell cell, TStorage storage)
        {
            for (var index = 0; index < Modifiers.Length; index++)
            {
                Modifiers[index].ApplyToStorage(cell, storage);
            }
        }

        public TCell GetCell(TCoordinate coordinates)
        {
            var i = ApplyModifiers(CellInitializer(coordinates));
            return i;
        }

        protected TCell ApplyModifiers(TCell cell)
        {
            for (var index = 0; index < Modifiers.Length; index++)
            {
                Modifiers[index].Callback(cell);
            }
            return cell;
        }
    }
}
