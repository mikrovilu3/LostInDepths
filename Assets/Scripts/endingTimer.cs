using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class EndingTimer : MonoBehaviour
{
    public float TimeToTriggerEnd = 180;
    public string Scene;
    public GameObject player;
    
    void Start()
    {
        Invoke(nameof(TriggerEndig),TimeToTriggerEnd);
    }

    void TriggerEndig()
    {
        SceneManager.LoadScene(Scene);
    }
    private void OnTriggerExit(Collider other)
    {   if(other != null&&other.gameObject==player)
        CancelInvoke();
    }
}
