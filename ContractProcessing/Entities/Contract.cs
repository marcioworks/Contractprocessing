using System;
using System.Collections.Generic;
using System.Text;

namespace ContractProcessing.Entities
{
    class Contract
    {
        public int Number { get; set; }
        public DateTime ContractDate { get; set; }
        public double ContractValue { get; set; }
        public List<Installment> Installments { get; set; }

        public Contract(int number, DateTime contractDate, double contractValue)
        {
            Number = number;
            ContractDate = contractDate;
            ContractValue = contractValue;
            Installments = new List<Installment>();
        }
        public void AddIntallment(Installment installment)
        {
            Installments.Add(installment);
        }
    }
}
