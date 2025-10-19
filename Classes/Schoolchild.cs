using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_R_1._2_Khasanova_BPI_23_01.Classes
{
    public class Schoolchild : Person
    {
        public Schoolchild(string fullName, int age, string gender, double income, double expense)
            : base(fullName, age, gender, income, expense)
        {

        }
        public override string GetInfo()
        {
            return base.GetInfo() + " (Школьник)";
        }
    }
}
