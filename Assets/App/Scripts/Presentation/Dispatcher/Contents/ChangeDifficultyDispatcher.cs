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
        private ContentsPageData gamePageData;

        // Start is called before the first frame update
        void Start()
        {
            this.gamePageData = new ContentsPageData(DifficultyType.Easy);

            this.GetComponent<Button>()
                .OnClickAsObservable()
                .Subscribe(_ => 
                {
                    var type = Unidux.State.Page.GetData<ContentsPageData>().DifficultyType;
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
                    this.gamePageData = new ContentsPageData(type);

                    this.ChangeSceneData();
                })
                .AddTo(this);
        }

        private void ChangeSceneData()
        {
            var action = PageDuck<PageName, SceneName>.ActionCreator.SetData(this.gamePageData);
            Unidux.Dispatch(action);
        }
    }
}
