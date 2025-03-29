using UnityEngine;

public class Dsamage_Handeler : MonoBehaviour
{


    public void Take(float damage)
    {
        if (gameObject.GetComponent<MoveToClickPoint>() != null)
        {
            gameObject.GetComponent<MoveToClickPoint>().Take(damage);
           
        }
        if (gameObject.GetComponent<Player_Heath>() != null)
        {
            gameObject.GetComponent<Player_Heath>().Take(damage);
            
        }
        
    } 
    
}
