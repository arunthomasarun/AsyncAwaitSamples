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
    }
}
