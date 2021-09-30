using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class timer : MonoBehaviour
{
    [Header("Timer references")]
    [SerializeField] private Image uifillimage;
    [SerializeField] private Text uitext;
    public int duration { get; private set; }
    private int remainingdiration;

    private void Awake()
    {
        ResetTimer();
    }

    public void ResetTimer()
    {
        uitext.text = "00:00";
        uifillimage.fillAmount = 0f;
        duration = remainingdiration = 0;
    }

    public timer SetDuration(int seconds)
    {
        duration = remainingdiration = seconds;
        return this;
    }

    public void Begin()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingdiration > 0)
        {
            updateUI(remainingdiration);
            remainingdiration--;
            yield return new WaitForSeconds(1f);
        }
        End();
    }

    private void updateUI(int seconds)
    {
        uitext.text = string.Format("{0:D2}:{1:D2}", seconds / 60, seconds % 60);
        uifillimage.fillAmount = Mathf.InverseLerp(0, duration, seconds);
    }

    public void End()
    {
        ResetTimer();
    }

}
