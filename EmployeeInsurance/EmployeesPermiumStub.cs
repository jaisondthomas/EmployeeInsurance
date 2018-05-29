using System;
using System.Collections.Generic;

namespace EmployeeInsurance
{
    public static class EmployeesPermiumStub
    {
        public static EmployeeInsurance EmployeeWithFirstPermium()
        {
           return new EmployeeInsurance { Permium1 = 10, Permium2 = 0, Permium3 = 0};
        }

        public static EmployeeInsurance EmployeeWithSecondPermium()
        {
            return new EmployeeInsurance { Permium1 = 0, Permium2 = 10, Permium3 = 0 };
        }

        public static EmployeeInsurance EmployeeWithThirdPermium()
        {
            return new EmployeeInsurance { Permium1 = 0, Permium2 = 0, Permium3 = 10 };
        }

        public static EmployeeInsurance EmployeeWithLessFirstPermium()
        {
            return new EmployeeInsurance { Permium1 = 0, Permium2 = 30, Permium3 = 0 };
        }

        public static EmployeeInsurance EmployeeWithGreaterFirstPermium()
        {
            return new EmployeeInsurance { Permium1 = 10, Permium2 = 5, Permium3 = 0 };
        }

        public static EmployeeInsurance EmployeeWithEqualFirstAndSecondPermium()
        {
            return new EmployeeInsurance { Permium1 = 10, Permium2 = 10, Permium3 = 300 };
        }

        public static EmployeeInsurance NoPermiumEmployee()
        {
            return new EmployeeInsurance { Permium1 = 0, Permium2 = 0, Permium3 = 0 };
        }

        

        public static List<EmployeeInsurance> Employees()
        {
            return new List<EmployeeInsurance>
            {
                new EmployeeInsurance
                {
                    EmployeeId = 1,
                    InsuranceCompanyId = 3,
                    Permium1 = 20,
                    Permium2 = 0,
                    Permium3 = 0
                },
                new EmployeeInsurance
                {
                    EmployeeId = 2,
                    InsuranceCompanyId = 2,
                    Permium1 = 0,
                    Permium2 = 0,
                    Permium3 = 30
                },
            };
        }


        public static List<EmployeeInsurance> NoInsuredEmployees()
        {
            return  new List<EmployeeInsurance>();
        }

        public static List<EmployeeInsurance> InvalidEmployees()
        {
            return new List<EmployeeInsurance>
            {
                new EmployeeInsurance
                {
                    EmployeeId = 0,
                    InsuranceCompanyId = 3,
                    Permium1 = 20,
                    Permium2 = 0,
                    Permium3 = 0
                }
            };
        }

        public static List<EmployeeInsurance> InvalidInsurance()
        {
            return new List<EmployeeInsurance>
            {
                new EmployeeInsurance
                {
                    EmployeeId = 1,
                    InsuranceCompanyId = 0,
                    Permium1 = 20,
                    Permium2 = 0,
                    Permium3 = 0
                }
            };
        }
    }
}