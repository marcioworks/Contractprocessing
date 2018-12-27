using System;
using System.Collections.Generic;
using ContractProcessing.Entities;
using ContractProcessing.Services;

namespace ContractProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Contract data");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Contract Value: ");
            double value = double.Parse(Console.ReadLine());
            Console.Write("Enter number of Installments: ");
            int months = int.Parse(Console.ReadLine());

            Contract myContract = new Contract(number,date,value);
            ContractService contractService = new ContractService(new PaypalService());
            contractService.ProcessContract(myContract,months);

            Console.WriteLine("INSTALLMENTS:");
            foreach(Installment installment in myContract.Installments)
            {
                Console.WriteLine(installment);
            }

        }
    }
}
