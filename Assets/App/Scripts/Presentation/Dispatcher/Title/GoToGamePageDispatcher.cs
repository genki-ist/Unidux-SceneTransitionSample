using SampleApp.Domain;
using Unidux.SceneTransition;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace SampleApp.Presentation
{
    public class GoToGamePageDispatcher : MonoBehaviour
    {
        // public SceneTransitionFaderRenderer faderRenderer;

        public void GoToGamePage(GamePageData gamePageData)
        {
            // this.faderRenderer.IntervalSecond = 0.5f;
            // this.faderRenderer.FadeIn();

            // this.UpdateAsObservable()
            //     .Where(_ => this.faderRenderer.CanSceneTransition)
            //     .Select(_ => PageDuck<Page, Scene>.ActionCreator.Push(Page.GamePage, gamePageData))
            //     .Subscribe(action => Unidux.Dispatch(action))
            //     .AddTo(this);
        }
    }
}