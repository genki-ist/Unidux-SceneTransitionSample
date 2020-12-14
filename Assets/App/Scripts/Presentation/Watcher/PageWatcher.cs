using SampleApp.Application;
using SampleApp.Domain;
using Unidux.SceneTransition;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace SampleApp.Presentation
{
    public class PageWatcher : MonoBehaviour
    {
        private ISceneConfig<Scene, Page> config = new SceneConfig();

        [SerializeField]
        private SceneTransitionFaderRenderer faderRenderer;

        void Start()
        {
            Unidux.Subject
                .Where(state => state.Page.IsStateChanged)
                // .StartWith(Unidux.State)
                // .Where(state => state.Page.IsReady)
                .Subscribe(_ => this.faderRenderer.FadeIn())
                // .Subscribe(state => UpdateScene(state))
                .AddTo(this);

            this.UpdateAsObservable()
                .Where(_ => this.faderRenderer.CanSceneTransition)
                // .ThrottleFrame(30)
                .Subscribe(state => 
                {
                    Debug.Log("can scene transition");
                    UpdateScene(Unidux.State);
                })
                .AddTo(this);
        }

        void UpdateScene(State state)
        {
            Debug.Log("UpdatePage");

            if (state.Scene.NeedsAdjust(config.GetPageScenes(), config.PageMap[state.Page.Current.Page]))
            {
                Unidux.Dispatch(PageDuck<Page, Scene>.ActionCreator.Adjust());
            }

            this.faderRenderer.FadeOut();
        }
    }
}
