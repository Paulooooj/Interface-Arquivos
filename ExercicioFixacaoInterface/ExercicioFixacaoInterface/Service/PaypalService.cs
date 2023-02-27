using System;
using System.Collections.Generic;


namespace ExercicioFixacaoInterface.Service
{
    internal class PaypalService : IOnlinePaymentService
    {

      public double PaymentFee(Double amount)
        {
            return amount * 0.02;
           
        }
        public double Interest(Double amount, int months)
        {

            return amount * 0.01 * months;

        }

    }
}
