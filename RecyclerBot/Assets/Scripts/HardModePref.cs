using UnityEngine;

public class HardModePref : MonoBehaviour
{
    public void DisableHardMode()
    {
        PlayerPrefs.SetInt("hardMode", -1);
    }
}
