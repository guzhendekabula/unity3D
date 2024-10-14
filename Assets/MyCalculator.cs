using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCalculator : MonoBehaviour
{
    public class Calculator_total
    {
        public string num1 { get; set; } = "";
        public string num2 { get; set; } = "";
        public float answer { get; set; }
        public string calculation_mode { get; set; }
        public bool Is_num2 { get; set; } = false;
        public string gongshi { get; set; } = "";
    }
    public class Calculator_logic
    {
        private Calculator_total my_calculator;

        public Calculator_logic(Calculator_total mycalculator)
        {
            my_calculator = mycalculator;
        }
        public void jisuan()
        {
            
            float a = float.Parse(my_calculator.num1);
            float b = float.Parse(my_calculator.num2);
            switch (my_calculator.calculation_mode)
            {
                case "+":
                    my_calculator.answer = a + b;
                    break;
                case "-":
                    my_calculator.answer = a - b;
                    break;
                case "*":
                    my_calculator.answer = a * b;
                    break;
                case "/":
                    my_calculator.answer = a / b;
                    break;
            }
            my_calculator.num1 = "";
            my_calculator.num2 = "";
            my_calculator.Is_num2 = false;
        }
        public void OnGUI()
        {
            //标签
            GUI.Box(new Rect(180, 15, 350, 450), " ");
            GUI.Label(new Rect(275, 15, 100, 75), "简易计算器");
            for(int i = 0; i <=9; i++)
            {
                if(GUI.Button(new Rect(200 + (i % 3) * 70, 60 + (i / 3) * 70, 60, 60), i.ToString()))
                {
                    if (my_calculator.Is_num2)
                    {
                        my_calculator.num2 = my_calculator.num2 + i.ToString();
                        my_calculator.gongshi = my_calculator.gongshi + i.ToString();
                    }
                    else
                    {
                        if (my_calculator.num1.Length == 0)
                        {
                            my_calculator.gongshi = "";
                        }
                        my_calculator.num1 = my_calculator.num1 + i.ToString();
                        my_calculator.gongshi = my_calculator.gongshi + i.ToString();
                    }
                }
            }
            if(GUI.Button(new Rect(410,270,60,60), "+"))
            {
                my_calculator.calculation_mode = "+";
                my_calculator.Is_num2 = true;
                my_calculator.gongshi = my_calculator.gongshi + "+";
            }
            if (GUI.Button(new Rect(410, 200, 60, 60), "-"))
            {
                my_calculator.calculation_mode = "-";
                my_calculator.Is_num2 = true;
                my_calculator.gongshi = my_calculator.gongshi + "-";
            }
            if (GUI.Button(new Rect(410, 130, 60, 60), "*"))
            {
                my_calculator.calculation_mode = "*";
                my_calculator.Is_num2 = true;
                my_calculator.gongshi = my_calculator.gongshi + "*";
            }
            if (GUI.Button(new Rect(410, 60, 60, 60), "/"))
            {
                my_calculator.calculation_mode = "/";
                my_calculator.Is_num2 = true;
                my_calculator.gongshi = my_calculator.gongshi + "/";
            }
            if (GUI.Button(new Rect(270, 270, 60, 60), "="))
            {
                jisuan();
            }
            if (GUI.Button(new Rect(340, 270, 60, 60), "重置"))
            {
                my_calculator.num1 = "";
                my_calculator.num2 = "";
                my_calculator.gongshi = "";
                my_calculator.answer = 0;
                my_calculator.Is_num2 = false;
            }
            GUI.Label(new Rect(275, 400, 200, 200), "运算结果为：" + my_calculator.answer);
            GUI.Label(new Rect(275, 350, 200, 200), "运算式为： " + my_calculator.gongshi);
        }
    }
    private Calculator_total my_calculator;
    private Calculator_logic _controller;
    // Start is called before the first frame update
    void Start()
    {
        my_calculator = new Calculator_total();
        _controller = new Calculator_logic(my_calculator);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI()
    {
        _controller.OnGUI();
    }
}
