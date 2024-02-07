using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Data;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    [SerializeField] private string fileName;
    [SerializeField] private bool encryptData;

    private GameData gameData;
    private List<ISaveManager> saveManagers;
    private FileHandler fileHandler;

    [ContextMenu("Delete save file")]

    private void Awake()
    {
        if(instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;

    }

    private void Start()
    {
        fileHandler = new FileHandler(Application.persistentDataPath, fileName,encryptData);
        saveManagers = FindAllSaveManagers();
        
        LoadGame();
    }
    public void NewGame()
    {
        gameData = new GameData();
    }

    public void LoadGame()
    {
        gameData = fileHandler.Load();

        if(this.gameData == null)
        {
            Debug.Log("No, saved data found");
            NewGame();
        }
        foreach (ISaveManager saveManager in saveManagers)
        {
            saveManager.LoadData(gameData);
        }

    }

    public void SaveGame()
    {
        foreach (ISaveManager saveManager in saveManagers)
        {
            saveManager.SaveData(ref gameData);
        }

        fileHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<ISaveManager> FindAllSaveManagers()
    {
        IEnumerable<ISaveManager> saveManagers = FindObjectsOfType<MonoBehaviour>().OfType<ISaveManager>();

        return new List<ISaveManager>(saveManagers);
    }

    public void DeleteSavedDate()
    {
        fileHandler = new FileHandler(Application.persistentDataPath, fileName,encryptData);
        fileHandler.Delete();
    }

    public bool HasSaveData()
    {
        if(fileHandler.Load() != null)
        {
            return true;
        }
        return false;
    }

}
