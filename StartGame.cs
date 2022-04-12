using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class StartGame : MonoBehaviour
{
    public string playerName;
    public int playerScore;
    public static StartGame Instance;
    public InputField playerNameInput;
    // Start is called before the first frame update
    private void Awake(){
        if(Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updatePlayerName(){
        playerName = playerNameInput.text;
        startGame();
    }
    private void startGame(){
        SceneManager.LoadScene(1);
    }
    [System.Serializable]
    class SaveData{
        public string savedPlayerName;
        public int savedPlayerScore;
    }
    public void SaveNameandScore(){
        SaveData data = new SaveData();
        data.savedPlayerName = playerName;
        data.savedPlayerScore = playerScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    //Needed if there was a high score UI Screen
    public void LoadNameandScore(){
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path)){
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.savedPlayerName;
            playerScore = data.savedPlayerScore;
        }
    }
}
