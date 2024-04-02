using UnityEngine;
using System.Collections;
using TMPro;
using System.Collections.Generic;

public class UI : MonoBehaviour,ISaveManager
{
    [Header("End screen")]
    [SerializeField] UI_fadeScreen fadeScreen;
    [SerializeField] GameObject endText;
    [SerializeField] GameObject restartButton;
    [Space]


    [SerializeField] GameObject characterUI;
    [SerializeField] GameObject skillTree;
    [SerializeField] GameObject itemUI;
    [SerializeField] GameObject optionUI;
    [SerializeField] GameObject inGameUI;


    public UI_ItemTool itemToolTip;
    public UI_StatToolTip statToolTip;

    [SerializeField] UI_AudioSlider[] volumeSettings;

    private void Awake()
    {
        fadeScreen.gameObject.SetActive(true);
    }

    void Start()
    {
        SwitchTo(inGameUI);
        itemToolTip.gameObject.SetActive(false);
        statToolTip.gameObject.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) //using tab key to open character UI 
            SwitchWithKeyTo(characterUI);

    }

    public void SwitchTo(GameObject _menu)
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            bool fadeScreen = transform.GetChild(i).GetComponent<UI_fadeScreen>() != null;
            if(!fadeScreen)
                transform.GetChild(i).gameObject.SetActive(false);
        }

        if (_menu != null)
        {
            _menu.SetActive(true);
        }

        if (GameManager.instance != null)
        {
            if (_menu == inGameUI)
                GameManager.instance.PauseGame(false); //unpaused the time during INGameUI
            else
                GameManager.instance.PauseGame(true);//paused the time when the characterUI open 
        }
    }

    public void SwitchWithKeyTo(GameObject _menu)
    {
        if (_menu != null && _menu.activeSelf)
        {
            _menu.SetActive(false);
            CheckForINGameUI();
            return;
        }
        SwitchTo(_menu);
    }

    private void CheckForINGameUI()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf && transform.GetChild(i).GetComponent<UI_fadeScreen>() == null)
                return;
        }
        SwitchTo(inGameUI);
    }


    public void SwitchOnEndScreen()
    {
        fadeScreen.FadeOut();
        StartCoroutine(EndScreenCorutione());
    }

    IEnumerator EndScreenCorutione()
    {
        yield return new WaitForSeconds(1);
        endText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        restartButton.SetActive(true);
    }
    public void RestartGameButton() => GameManager.instance.RestartGame();
    

    public void LoadData(GameData _data)
    {
        foreach(KeyValuePair<string, float> pair in _data.volumeSetting)
        {
            foreach(UI_AudioSlider item in volumeSettings)
            {
                if(item.parameter == pair.Key)
                    item.LoadSlider(pair.Value);
            }
        }
    }
    public void SaveData(ref GameData _data)
    {
        _data.volumeSetting.Clear();

        foreach(UI_AudioSlider item in volumeSettings)
            _data.volumeSetting.Add(item.parameter, item.slider.value);
    }
}
