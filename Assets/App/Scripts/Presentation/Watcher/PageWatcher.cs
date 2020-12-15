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
        private ISceneConfig<Scene, Page> config = new SceneConfig();

        [SerializeField]
        private SceneTransitionFaderRenderer faderRenderer = default;

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
                    this.UpdateScenes(Unidux.State.Scene);
                    // Debug.Log(Unidux.State.Page.Name);
                    this.currentPageName = Unidux.State.Page.Name;
                })
                .AddTo(this);
        }

        void UpdatePage(State state)
        {
            if (state.Scene.NeedsAdjust(config.GetPageScenes(), config.PageMap[state.Page.Current.Page]))
            {
                Unidux.Dispatch(PageDuck<Page, Scene>.ActionCreator.Adjust());
            }

            this.faderRenderer.FadeOut();
        }

        void UpdateScenes(SceneState<Scene> state)
        {
            foreach (var scene in state.Additionals(SceneUtil.GetActiveScenes<Scene>()))
            {
                StartCoroutine(SceneUtil.Add(scene.ToString()));
            }

            foreach (var scene in state.Removals(SceneUtil.GetActiveScenes<Scene>()))
            {
                StartCoroutine(SceneUtil.Remove(scene.ToString()));
            }
        }
    }
}
