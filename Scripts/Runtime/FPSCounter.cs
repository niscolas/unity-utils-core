using System.Collections;
using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public class FPSCounter : MonoBehaviour
    {
        private float count;
        private string label = "";

        private IEnumerator Start()
        {
            GUI.depth = 2;
            while (true)
            {
                if (Time.timeScale > 0)
                {
                    yield return new WaitForSeconds(0.1f);
                    count = 1 / Time.deltaTime;
                    label = "FPS :" + Mathf.Round(count);
                }
                else
                {
                    label = "Pause";
                }

                yield return new WaitForSeconds(0.5f);
            }
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(5, 40, 100, 25), label);
        }
    }
}