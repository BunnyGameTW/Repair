﻿using DG.Tweening;
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
    [SerializeField]
    private Text text;
    [SerializeField]
    private Text loadingText;
    [SerializeField]
    private DragDetector dragDetector;
    [SerializeField]
    private Image light;

    private bool changeScene;
    private float lightDuration = 1.0f;
    private Vector3 imagePos;
    Sequence sequence;
    Sequence lightSequence;

    public void ChangeScene()
    {
        if (!changeScene)
        {
            changeScene = true;
            GameManager.ChangeScene(1);
        }
    }

    private void Start()
    {
        imagePos = image.transform.localPosition;
        scrollbar.interactable = false;
        text.transform.DOLocalMoveY(650, 10).SetEase(Ease.Linear);

        // 0%: -483, 87%: 476.61, 100%: 620
        image.transform.DOLocalMoveX(476.61f, 10).SetEase(Ease.Linear);
        sequence = DOTween.Sequence();

        sequence.Append(DOTween.To(() => scrollbar.size, x => scrollbar.size = x, 0.87f, 10).SetEase(Ease.Linear)).OnComplete(() =>
        {
            dragDetector.IsDragable = true;
        });
        sequence.AppendCallback(() =>
        {
            Color startColor = new Color(1, 1, 1, 1);
            Color endColor = new Color(1, 1, 1, 0);

            Sequence lightSequence = DOTween.Sequence();
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
            ChangeScene();
        }
    }
}
