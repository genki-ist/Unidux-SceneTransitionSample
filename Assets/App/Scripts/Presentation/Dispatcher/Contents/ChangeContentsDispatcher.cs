using UnityEngine;
using SampleApp.Domain;
using Unidux.SceneTransition;
using UniRx;
using UnityEngine.UI;

namespace SampleApp.Presentation
{
    [RequireComponent(typeof(Button))]
    public class ChangeContentsDispatcher : MonoBehaviour
    {
        [SerializeField]
        private GameObject cubeObject = default;
        [SerializeField]
        private GameObject capsuleObject = default;

        private ContentsPageData contentsPageData;

        // Start is called before the first frame update
        void Start()
        {
            this.InitContentsPageData();

            this.GetComponent<Button>()
                .OnClickAsObservable()
                .Subscribe(_ => 
                {
                    this.SetContentsPageData();
                    this.ChangePageData();
                })
                .AddTo(this);
        }

        private void InitContentsPageData()
        {
            var type = Unidux.State.Page.GetData<ContentsPageData>().ContentsType;
            var count = Unidux.State.Page.GetData<ContentsPageData>().MouseClickCount;

            switch(type)
            {
                case ContentsType.Cube:
                    type = ContentsType.Cube;
                    this.cubeObject.SetActive(true);
                    this.capsuleObject.SetActive(false);
                break;
                case ContentsType.Capsule:
                    type = ContentsType.Capsule;
                    this.cubeObject.SetActive(false);
                    this.capsuleObject.SetActive(true);
                break;
            }

            this.contentsPageData = new ContentsPageData(type, count);
        }

        private void SetContentsPageData()
        {
            var type = Unidux.State.Page.GetData<ContentsPageData>().ContentsType;
            var count = Unidux.State.Page.GetData<ContentsPageData>().MouseClickCount;

            switch(type)
            {
                case ContentsType.Cube:
                    type = ContentsType.Capsule;
                    this.cubeObject.SetActive(false);
                    this.capsuleObject.SetActive(true);
                break;
                case ContentsType.Capsule:
                    type = ContentsType.Cube;
                    this.cubeObject.SetActive(true);
                    this.capsuleObject.SetActive(false);
                break;
            }

            this.contentsPageData = new ContentsPageData(type, count);
        }

        private void ChangePageData()
        {
            var action = PageDuck<PageName, SceneName>.ActionCreator.SetData(this.contentsPageData);
            Unidux.Dispatch(action);
        }
    }
}
