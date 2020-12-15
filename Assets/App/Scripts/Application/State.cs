using System;
using SampleApp.Domain;
using Unidux;
using Unidux.SceneTransition;

namespace SampleApp.Application
{
    [Serializable]
    public class State : StateBase
    {
        public SceneState<Scene> Scene = new SceneState<Scene>();
        public PageState<Page> Page = new PageState<Page>();
    }
}
