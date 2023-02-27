using System;


namespace ExercicioFixacaoInterface.Service
{
    interface IOnlinePaymentService
    {
        double PaymentFee(Double amount);
        double Interest(Double amount, int months);
    }
}
