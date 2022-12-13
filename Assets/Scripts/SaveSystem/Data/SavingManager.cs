using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SavingManager:MonoBehaviour
{
   private GameData gameData;
   private List<ISavingManager> savingManagers;
    [SerializeField] private string fileName;

    private FileDataHandler fileHandler;
   public static SavingManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null)
            Debug.Log("There is already saving manager in this scene.");
        instance = this;
    }
    private void Start()
    {
        this.fileHandler = new FileDataHandler(Application.persistentDataPath,fileName);
        this.savingManagers = FindAllSavingManagerObjects();
        var ddm = GameObject.Find("DontDestroyManager");
        if (ddm != null)
        {
            var script = ddm.GetComponent<LoadingScreenSCript>();
            if (script.loadGame == true)
            {
                LoadGame();
                script.loadGame = false;

            }
            else if (script.newGame == true)
            {
                NewGame();
                script.newGame = false;
            }
        }
        else
            return;

    }
    public void NewGame()
    {
        this.gameData=new GameData();
        foreach (ISavingManager savingManager in savingManagers)
        {
            savingManager.Load(gameData);
        }
    }
    public void LoadGame()
    {
        this.gameData = fileHandler.Load();
        if (this.gameData== null)
            NewGame();
        foreach(ISavingManager savingManager in savingManagers)
        {
            savingManager.Load(gameData);
        }
    }
    public void SaveGame()
    {
        foreach (ISavingManager savingManager in savingManagers)
        {
            savingManager.Save(gameData);
            fileHandler.Save(gameData);
        }
    }
    private List<ISavingManager> FindAllSavingManagerObjects()
    {
        IEnumerable<ISavingManager> savingManagerObjects = FindObjectsOfType<MonoBehaviour>().OfType<ISavingManager>();
        return new List<ISavingManager>(savingManagerObjects);
    }
}
