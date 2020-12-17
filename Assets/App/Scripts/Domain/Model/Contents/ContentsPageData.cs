using System;
using Unidux.SceneTransition;

namespace SampleApp.Domain
{
    [Serializable]
    public class ContentsPageData : IPageData
    {
        public ContentsType ContentsType;

        public ContentsPageData()
        {
        }

        public ContentsPageData(ContentsType ContentsType)
        {
            this.ContentsType = ContentsType;
        }
    }
}

