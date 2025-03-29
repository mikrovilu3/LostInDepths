using UnityEngine;

public class Dsamage_Handeler : MonoBehaviour
{


    public void Take(float damage)
    {
        if (gameObject.GetComponent<MoveToClickPoint>() != null)
        {
            gameObject.GetComponent<MoveToClickPoint>().Take(damage);
        }else { Debug.Log("nonav handeler"); }
        if (gameObject.GetComponent<Player_Heath>() != null)
        {
            gameObject.GetComponent<Player_Heath>().Take(damage);
        }
        else { Debug.Log("no player"); }
    } 
    
}
