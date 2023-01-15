/*
 * Program ID: SINvalidation
 * 
 * Prupose: To create the SIN calidation
 * 
 * Revision history:
 * Bryan Ayala and November 16,2022
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inClass5JRivasAyalaB_Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            //variable
            bool isValid;


            Console.WriteLine("Plese Enter your SIN in the follow format 'XXX-XXX-XXX'");
           
            isValid = validate(getSin());
            
            if (isValid)
            {
                Console.WriteLine("Validation Success!!!");
            }

            else if (!isValid)
            {
                Console.WriteLine("Validation Fails");
            }

            

            Console.ReadKey();

        }
        //Methog Get SIN
        static int[] getSin()
        {   
            //variables
            string sinString;
            bool enterToCath = false;
            int checkDigit = 0;
            int k = 0;
            bool keepgoing = true;
            int[] sinDigits = new int[9];

            while (keepgoing)
            {

                sinString = Console.ReadLine();

                

                int[] sinArray = new int[sinString.Length-2];
                char[] sinChar = new char[9];
                
                
                if (sinString.Length == 11)
                {

                    //Checking the hyphens
                    if (sinString[3].ToString() != "-" && !enterToCath)
                    {
                        enterToCath = true;
                    }

                    //Checking the hyphens
                    if (sinString[7].ToString() != "-" && !enterToCath)
                    {
                        enterToCath = true;
                    }


                    //checking the digits
                    for (int i = 0; i < sinString.Length; i++)
                    {
                       
                        if (char.IsDigit(sinString[i]) && !enterToCath)
                        {
                            checkDigit++;

                            sinChar[k] = sinString[i];

                            k++;

                           
                        }
                    }


                    if (checkDigit != 9)
                    {
                        enterToCath = true;
                    }

                    sinArray = Array.ConvertAll(sinChar, c => (int)char.GetNumericValue(c));

                  
                }
                
                else if(sinString.Length!=11)
                {
                    enterToCath = true;
                }
      

                if (enterToCath)
                {
                    try
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        Console.WriteLine();
                        Console.WriteLine("SIN FORMAT ERROR. TRY AGAIN");
                        Console.WriteLine();
                    }
                }

                else if(!enterToCath)
                {
                    keepgoing = false;
                }

                //Normalize varibles
                checkDigit = 0;
                enterToCath = false;
                k = 0;

                if (!keepgoing)
                {
                    sinDigits =sinArray;
                }

            }

            return sinDigits;


        }

        //Method validate SIN
        static Boolean validate(int[] sinDigits)
        {

            //variables
            int sum = 0;
            string memory;
            int value1 = 0;
            int value2 = 0;
            int value3 = 0;
            bool validSIN = false;

            //For character 2 of array
            sinDigits[1] = sinDigits[1] * 2;

            memory = sinDigits[1].ToString();


            if (memory.Length == 2)
            {
                value1 = (int)char.GetNumericValue(memory[0]);
                value2 = (int)char.GetNumericValue(memory[1]);
                sinDigits[1] = value1 + value2;

            }

            else
            {
                value1 = (int)char.GetNumericValue(memory[0]);
                sinDigits[1] = value1;
            }

            //For character 4 of array
            sinDigits[3] = sinDigits[3] * 2;

            memory = sinDigits[3].ToString();

            if (memory.Length == 2)
            {
                value1 = (int)char.GetNumericValue(memory[0]);
                value2 = (int)char.GetNumericValue(memory[1]);
                sinDigits[3] = value1 + value2;
            }

            else
            {
                value1 = (int)char.GetNumericValue(memory[0]);
                sinDigits[3] = value1;
            }

            //For character 6 of array
            sinDigits[5] = sinDigits[5] * 2;

            memory = sinDigits[5].ToString();

            if (memory.Length == 2)
            {
                value1 = (int)char.GetNumericValue(memory[0]);
                value2 = (int)char.GetNumericValue(memory[1]);
                sinDigits[5] = value1 + value2;
            }

            else
            {
                value1 = (int)char.GetNumericValue(memory[0]);
                sinDigits[5] = value1;
            }

            //For character 8 of array
            sinDigits[7] = sinDigits[7] * 2;

            memory = sinDigits[7].ToString();

            if (memory.Length == 2)
            {
                value1 = (int)char.GetNumericValue(memory[0]);
                value2 = (int)char.GetNumericValue(memory[1]);
                sinDigits[7] = value1 + value2;

            }

            else
            {
                value1 = (int)char.GetNumericValue(memory[0]);
                sinDigits[7] = value1;
            }


            //Sum of the first (eight) characters in the array

            for (int i = 0; i < sinDigits.Length; i++)
            {
                sum += sinDigits[i];
            }


            //Validate if the last digit of the SIN match with last digit of the sum



            if (memory.Length == 2)
            {

                if (sum % 10 == 0)  
                {
                    validSIN = true;
                }
                else 
                {
                    validSIN = false;
                }
            }

            else if (sum % 10 == 0)
            {

                if (value3 == sinDigits[8])
                {
                    validSIN = true;
                }
                else
                {
                    validSIN = false;
                }
            }


            return validSIN;
        }



    }
}
