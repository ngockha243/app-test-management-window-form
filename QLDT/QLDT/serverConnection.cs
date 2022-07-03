using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDT;

namespace QLDT
{
    public class serverConnection
    {
        public static string connectServer(string basis)
        {
            if (basis == "CS1")         //server phan tan 1
            {
                basis = @"Data Source=LAPTOP-L3ADQ9AS\MSSQLSERVER02;Initial Catalog=THI_TN;Persist Security Info=True;User ID=sa;Password=oneforall11";
            }
            else if (basis == "CS2")    //server phan tan 2
            {
                basis = @"Data Source=LAPTOP-L3ADQ9AS\MSSQLSERVER03;Initial Catalog=THI_TN;Persist Security Info=True;User ID=sa;Password=oneforall11";
            }
            else                        //server goc
            {
                basis = @"Data Source=LAPTOP-L3ADQ9AS\MSSQLSERVER01;Initial Catalog=THI_TN;Persist Security Info=True;User ID=sa;Password=oneforall11";
            }
            return basis;
        }
    }
}
