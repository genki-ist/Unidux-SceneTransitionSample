﻿using SampleApp.Domain;
using Unidux.SceneTransition;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

namespace SampleApp.Presentation
{
    [RequireComponent(typeof(Button))]
    public class TitleButtonDispatcher : MonoBehaviour
    {
        public GamePageData GamePageData;

        void Start()
        {
            this.GetComponent<Button>().OnClickAsObservable()
                                       .Select(_ => PageDuck<Page, Scene>.ActionCreator.Push(Page.GamePage, this.GamePageData))
                                       .Subscribe(action => Unidux.Dispatch(action))
                                       .AddTo(this);
        }
    }
}