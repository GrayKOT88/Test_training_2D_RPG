using UnityEngine;

public class ShopButtonToggles : MonoBehaviour
{
    public void OpenItemShop()
    {
        if(ShopKeeper.currentShopKeeper != null)
        {
            ShopKeeper.currentShopKeeper.OpenItemShop();
        }
    }
    public void OpenWeaponsShop()
    {
        if(ShopKeeper.currentShopKeeper != null)
        {
            ShopKeeper.currentShopKeeper.OpenWeaponShop();
        }
    }
    public void OpenArmoursShop()
    {
        if(ShopKeeper.currentShopKeeper != null)
        {
            ShopKeeper.currentShopKeeper.OpenArmourShop();
        }
    }

}
