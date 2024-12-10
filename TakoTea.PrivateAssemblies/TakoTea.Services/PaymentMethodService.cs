using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TakoTea.Models;

namespace TakoTea.Services
{
    public class PaymentMethodService
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

        public static void RemovePaymentMethod(string paymentMethodName)
        {
            using (Entities context = new Entities())
            {
                PaymentMethod paymentMethod = context.PaymentMethods.FirstOrDefault(p => p.MethodName == paymentMethodName);
                if (paymentMethod != null)
                {
                    paymentMethod.IsActive = false; // Soft delete by setting IsActive to false
                    _ = context.SaveChanges();
                }
                else
                {
                    throw new Exception("Payment method not found.");
                }
            }
        }

        public static void AddPaymentMethod(string paymentMethodName)
        {
            using (Entities context = new Entities())
            {
                // Check if the payment method already exists (ignoring case)
                if (context.PaymentMethods.Any(p => p.MethodName.Equals(paymentMethodName, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new Exception("Payment method already exists.");
                }

                PaymentMethod newPaymentMethod = new PaymentMethod
                {
                    MethodName = paymentMethodName,
                    IsActive = true
                };

                _ = context.PaymentMethods.Add(newPaymentMethod);
                _ = context.SaveChanges();
            }
        }
        public static List<string> GetAllPaymentMethods()
        {
            using (Entities context = new Entities())
            {
                return context.PaymentMethods
                    .Where(p => p.IsActive) // Filter for active payment methods
                    .Select(p => p.MethodName)
                    .ToList();
            }
        }
        public void EditPaymentMethod(PaymentMethod paymentMethod)
        {
            // Validate the payment method
            ValidatePaymentMethod(paymentMethod);

            // Update the payment method in the database
            _context.Entry(paymentMethod).State = EntityState.Modified;
            _ = _context.SaveChanges();
        }

        public void DeletePaymentMethod(int paymentMethodId)
        {
            // Delete the payment method from the database
            PaymentMethod paymentMethod = _context.PaymentMethods.Find(paymentMethodId);
            if (paymentMethod != null)
            {
                _ = _context.PaymentMethods.Remove(paymentMethod);
                _ = _context.SaveChanges();
            }
        }

        public void ValidatePaymentMethod(PaymentMethod paymentMethod)
        {
            // Validate the payment method data
            // ... and throw an exception if invalid
        }
    }
}
