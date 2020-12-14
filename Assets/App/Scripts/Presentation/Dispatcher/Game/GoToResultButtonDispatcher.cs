using GameCycleSample.Config;
using GameCycleSample.Struct;
using Unidux.SceneTransition;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;


namespace GameCycleSample.UI
{
    [RequireComponent(typeof(Button))]
    public class GoToResultButtonDispatcher : MonoBehaviour
    {
        public SceneTransitionFaderRenderer faderRenderer;

        void Start()
        {
            this.GetComponent<Button>().OnClickAsObservable()
                .Subscribe(_ => {
                    this.faderRenderer.FadeIn();
                })
                .AddTo(this);

            this.faderRenderer.IntervalSecond = 0.5f;
            
            this.UpdateAsObservable()
                .Where(_ => this.faderRenderer.CanSceneTransition)
                .Select(_ => PageDuck<Page, Scene>.ActionCreator.Push(Page.ResultPage, new ResultPageData(Random.Range(0, 101))))
                .Subscribe(action => Unidux.Dispatch(action))
                .AddTo(this);
        }
    }
}