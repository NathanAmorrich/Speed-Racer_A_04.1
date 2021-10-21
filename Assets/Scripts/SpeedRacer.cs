using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SpeedRacer : MonoBehaviour
{

    public string carModel = "Huracan Evoby";
    public string engineType = "Naturally Aspirated V10";
    public string carMaker = "Lamborghini";
    public int carWeight = 1665;
    public int yearMade = 2019;
    public int carAge = 0;
    public float maxAcceleration = 1.06f;
    public bool isCarTypeSedan = false;
    public bool hasFrontEngine = false;

    public Text CarIntro_txt;
    public Text YearMade_txt;
    public Text CarAge_txt;
    public Text CarMaxAccell_txt;
    public Text CarWeight_txt;
    public Text CarType_txt;
    public Text CarFuelLevel_txt;


    public class Fuel
    {
        public int fuelLevel;

        public Fuel(int amount)
        {
            fuelLevel = amount;
        }
    }

    public Fuel carFuel = new Fuel(110);

    // Called when the script instance is being loaded.
    void Awake()
    {
        CarIntro_txt = GameObject.Find("Canvas/CarIntro_txt").GetComponent<Text>();
        YearMade_txt = GameObject.Find("Canvas/YearMade_txt").GetComponent<Text>();
        CarAge_txt = GameObject.Find("Canvas/CarAge_txt").GetComponent<Text>();
        CarMaxAccell_txt = GameObject.Find("Canvas/CarMaxAccell_txt").GetComponent<Text>();
        CarWeight_txt = GameObject.Find("Canvas/CarWeight_txt").GetComponent<Text>();
        CarType_txt = GameObject.Find("Canvas/CarType_txt").GetComponent<Text>();
        CarFuelLevel_txt = GameObject.Find("Canvas/DecreaseCarFuel10_btn/CarFuelLevel_txt").GetComponent<Text>();
    }

    void ConsumeFuel()
    {
        carFuel.fuelLevel -= 10;
    }

    void CheckFuelLevel()
    {
        switch (carFuel.fuelLevel)
        {
            case 70:
                //print("Fuel level is nearing two-thirds.");
                CarFuelLevel_txt.text = "Fuel level is nearing two-thirds.";
                break;

            case 50:
                //print("Fuel level is at half amount.");
                CarFuelLevel_txt.text = "Fuel level is at half amount.";
                break;

            case 10:
                //print("Warning ! Fuel level is critically low.");
                CarFuelLevel_txt.text = "Warning ! Fuel level is critically low.";
                break;

            default:
                //print("Nothing to report.");
                CarFuelLevel_txt.text = "Nothing to report";
                break;
        }
    }

    // Start is called before the first frame update.
    void Start()
    {

        //print("The car model is "+carModel+" from "+carMaker+" and has a "+engineType+" engine.");
        CarIntro_txt.text = "The car model is " + carModel + " from " + carMaker + " and has a " + engineType + " engine.";

        CheckWeight();

        if (yearMade <= 2009)
        {
            //print("The car was introduced in " + yearMade);
            YearMade_txt.text = "The car was introduced in " + yearMade;

            carAge = CalculateAge(yearMade);

            //print("The age of the car is "+carAge+" years old.");
            CarAge_txt.text = "The age of the car is " + carAge + " years old.";
        }
        else
        {
            //print("The car was introduced in the 2010's");
            CarAge_txt.text = "The car was introduced in the 2010's";

            //print("The car's maximum acceleration is " +maxAcceleration+ "m/s^2");
            CarMaxAccell_txt.text = "The car's maximum acceleration is " + maxAcceleration + "m/s^2";

        }

        //print(CheckCharacteristics());
        CheckCharacteristics();

    }

    void CheckWeight()
    {
        if (carWeight < 1500)
        {
            //print("The car weights LESS than 1500kg");
            CarWeight_txt.text = "The car weights LESS than 1500kg";
        }
        else
        {
            //print("The car weights MORE than 1500kg");
            CarWeight_txt.text = "The car weights MORE than 1500kg";
        }
    }

    int CalculateAge(int age)
    {
        return 2021 - age;
    }

    string CheckCharacteristics()
    {

        if (isCarTypeSedan)
        {
            CarType_txt.text = "This car is a sedan";
            return "This car is a sedan";

        }
        else
        {

            if (hasFrontEngine)
            {
                CarType_txt.text = "This car is not a sedan but it has a front engine";
                return "This car is not a sedan but it has a front engine";


            }
            else
            {
                CarType_txt.text = "This car is not a sedan and has no front engine";
                return "This car is not a sedan and has no front engine";

            }
        }

    }

    public void OnClickDecreaseFuel()
    {
        ConsumeFuel();
        CheckFuelLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ConsumeFuel();
            CheckFuelLevel();
        }
    }
}
