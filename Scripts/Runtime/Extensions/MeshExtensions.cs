using UnityEngine;

namespace niscolas.UnityUtils.Core.Extensions
{
    public static class MeshExtensions
    {
        public static int GetRandomIndex(this Mesh mesh)
        {
            return Random.Range(0, mesh.vertexCount - 1);
        }
    }
}