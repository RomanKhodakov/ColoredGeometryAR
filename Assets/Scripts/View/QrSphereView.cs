using UnityEngine;

namespace ColoredGeometry
{
    internal sealed class QrSphereView : MonoBehaviour, IQrView
    {
        private Transform _qrTransform;

        public Transform QrTransform
        {
            get
            {
                if (!_qrTransform) _qrTransform = gameObject.GetComponent<Transform>();
                return _qrTransform;
            }
        }
    }
}