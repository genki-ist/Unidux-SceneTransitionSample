using System.Collections;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

[RequireComponent(typeof(Image))]
public class SceneTransitionFaderRenderer : MonoBehaviour
{
    private Image fader;

    private Color faderColor;
    private float fadeAlpha;
    private bool canSceneTransition;
    private float intervalSecond;

    public float FadeAlpha
    {
        get => this.fadeAlpha;
    }

    public bool CanSceneTransition
    {
        get => this.canSceneTransition;
    }

    public float IntervalSecond
    {
        get => this.intervalSecond;
        set => this.intervalSecond = value;
    }

    // Start is called before the first frame update
    void Awake()
    {
        this.fader = this.GetComponent<Image>();

        this.intervalSecond = 1f;
        this.canSceneTransition = false;
        this.fadeAlpha = 1f;
        this.faderColor.a = this.fadeAlpha;
        this.faderColor = this.fader.color;
        this.FadeOut();
    }

    //0->1
    public void FadeIn()
    {
        StartCoroutine(FadeAnimation(0f, 1f));
    }

    //1->0
    public void FadeOut()
    {
        StartCoroutine(FadeAnimation(1f, 0f));
    }

    // フェード
    private IEnumerator FadeAnimation(float startVal, float goalVal)
    {
        float time = 0f;

        while (time <= this.intervalSecond)
        {
            this.fadeAlpha = Mathf.Lerp(startVal, goalVal, time / this.intervalSecond);
            this.faderColor.a = this.fadeAlpha;
            this.fader.color = this.faderColor;
            time += Time.deltaTime;
            yield return null;
        }

        this.fadeAlpha = goalVal;

        if(goalVal == 1f)
        {
            this.canSceneTransition = true;
        }
        else
        {
            this.canSceneTransition = false;
        }

    }
}
