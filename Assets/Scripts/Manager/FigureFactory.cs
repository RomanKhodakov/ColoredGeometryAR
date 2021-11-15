using System.Collections.Generic;
using UnityEngine;

namespace ColoredGeometry
{
    internal sealed class FigureFactory
    {
        private readonly List<BaseData> _baseDates;
        private readonly List<GameObject> _figuresGO;
        private readonly List<Material> _figureMaterials;

        public FigureFactory(List<BaseData> baseDates)
        {
            _baseDates = baseDates;
            _figuresGO = new List<GameObject>(4);
            _figureMaterials = new List<Material>(4);
        }

        public List<GameObject> GetFiguresGO()
        {
            foreach (var baseData in _baseDates)
            {
                _figuresGO.Add(baseData.figureGO);
            }

            return _figuresGO;
        }

        public List<Material> GetFiguresMaterials()
        {
            foreach (var baseData in _baseDates)
            {
                _figureMaterials.Add(baseData.figureMaterial);
            }

            return _figureMaterials;
        }
    }
}