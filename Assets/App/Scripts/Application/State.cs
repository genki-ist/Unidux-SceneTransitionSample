using System;
using SampleApp.Domain;
using Unidux;
using Unidux.SceneTransition;

namespace SampleApp.Application
{
    [Serializable]
    public class State : StateBase
    {
        public SceneState<SceneName> Scene = new SceneState<SceneName>();
        public PageState<PageName> Page = new PageState<PageName>();
    }
}
