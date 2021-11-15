using UnityEngine;
using UnityEngine.UI;

namespace ColoredGeometry
{
    internal sealed class OnQrRecognizeController
    {
        private const int MAX_LOOP_COUNT = 100;
        private const float GRAYSCALE_TRASHOLD = 0.5f;
        private const float COLOR_TRASHOLD = 0.5f;
        private readonly int _width = Screen.width;
        private readonly int _height = Screen.height;
        private Texture2D _screenshotTexture2D;
        private Color _pixelColor;
        private int _currentLoopCount;

        public void GetScreenshot(Camera mailCamera, RenderTexture renderTexture)
        {
            mailCamera.targetTexture = renderTexture;
            RenderTexture.active = renderTexture;
            mailCamera.Render();
            _screenshotTexture2D = new Texture2D(_width, _height, TextureFormat.RGB24, false);
            _screenshotTexture2D.ReadPixels(new Rect(0, 0, _width, _height), 0, 0);
            _screenshotTexture2D.Apply();
            RenderTexture.active = null;
            mailCamera.targetTexture = null;
        }

        public void SetFigureColor(Material figureMaterial)
        {
            _pixelColor = _screenshotTexture2D.GetPixel(_width / 2, _height / 2);

            while (IsWhiteColor())
            {
                _pixelColor = _screenshotTexture2D.GetPixel(_width / 2, _height / 2 +
                                                                        (_currentLoopCount % 2 == 0
                                                                            ? _currentLoopCount
                                                                            : -_currentLoopCount));
                _currentLoopCount++;
            }

            _currentLoopCount = 0;
            figureMaterial.color = _pixelColor;
        }

        private bool IsWhiteColor()
        {
            return _pixelColor.grayscale > GRAYSCALE_TRASHOLD && _pixelColor.r > COLOR_TRASHOLD 
                                                              && _pixelColor.b > COLOR_TRASHOLD
                                                              && _currentLoopCount < MAX_LOOP_COUNT;
        }

        public void SetActiveObjects(GameObject figureGO, Image backgroundImage)
        {
            figureGO.SetActive(true);
            backgroundImage.gameObject.SetActive(true);
        }
    }
}
