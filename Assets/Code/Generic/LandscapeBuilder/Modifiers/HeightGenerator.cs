using System.Collections.Generic;
using Code.Generic.LandscapeBuilder.UnityBind;
using LibNoise.Generator;
using UnityEngine;

namespace Code.Generic.LandscapeBuilder.Modifiers
{
    class HeightGenerator : MonoBehaviour, IModifier<Cell, Storage>
    {
        private Billow _noiseOsc;
        public float NoiseFreq;
        private float _tangent;
        public float Degrees;
        public List<float> MaxHeight;
        public void Start()
        {
            _noiseOsc = new Billow{Frequency = NoiseFreq, OctaveCount = 5,Seed = 34};
            _tangent = Mathf.Tan(Mathf.Deg2Rad * Degrees);
        }


        public void ApplyToStorage(Cell current, Storage storage)
        {

        }

        public void Callback(Cell current)
        {
            current.Height = (float)_noiseOsc.GetValue(current.Position,0f,0f) + 0.3f + current.Position * _tangent;
            MaxHeight.Add((float) _noiseOsc.GetValue(current.Position, 0f, 0f));
        }

    }
}