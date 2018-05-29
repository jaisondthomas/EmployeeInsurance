using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeInsurance
{
    public static class Insurance
    {
        public static decimal PermiumPicker(EmployeeInsurance employee)
        {
            if (OnlyFirstPermium(employee))
            {
                return employee.Permium1;
            }
            if (OnlySecondPermium(employee))
            {
                return employee.Permium2;
            }

            if (OnlyThirdPermium(employee))
            {
                return employee.Permium3;
            }

            if (FirstPermiumLessThanSecondPermium(employee))
            {
                return employee.Permium2;
            }

            if (FirstPermiumGreaterThanSecondPermium(employee))
            {
                return employee.Permium1;
            }

            if (FirstPermiumEqualsSecondPermium(employee) && ThirdPermiumExist(employee))
            {
                return employee.Permium3;
            }

            if (NoPermiumFound(employee))
            {
                return 0;
            }


            return 0;
        }

        private static bool NoPermiumFound(EmployeeInsurance employee)
        {
            return employee.Permium1 == 0 && employee.Permium2 == 0 &&
                   employee.Permium3 == 0;
        }

        private static bool ThirdPermiumExist(EmployeeInsurance employee)
        {
            return employee.Permium3 > 0;
        }

        private static bool FirstPermiumEqualsSecondPermium(EmployeeInsurance employee)
        {
            return employee.Permium1 == employee.Permium2;
        }

        private static bool FirstPermiumGreaterThanSecondPermium(
            EmployeeInsurance employee)
        {
            return employee.Permium1 > employee.Permium2;
        }

        private static bool FirstPermiumLessThanSecondPermium(EmployeeInsurance employee)
        {
            return employee.Permium1 < employee.Permium2;
        }

        private static bool OnlyThirdPermium(EmployeeInsurance employee)
        {
            return employee.Permium1 <= 0 && employee.Permium2 <= 0 &&
                   employee.Permium3 > 0;
        }

        private static bool OnlySecondPermium(EmployeeInsurance employee)
        {
            return employee.Permium1 <= 0 && employee.Permium2 > 0 &&
                   employee.Permium3 <= 0;
        }

        private static bool OnlyFirstPermium(EmployeeInsurance employee)
        {
            return employee.Permium1 > 0 && employee.Permium2 <= 0 &&
                   employee.Permium3 <= 0;
        }

     

     

        public static List<EmployeeInsurance> EmployeesPermium(
            List<EmployeeInsurance> employees)
        {
            NoInsuredEmployeesFound(employees);

            return employees.Select(employee => new EmployeeInsurance
                {
                    EmployeeId = employee.EmployeeId,
                    InsuranceCompanyId = employee.InsuranceCompanyId,
                    Permium = PermiumPicker(employee)
                })
                .ToList();
        }

        private static void NoInsuredEmployeesFound(List<EmployeeInsurance> employees)
        {
            if (employees == null) throw new ArgumentNullException(nameof(employees));
            if (employees.Count <= 0) throw new Exception("No insured employees found");
        }

        public static List<EmployeeInsurance> InvalidEmployees(List<EmployeeInsurance> employees)
        {
            return employees.Where(employee => employee.EmployeeId == 0).ToList();
        }

        public static List<EmployeeInsurance> InvalidInsurances(List<EmployeeInsurance> employees)
        {
            return employees.Where(employee => employee.InsuranceCompanyId == 0).ToList();
        }
    }
}