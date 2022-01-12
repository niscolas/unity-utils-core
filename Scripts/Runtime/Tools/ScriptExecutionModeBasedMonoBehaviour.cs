using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [ExecuteAlways]
    public abstract class ScriptExecutionModeBasedMonoBehaviour : CachedMonoBehaviour
    {
        [SerializeField]
        private ScriptExecutionMode _executionMode = ScriptExecutionMode.All;

        protected override void Awake()
        {
            base.Awake();

            if (CheckShouldRun())
            {
                Inner_Awake();
            }
        }

        protected bool CheckShouldRun()
        {
            bool result = false;

            if (_executionMode.HasFlag(ScriptExecutionMode.EditMode))
            {
                result = ApplicationUtility.IsEditMode();
            }

            if (_executionMode.HasFlag(ScriptExecutionMode.PlayMode))
            {
                result = result || ApplicationUtility.IsEditorPlayMode();
            }

            if (_executionMode.HasFlag(ScriptExecutionMode.Player))
            {
                result = result || ApplicationUtility.IsPlayer();
            }

            return result;
        }

        protected virtual void Inner_Awake() { }

        protected virtual void Inner_OnEnable() { }

        protected virtual void Inner_Start() { }

        protected virtual void Inner_Update() { }

        protected virtual void Inner_FixedUpdate() { }

        protected virtual void Inner_LateUpdate() { }

        protected virtual void Inner_OnDisable() { }

        protected virtual void Inner_OnDestroy() { }

        private void Start()
        {
            if (CheckShouldRun())
            {
                Inner_Start();
            }
        }

        private void Update()
        {
            if (CheckShouldRun())
            {
                Inner_Update();
            }
        }

        private void FixedUpdate()
        {
            if (CheckShouldRun())
            {
                Inner_FixedUpdate();
            }
        }

        private void LateUpdate()
        {
            if (CheckShouldRun())
            {
                Inner_LateUpdate();
            }
        }

        private void OnEnable()
        {
            if (CheckShouldRun())
            {
                Inner_OnEnable();
            }
        }

        private void OnDisable()
        {
            if (CheckShouldRun())
            {
                Inner_OnDisable();
            }
        }

        private void OnDestroy()
        {
            if (CheckShouldRun())
            {
                Inner_OnDestroy();
            }
        }
    }
}