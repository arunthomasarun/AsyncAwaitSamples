using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwaitSamples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var op1 = CallComplexOperation();
            var op2 = CallComplexOperation();
            var op3 = CallComplexOperation();
            var op4 = CallComplexOperation();

            await Task.WhenAll(op1, op2, op3, op4);

            int sum = op1.Result + op2.Result + op3.Result + op4.Result;
            MessageBox.Show(sum.ToString());
        }

        private  Task<int> CallComplexOperation()
        {
          
            return Task.Run(() =>
            {
                var complexCalc = new ComplexCalculation();
                return  complexCalc.DoComplexCalculation();
            });            
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var complexCalc = new AsyncComplexCalculation();

            var op1 = complexCalc.DoComplexCalculationAsync();
            var op2 = complexCalc.DoComplexCalculationAsync();
            var op3 = complexCalc.DoComplexCalculationAsync();
            var op4 = complexCalc.DoComplexCalculationAsync();

            await Task.WhenAll(op1, op2, op3, op4);

            int sum = op1.Result + op2.Result + op3.Result + op4.Result;
            MessageBox.Show(sum.ToString());
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var complexCalc = new AsyncComplexCalculation();

            Task<int> op1 = complexCalc.DoComplexCalculationAsync();
            Task<int> op2 = complexCalc.DoComplexCalculationAsync();
            Task<int> op3 = complexCalc.DoComplexCalculationAsync();
            Task<int> op4 = complexCalc.DoComplexCalculationAsync();

            await Task.WhenAll(op1, op2, op3, op4);

            int sum = op1.Result + op2.Result + op3.Result + op4.Result;
            MessageBox.Show(sum.ToString());
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var complexCalc = new AsyncComplexCalculation();

            Task<int> op1 = complexCalc.DoComplexCalculationAsync();
            Task<int> op2 = complexCalc.DoComplexCalculationAsync();
            Task<int> op3 = complexCalc.DoComplexCalculationAsync();
            Task<int> op4 = complexCalc.DoComplexCalculationAsync();

            int a = await op1;
            int b = await op2;
            int c = await op3;
            int d = await op4;

            int sum = a + b + c + d;
            MessageBox.Show(sum.ToString());
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            var t1 = Task.Run(() =>
            {
                Task.Delay(8000);
                MessageBox.Show("Inside Task");
            });

            await Task.WhenAll(t1);
            MessageBox.Show("Outside Task");
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            var t1 = DoSomeOpertation();
            var t2 = DoSomeOpertation2();
            await Task.WhenAll(t1, t2);
            MessageBox.Show(t1.Result.ToString());
        }

        private Task<int> DoSomeOpertation()
        {
            return  Task.Run(() =>
             {
                 Task.Delay(3000);
                 return 1;
             });
        }

        private async Task<int> DoSomeOpertation2()
        {
            return await Task.Run(async () =>
            {
                await Task.Delay(3000);
                return 1;
            });
        }
    }
}
