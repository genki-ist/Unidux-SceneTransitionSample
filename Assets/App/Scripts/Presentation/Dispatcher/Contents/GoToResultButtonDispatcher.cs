using SampleApp.Domain;
using Unidux.SceneTransition;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

namespace SampleApp.Presentation
{
    [RequireComponent(typeof(Button))]
    public class GoToResultButtonDispatcher : MonoBehaviour
    {
        private int score;

        void Start()
        {
             this.GetComponent<Button>().OnClickAsObservable()
                .Select(_ => this.score = Unidux.State.Page.GetData<ContentsPageData>().MouseClickCount)
                .Subscribe(_ => this.DispatchPageData())
                .AddTo(this);
        }

        private void DispatchPageData()
        {
            var action = PageDuck<PageName, SceneName>.ActionCreator.Push(PageName.PAGE_RESULT, new ResultPageData(this.score));
            Unidux.Dispatch(action);
        }
    }
}