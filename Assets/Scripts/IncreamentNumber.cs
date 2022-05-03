using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IncreamentNumber : MonoBehaviour
{
    private bool isCounting;
    private int counter;
    public TextMeshProUGUI counterText;

    private void Start()
    {
        isCounting = false;
        counter = 0;
        if (PlayerPrefs.HasKey("counter"))
        {
            counter = PlayerPrefs.GetInt("counter");
        }
        counterText.text = counter.ToString();
    }

    // On/Off Button
    public void OnAndOffButton()
    {
        if (isCounting)
            isCounting = false;
        else
        {
            isCounting = true;
            StartCoroutine(Count());
        }
    }

    // Count every second
    IEnumerator Count()
    {
        while (isCounting)
        {
            yield return new WaitForSeconds(1f);
            counter++;
            PlayerPrefs.SetInt("counter", counter);
            counterText.text = counter.ToString();
        }
    }
}
