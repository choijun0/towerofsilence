using UnityEngine;

public class ScreenLock : MonoBehaviour
{
    [SerializeField] private GameObject locker;
    
    private static ScreenLock instance;
    public static ScreenLock Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScreenLock>();
            }

            return instance;
        }
    }

    public static void Lock()
    {
        Instance.locker.SetActive(true);
    }

    public static void Unlock()
    {
        Instance.locker.SetActive(false);
    }

}
