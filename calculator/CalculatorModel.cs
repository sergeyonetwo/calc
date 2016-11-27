using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class CalculatorModel
    {
        private string firstOperand;
        private string secondOperand;
        private string operation;
        private string result;

        #region constructors
        public CalculatorModel()
        {
            this.firstOperand = string.Empty;
            this.secondOperand = string.Empty;
            this.operation = string.Empty;
            this.result = string.Empty;
        }
        #endregion

        public string FirstOperand
        {
            get
            {
                return firstOperand;
            }
            set
            {
                firstOperand = value;
            }
        }
        public string SecondOperand
        {
            get
            {
                return secondOperand;
            }
            set
            {
                secondOperand = value;
            }
        }
        public string Operation
        {
            get
            {
                return operation;
            }
            set
            {
                operation = value;
            }
        }
        public string Result { get { return result; } }

        public void CalculateResult()
        {
            ValidateOperand(firstOperand);
            ValidateOperand(secondOperand);
            try
            {
                switch (operation)
                {
                    case "+":
                        result = (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                        break;
                    case "-":
                        result = (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                        break;
                    case "*":
                        result = (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                        break;
                    case "/":
                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand)).ToString();
                        break;
                }

            }
            catch (Exception)
            {
                result = "Error during calculation";
            }
        }

        public void ValidateOperand(string operand)
        {
            try
            {
                Convert.ToDouble(operand);
            }
            catch (Exception)
            {
                result = "Invalid number:" + firstOperand;
                throw new Exception("Wrong input");
            }
        }

        public void Clear()
        {
            this.firstOperand = string.Empty;
            this.secondOperand = string.Empty;
            this.Operation = string.Empty;
            this.result = string.Empty;
        }
    }
}
