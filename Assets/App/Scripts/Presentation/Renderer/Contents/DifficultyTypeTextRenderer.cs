using SampleApp.Application;
using SampleApp.Domain;
using TMPro;
using UnityEngine;
using UniRx;

namespace SampleApp.Presentation
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class DifficultyTypeTextRenderer : MonoBehaviour
    {
        public TextMeshProUGUI DifficultyTypeText;

        void Start()
        {
            Unidux.Subject
                .Where(state => state.Page.IsReady && state.Page.IsStateChanged)
                .Where(state => state.Page.Data is ContentsPageData) // Page.Dataの型チェック
                .StartWith(Unidux.State)
                .Subscribe(state => this.Render(state))
                .AddTo(this);
        }

        private void Render(State state)
        {
            ContentsPageData pageData = state.Page.GetData<ContentsPageData>();
            this.DifficultyTypeText.text = pageData.DifficultyType.ToString();
        }
    }
}