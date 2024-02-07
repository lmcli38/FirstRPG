using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EntityFX : MonoBehaviour
{
    SpriteRenderer sr;

    [Header("POp Up Text")]
    [SerializeField] private GameObject popUpTextPrefab;

    [Header("Flash Fx")]
    [SerializeField] float flashDuration;
    [SerializeField] Material hitMat;
    Material originalMat;

    [Header("Ailment colors")]
    [SerializeField] Color[] igniteColor;
    [SerializeField] Color[] chillColor;
    [SerializeField] Color[] shockColor;

    private GameObject myHealthBar;
    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        originalMat = sr.material;
        if(this.GetComponent<Player>()==null)
            myHealthBar = GetComponentInChildren<HealthBar_UI>().gameObject;
    }

    IEnumerator FlashFX()
    {
        sr.material = hitMat;
        Color currentColor = sr.color;

        sr.color = Color.white;

        yield return new WaitForSeconds(flashDuration);

        sr.material = originalMat;
    }
    void CancelColorChange()
    {
        CancelInvoke();
        sr.color = Color.white;
    }

    public void IngiteFxFor(float _seconds)
    {
        InvokeRepeating("IngiteColorFX", 0, .3f);
        Invoke("CancelColorChange", _seconds);
    }
    public void ChillFxFor(float _seconds)
    {
        InvokeRepeating("ChillColorFX", 0, .3f);
        Invoke("CancelColorChange", _seconds);
    }

    public void ShockFxFor(float _seconds)
    {
        InvokeRepeating("ShockColorFx", 0, .3f);
        Invoke("CancelColorChange", _seconds);
    }


    void IngiteColorFX()
    {
        if(sr.color != igniteColor[0]) 
            sr.color = igniteColor[0];
        else
            sr.color = igniteColor[1];
    }
    void ChillColorFX()
    {
        if (sr.color != chillColor[0])
            sr.color = chillColor[0];
        else
            sr.color = chillColor[1];
    }
    void ShockColorFx()
    {
        if (sr.color != shockColor[0])
            sr.color = shockColor[0];
        else
            sr.color = shockColor[1];
    }

    public void MakeTransprent(bool _transprent)
    {
        if (_transprent)
        {
            myHealthBar.SetActive(false);
            sr.color = Color.clear;
        }
        else
        {
            myHealthBar.SetActive(true);
            sr.color = Color.white;
        }
    }

    public void CreatePopUpText(string _text)
    {
        float randomX = Random.Range(-1, 1);
        float randomY = Random.Range(1, 5);
        Vector3 positionOffset = new Vector3(randomX, randomY, 0);

        GameObject newText = Instantiate(popUpTextPrefab,transform.position + positionOffset,Quaternion.identity);
        newText.GetComponent<TextMeshPro>().text = _text;
    }
}
