using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{
    public bool show = false;

    [SerializeField]
    private List<Image> icons = new List<Image>();
    [SerializeField]
    private Image playerIcon;
    [SerializeField]
    private Image turn;

    private float lightDuration = 1.0f;
    private Vector3 imagePos;
    private Color startColor = new Color(1, 1, 1, 1);
    private Color endColor = new Color(1, 1, 1, 0);

    Sequence sequence;

    private void Start()
    {
        for (int i = 0; i < icons.Count; i++)
        {
            icons[i].color = endColor;
        }
        turn.color = endColor;
        playerIcon.color = endColor;

        sequence = DOTween.Sequence();
        sequence.Append(icons[2].DOColor(startColor, lightDuration));
        sequence.Append(icons[6].DOColor(startColor, lightDuration));
        sequence.Append(icons[4].DOColor(startColor, lightDuration));
        sequence.Append(icons[7].DOColor(startColor, lightDuration));
        sequence.Append(icons[8].DOColor(startColor, lightDuration));
        sequence.AppendCallback(() =>
        {
            turn.DOColor(startColor, lightDuration);
            playerIcon.DOColor(startColor, lightDuration);
        });
    }
}
