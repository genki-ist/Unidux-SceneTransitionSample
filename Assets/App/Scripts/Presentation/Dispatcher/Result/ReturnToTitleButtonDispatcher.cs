using SampleApp.Domain;
using Unidux.SceneTransition;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;


namespace SampleApp.Presentation
{
    [RequireComponent(typeof(Button))]
    public class ReturnToTitleButtonDispatcher : MonoBehaviour
    {
        public SceneTransitionFaderRenderer faderRenderer;

        void Start()
        {
            this.GetComponent<Button>().OnClickAsObservable()
                .Subscribe(_ => this.faderRenderer.FadeIn())
                .AddTo(this);
            
            this.faderRenderer.IntervalSecond = 0.5f;
            
            this.UpdateAsObservable()
                .Where(_ => this.faderRenderer.CanSceneTransition)
                .Skip(1)
                .Select(_ => PageDuck<Page, Scene>.ActionCreator.Push(Page.TitlePage))
                .Subscribe(action => Unidux.Dispatch(action))
                .AddTo(this);
        }
    }
}
