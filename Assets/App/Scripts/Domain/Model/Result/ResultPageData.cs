using System;
using Unidux.SceneTransition;

namespace SampleApp.Domain
{
    [Serializable]
    public class ResultPageData : IPageData
    {
        public int Score;

        public ResultPageData()
        {
        }

        public ResultPageData(int score)
        {
            this.Score = score;
        }
    }
}