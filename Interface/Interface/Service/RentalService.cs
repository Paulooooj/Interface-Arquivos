using Interface.Service;
using ProjetoSemInterface.Entities;
using System;


namespace ProjetoSemInterface.Services
{
    internal class RentalService
    {
        public double PricePerHour { get; set; }
        public double PricePerDay { get; set; }

        private ITaxServices _taxService;
        public RentalService(double pricePerHour, double pricePerDay, ITaxServices taxService)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _taxService = taxService;
        }

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);
            double basicpayment = 0.0;

            if (duration.TotalHours <= 12.0)
            {
                basicpayment = PricePerHour * Math.Ceiling(duration.TotalHours);
            }
            else
            {
                basicpayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }
            double tax = _taxService.Tax(basicpayment);

            carRental.Invoice = new Invoice(basicpayment, tax);
        }
    }
}
