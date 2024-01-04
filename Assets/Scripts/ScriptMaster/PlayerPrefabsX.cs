using UnityEngine;

public class PlayerPrefabsX : MonoBehaviour
{
    //private int savevalue = 0;

    // Save the players user settings
    public void SetSavePrefs(string savedata, int savevalue)
    {
        PlayerPrefs.SetInt(savedata, savevalue);
        PlayerPrefs.Save();
    }
    
    // Get the Player's Preferences
    public int GetPlayerPrefs(string savedata)
    {
        int savevalue = PlayerPrefs.GetInt(savedata, 0);
        return savevalue;
    }

}
