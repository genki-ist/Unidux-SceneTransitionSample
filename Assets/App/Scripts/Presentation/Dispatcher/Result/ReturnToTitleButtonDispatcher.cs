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
        void Start()
        {
            this.GetComponent<Button>().OnClickAsObservable()
                .Select(_ => PageDuck<PageName, SceneName>.ActionCreator.Push(PageName.PAGE_TITLE))
                .Subscribe(action => Unidux.Dispatch(action))
                .AddTo(this);
        }
    }
}
