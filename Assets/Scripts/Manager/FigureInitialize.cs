using System.Collections.Generic;
using UnityEngine;

namespace ColoredGeometry
{
    internal sealed class FigureInitialize
    {
        private readonly List<GameObject> _figureGO;
        private readonly List<GameObject> _figuresInstances;
        private readonly List<IQrView> _qrViews;
        private readonly List<Material> _figureMaterials;


        public FigureInitialize(FigureFactory figureFactory, List<IQrView> qrViews)
        {
            _figureGO = figureFactory.GetFiguresGO();
            _figureMaterials = figureFactory.GetFiguresMaterials();
            _qrViews = qrViews;
            _figuresInstances = new List<GameObject>(4);
            Initialize();
        }

        public void Initialize()
        {
            for (int index = 0; index < _figureGO.Count; index++)
            {
                _figuresInstances.Add(Object.Instantiate(_figureGO[index], _qrViews[index].QrTransform));
            }
        }

        public List<GameObject> GetFiguresInstance() => _figuresInstances;
        public List<Material> GetFiguresMaterials() => _figureMaterials;
    }
}