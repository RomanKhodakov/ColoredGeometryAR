using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ColoredGeometry
{
    internal sealed class OnQrRecognize : MonoBehaviour
    {
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private List<BaseData> _baseDates;
        [SerializeField] private QrCubeView _qrCubeView;
        [SerializeField] private QrSphereView _qrSphereView;
        [SerializeField] private QrPyramidView _qrPyramidView;
        private readonly List<IQrView> _qrViews = new List<IQrView>();
        private OnQrDetectionController _onQrDetectionController;
        private List<GameObject> _figuresGO;
        private List<Material> _figuresMaterials;


        public void Awake()
        {
            _qrViews.Add(_qrCubeView);
            _qrViews.Add(_qrSphereView);
            _qrViews.Add(_qrPyramidView);
            var figureFactory = new FigureFactory(_baseDates);
            var figureInitialize = new FigureInitialize(figureFactory, _qrViews);
            _figuresGO = figureInitialize.GetFiguresInstance();
            _figuresMaterials = figureInitialize.GetFiguresMaterials();
            _onQrDetectionController = new OnQrDetectionController(_figuresGO, _figuresMaterials, _backgroundImage);
        }

        public void OnRecognizeFigure(int figureIndex)
        {
            _onQrDetectionController.OnRecognizeFigure(figureIndex);
        }

        public void OnLoss(int figureIndex)
        {
            _onQrDetectionController.OnLoss(figureIndex);
        }
    }
}