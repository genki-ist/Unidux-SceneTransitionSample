using SampleApp.Domain;
using Unidux.SceneTransition;
using UnityEngine;

namespace SampleApp.Presentation
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
