using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GuiLab3Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double tempValue = 0;
        private char lastActionClicked; 

        public MainWindow()
        {
            InitializeComponent();
        }

        /*-------------------------------- Övriga metoder ----------------------------------------*/
        private void setLabel(string value)
        {
            if (containsDecimal(label_Value.Content.ToString()) && value != ",")    //Inte två decimaler i samma tal
                label_Value.Content = label_Value.Content + value;

            else if (getValueFromLabel() != 0 && !containsDecimal(label_Value.Content.ToString()))
                label_Value.Content = label_Value.Content + value;


            else label_Value.Content = value;
        }

        private double getValueFromLabel()
        {
            return Convert.ToDouble(label_Value.Content);
        }

        private void resetAll()
        {
            label_Value.Content = "0";
            label_Remember.Content = "";
            tempValue = 0;
        }

        private bool containsDecimal(string str)
        {
            foreach (char c in str)
                if (c == ',')
                    return true;

            return false;
        }
        /*-----------------------------------------------------------------------------------------*/

        /*------------------------------- Knappar -EVENTHANTERARE --------------------------------*/
        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            resetAll();
        }

        private void btn_Number_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string value = btn.Content.ToString();

            setLabel(value);
        }

        private void btn_Decimal_Click(object sender, RoutedEventArgs e)
        {
            setLabel(",");
        }

        private void btn_Plus_Click(object sender, RoutedEventArgs e)
        {
            lastActionClicked = '+';

            if (tempValue > 0)
                calcPlus();

            else
            {
                tempValue = getValueFromLabel();
                label_Remember.Content = tempValue + " +";
                label_Value.Content = 0;
            }
        }

        private void btn_Minus_Click(object sender, RoutedEventArgs e)
        {
            lastActionClicked = '-';

            if (tempValue > 0)
                calcMinus();

            else
            {
                tempValue = getValueFromLabel();
                label_Remember.Content = tempValue + " -";
                label_Value.Content = 0;
            }
        }

        private void btn_Division_Click(object sender, RoutedEventArgs e)
        {
            lastActionClicked = '÷';

            if (tempValue > 0)
                calcDivision();

            else
            {
                tempValue = getValueFromLabel();
                label_Remember.Content = tempValue + " ÷";
                label_Value.Content = 0;
            }
        }

        private void btn_Multi_Click(object sender, RoutedEventArgs e)
        {
            lastActionClicked = '*';

            if (tempValue > 0)
                calcMult();

            else
            {
                tempValue = getValueFromLabel();
                label_Remember.Content = tempValue + " x";
                label_Value.Content = 0;
            }
        }

        private void btn_Equals_Click(object sender, RoutedEventArgs e)
        {
            if (lastActionClicked == '+')
                calcPlus();

            else if (lastActionClicked == '-')
                calcMinus();

            else if (lastActionClicked == '÷')
                calcDivision();

            else if (lastActionClicked == '*')
                calcMult();
        }

        private void btn_PosNeg_Click(object sender, RoutedEventArgs e)
        {
            double value = getValueFromLabel();
            value = value * -1;

            resetAll();
            setLabel(value.ToString());

        }
        /*-----------------------------------------------------------------------------------------*/

        /*------------------------------------- Beräkningar ---------------------------------------*/
        private void calcPlus()
        {
            double newVal;
            newVal = tempValue + getValueFromLabel();
            resetAll();
            setLabel(newVal.ToString());
        }

        private void calcMinus()
        {
            double newVal;
            newVal = tempValue - getValueFromLabel();
            resetAll();
            setLabel(newVal.ToString());
        }

        private void calcDivision()
        {
            double newVal;
            newVal = tempValue / getValueFromLabel();
            resetAll();
            setLabel(newVal.ToString());
        }

        private void calcMult()
        {
            double newVal;
            newVal = tempValue * getValueFromLabel();
            resetAll();
            setLabel(newVal.ToString());
        }
        /*-----------------------------------------------------------------------------------------*/
    }
}
