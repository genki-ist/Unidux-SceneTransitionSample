using GameCycleSample.Config;
using Unidux.SceneTransition;
using UnityEngine;

namespace GameCycleSample.UI
{
    public class BaseSceneDispatcher : MonoBehaviour
    {
        void Start()
        {
            Unidux.Dispatch(PageDuck<Page, Scene>.ActionCreator.Reset());
            Unidux.Dispatch(PageDuck<Page, Scene>.ActionCreator.Push(Page.TitlePage));
        }
    }
}
