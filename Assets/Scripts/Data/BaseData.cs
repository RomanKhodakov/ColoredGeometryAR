using UnityEngine;

namespace ColoredGeometry
{
    internal abstract class BaseData : ScriptableObject
    {
        [SerializeField] public GameObject figureGO;
        [SerializeField] public Material figureMaterial;
    }
}