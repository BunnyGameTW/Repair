using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    [SerializeField]
    private Scrollbar scrollbar;
    [SerializeField]
    private Image image;
    //[SerializeField]
    //private Text text;
    [SerializeField]
    private GameObject text;
    [SerializeField]
    private Text loadingText;
    [SerializeField]
    private DragDetector dragDetector;
    [SerializeField]
    private Image light;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip refill;

    private bool changeScene;
    private float lightDuration = 1.0f;
    private Vector3 imagePos;
    Sequence sequence;
    Sequence lightSequence;
    Sequence shakeSequence;


    private void Start()
    {
        imagePos = image.transform.localPosition;
        scrollbar.interactable = false;
        text.transform.DOLocalMove(new Vector3(-9.9f, 25, 25), 50).SetEase(Ease.Linear);

        StartCoroutine(Play());
    }
    private IEnumerator Play()
    {
        yield return new WaitForSeconds(2.0f);

        // 0%: -483, 87%: 476.61, 100%: 620
        image.transform.DOLocalMoveX(476.61f, 10).SetEase(Ease.Linear);
        sequence = DOTween.Sequence();

        sequence.Append(DOTween.To(() => scrollbar.size, x => scrollbar.size = x, 0.87f, 10).SetEase(Ease.Linear));
        sequence.AppendInterval(1);
        sequence.AppendCallback(() =>
        {
            shakeSequence = DOTween.Sequence();
            shakeSequence.AppendInterval(0.5f);
            shakeSequence.Append(DOTween.To(() => scrollbar.size, x => scrollbar.size = x, 0.8f, 2));
            shakeSequence.Append(DOTween.To(() => scrollbar.size, x => scrollbar.size = x, 0.87f, 0.1f));
            shakeSequence.SetLoops(-1);
            dragDetector.shakeDelegate = StopShakeAnim;
        });
        sequence.AppendInterval(5);
        sequence.AppendCallback(() =>
        {
            dragDetector.IsDragable = true;
            Color startColor = new Color(1, 1, 1, 1);
            Color endColor = new Color(1, 1, 1, 0);

            lightSequence = DOTween.Sequence();
            lightSequence.AppendCallback(() =>
            {
                light.color = endColor;
                light.DOColor(startColor, lightDuration / 2).OnComplete(() => { light.DOColor(endColor, lightDuration / 2); });

            });
            lightSequence.AppendInterval(lightDuration);
            lightSequence.SetLoops(-1);
        });

    }
    private void Update()
    {
        loadingText.text = "Loading..." + (scrollbar.size * 100).ToString("N0") + "%";

        Vector3 pos = new Vector3(-483 + scrollbar.size * 1103, imagePos.y, imagePos.z);
        Vector3 lightPos = new Vector3(-470 + scrollbar.size * 1103, -429, 0);
        image.rectTransform.localPosition = pos;
        light.transform.localPosition = lightPos;

        if (scrollbar.size == 1)
        {
            StartCoroutine(ChangeScene());
        }
    }
    private IEnumerator ChangeScene()
    {
        if (!changeScene)
        {
            changeScene = true;
            audioSource.PlayOneShot(refill);
            yield return new WaitForSeconds(0.5f);
            GameManager.ChangeScene(1);
        }
        else
        {
            yield return null;
        }
    }

    private void StopShakeAnim()
    {
        shakeSequence.Kill();
    }
}
