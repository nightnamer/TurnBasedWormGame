using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] private Image staminaImage;
    public void UpdateStaminaBar(float maxStamina, float stamina)
    {
        staminaImage.fillAmount = stamina / maxStamina;
    }
}
