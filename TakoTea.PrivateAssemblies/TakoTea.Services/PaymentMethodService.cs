using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakoTea.Interfaces;
using TakoTea.Models;

namespace TakoTea.Services
{
    public class PaymentMethodService : IPaymentMethodForm
    {
        private readonly Entities _context;

        public PaymentMethodService(Entities context)
        {
            _context = context;
        }

        public void LoadPaymentMethods()
        {
            // Load payment methods from the database
            // ... and populate the UI elements in the PaymentMethodForm
        }

        public void AddPaymentMethod(PaymentMethod paymentMethod)
        {
            // Validate the payment method
            ValidatePaymentMethod(paymentMethod);

            // Add the payment method to the database
            _context.PaymentMethods.Add(paymentMethod);
            _context.SaveChanges();
        }

        public void EditPaymentMethod(PaymentMethod paymentMethod)
        {
            // Validate the payment method
            ValidatePaymentMethod(paymentMethod);

            // Update the payment method in the database
            _context.Entry(paymentMethod).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeletePaymentMethod(int paymentMethodId)
        {
            // Delete the payment method from the database
            var paymentMethod = _context.PaymentMethods.Find(paymentMethodId);
            if (paymentMethod != null)
            {
                _context.PaymentMethods.Remove(paymentMethod);
                _context.SaveChanges();
            }
        }

        public void ValidatePaymentMethod(PaymentMethod paymentMethod)
        {
            // Validate the payment method data
            // ... and throw an exception if invalid
        }
    }
}
