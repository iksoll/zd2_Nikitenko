using Xamarin.Forms;
using System;

namespace App1
{
    public partial class CalculatorPage :ContentPage
    {
        public CalculatorPage ()
        {
            InitializeComponent();
        }

        private void OnSliderValueChanged (object sender, ValueChangedEventArgs e)
        {
            // Обновляем процентную ставку в метке
            InterestRateLabel.Text = $"{e.NewValue:F1}%";

            // Пересчитываем ежемесячный платеж
            CalculateMonthlyPayment();
        }

        private void CalculateMonthlyPayment ()
        {
            // Получаем значения из полей ввода
            double loanAmount;
            double loanTerm;
            double interestRate;

            // Проверяем правильность ввода суммы и срока
            if (double.TryParse(LoanAmountEntry.Text, out loanAmount) &&
                double.TryParse(LoanTermEntry.Text, out loanTerm))
            {
                interestRate = double.Parse(InterestRateLabel.Text.Trim('%')) / 100;

                // Формула для расчета ежемесячного платежа
                double monthlyRate = interestRate / 12;
                double monthlyPayment = 0;

                if (monthlyRate != 0)
                {
                    monthlyPayment = loanAmount * monthlyRate / (1 - Math.Pow(1 + monthlyRate, -loanTerm));
                } else
                {
                    monthlyPayment = loanAmount / loanTerm;
                }

                // Отображаем ежемесячный платеж
                MonthlyPaymentLabel.Text = $"{monthlyPayment:F2} руб.";
            } else
            {
                // Если данные введены некорректно
                MonthlyPaymentLabel.Text = "Ошибка ввода";
            }
        }
    }
}
