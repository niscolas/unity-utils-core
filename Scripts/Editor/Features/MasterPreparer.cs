// original author: https://github.com/Deadcows

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace niscolas.UnityUtils.Core.Editor
{
    public static class MasterPreparer
    {
        public static bool IsEnabled { get; set; } = true;

        public static Action BeforePrepared;
        public static Action Preparing;
        public static Action AfterPrepared;

        [InitializeOnLoadMethod]
        private static void Init()
        {
            TheEditor.ExitingEditMode += PrepareOnPlay;
        }

        private static void PrepareOnPlay()
        {
            if (!IsEnabled)
            {
                return;
            }

            RunPrepare();
        }

        public static void RunPrepare()
        {
            BeforePrepared?.Invoke();
            Preparing?.Invoke();

            IEnumerable<ComponentOfInterface<IPrepare>> prepareComponents = TheGameObjectUtility
                .FindObjectsOfInterfaceAsComponents<IPrepare>();

            HashSet<Scene> modifiedScenes = null;

            foreach (ComponentOfInterface<IPrepare> prepare in prepareComponents)
            {
                bool changed = prepare.Interface.Prepare();
                Component prepareComponent = prepare.Component;

                if (!changed || !prepareComponent)
                {
                    continue;
                }

                if (modifiedScenes == null)
                {
                    modifiedScenes = new HashSet<Scene>();
                }

                modifiedScenes.Add(prepareComponent.gameObject.scene);

                EditorUtility.SetDirty(prepareComponent);

                TheBugger.Log(
                    $"{prepareComponent.name}.{prepareComponent.GetType().Name}: changed on prepare...",
                    prepareComponent);
            }

            if (modifiedScenes != null)
            {
                EditorSceneManager.SaveScenes(modifiedScenes.ToArray());
            }

            AfterPrepared?.Invoke();
        }
    }
}