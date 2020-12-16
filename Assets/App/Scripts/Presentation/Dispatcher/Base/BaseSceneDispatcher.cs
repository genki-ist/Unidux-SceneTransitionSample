using SampleApp.Domain;
using Unidux.SceneTransition;
using UnityEngine;

namespace SampleApp.Presentation
{
    public class BaseSceneDispatcher : MonoBehaviour
    {
        void Awake()
        {
            Unidux.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Reset());
            Unidux.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Push(PageName.PAGE_TITLE));
        }
    }
}
