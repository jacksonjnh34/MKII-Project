using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class GUI : MonoBehaviour
{
    public int maxHealth = 6;
    public int health = 3;

    public float maxStamina;
    public float currentStamina;

    [SerializeField] Text textComponentStamina;
    [SerializeField] Text textComponent;
    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth(maxHealth.ToString());
    }

    void Update()
    {
        //Change this to If(takes damage) once we implement damage
        if (Input.GetKey("g"))
        {
            UpdateHealth(health.ToString());
        }

        PlayerController maxStaminaGUI = GetComponent<PlayerController>();
        maxStamina = maxStaminaGUI.maxStamina;
        PlayerController currentStaminaGUI = GetComponent<PlayerController>();
        currentStamina = currentStaminaGUI.currentStamina;
        UpdateStamina(currentStamina.ToString());
    }

    // Update is called once per frame
    public void UpdateHealth(string health)
    {
        textComponent.text = health.ToString() + "/" + maxHealth.ToString();
    }
    
    // Update is called once per frame
    public void UpdateStamina(string currentStamina)
    {
        textComponentStamina.text = currentStamina.ToString() + "/" + maxStamina.ToString();
    }
}
