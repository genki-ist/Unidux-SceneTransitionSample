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
        private GamePageData gamePageData;

        // Start is called before the first frame update
        void Start()
        {
            this.gamePageData = new GamePageData(DifficultyType.Easy);

            this.GetComponent<Button>()
                .OnClickAsObservable()
                .Subscribe(_ => 
                {
                    var type = Unidux.State.Page.GetData<GamePageData>().DifficultyType;
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
                    this.gamePageData = new GamePageData(type);

                    this.ChangeSceneData();
                })
                .AddTo(this);
        }

        private void ChangeSceneData()
        {
            var action = PageDuck<Page, Scene>.ActionCreator.SetData(this.gamePageData);
            Unidux.Dispatch(action);
        }
    }
}
