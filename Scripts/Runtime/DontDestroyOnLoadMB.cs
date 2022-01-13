using System.Collections.Generic;
using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Dont Destroy on Load")]
    [DisallowMultipleComponent]
    public class DontDestroyOnLoadMB : AutoTriggerMB
    {
        private static readonly List<string> ActiveIds = new();

        [SerializeField]
        private GameObject _target;

        [SerializeField]
        private string _id;

        private GameObject Target
        {
            get
            {
                if (!_target)
                {
                    _target = gameObject;
                }

                return _target;
            }
        }

        private void OnDestroy()
        {
            ActiveIds.Remove(_id);
        }

        public override void Do()
        {
            if (ActiveIds.Contains(_id))
            {
                Destroy(gameObject);
                return;
            }

            ActiveIds.Add(_id);
            DontDestroyOnLoad(Target);
        }
    }
}