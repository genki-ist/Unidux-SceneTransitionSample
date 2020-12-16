using SampleApp.Application;
using SampleApp.Domain;
using Unidux.SceneTransition;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using System.Linq;

namespace SampleApp.Presentation
{
    public class PageWatcher : MonoBehaviour
    {
        [SerializeField]
        private SceneTransitionFaderRenderer faderRenderer = default;
        [SerializeField]
        private SceneWatcher sceneWatcher = default;

        private ISceneConfig<SceneName, PageName> config = new SceneConfig();
        private string currentPageName = "";

        void Start()
        {
            Unidux.Subject
                .Where(state => state.Page.IsStateChanged && this.currentPageName != state.Page.Name)
                .Subscribe(_ => this.faderRenderer.FadeIn())
                .AddTo(this);

            this.UpdateAsObservable()
                .Where(_ => this.faderRenderer.CanSceneTransition)
                .Subscribe(_ => 
                {
                    this.UpdatePage(Unidux.State);
                    this.sceneWatcher.UpdateScenes(Unidux.State.Scene);
                    // Debug.Log(Unidux.State.Page.Name);
                    this.currentPageName = Unidux.State.Page.Name;
                })
                .AddTo(this);
        }

        private void UpdatePage(State state)
        {
            if (state.Scene.NeedsAdjust(config.GetPageScenes(), config.PageMap[state.Page.Current.Page]))
            {
                Unidux.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Adjust());
            }

            this.faderRenderer.FadeOut();
        }
    }
}
