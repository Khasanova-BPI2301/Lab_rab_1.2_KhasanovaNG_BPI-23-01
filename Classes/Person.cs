using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_R_1._2_Khasanova_BPI_23_01.Classes
{
    public class Person : IPersonFinance
    {
        protected string fullName;
        protected int age;
        protected string gender;
        protected double income;
        protected double expense;

        public Person(string fullName, int age, string gender, double income, double expense)
        {
            this.fullName = fullName;
            this.age = age;
            this.gender = gender;
            this.income = income;
            this.expense = expense;
        }

        public virtual double GetAverageIncome()
        {
            return income/12;
        }
        public virtual double GetAverageExpense()
        {
            return expense/12;
        }
        public virtual string GetInfo()
        {
            return $"ФИО: {fullName}, Возраст: {age}, Пол: {gender}";
        }

    }
}
