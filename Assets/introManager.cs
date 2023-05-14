using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class introManager : MonoBehaviour
{
    [SerializeField] Image image = null;
    [SerializeField] Image image1 = null;
    [SerializeField] Image image2 = null;
    video thevdo;

    void Start()
    {
        thevdo = FindObjectOfType<video>();
        StartCoroutine(FadeTextToFullAlpha(1.5f, image, image2, image1));
    }

    public IEnumerator FadeTextToFullAlpha(float t, Image i, Image j, Image k)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        j.color = new Color(j.color.r, j.color.g, j.color.b, 0);
        k.color = new Color(k.color.r, k.color.g, k.color.b, 0);

        while (j.color.a < 1.0f)
        {
            j.color = new Color(j.color.r, j.color.g, j.color.b, j.color.a + (Time.deltaTime / t));
            yield return null;
        }
        j.color = new Color(j.color.r, j.color.g, j.color.b, 1);
        while (j.color.a > 0.0f)
        {
            j.color = new Color(j.color.r, j.color.g, j.color.b, j.color.a - (Time.deltaTime / t));
            yield return null;
        }

        while (i.color.a < 1.5f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            k.color = new Color(k.color.r, k.color.g, k.color.b, k.color.a + (Time.deltaTime / t));
            yield return null;
        }
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        k.color = new Color(k.color.r, k.color.g, k.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            k.color = new Color(k.color.r, k.color.g, k.color.b, k.color.a - (Time.deltaTime / t));
            yield return null;
        }

        thevdo.videoStart();
    }

}
