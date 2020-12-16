using SampleApp.Domain;
using Unidux.SceneTransition;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

namespace SampleApp.Presentation
{
    [RequireComponent(typeof(Button))]
    public class TitleButtonDispatcher : MonoBehaviour
    {
        public GamePageData GamePageData;

        void Start()
        {
            this.GetComponent<Button>().OnClickAsObservable()
                                       .Select(_ => PageDuck<PageName, SceneName>.ActionCreator.Push(PageName.PAGE_CONTENTS, this.GamePageData))
                                       .Subscribe(action => Unidux.Dispatch(action))
                                       .AddTo(this);
        }
    }
}