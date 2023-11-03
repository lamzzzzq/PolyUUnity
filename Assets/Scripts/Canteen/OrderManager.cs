using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [Header("CanteenWindows")]
    public GameObject btnA;
    public GameObject btnB;
    public GameObject btnC;
    public GameObject btnD;


    [Header("CanteenWindows")]
    public GameObject FoodA_CanteenWindows;
    public GameObject FoodB_CanteenWindows;
    public GameObject FoodC_CanteenWindows;
    public GameObject FoodD_CanteenWindows;

    [Header("TableMeal_BeforeAsk")]
    public GameObject FoodA_BeforeAsk;
    public GameObject FoodB_BeforeAsk;
    public GameObject FoodC_BeforeAsk;
    public GameObject FoodD_BeforeAsk;

    [Header("TableMeal_AfterAsk")]
    public GameObject FoodA_AfterAsk;
    public GameObject FoodB_AfterAsk;
    public GameObject FoodC_AfterAsk;
    public GameObject FoodD_AfterAsk;

    [Header("TableMeal_Final")]
    public GameObject FoodA_Final;
    public GameObject FoodB_Final;
    public GameObject FoodC_Final;
    public GameObject FoodD_Final;

    [Header("Tray")]
    public GameObject FoodA_Tray;
    public GameObject FoodB_Tray;
    public GameObject FoodC_Tray;
    public GameObject FoodD_Tray;


    private string selectedMeal;

    // 用于初始化，确保所有食物都是不活动的
    private void Start()
    {
        FoodA_CanteenWindows.SetActive(false);
        FoodB_CanteenWindows.SetActive(false);
        FoodC_CanteenWindows.SetActive(false);
        FoodD_CanteenWindows.SetActive(false);
    }

    // 记录玩家的选择
    public void SelectMeal(string meal)
    {
        selectedMeal = meal;
        DeactivateAllButtons();
        Debug.Log("I have ordered" + meal);
    }

    // 根据玩家的选择激活相应的食物
    public void WindowsMeal()
    {
        DeactivateWindowsMeals();  // 首先确保所有食物都是不活动的

        switch (selectedMeal)
        {
            case "A":
                FoodA_CanteenWindows.SetActive(true);
                break;
            case "B":
                FoodB_CanteenWindows.SetActive(true);
                break;
            case "C":
                FoodC_CanteenWindows.SetActive(true);
                break;
            case "D":
                FoodD_CanteenWindows.SetActive(true);
                break;
        }
    }

    public void MealOnTableBeforeAsk()
    {
        switch (selectedMeal)
        {
            case "A":
                FoodA_BeforeAsk.SetActive(true);
                break;
            case "B":
                FoodB_BeforeAsk.SetActive(true);
                break;
            case "C":
                FoodC_BeforeAsk.SetActive(true);
                break;
            case "D":
                FoodD_BeforeAsk.SetActive(true);
                break;
        }

        DeactivateWindowsMeals();

    }

    public void MealOnTableForGrab()
    {
        switch (selectedMeal)
        {
            case "A":
                FoodA_AfterAsk.SetActive(true);
                break;
            case "B":
                FoodB_AfterAsk.SetActive(true);
                break;
            case "C":
                FoodC_AfterAsk.SetActive(true);
                break;
            case "D":
                FoodD_AfterAsk.SetActive(true);
                break;
        }
    }

    public void MealOnTableForEat()
    {
        switch (selectedMeal)
        {
            case "A":
                FoodA_Final.SetActive(true);
                break;
            case "B":
                FoodB_Final.SetActive(true);
                break;
            case "C":
                FoodC_Final.SetActive(true);
                break;
            case "D":
                FoodD_Final.SetActive(true);
                break;
        }
    }

    private void Tray()
    {
        switch (selectedMeal)
        {
            case "A":
                FoodA_Tray.SetActive(true);
                break;
            case "B":
                FoodB_Tray.SetActive(true);
                break;
            case "C":
                FoodC_Tray.SetActive(true);
                break;
            case "D":
                FoodD_Tray.SetActive(true);
                break;
        }
    }


    // 确保所有食物都是不活动的
    private void DeactivateWindowsMeals()
    {
        FoodA_CanteenWindows.SetActive(false);
        FoodB_CanteenWindows.SetActive(false);
        FoodC_CanteenWindows.SetActive(false);
        FoodD_CanteenWindows.SetActive(false);
    }

    public void DeactivateTableMeal_BeforeAsk()
    {
        Debug.Log("Deactivated!");
        FoodA_BeforeAsk.SetActive(false);
        FoodB_BeforeAsk.SetActive(false);
        FoodC_BeforeAsk.SetActive(false);
        FoodD_BeforeAsk.SetActive(false);
    }

    //call when move to the new seat
    public void DeactivateTableMeal_AfterAsk()
    {
        FoodA_AfterAsk.SetActive(false);
        FoodB_AfterAsk.SetActive(false);
        FoodC_AfterAsk.SetActive(false);
        FoodD_AfterAsk.SetActive(false);
    }

    //call when place the tray
    public void DeactivateTableMeal_AfterEat()
    {
        FoodA_Final.SetActive(false);
        FoodB_Final.SetActive(false);
        FoodC_Final.SetActive(false);
        FoodD_Final.SetActive(false);

        Tray();
    }

    private void DeactivateAllButtons()
    {
        GameObject[] allButtons = { btnA, btnB, btnC, btnD };
        foreach (GameObject btn in allButtons)
        {
            btn.SetActive(false);
        }
    }




}

