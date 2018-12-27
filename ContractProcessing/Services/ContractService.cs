using System;
using ContractProcessing.Entities;

namespace ContractProcessing.Services
{
    class ContractService
    {

        private IOnlinePaymentService _onlinePaymentService;

        public ContractService(IOnlinePaymentService onlinePaymentService)
        {
            _onlinePaymentService = onlinePaymentService;
        }

        public void ProcessContract(Contract contract, int months)
        {
            double basicQuota = contract.ContractValue / months;

            for (int i = 1; i <= months; i++)
            {
                DateTime date = contract.ContractDate.AddMonths(i);
                double updateQuota = basicQuota + _onlinePaymentService.Interest(basicQuota, i);
                double fullQuota = updateQuota + _onlinePaymentService.PaymentFee(updateQuota);

                contract.AddIntallment(new Installment(date,fullQuota));
            }
        }


    }
}
