using UnityEngine;

public class LocationObjectDestruction : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D col)
   {
       {
           Destroy(col.gameObject);

       }
       
   }
}
