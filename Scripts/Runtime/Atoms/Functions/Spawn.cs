using niscolas.UnityUtils;
using Sirenix.OdinInspector;
using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityAtoms.Tags;
using UnityEngine;

namespace UnityUtils
{
	[CreateAssetMenu(menuName = AtomsConstants.ActionsCreateAssetMenuPath + "(GameObject) => Spawn")]
	public class Spawn : AtomFunction<GameObject, GameObject>
	{
		[SerializeField]
		private GameObjectReference _prefab;

		[SerializeField]
		private SpawnStrategy _strategy;

		[Title("Despawn")]
		[SerializeField]
		private bool _autoDespawn;

		[ShowIf(nameof(_autoDespawn))]
		[SerializeField]
		private DespawnStrategy _despawnStrategy;

		[ShowIf(nameof(_autoDespawn))]
		[SerializeField]
		private FloatReference _despawnDelay;

		[Title("Parent")]
		[SerializeField]
		private StringConstant _parentTag;

		[SerializeField]
		private bool _worldPositionStays;

		[Title("Position and Rotation")]
		[SerializeField]
		private bool _overwritePosition;

		[ShowIf(nameof(_overwritePosition))]
		[SerializeField]
		private Vector3Reference _position;

		[SerializeField]
		private bool _overwriteRotation;

		[ShowIf(nameof(_overwriteRotation))]
		[SerializeField]
		private QuaternionReference _rotation;

		public override GameObject Call(GameObject gameObjectPositionReference)
		{
			return DoSpawn(gameObjectPositionReference.transform);
		}

		public GameObject Call()
		{
			return DoSpawn();
		}

		public void Do()
		{
			Call();
		}

		public void Do(GameObject gameObjectPositionReference)
		{
			Call(gameObjectPositionReference);
		}

		private GameObject DoSpawn(Transform transformReference = null)
		{
			if (!_strategy)
			{
				return default;
			}

			Transform parent = FindParent();
			Vector3 computedPosition = ComputePosition(transformReference);
			Quaternion computedRotation = ComputeRotation();

			GameObject instance = _strategy.Spawn(_prefab.Value, computedPosition, computedRotation);
			if (parent)
			{
				instance.transform.SetParent(parent, _worldPositionStays);
			}

			if (_autoDespawn && _despawnStrategy)
			{
				_despawnStrategy.Despawn(instance, _despawnDelay);
			}

			return instance;
		}

		private Vector3 ComputePosition(Transform transformReference = null)
		{
			Vector3 position = default;

			if (!transformReference || _overwritePosition)
			{
				position = _position.Value;
			}
			else
			{
				if (transformReference)
				{
					position = transformReference.position;
				}
			}

			return position;
		}

		private Quaternion ComputeRotation(Transform transformReference = null)
		{
			Quaternion rotation = default;

			if (!transformReference || _overwriteRotation)
			{
				rotation = _rotation.Value;
			}
			else
			{
				if (transformReference)
				{
					rotation = transformReference.rotation;
				}
			}

			return rotation;
		}

		private Transform FindParent()
		{
			Transform parent = null;

			if (_parentTag)
			{
				GameObject parentGameObject = AtomTags.FindByTag(_parentTag.Value);
				if (parentGameObject)
				{
					parent = parentGameObject.transform;
				}
			}

			return parent;
		}
	}
}