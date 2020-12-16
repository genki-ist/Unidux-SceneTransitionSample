using System;
using Unidux.SceneTransition;

namespace SampleApp.Domain
{
    [Serializable]
    public class ContentsPageData : IPageData
    {
        public DifficultyType DifficultyType;

        public ContentsPageData()
        {
        }

        public ContentsPageData(DifficultyType difficultyType)
        {
            this.DifficultyType = difficultyType;
        }
    }
}

