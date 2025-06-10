using UnityEngine;
public class MobileInputBridge : MonoBehaviour
{
    public PlayerController player;
    
    public void OnCrouchButtonPressed()
    {
        player.SendMessage("ToggleCrouch");
    }
}
