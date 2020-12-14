using UnityEngine;
using GameCycleSample.Config;
using GameCycleSample.Struct;
using GameCycleSample.Type;
using Unidux.SceneTransition;
using UniRx;
using UnityEngine.UI;

namespace GameCycleSample.UI
{
    [RequireComponent(typeof(Button))]
    public class ChangeDifficultyDispatcher : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var type = DifficultyType.Easy;
            var data = new GamePageData(type);

            this.GetComponent<Button>().OnClickAsObservable()
                .Select(_ => PageDuck<Page, Scene>.ActionCreator.SetData(data))
                .Subscribe(action => 
                {
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
                    data = new GamePageData(type);
                    Unidux.Dispatch(action);
                })
                .AddTo(this);
        }
    }
}
