using SampleApp.Domain;
using Unidux.SceneTransition;
using UnityEngine;

namespace SampleApp.Presentation
{
    public class SceneWatcher : MonoBehaviour
    {
        public void UpdateScenes(SceneState<SceneName> state)
        {
            foreach (var scene in state.Additionals(SceneUtil.GetActiveScenes<SceneName>()))
            {
                StartCoroutine(SceneUtil.Add(scene.ToString()));
            }

            foreach (var scene in state.Removals(SceneUtil.GetActiveScenes<SceneName>()))
            {
                StartCoroutine(SceneUtil.Remove(scene.ToString()));
            }
        }
    }
}