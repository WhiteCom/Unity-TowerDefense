using UnityEngine;

public class PlayerPrefsReset : MonoBehaviour
{ 
    
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
}
