﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public class DontDestroyOnLoad : AutoTriggerMonoBehaviour
    {
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

        private static readonly List<string> ActiveIds = new List<string>();

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

        private void OnDestroy()
        {
            ActiveIds.Remove(_id);
        }
    }
}