using ExercicioFixacaoInterface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioFixacaoInterface.Service
{
    internal class ContactService
    {
        private IOnlinePaymentService _onlinePaumenteService;
        public ContactService(IOnlinePaymentService onlinePaumentService) 
        {
            _onlinePaumenteService= onlinePaumentService;
        }
        public void ProcessContract(Contract contract, int months)
        {
            double quota = contract.TotalValue / months;
            
            for(int i = 1; i <= months; i++) {
                
                DateTime date = contract.Date.AddMonths(i);
                double paymentfee = quota +  _onlinePaumenteService.PaymentFee(quota);
                double interest = paymentfee + _onlinePaumenteService.Interest(paymentfee, i);

                Installment installment = new Installment(date, interest);

                contract.AddInstallmente(installment);
            
            
            
            }
        }
    }
}
