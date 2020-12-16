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
                    {SceneName.SCENE_BASE, SceneCategory.Permanent},
                    {SceneName.SCENE_TITLE, SceneCategory.Page},
                    {SceneName.SCENE_CONTENTS, SceneCategory.Page},
                    {SceneName.SCENE_RESULT, SceneCategory.Page},
                };
            }
        }

        public IDictionary<PageName, SceneName[]> PageMap
        {
            get
            {
                return this._pageMap = this._pageMap ?? new Dictionary<PageName, SceneName[]>()
                {
                    {PageName.PAGE_TITLE, new[] {SceneName.SCENE_TITLE}},
                    {PageName.PAGE_CONTENTS, new[] {SceneName.SCENE_BASE}},
                    {PageName.PAGE_RESULT, new[] {SceneName.SCENE_RESULT}},
                };
            }
        }
    }
}