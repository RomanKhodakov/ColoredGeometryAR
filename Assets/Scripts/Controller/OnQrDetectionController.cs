using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ColoredGeometry
{
    internal sealed class OnQrDetectionController
    {
        private readonly int _width = Screen.width;
        private readonly int _height = Screen.height;
        private readonly Image _backgroundImage;
        private readonly List<GameObject> _figuresGO;
        private readonly List<Material> _figuresMaterials;
        private readonly OnQrRecognizeController _onQrRecognizeController;
        private readonly Camera _mailCamera;
        private readonly RenderTexture _renderTexture;

        public OnQrDetectionController(List<GameObject> figuresGO, List<Material> figuresMaterials, Image backgroundImage)
        {
            _figuresGO = figuresGO;
            _figuresMaterials = figuresMaterials;
            _backgroundImage = backgroundImage;
            _mailCamera = Camera.main.GetComponent<Camera>();
            _renderTexture = new RenderTexture(_width, _height, 24);
            _onQrRecognizeController = new OnQrRecognizeController();
        }

        public void OnRecognizeFigure(int figureIndex)
        {
            _onQrRecognizeController.GetScreenshot(_mailCamera, _renderTexture);
            _onQrRecognizeController.SetFigureColor(_figuresMaterials[figureIndex]);
            _onQrRecognizeController.SetActiveObjects(_figuresGO[figureIndex], _backgroundImage);
        }

        public void OnLoss(int figureIndex)
        {
            _figuresGO[figureIndex].SetActive(false);
            _backgroundImage.gameObject.SetActive(false);
        }
    }
}