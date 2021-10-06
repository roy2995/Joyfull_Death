using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChangerTest : MonoBehaviour
{

    public ChairTrigger _ChairWaiting;

    [SerializeField]
    public float _duration;
    public Image _rawImage;
    private bool _isSit;
    public float Timer = 0f;
    public Color currentColor, startColor, endColor;
    void Start()
    {
        startColor = new Color(0f, 1f, 0);
        endColor = new Color(1f, 0f, 0f);
    }

    /*void Update()
    {
        if(Timer <= _duration)
        {
            Timer += Time.deltaTime;
            currentColor = Color.Lerp(startColor, endColor, Timer / _duration);
            _rawImage.color = currentColor;
        }
    }*/

    void ColorChangin()
    {
        if (Timer <= _duration)
        {
            Timer += Time.deltaTime;
            currentColor = Color.Lerp(startColor, endColor, Timer / _duration);
            _rawImage.color = currentColor;
        }
    }

    private void OnTriggerStay(Collider sitting)
    {
        if (gameObject.tag == "Client")
        {
            _isSit = true;
            StartCoroutine("WaitingTime");
        }
        else
        {
            _isSit = false;
            StopCoroutine("WaitingTime");
        }

        //Esta parte del trigger se supuso que al precionar E reiniciaria el tiempo.
        if (gameObject.CompareTag("Player"))
        {
            if (_ChairWaiting._takeOrder == true)
                if (Input.GetKeyDown(KeyCode.E))
                {
                    {
                        Debug.Log("Se ha reiniciado el tiempo?");
                        Timer = 0f;
                    }
                }
        }


    }

    IEnumerator WaitingTime()
    {
        if (_isSit == true)
        {
            ColorChangin();
        }
        yield return new WaitForSeconds(1f);
    }
}
