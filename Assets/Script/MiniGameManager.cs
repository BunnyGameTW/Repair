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
    [SerializeField]
    private Transform suck;
    [SerializeField]
    private Transform super;
    [SerializeField]
    private Image superLight;
    [SerializeField]
    private AudioClip win;
    [SerializeField]
    private AudioClip lose;
    [SerializeField]
    private AudioSource audioSource;

    private float lightDuration = 1.0f;
    private Vector3 imagePos;
    private Color startColor = new Color(1, 1, 1, 1);
    private Color endColor = new Color(1, 1, 1, 0);

    Sequence sequence;
    Sequence lightSequence;
    Sequence chooseSequence;

    public void Choose(int index)
    {
        if (index == 9)
        {
            // Win
            chooseSequence = DOTween.Sequence();
            chooseSequence.Append(turn.DOColor(endColor, lightDuration));
            chooseSequence.Join(playerIcon.DOColor(endColor, lightDuration));
            chooseSequence.Append(super.DOScale(Vector3.one * 0.6f, 0.5f));
            chooseSequence.AppendCallback(() =>
            {
                lightSequence = DOTween.Sequence();
                lightSequence.Append(superLight.DOColor(startColor, lightDuration / 2));
                lightSequence.Append(superLight.DOColor(endColor, lightDuration / 2));
                lightSequence.SetLoops(-1);
            });
            audioSource.PlayOneShot(win);
            StartGameManager.Singleton.SetHasLetter("s");
        }
        else if (index == 5)
        {
            // Lose
            chooseSequence = DOTween.Sequence();
            chooseSequence.Append(turn.DOColor(endColor, lightDuration));
            chooseSequence.Join(playerIcon.DOColor(endColor, lightDuration));
            chooseSequence.Append(icons[10].DOColor(startColor, lightDuration));
            chooseSequence.Append(suck.DOScale(Vector3.one * 0.6f, 0.5f));
            audioSource.PlayOneShot(lose);
        }
        else
        {
            // Lose
            chooseSequence.Append(turn.DOColor(endColor, lightDuration));
            chooseSequence.Join(playerIcon.DOColor(endColor, lightDuration));
            chooseSequence.Append(icons[11].DOColor(startColor, lightDuration));
            chooseSequence.Append(suck.DOScale(Vector3.one * 0.6f, 0.5f));
            audioSource.PlayOneShot(lose);
        }
    }

    private void Start()
    {
        show = true;
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
            show = false;
        });
    }
}
