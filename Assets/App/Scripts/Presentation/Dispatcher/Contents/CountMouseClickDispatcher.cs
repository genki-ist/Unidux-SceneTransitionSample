using SampleApp.Domain;
using Unidux.SceneTransition;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.EventSystems;

namespace SampleApp.Presentation
{
    public class CountMouseClickDispatcher : MonoBehaviour
    {
        private ContentsPageData contentsPageData;

        // Start is called before the first frame update
        void Start()
        {
            this.UpdateAsObservable()
                .Where(_ => Input.GetMouseButtonDown(0))
                .Where(_ => !EventSystem.current.IsPointerOverGameObject())
                .Subscribe(_ => 
                {
                    var type = Unidux.State.Page.GetData<ContentsPageData>().ContentsType;
                    var count = Unidux.State.Page.GetData<ContentsPageData>().MouseClickCount;
                    count += 1;
                    this.contentsPageData = new ContentsPageData(type, count);

                    this.ChangeSceneData();
                })
                .AddTo(this);
        }

        private void ChangeSceneData()
        {
            var action = PageDuck<PageName, SceneName>.ActionCreator.SetData(this.contentsPageData);
            Unidux.Dispatch(action);
        }
    }
}
