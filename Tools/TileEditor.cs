#if UNITY_EDITOR
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityExtensions;

namespace RoadModule
{
	public class TileEditor : MonoBehaviour
	{
		[OnValueChanged(nameof(UpdateMesh))]
		[FormerlySerializedAs("_size"), SerializeField]
		private Vector3Int _quantity;

		[OnValueChanged(nameof(UpdateMesh))]
		[SerializeField]
		private GameObject _tile;

		[OnValueChanged(nameof(UpdateTilesPositions))]
		[FormerlySerializedAs("_tileSize"), SerializeField]
		private Vector3 _offset;

		[OnValueChanged(nameof(UpdateTilesPositions))]
		[SerializeField]
		private bool _forceUnpack;

		[Header("Debug")]
		[ReadOnly]
		[SerializeField]
		private GameObject[] _tiles;

		[Button]
		private void UpdateMesh()
		{
			Clear();

			_tiles = CreateTiles(_tile, transform.position, _quantity, _offset, transform, _forceUnpack);
		}

		[Button]
		private void UpdateTilesPositions()
		{
			UpdateTilesPositions(_tiles, transform.position, _quantity, _offset);
		}

		public static GameObject[] CreateTiles(
			GameObject tile,
			Vector3 center,
			Vector3Int quantity,
			Vector3 offset,
			Transform parent = null,
			bool forceUnpack = false)
		{
			if (!tile) return default;

			GameObject[] tiles = new GameObject[quantity.x * quantity.y * quantity.z];

			Vector3 gridOffset = ComputeGridOffset(quantity, offset);

			int counter = 0;
			for (int i = 0; i < quantity.x; i++)
			{
				for (int j = 0; j < quantity.y; j++)
				{
					for (int k = 0; k < quantity.z; k++)
					{
						GameObject tileInstance;
						Vector3 position = ComputeTilePosition(i, j, k, center, offset, gridOffset);

						if (tile.IsPartOfPrefab())
						{
							tileInstance = PrefabUtility.InstantiatePrefab(tile, parent) as GameObject;

							if (forceUnpack)
							{
								PrefabUtility.UnpackPrefabInstance(tileInstance, PrefabUnpackMode.Completely,
									InteractionMode.AutomatedAction);
							}

							tileInstance.transform.position = position;
						}
						else
						{
							tileInstance = Instantiate(tile, position, tile.transform.rotation, parent);
						}

						tiles[counter] = tileInstance;
						counter++;
					}
				}
			}

			return tiles;
		}

		public static Vector3 ComputeGridOffset(Vector3Int quantity, Vector3 offset)
		{
			Vector3 result = -(offset.Multiply(quantity - Vector3Int.one) * 0.5f);
			return result;
		}

		public static void UpdateTilesPositions(GameObject[] tiles, Vector3 center, Vector3Int quantity, Vector3 offset)
		{
			Vector3 gridOffset = ComputeGridOffset(quantity, offset);

			int counter = 0;
			for (int i = 0; i < quantity.x; i++)
			{
				for (int j = 0; j < quantity.y; j++)
				{
					for (int k = 0; k < quantity.z; k++)
					{
						tiles[counter].transform.position = ComputeTilePosition(i, j, k, center, offset, gridOffset);
						counter++;
					}
				}
			}
		}

		public static Vector3 ComputeTilePosition(int i, int j, int k, Vector3 center, Vector3 offset, Vector3 gridOffset)
		{
			Vector3 position = center;
			position.x += offset.x * i + gridOffset.x;
			position.y += offset.y * j + gridOffset.y;
			position.z += offset.z * k + gridOffset.z;

			return position;
		}

		[Button]
		private void Clear()
		{
			transform.DestroyChildren();
		}
	}
}
#endif