using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public interface IAssetProvider : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 position);
    }
}