using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverDetector : MonoBehaviour
{
    public int index;

    [SerializeField]
    private Image hint;
    [SerializeField]
    private Image icon;
    [SerializeField]
    private MiniGameManager miniGameManager;

    private float lightDuration = 1.0f;
    private Sequence sequence;
    private Color startColor = new Color(1, 0, 0, 1);
    private Color endColor = new Color(1, 0, 0, 0);

    public void Light()
    {
        if (!miniGameManager.show)
        {
            sequence = DOTween.Sequence();
            sequence.Append(hint.DOColor(startColor, lightDuration));
            sequence.Append(hint.DOColor(endColor, lightDuration));
            sequence.SetLoops(-1);
        }
    }

    public void OffLight()
    {
        if (!miniGameManager.show)
        {
            sequence.Kill(true);
            hint.color = endColor;
        }
    }

    public void ShowIcon()
    {
        if (!miniGameManager.show)
        {
            miniGameManager.Choose(index);
            icon.DOColor(startColor, lightDuration);
            sequence.Kill(true);
            hint.color = endColor;
            miniGameManager.show = true;
        }
    }
}
