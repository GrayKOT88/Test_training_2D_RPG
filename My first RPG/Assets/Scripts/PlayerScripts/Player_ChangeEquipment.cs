using UnityEngine;

public class Player_ChangeEquipment : MonoBehaviour
{
    public Player_Combat combat;
    public Player_Bow bow;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            combat.enabled =!combat.enabled;
            bow.enabled =!bow.enabled;
        }
    }
}