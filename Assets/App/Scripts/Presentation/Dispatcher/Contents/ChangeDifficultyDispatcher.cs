using UnityEngine;
using SampleApp.Domain;
using Unidux.SceneTransition;
using UniRx;
using UnityEngine.UI;

namespace SampleApp.Presentation
{
    [RequireComponent(typeof(Button))]
    public class ChangeDifficultyDispatcher : MonoBehaviour
    {
        private ContentsPageData contentsPageData;

        // Start is called before the first frame update
        void Start()
        {
            var type = Unidux.State.Page.GetData<ContentsPageData>().DifficultyType;
            this.contentsPageData = new ContentsPageData(type);

            this.GetComponent<Button>()
                .OnClickAsObservable()
                .Subscribe(_ => 
                {
                    type = Unidux.State.Page.GetData<ContentsPageData>().DifficultyType;
                    // Debug.Log(type.ToString());

                    switch(type)
                    {
                        case DifficultyType.Easy:
                            type = DifficultyType.Normal;
                        break;
                        case DifficultyType.Normal:
                            type = DifficultyType.Hard;
                        break;
                        case DifficultyType.Hard:
                            type = DifficultyType.Easy;
                        break;
                    }
                    this.contentsPageData = new ContentsPageData(type);

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
