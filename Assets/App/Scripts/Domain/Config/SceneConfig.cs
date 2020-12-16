using System.Collections.Generic;
using Unidux.SceneTransition;

namespace SampleApp.Domain
{
    public class SceneConfig : ISceneConfig<SceneName, PageName>
    {
        private IDictionary<SceneName, int> _categoryMap;
        private IDictionary<PageName, SceneName[]> _pageMap;

        public IDictionary<SceneName, int> CategoryMap
        {
            get
            {
                return this._categoryMap = this._categoryMap ?? new Dictionary<SceneName, int>()
                {
                    {SceneName.Base, SceneCategory.Permanent},
                    {SceneName.Title, SceneCategory.Page},
                    {SceneName.Contents, SceneCategory.Page},
                    {SceneName.Result, SceneCategory.Page},
                };
            }
        }

        public IDictionary<PageName, SceneName[]> PageMap
        {
            get
            {
                return this._pageMap = this._pageMap ?? new Dictionary<PageName, SceneName[]>()
                {
                    {PageName.PAGE_TITLE, new[] {SceneName.Title}},
                    {PageName.PAGE_CONTENTS, new[] {SceneName.Contents}},
                    {PageName.PAGE_RESULT, new[] {SceneName.Result}},
                };
            }
        }
    }
}