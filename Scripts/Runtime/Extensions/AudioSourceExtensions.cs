using UnityEngine;

namespace niscolas.UnityUtils.Core.Extensions
{
    public static class AudioSourceExtensions
    {
        public static void TogglePlay(this AudioSource audioSource)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }
            else
            {
                audioSource.Play();
            }
        }
    }
}