using GameCycleSample.Config;
using GameCycleSample.Struct;
using Unidux.SceneTransition;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

namespace GameCycleSample.UI
{
    [RequireComponent(typeof(Button))]
    public class TitleButtonDispatcher : MonoBehaviour
    {
        public GamePageData GamePageData;

        public GoToGamePageDispatcher goToGamePageDispatcher;

        void Start()
        {
            this.GetComponent<Button>().OnClickAsObservable()
                .Subscribe(_ => {
                    this.goToGamePageDispatcher.GoToGamePage(this.GamePageData);
                })
                .AddTo(this);

            // this.faderRenderer.FadeAlpha.Where(val => val >= 1f)
            //                             .Skip(1)
            //                             .Select(_ => PageDuck<Page, Scene>.ActionCreator.Push(Page.GamePage, this.GamePageData))
            //                             .Subscribe(action => Unidux.Dispatch(action))
            //                             .AddTo(this);
        }
    }
}