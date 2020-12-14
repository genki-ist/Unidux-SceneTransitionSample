﻿using System;
using SampleApp.Domain;
using Unidux.SceneTransition;
using Unidux;

using UnityEngine;

namespace SampleApp.Application
{
    public class SceneReducer : SceneDuck<Scene>.Reducer
    {
        public override object ReduceAny(object state, object action)
        {
            // It's required for detecting scene state location
            var _state = (State) state;
            var _action = (SceneDuck<Scene>.Action) action;
            _state.Scene =  base.Reduce(_state.Scene, _action);
            return state;
        }
    }
}