using SampleApp.Domain;
using Unidux.SceneTransition;
using PageName = SampleApp.Domain.PageName;
using SceneName = SampleApp.Domain.SceneName;

namespace SampleApp.Application
{
    public class PageReducer : PageDuck<PageName, SceneName>.Reducer
    {
        public PageReducer() : base(new SceneConfig())
        {
        }
        
        public override object ReduceAny(object state, object action)
        {
            // It's required for detecting page scene state location
            var _state = (State) state;
            var _action = (PageDuck<PageName, SceneName>.IPageAction) action;
            _state.Page = base.Reduce(_state.Page, _state.Scene, _action);
            return state;
        }
    }
}
