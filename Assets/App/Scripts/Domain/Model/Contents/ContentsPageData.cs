using System;
using Unidux.SceneTransition;

namespace SampleApp.Domain
{
    [Serializable]
    public class ContentsPageData : IPageData
    {
        public ContentsType ContentsType;

        public int MouseClickCount
        {
            get => this.mouseClickCount;
            set => this.mouseClickCount = value;
        }

        private int mouseClickCount;

        public ContentsPageData()
        {
            this.mouseClickCount = 0;
        }

        public ContentsPageData(ContentsType ContentsType, int mouseClickCount)
        {
            this.ContentsType = ContentsType;
            if(mouseClickCount > 0)
            {
                this.mouseClickCount = mouseClickCount;
            }
            else
            {
                this.mouseClickCount = 0;
            }
        }
    }
}

