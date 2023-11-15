using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
   public void GoToScene (string scenename)
   {
     SceneManager.LoadScene (scenename);    
   }

   public void QuitGame ()
   {
        Application.Quit ();    
   }   
}
