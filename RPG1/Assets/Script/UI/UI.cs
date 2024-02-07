using UnityEngine;

public class UI : MonoBehaviour
{
    public UI_ItemTool itemToolTip;
    public UI_StatToolTip statToolTip;

    [SerializeField] GameObject characterUI;
    [SerializeField] GameObject skillTree;
    [SerializeField] GameObject itemUI;
    [SerializeField] GameObject optionUI;
    [SerializeField] GameObject inGameUI;
    void Start()
    {
        SwitchTo(inGameUI);
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
            transform.GetChild(i).gameObject.SetActive(false);
        }

        if (_menu != null)
        {
            _menu.SetActive(true);
        }

        if (GameManager.instance != null)
        {
            if (_menu == inGameUI)
            {
                GameManager.instance.PauseGame(false); //unpaused the time during INGameUI
            }
            else
            {
                GameManager.instance.PauseGame(true);//paused the time when the characterUI open 
            }
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
            if (transform.GetChild(i).gameObject.activeSelf)
                return;
        }
        SwitchTo(inGameUI);
    }

    public void RestartGameButton() => GameManager.instance.RestartGame();
}
