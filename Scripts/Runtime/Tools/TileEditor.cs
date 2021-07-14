#if UNITY_EDITOR
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using UnityExtensions;
using UnityUtils;

namespace RoadModule
{
	public class TileEditor : MonoBehaviour
	{
		[OnValueChanged(nameof(UpdateEditorMesh))]
		[SerializeField]
		private GameObject[] _baseTiles;

		[ShowIf("@" + nameof(_baseTiles) + ".Length > 1")]
		[SerializeField]
		private MultiTileSpawnType _multiTileSpawnType;

		[OnValueChanged(nameof(UpdateEditorMesh))]
		[FormerlySerializedAs("_size"), SerializeField]
		private Vector3Int _quantity;

		[OnValueChanged(nameof(UpdateEditorTilesPositions))]
		[FormerlySerializedAs("_tileSize"), SerializeField]
		private Vector3 _offset;

		[Header("Debug")]
		[ReadOnly]
		[SerializeField]
		private GameObject[] _existingTiles;

		private static readonly ISpawnService SpawnService = new UnityInstantiateService();

		[ContextMenu(nameof(UpdateEditorMesh))]
		[Button]
		private void UpdateEditorMesh()
		{
			Clear();

			_existingTiles = CreateTiles(
				_baseTiles,
				_multiTileSpawnType,
				_quantity,
				_offset,
				transform);
		}

		[Button]
		private void UpdateEditorTilesPositions()
		{
			UpdateTilesPositions(_existingTiles, _quantity, _offset);
		}

		public static GameObject[] CreateTiles(
			GameObject baseTile,
			Vector3Int quantity,
			Vector3 offset,
			Transform parent = null)
		{
			return CreateTiles(new[] {baseTile}, default, quantity, offset, parent);
		}

		public static GameObject[] CreateTiles(
			GameObject[] baseTiles,
			MultiTileSpawnType multiTileSpawnType,
			Vector3Int quantity,
			Vector3 offset,
			Transform parent = null)
		{
			if (baseTiles.IsNullOrEmpty()) return default;

			GameObject[] tiles = new GameObject[quantity.x * quantity.y * quantity.z];

			Vector3 gridOffset = ComputeGridOffset(quantity, offset);

			int counter = 0;
			for (int i = 0; i < quantity.x; i++)
			{
				for (int j = 0; j < quantity.y; j++)
				{
					for (int k = 0; k < quantity.z; k++)
					{
						GameObject baseTile = ChooseTile(baseTiles, multiTileSpawnType);
						GameObject tileInstance = CreateTile(baseTile, offset, parent, i, j, k, gridOffset);

						tiles[counter] = tileInstance;
						counter++;
					}
				}
			}

			return tiles;
		}

		private static GameObject ChooseTile(GameObject[] baseTiles, MultiTileSpawnType multiTileSpawnType)
		{
			return baseTiles[0];
		}

		private static GameObject CreateTile(
			GameObject tile,
			Vector3 offset,
			Transform parent,
			int i,
			int j,
			int k,
			Vector3 gridOffset)
		{
			Vector3 position = ComputeTilePosition(i, j, k, offset, gridOffset);
			GameObject tileInstance = SpawnService.Spawn(tile, parent);
			tileInstance.transform.localPosition = position;

			// if (tile.IsPartOfPrefab())
			// {
			// 	tileInstance = PrefabUtility.InstantiatePrefab(tile, parent) as GameObject;
			//
			// 	tileInstance.transform.position = position;
			// }
			// else
			// {
			// 	tileInstance = Instantiate(tile, position, tile.transform.rotation, parent);
			// }

			return tileInstance;
		}

		public static Vector3 ComputeGridOffset(Vector3Int quantity, Vector3 offset)
		{
			Vector3 result = -(offset.Multiply(quantity - Vector3Int.one) * 0.5f);
			return result;
		}

		public static void UpdateTilesPositions(GameObject[] tiles, Vector3Int quantity, Vector3 offset)
		{
			Vector3 gridOffset = ComputeGridOffset(quantity, offset);

			int counter = 0;
			for (int i = 0; i < quantity.x; i++)
			{
				for (int j = 0; j < quantity.y; j++)
				{
					for (int k = 0; k < quantity.z; k++)
					{
						tiles[counter].transform.localPosition = ComputeTilePosition(i, j, k, offset, gridOffset);
						counter++;
					}
				}
			}
		}

		public static Vector3 ComputeTilePosition(int i, int j, int k, Vector3 offset, Vector3 gridOffset)
		{
			Vector3 position = new Vector3
			{
				x = offset.x * i + gridOffset.x,
				y = offset.y * j + gridOffset.y,
				z = offset.z * k + gridOffset.z
			};

			return position;
		}

		[Button]
		private void Clear()
		{
			transform.DestroyChildren();
		}

		public enum MultiTileSpawnType
		{
			Alternate,
			Randomize
		}
	}
}
#endif