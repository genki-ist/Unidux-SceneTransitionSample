using System;
using Unidux.SceneTransition;

namespace SampleApp.Domain
{
    [Serializable]
    public class GamePageData : IPageData
    {
        public DifficultyType DifficultyType;

        public GamePageData()
        {
        }

        public GamePageData(DifficultyType difficultyType)
        {
            this.DifficultyType = difficultyType;
        }
    }
}

