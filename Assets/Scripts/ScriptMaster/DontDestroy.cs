using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // Keep Script Manager Active even when switching scenes
    public void Awake(){
        DontDestroyOnLoad(this);
    }   
}
