using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
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
        }
        public static void RemovePaymentMethod(string paymentMethodName)
        {
            using (Entities context = new Entities())
            {
                PaymentMethod paymentMethod = context.PaymentMethods.FirstOrDefault(p => p.MethodName == paymentMethodName);
                if (paymentMethod != null)
                {
                    paymentMethod.IsActive = false; _ = context.SaveChanges();
                }
                else
                {
                    throw new Exception("Payment method not found.");
                }
            }
        }
        public static void AddPaymentMethod(string paymentMethodName, Entities context)
        {
            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show("Error adding payment method: " + ex.Message);
            }
        }
        public static List<string> GetAllPaymentMethods()
        {
            using (Entities context = new Entities())
            {
                return context.PaymentMethods
                    .Where(p => p.IsActive).Select(p => p.MethodName)
                    .ToList();
            }
        }
        public void EditPaymentMethod(PaymentMethod paymentMethod)
        {
            ValidatePaymentMethod(paymentMethod);
            _context.Entry(paymentMethod).State = EntityState.Modified;
            _ = _context.SaveChanges();
        }
        public static void DeletePaymentMethod(string paymentMethodName, Entities context)
        {
            try
            {
                PaymentMethod paymentMethod = context.PaymentMethods.FirstOrDefault(p => p.MethodName == paymentMethodName);
                if (paymentMethod != null)
                {
                    // No need to ask for confirmation again here
                    context.PaymentMethods.Remove(paymentMethod);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting payment method: " + ex.Message);
            }
        }
        public void ValidatePaymentMethod(PaymentMethod paymentMethod)
        {
        }
    }
}
